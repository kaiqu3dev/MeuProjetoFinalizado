using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace teste_de_designe
{
    public partial class TelaHistoricoDeAgendamento : Form
    {
        public string usuarioLogadoEmail;

        decimal total = 0;
        decimal reembolsado = 0;

        private const string EmailSistema = "projetodoulaefuro01@gmail.com";
        private const string SenhaAppEmail = "qvxmylkwzrgqtiee";
        private const string NomeRemetente = "Sistema Doula";

        List<ItemGrid> lista = new List<ItemGrid>();

        public TelaHistoricoDeAgendamento(string email)
        {
            InitializeComponent();
            usuarioLogadoEmail = email;
        }

        private EmailService CriarEmailService()
        {
            return new EmailService(
                "smtp.gmail.com",
                587,
                EmailSistema,
                SenhaAppEmail,
                NomeRemetente
            );
        }

        private void EnviarEmailCancelamento(ItemGrid item)
        {
            try
            {
                EmailService emailService = CriarEmailService();

                string assuntoCliente = "Cancelamento de agendamento confirmado";

                string corpoCliente = $@"Olá!

Seu agendamento foi cancelado com sucesso.

Data: {item.Data:dd/MM/yyyy}
Horário: {item.Horario}
Serviço: {item.Servico}
Tipo: {item.Tipo}
Valor de referência: R$ {item.Valor:N2}

Se desejar, você poderá realizar um novo agendamento pelo sistema.

Sistema Doula & Furo";

                if (!string.IsNullOrWhiteSpace(item.Email))
                {
                    emailService.EnviarEmail(item.Email, assuntoCliente, corpoCliente);
                }

                string assuntoEmpresa = "Cancelamento registrado no sistema";

                string corpoEmpresa = $@"Um cancelamento foi registrado no sistema.

Cliente: {item.Nome}
Email: {item.Email}
Telefone: {item.Telefone}

Data: {item.Data:dd/MM/yyyy}
Horário: {item.Horario}
Serviço: {item.Servico}
Tipo: {item.Tipo}
Valor: R$ {item.Valor:N2}

Verifique o painel administrativo para mais detalhes.";

                emailService.EnviarEmail(EmailSistema, assuntoEmpresa, corpoEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cancelamento realizado, mas houve erro ao enviar o e-mail:\n" + ex.Message);
            }
        }


        public class ItemGrid
        {
            public int AgendamentoId { get; set; }
            public int ItemServicoId { get; set; }
            public DateTime Data { get; set; }
            public string Horario { get; set; }
            public string Servico { get; set; }
            public int Quantidade { get; set; }
            public string Status { get; set; }
            public decimal Valor { get; set; }
            public string Tipo { get; set; }
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
        }

        private void CarregarGrid()
        {
            lista.Clear();

            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();

                string sql = @"
SELECT
    A.Id AS AgendamentoId,
    MIN(S.Id) AS ItemServicoId,
    S.Data,
    S.Horario,
    S.Servico,
    S.Tipo,
    S.Status,
    SUM(S.Valor) AS ValorTotalItem,
    CASE
        WHEN S.Tipo = 'Furo' THEN COUNT(*)
        ELSE 1
    END AS Quantidade,
    U.Nome,
    U.Telefone,
    A.Email
FROM Agendamentos A
INNER JOIN AgendamentoServicos S ON A.Id = S.AgendamentoId
INNER JOIN Usuarios U ON A.Email = U.Email
WHERE A.Email = @Email
GROUP BY
    A.Id,
    S.Data,
    S.Horario,
    S.Servico,
    S.Tipo,
    S.Status,
    U.Nome,
    U.Telefone,
    A.Email
ORDER BY S.Data DESC, S.Horario";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", usuarioLogadoEmail);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ItemGrid
                            {
                                AgendamentoId = Convert.ToInt32(reader["AgendamentoId"]),
                                ItemServicoId = Convert.ToInt32(reader["ItemServicoId"]),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Horario = reader["Horario"].ToString(),
                                Servico = reader["Servico"].ToString(),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Status = reader["Status"].ToString(),
                                Valor = Convert.ToDecimal(reader["ValorTotalItem"]),
                                Tipo = reader["Tipo"].ToString(),
                                Nome = reader["Nome"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Email = reader["Email"].ToString()
                            });
                        }
                    }
                }
            }

            AtualizarGrid(lista);
        }

        private void AtualizarGrid(List<ItemGrid> dados)
        {
            dgvHistorico_Tabela.DataSource = null;
            dgvHistorico_Tabela.DataSource = dados;

            if (dgvHistorico_Tabela.Columns.Contains("AgendamentoId"))
                dgvHistorico_Tabela.Columns["AgendamentoId"].Visible = false;

            if (dgvHistorico_Tabela.Columns.Contains("ItemServicoId"))
                dgvHistorico_Tabela.Columns["ItemServicoId"].Visible = false;

            if (dgvHistorico_Tabela.Columns.Contains("Email"))
                dgvHistorico_Tabela.Columns["Email"].Visible = false;
        }

        private bool PodeAlterarAgendamento(DateTime dataAgendada)
        {
            return (dataAgendada.Date - DateTime.Today).TotalDays >= 2;
        }

        private void AtualizarResumoAgendamentoPai(int agendamentoId)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();

                string sqlItens = @"
