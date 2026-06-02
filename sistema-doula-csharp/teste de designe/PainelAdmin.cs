using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace teste_de_designe
{
    public partial class PainelAdmin : Form
    {
        public string adminEmail;

        DataTable tabelaAgendamentos = new DataTable();
        bool atualizandoPainel = false;

        private const string EmailSistema = "projetodoulaefuro01@gmail.com";
        private const string SenhaAppEmail = "qvxmylkwzrgqtiee";
        private const string NomeRemetente = "Sistema Doula";

        public PainelAdmin(string email)
        {
            InitializeComponent();

            adminEmail = email;

            dgvPainelAdm_Agendamentos.AutoGenerateColumns = true;

            txtPainelAdm_Nome.TextChanged += Filtro_TextChanged;
            txtPainelAdm_Email.TextChanged += Filtro_TextChanged;
            mskPainelAdm_Telefone.TextChanged += Filtro_TextChanged;
            mskPainelAdm_CPF.TextChanged += Filtro_TextChanged;
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

        private void EnviarEmailReembolso(
            string nome,
            string email,
            string telefone,
            string tipo,
            string servico,
            DateTime data,
            string horario,
            decimal valor)
        {
            try
            {
                EmailService emailService = CriarEmailService();

                string assuntoCliente = "Reembolso registrado com sucesso";

                string corpoCliente = $@"Olá!
 
Seu reembolso foi registrado no sistema.
 
Data: {data:dd/MM/yyyy}
Horário: {horario}
Serviço: {servico}
Tipo: {tipo}
Valor de referência: R$ {valor:N2}
 
Caso precise, consulte o histórico do sistema para acompanhar suas informações.
 
Sistema Doula & Furo";

                if (!string.IsNullOrWhiteSpace(email))
                {
                    emailService.EnviarEmail(email, assuntoCliente, corpoCliente);
                }

                string assuntoEmpresa = "Reembolso realizado no sistema";

                string corpoEmpresa = $@"Um reembolso foi registrado no sistema.
 
Cliente: {nome}
Email: {email}
Telefone: {telefone}
 
Data: {data:dd/MM/yyyy}
Horário: {horario}
Serviço: {servico}
Tipo: {tipo}
Valor: R$ {valor:N2}
 
Verifique o painel administrativo para mais detalhes.";

                emailService.EnviarEmail(EmailSistema, assuntoEmpresa, corpoEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reembolso realizado, mas houve erro ao enviar o e-mail:\n" + ex.Message);
            }
        }

        private void EnviarEmailReagendamentoAdmin(
            string nome,
            string email,
            string telefone,
            string tipo,
            string servico,
            DateTime novaData,
            string novoHorario)
        {
            try
            {
                EmailService emailService = CriarEmailService();

                string assuntoCliente = "Seu agendamento foi reagendado pela administração";

                string corpoCliente = $@"Olá!
 
Seu agendamento foi atualizado pela administração do sistema.
 
Nova data: {novaData:dd/MM/yyyy}
Novo horário: {novoHorario}
Serviço: {servico}
Tipo: {tipo}
 
Caso tenha dúvidas, entre em contato com a empresa responsável.
 
Sistema Doula & Furo";

                if (!string.IsNullOrWhiteSpace(email))
                {
                    emailService.EnviarEmail(email, assuntoCliente, corpoCliente);
                }

                string assuntoEmpresa = "Reagendamento realizado pelo painel administrativo";

                string corpoEmpresa = $@"Um agendamento foi reagendado pelo painel administrativo.
 
Cliente: {nome}
Email: {email}
Telefone: {telefone}
 
Nova data: {novaData:dd/MM/yyyy}
Novo horário: {novoHorario}
Serviço: {servico}
Tipo: {tipo}
 
Verifique o painel administrativo para mais detalhes.";

                emailService.EnviarEmail(EmailSistema, assuntoEmpresa, corpoEmpresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reagendamento realizado, mas houve erro ao enviar o e-mail:\n" + ex.Message);
            }
        }

        private void PainelAdmin_Load(object sender, EventArgs e)
        {
            CarregarHorariosAdmin();
            CarregarAgendamentos();
        }

        private void CarregarAgendamentos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
                {
                    conn.Open();

                    string sql = @"
SELECT
    MIN(S.Id) AS ItemServicoId,
    A.Id AS AgendamentoId,
    U.Nome,
    U.Email,
    U.Telefone,
    U.CPF,
    IFNULL(U.Status,'Ativo') AS StatusUsuario,
    S.Tipo,
    S.Servico,
    S.Data,
    S.Horario,
    CASE 
        WHEN S.Tipo = 'Furo' THEN COUNT(*)
        ELSE 1
    END AS QuantidadePessoas,
    SUM(S.Valor) AS Valor,
    S.Status
FROM AgendamentoServicos S
INNER JOIN Agendamentos A ON A.Id = S.AgendamentoId
INNER JOIN Usuarios U ON U.Email = A.Email
GROUP BY
    A.Id,
    U.Nome,
    U.Email,
    U.Telefone,
    U.CPF,
    U.Status,
    S.Tipo,
    S.Servico,
    S.Data,
    S.Horario,
    S.Status
ORDER BY S.Data DESC, S.Horario";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    tabelaAgendamentos = new DataTable();
                    da.Fill(tabelaAgendamentos);

                    dgvPainelAdm_Agendamentos.DataSource = null;
                    dgvPainelAdm_Agendamentos.DataSource = tabelaAgendamentos;

                    if (dgvPainelAdm_Agendamentos.Columns.Contains("ItemServicoId"))
                        dgvPainelAdm_Agendamentos.Columns["ItemServicoId"].Visible = false;

                    if (dgvPainelAdm_Agendamentos.Columns.Contains("AgendamentoId"))
                        dgvPainelAdm_Agendamentos.Columns["AgendamentoId"].Visible = false;

                    dgvPainelAdm_Agendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPainelAdm_Agendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPainelAdm_Agendamentos.MultiSelect = false;
                    dgvPainelAdm_Agendamentos.ReadOnly = true;
                    dgvPainelAdm_Agendamentos.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar agendamentos: " + ex.Message);
            }
        }

        private string PegarValorLinha(DataGridViewRow row, string nomeColuna)
        {
            if (row == null)
                return "";

            if (row.DataBoundItem is DataRowView drv)
            {
                if (drv.Row.Table.Columns.Contains(nomeColuna))
                    return drv[nomeColuna]?.ToString() ?? "";
            }

            return "";
        }

        private void Filtro_TextChanged(object sender, EventArgs e)
        {
            if (atualizandoPainel)
                return;

            try
            {
                string filtro = "";

                if (!string.IsNullOrWhiteSpace(txtPainelAdm_Nome.Text))
                    filtro += $"Nome LIKE '%{txtPainelAdm_Nome.Text.Replace("'", "''")}%'";

                if (!string.IsNullOrWhiteSpace(txtPainelAdm_Email.Text))
                    filtro += (filtro != "" ? " AND " : "") +
                              $"Email LIKE '%{txtPainelAdm_Email.Text.Replace("'", "''")}%'";

                if (!string.IsNullOrWhiteSpace(mskPainelAdm_Telefone.Text))
                    filtro += (filtro != "" ? " AND " : "") +
                              $"Telefone LIKE '%{mskPainelAdm_Telefone.Text.Replace("'", "''")}%'";

                if (!string.IsNullOrWhiteSpace(mskPainelAdm_CPF.Text))
                    filtro += (filtro != "" ? " AND " : "") +
                              $"CPF LIKE '%{mskPainelAdm_CPF.Text.Replace("'", "''")}%'";

                tabelaAgendamentos.DefaultView.RowFilter = filtro;
            }
            catch
            {
            }
        }

        private void dgvPainelAdm_Agendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPainelAdm_Agendamentos.Rows[e.RowIndex];

            txtPainelAdm_Nome.Text = PegarValorLinha(row, "Nome");
            txtPainelAdm_Email.Text = PegarValorLinha(row, "Email");
            mskPainelAdm_Telefone.Text = PegarValorLinha(row, "Telefone");
            mskPainelAdm_CPF.Text = PegarValorLinha(row, "CPF");

            cbbPainelAdm_NovoHorario.Text = PegarValorLinha(row, "Horario");

            string dataTexto = PegarValorLinha(row, "Data");

            if (DateTime.TryParse(dataTexto, out DateTime dataSelecionada))
                dtpPainelAdm_NovaData.Value = dataSelecionada;
        }

        private void dgvPainelAdm_Agendamentos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvPainelAdm_Agendamentos.Rows[e.RowIndex];

            string statusItem = PegarValorLinha(row, "Status");
            string statusUsuario = PegarValorLinha(row, "StatusUsuario");

            if (statusItem == "Ativo")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            else if (statusItem == "Cancelado")
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else if (statusItem == "Pendente")
                row.DefaultCellStyle.BackColor = Color.Orange;

            if (!string.IsNullOrWhiteSpace(statusUsuario)
&& dgvPainelAdm_Agendamentos.Columns.Contains("StatusUsuario"))
            {
                if (statusUsuario == "Banido")
                    row.Cells["StatusUsuario"].Style.ForeColor = Color.DarkRed;
                else
                    row.Cells["StatusUsuario"].Style.ForeColor = Color.DarkBlue;
            }
        }

        private void CarregarHorariosAdmin()
        {
            cbbPainelAdm_NovoHorario.Items.Clear();

            string[] horarios =
            {
                "08:00","09:00","10:00","11:00",
                "13:00","14:00","15:00","16:00",
                "17:00","18:00"
            };

            cbbPainelAdm_NovoHorario.Items.AddRange(horarios);

            if (cbbPainelAdm_NovoHorario.Items.Count > 0)
                cbbPainelAdm_NovoHorario.SelectedIndex = 0;
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

        private void btnPainelAdmin_Reagendar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPainelAdm_Agendamentos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um item.");
                    return;
                }

                DataGridViewRow row = dgvPainelAdm_Agendamentos.SelectedRows[0];

                int idServico = Convert.ToInt32(PegarValorLinha(row, "ItemServicoId"));
                int agendamentoId = Convert.ToInt32(PegarValorLinha(row, "AgendamentoId"));
                string tipoServico = PegarValorLinha(row, "Tipo");
                string statusAtual = PegarValorLinha(row, "Status");

                string nome = PegarValorLinha(row, "Nome");
                string email = PegarValorLinha(row, "Email");
                string telefone = PegarValorLinha(row, "Telefone");
                string servico = PegarValorLinha(row, "Servico");

                DateTime novaData = dtpPainelAdm_NovaData.Value.Date;
                string novoHorario = cbbPainelAdm_NovoHorario.Text;

                if (statusAtual == "Cancelado")
                {
                    MessageBox.Show("Não é possível reagendar um item cancelado.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(novoHorario))
                {
                    MessageBox.Show("Escolha um horário.");
                    return;
                }

                if (novaData < DateTime.Today)
                {
                    MessageBox.Show("Não pode reagendar para datas passadas.");
                    return;
                }

                DateTime dataHoraNova = DateTime.Parse($"{novaData:dd/MM/yyyy} {novoHorario}");
                if (dataHoraNova < DateTime.Now)
                {
                    MessageBox.Show("Não pode reagendar para data e horário passados.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
                {
                    conn.Open();

                    if (tipoServico == "Doula")
                    {
                        string sqlVerificar = @"
SELECT COUNT(*)
FROM AgendamentoServicos
WHERE Tipo = 'Doula'
AND Data = @Data
AND Horario = @Horario
AND Status <> 'Cancelado'
AND Id <> @Id";

                        MySqlCommand cmdVerificar = new MySqlCommand(sqlVerificar, conn);
                        cmdVerificar.Parameters.AddWithValue("@Data", novaData);
                        cmdVerificar.Parameters.AddWithValue("@Horario", novoHorario);
                        cmdVerificar.Parameters.AddWithValue("@Id", idServico);

                        int quantidade = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (quantidade > 0)
                        {
                            MessageBox.Show("Esse horário já está ocupado para a doula.");
                            return;
                        }
                    }

                    string sql = @"
UPDATE AgendamentoServicos
SET Data = @Data, Horario = @Horario
WHERE Id = @Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Data", novaData);
                    cmd.Parameters.AddWithValue("@Horario", novoHorario);
                    cmd.Parameters.AddWithValue("@Id", idServico);

                    cmd.ExecuteNonQuery();
                }

                AtualizarResumoAgendamentoPai(agendamentoId);

                EnviarEmailReagendamentoAdmin(
                    nome,
                    email,
                    telefone,
                    tipoServico,
                    servico,
                    novaData,
                    novoHorario
                );

                MessageBox.Show("Reagendado com sucesso!");
                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reagendar: " + ex.Message);
            }
        }

        private void btnPainelAdmin_Reembolsar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPainelAdm_Agendamentos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um item.");
                    return;
                }

                DataGridViewRow row = dgvPainelAdm_Agendamentos.SelectedRows[0];

                int idServico = Convert.ToInt32(PegarValorLinha(row, "ItemServicoId"));
                int agendamentoId = Convert.ToInt32(PegarValorLinha(row, "AgendamentoId"));
                string nome = PegarValorLinha(row, "Nome");
                string email = PegarValorLinha(row, "Email");
                string telefone = PegarValorLinha(row, "Telefone");
                string tipo = PegarValorLinha(row, "Tipo");
                string servico = PegarValorLinha(row, "Servico");
                string horario = PegarValorLinha(row, "Horario");
                decimal valor = decimal.TryParse(PegarValorLinha(row, "Valor"), out decimal valorConvertido)
                    ? valorConvertido
                    : 0;

                DateTime data = DateTime.Today;
                DateTime.TryParse(PegarValorLinha(row, "Data"), out data);

                using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
                {
                    conn.Open();

                    string sql = "UPDATE AgendamentoServicos SET Status='Cancelado' WHERE Id=@Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", idServico);

                    cmd.ExecuteNonQuery();
                }

                AtualizarResumoAgendamentoPai(agendamentoId);

                EnviarEmailReembolso(nome, email, telefone, tipo, servico, data, horario, valor);

                MessageBox.Show("Reembolso realizado!");
                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reembolsar: " + ex.Message);
            }
        }

        private void AtualizarStatusUsuario(string status)
        {
            try
            {
                if (dgvPainelAdm_Agendamentos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um usuário.");
                    return;
                }

                DataGridViewRow row = dgvPainelAdm_Agendamentos.SelectedRows[0];
                string emailUsuario = PegarValorLinha(row, "Email");

                using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
                {
                    conn.Open();

                    string sql = "UPDATE Usuarios SET Status=@Status WHERE Email=@Email";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Email", emailUsuario);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Status atualizado com sucesso!");
                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnPainelAdmin_Banir_Usuario_Click(object sender, EventArgs e)
        {
            AtualizarStatusUsuario("Banido");
        }

        private void btnPainelAdmin_DesbanirUsuario_Click(object sender, EventArgs e)
        {
            AtualizarStatusUsuario("Ativo");
        }

        private void btnPainelAdmin_Atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                atualizandoPainel = true;

                txtPainelAdm_Nome.Clear();
                txtPainelAdm_Email.Clear();
                mskPainelAdm_Telefone.Clear();
                mskPainelAdm_CPF.Clear();

                CarregarHorariosAdmin();

                if (cbbPainelAdm_NovoHorario.Items.Count > 0)
                    cbbPainelAdm_NovoHorario.SelectedIndex = 0;
                else
                    cbbPainelAdm_NovoHorario.Text = "";

                dtpPainelAdm_NovaData.Value = DateTime.Today;

                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar painel: " + ex.Message);
            }
            finally
            {
                atualizandoPainel = false;
            }
        }

        private void btnPainelAdmin_Reagendar_completo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPainelAdm_Agendamentos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um agendamento.");
                    return;
                }

                DataGridViewRow row = dgvPainelAdm_Agendamentos.SelectedRows[0];

                int agendamentoId =
                    Convert.ToInt32(PegarValorLinha(row, "AgendamentoId"));

                string nome = PegarValorLinha(row, "Nome");
                string email = PegarValorLinha(row, "Email");
                string telefone = PegarValorLinha(row, "Telefone");

                string tipoServico = PegarValorLinha(row, "Tipo");
                string servico = PegarValorLinha(row, "Servico");

                DateTime novaData = dtpPainelAdm_NovaData.Value.Date;
                string novoHorario = cbbPainelAdm_NovoHorario.Text;

                if (string.IsNullOrWhiteSpace(novoHorario))
                {
                    MessageBox.Show("Escolha um horário.");
                    return;
                }

                if (novaData < DateTime.Today)
                {
                    MessageBox.Show("Não pode reagendar para datas passadas.");
                    return;
                }

                DateTime dataHoraNova =
                    DateTime.Parse($"{novaData:dd/MM/yyyy} {novoHorario}");

                if (dataHoraNova < DateTime.Now)
                {
                    MessageBox.Show("Não pode reagendar para data e horário passados.");
                    return;
                }

                using (MySqlConnection conn =
                    new MySqlConnection(Conexao.StringConexao))
                {
                    conn.Open();

                    string sqlBuscarItens = @"
SELECT Id
FROM AgendamentoServicos
WHERE AgendamentoId = @AgendamentoId
AND Status = 'Ativo'";

                    List<int> idsItens = new List<int>();

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlBuscarItens, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@AgendamentoId",
                            agendamentoId
                        );

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idsItens.Add(
                                    Convert.ToInt32(reader["Id"])
                                );
                            }
                        }
                    }

                    if (idsItens.Count == 0)
                    {
                        MessageBox.Show(
                            "Nenhum item ativo encontrado para reagendar."
                        );
                        return;
                    }

                    foreach (int idItem in idsItens)
                    {
                        string sqlUpdate = @"
UPDATE AgendamentoServicos
SET Data = @NovaData,
    Horario = @NovoHorario
WHERE Id = @Id";

                        using (MySqlCommand cmdUpdate =
                            new MySqlCommand(sqlUpdate, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue(
                                "@NovaData",
                                novaData
                            );

                            cmdUpdate.Parameters.AddWithValue(
                                "@NovoHorario",
                                novoHorario
                            );

                            cmdUpdate.Parameters.AddWithValue(
                                "@Id",
                                idItem
                            );

                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                }

                AtualizarResumoAgendamentoPai(agendamentoId);

                EnviarEmailReagendamentoAdmin(
                    nome,
                    email,
                    telefone,
                    tipoServico,
                    servico,
                    novaData,
                    novoHorario
                );

                MessageBox.Show("Agendamento completo reagendado com sucesso!");

                CarregarAgendamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao reagendar completo:\n" + ex.Message
                );
            }
        }

        private void btnPainelAdmin_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}