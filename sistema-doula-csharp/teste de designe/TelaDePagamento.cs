using System;
using System.Windows.Forms;

namespace teste_de_designe
{
    public partial class TelaDePagamento : Form
    {
        public bool PagamentoConfirmado = false;

        DateTime data;
        string horarios;
        string servicos;
        decimal total;
        int quantidade;
        int id;

        string companheiro;
        string bebe;
        string local;
        DateTime dpp;
        string equipe;

        public TelaDePagamento(
            DateTime dataSel,
            string horariosSel,
            string servicosSel,
            decimal valor,
            int qtd,
            int agId,
            string nomeComp,
            string nomeBebe,
            string localP,
            DateTime dppData,
            string equipeMed
        )
        {
            InitializeComponent();

            data = dataSel;
            horarios = horariosSel;
            servicos = servicosSel;
            total = valor;
            quantidade = qtd;
            id = agId;

            companheiro = nomeComp;
            bebe = nomeBebe;
            local = localP;
            dpp = dppData;
            equipe = equipeMed;
        }

        private void TelaDePagamento_Load(object sender, EventArgs e)
        {
            lblPagemento_Data.Text = data.ToString("dd/MM/yyyy");
            lblPagemento_Horario.Text = string.IsNullOrWhiteSpace(horarios) ? "-" : horarios;
            lblPagamento_Servico.Text = string.IsNullOrWhiteSpace(servicos) ? "-" : servicos;
            lblTelaPagamento_ValoraPagar.Text = $"R$ {total:N2}";

            if (quantidade > 0)
                lblPagamento_Pessoas.Text = $"{quantidade} pessoa(s) no furo";
            else
                lblPagamento_Pessoas.Text = "Sem furo selecionado";

            bool temDoula =
                !string.IsNullOrWhiteSpace(companheiro) ||
                !string.IsNullOrWhiteSpace(bebe) ||
                !string.IsNullOrWhiteSpace(local) ||
                dpp != DateTime.MinValue ||
                !string.IsNullOrWhiteSpace(equipe);

            if (temDoula)
            {
                lblPagemento_Companheiro.Text = string.IsNullOrWhiteSpace(companheiro) ? "-" : companheiro;
                lblPagemento_Bebe.Text = string.IsNullOrWhiteSpace(bebe) ? "-" : bebe;
                lblPagemento_Local.Text = string.IsNullOrWhiteSpace(local) ? "-" : local;
                lblPagemento_DPP.Text = dpp == DateTime.MinValue ? "-" : dpp.ToString("dd/MM/yyyy");
                lblPagemento_Equipe.Text = string.IsNullOrWhiteSpace(equipe) ? "-" : equipe;
            }
            else
            {
                lblPagemento_Companheiro.Text = "-";
                lblPagemento_Bebe.Text = "-";
                lblPagemento_Local.Text = "-";
                lblPagemento_DPP.Text = "-";
                lblPagemento_Equipe.Text = "-";
            }

            cbbPagamento_FormasdePagamento.Items.Clear();
            cbbPagamento_FormasdePagamento.Items.Add("Pix");
            cbbPagamento_FormasdePagamento.Items.Add("Cartão");
            cbbPagamento_FormasdePagamento.Items.Add("Boleto");
            cbbPagamento_FormasdePagamento.SelectedIndex = 0;
        }

        private void btnPagamento_ConfirmarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbPagamento_FormasdePagamento.SelectedIndex == -1)
                {
                    MessageBox.Show("Escolha a forma de pagamento!");
                    return;
                }

                string formaPagamento = cbbPagamento_FormasdePagamento.SelectedItem.ToString();

                PagamentoConfirmado = true;

                MessageBox.Show(
                    $"Pagamento confirmado com sucesso!\n\nForma de pagamento: {formaPagamento}\nValor: R$ {total:N2}",
                    "Pagamento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no pagamento:\n" + ex.Message);
            }
        }

        private void btnPagamento_Cancelar_Click(object sender, EventArgs e)
        {
            var op = MessageBox.Show(
                "Deseja cancelar o pagamento?",
                "Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (op == DialogResult.Yes)
            {
                PagamentoConfirmado = false;
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}