SELECT Data, Horario, Servico, Tipo, Valor, Status
FROM AgendamentoServicos
WHERE AgendamentoId = @AgendamentoId";

                List<DateTime> datasAtivas = new List<DateTime>();
                List<string> horariosAtivos = new List<string>();
                List<string> servicosAtivos = new List<string>();
                decimal valorTotalAtivo = 0;
                int quantidadeFuroAtiva = 0;
                bool temAtivo = false;

                using (MySqlCommand cmd = new MySqlCommand(sqlItens, conn))
                {
                    cmd.Parameters.AddWithValue("@AgendamentoId", agendamentoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["Status"].ToString();
                            if (status != "Ativo")
                                continue;

                            temAtivo = true;

                            DateTime data = Convert.ToDateTime(reader["Data"]);
                            string horario = reader["Horario"].ToString();
                            string servico = reader["Servico"].ToString();
                            string tipo = reader["Tipo"].ToString();
                            decimal valor = Convert.ToDecimal(reader["Valor"]);

                            datasAtivas.Add(data);
                            horariosAtivos.Add(horario);
                            servicosAtivos.Add(servico);
                            valorTotalAtivo += valor;

                            if (tipo == "Furo")
                                quantidadeFuroAtiva++;
                        }
                    }
                }

                string sqlUpdate = @"
UPDATE Agendamentos
SET Data = @Data,
    Horarios = @Horarios,
    Servicos = @Servicos,
    ValorTotal = @ValorTotal,
    QuantidadePessoas = @QuantidadePessoas,
    Status = @Status
WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", agendamentoId);
                    cmd.Parameters.AddWithValue("@Data", temAtivo ? datasAtivas.Min().Date : DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@Horarios", temAtivo ? string.Join(",", horariosAtivos.Distinct()) : "");
                    cmd.Parameters.AddWithValue("@Servicos", temAtivo ? string.Join(", ", servicosAtivos.Distinct()) : "");
                    cmd.Parameters.AddWithValue("@ValorTotal", valorTotalAtivo);
                    cmd.Parameters.AddWithValue("@QuantidadePessoas", quantidadeFuroAtiva);
                    cmd.Parameters.AddWithValue("@Status", temAtivo ? "Ativo" : "Cancelado");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CancelarGrupo(ItemGrid item)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();

                string sql = @"
UPDATE AgendamentoServicos
SET Status = 'Cancelado'
WHERE AgendamentoId = @AgendamentoId
  AND Data = @Data
  AND Horario = @Horario
  AND Servico = @Servico
  AND Tipo = @Tipo
  AND Status = 'Ativo'";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AgendamentoId", item.AgendamentoId);
                    cmd.Parameters.AddWithValue("@Data", item.Data.Date);
                    cmd.Parameters.AddWithValue("@Horario", item.Horario);
                    cmd.Parameters.AddWithValue("@Servico", item.Servico);
                    cmd.Parameters.AddWithValue("@Tipo", item.Tipo);

                    cmd.ExecuteNonQuery();
                }
            }

            AtualizarResumoAgendamentoPai(item.AgendamentoId);
        }

        private void dgvHistorico_Tabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var item = (ItemGrid)dgvHistorico_Tabela.Rows[e.RowIndex].DataBoundItem;
            string nomeColuna = dgvHistorico_Tabela.Columns[e.ColumnIndex].Name;

            if (nomeColuna != "Cancelar" && nomeColuna != "Reagendar")
                return;

            if (!PodeAlterarAgendamento(item.Data))
            {
                MessageBox.Show("Só pode cancelar ou reagendar com 2 dias de antecedência!");
                return;
            }

            if (nomeColuna == "Cancelar")
            {
                if (item.Status == "Cancelado")
                {
                    MessageBox.Show("Esse item já foi cancelado!");
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Deseja cancelar o serviço {item.Tipo}?\n\nReembolso: R$ {item.Valor:N2}",
                    "Cancelar agendamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    CancelarGrupo(item);
                    reembolsado += item.Valor;
                    EnviarEmailCancelamento(item);
                    MessageBox.Show($"{item.Tipo} cancelado com sucesso!");
                    CarregarGrid();
                    AtualizarResumo();
                }
            }

            if (nomeColuna == "Reagendar")
            {
                if (item.Status == "Cancelado")
                {
                    MessageBox.Show("Não é possível reagendar um item cancelado!");
                    return;
                }

                Agendamento agendamento = new Agendamento
                {
                    Id = item.AgendamentoId,
                    ItemServicoId = item.ItemServicoId,
                    Data = item.Data,
                    Horarios = new List<string> { item.Horario },
                    Servicos = new List<string> { item.Servico },
                    ValorTotal = item.Valor,
                    QuantidadePessoas = item.Tipo == "Furo" ? item.Quantidade : 1,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    TipoItem = item.Tipo,
                    ServicoItem = item.Servico,
                    Status = item.Status
                };

                using (PaginaAgendamentoDoula tela = new PaginaAgendamentoDoula(agendamento, usuarioLogadoEmail))
                {
                    tela.ShowDialog();
                }

                CarregarGrid();
                AtualizarResumo();
            }
        }

        private void dgvHistorico_Tabela_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvHistorico_Tabela.Rows[e.RowIndex];

            string status = row.Cells["Status"].Value?.ToString();
            string tipo = row.Cells["Tipo"].Value?.ToString();

            if (status == "Cancelado")
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;

                if (dgvHistorico_Tabela.Columns.Contains("Cancelar"))
                {
                    row.Cells["Cancelar"].ReadOnly = true;
                    row.Cells["Cancelar"].Style.BackColor = Color.Gray;
                }

                if (dgvHistorico_Tabela.Columns.Contains("Reagendar"))
                {
                    row.Cells["Reagendar"].ReadOnly = true;
                    row.Cells["Reagendar"].Style.BackColor = Color.Gray;
                }
            }
            else
            {
                row.DefaultCellStyle.BackColor = tipo == "Doula" ? Color.LightPink : Color.LightSkyBlue;

                if (dgvHistorico_Tabela.Columns.Contains("Cancelar"))
                {
                    row.Cells["Cancelar"].ReadOnly = false;
                    row.Cells["Cancelar"].Style.BackColor = Color.White;
                }

                if (dgvHistorico_Tabela.Columns.Contains("Reagendar"))
                {
                    row.Cells["Reagendar"].ReadOnly = false;
                    row.Cells["Reagendar"].Style.BackColor = Color.White;
                }
            }
        }

        private void TelaHistoricoDeAgendamento_Load(object sender, EventArgs e)
        {
            dgvHistorico_Tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CarregarGrid();

            if (!dgvHistorico_Tabela.Columns.Contains("Cancelar"))
            {
                var btnCancelar = new DataGridViewButtonColumn
                {
                    Name = "Cancelar",
                    HeaderText = "Cancelar",
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true
                };
                dgvHistorico_Tabela.Columns.Add(btnCancelar);
            }

            if (!dgvHistorico_Tabela.Columns.Contains("Reagendar"))
            {
                var btnReagendar = new DataGridViewButtonColumn
                {
                    Name = "Reagendar",
                    HeaderText = "Reagendar",
                    Text = "Reagendar",
                    UseColumnTextForButtonValue = true
                };
                dgvHistorico_Tabela.Columns.Add(btnReagendar);
            }

            dgvHistorico_Tabela.CellContentClick -= dgvHistorico_Tabela_CellContentClick;
            dgvHistorico_Tabela.CellContentClick += dgvHistorico_Tabela_CellContentClick;

            dgvHistorico_Tabela.RowPrePaint -= dgvHistorico_Tabela_RowPrePaint;
            dgvHistorico_Tabela.RowPrePaint += dgvHistorico_Tabela_RowPrePaint;

            AtualizarResumo();
        }

        private void AtualizarResumo()
        {
            total = lista.Where(x => x.Status == "Ativo").Sum(x => x.Valor);

            lblHistorico_Total.Text = $"Total: R$ {total:N2}";
            lblHistorico_Reembolso.Text = $"Reembolsado: R$ {reembolsado:N2}";
        }

        private void txtHistorico_Filtro_TextChanged(object sender, EventArgs e)
        {
            string texto = txtHistorico_Filtro.Text.ToLower();

            var filtrado = lista.Where(x =>
                (x.Nome ?? "").ToLower().Contains(texto) ||
                (x.Email ?? "").ToLower().Contains(texto) ||
                (x.Telefone ?? "").Contains(texto) ||
                (x.Servico ?? "").ToLower().Contains(texto) ||
                (x.Tipo ?? "").ToLower().Contains(texto) ||
                x.Data.ToString("dd/MM/yyyy").Contains(texto)
            ).ToList();

            AtualizarGrid(filtrado);
        }

        private void btnHistorico_Voltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}