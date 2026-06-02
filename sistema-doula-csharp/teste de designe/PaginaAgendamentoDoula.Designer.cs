namespace teste_de_designe
{
    partial class PaginaAgendamentoDoula

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaAgendamentoDoula));
            monthCalendar1 = new MonthCalendar();
            ccbAgendaDoula_AcompanhamentoParto = new CheckBox();
            ccbAgendaDoula_ConsultaPreNatal = new CheckBox();
            ccbAgendaDoula_PosParto = new CheckBox();
            ccbAgendaDoula_Amamentacao = new CheckBox();
            pnlAgendamentoDoula_Horarios = new FlowLayoutPanel();
            btnDoula_Agendar = new Button();
            btnDoula_Voltar = new Button();
            btnDoula_Limpar = new Button();
            lblAgendaDoula_ValorTotal = new Label();
            label1 = new Label();
            label2 = new Label();
            ccbAgendaFuro_Titanio = new CheckBox();
            ccbAgendaFuro_Aco = new CheckBox();
            ccbAgendaFuro_Ouro = new CheckBox();
            ccbAgendaFuro_Prata = new CheckBox();
            pnl_GrupoDoula = new Panel();
            pnl_GrupoFuroDeOrelha = new Panel();
            pnlAgendamentoFuro_Horarios = new FlowLayoutPanel();
            cbbQuantidadeFuro_Pessoas = new ComboBox();
            label3 = new Label();
            btnDoula_Historico = new Button();
            pnl_GrupoDoula.SuspendLayout();
            pnl_GrupoFuroDeOrelha.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(43, 3);
            monthCalendar1.Margin = new Padding(0);
            monthCalendar1.MaxDate = new DateTime(2998, 12, 1, 0, 0, 0, 0);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MinDate = new DateTime(2026, 3, 1, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // ccbAgendaDoula_AcompanhamentoParto
            // 
            ccbAgendaDoula_AcompanhamentoParto.AutoSize = true;
            ccbAgendaDoula_AcompanhamentoParto.Location = new Point(3, 84);
            ccbAgendaDoula_AcompanhamentoParto.Name = "ccbAgendaDoula_AcompanhamentoParto";
            ccbAgendaDoula_AcompanhamentoParto.Size = new Size(129, 34);
            ccbAgendaDoula_AcompanhamentoParto.TabIndex = 1;
            ccbAgendaDoula_AcompanhamentoParto.Text = "Acompanhamento \r\nparto R$300";
            ccbAgendaDoula_AcompanhamentoParto.UseVisualStyleBackColor = true;
            ccbAgendaDoula_AcompanhamentoParto.CheckedChanged += ccbAgendaDoula_CheckedChanged;
            // 
            // ccbAgendaDoula_ConsultaPreNatal
            // 
            ccbAgendaDoula_ConsultaPreNatal.AutoSize = true;
            ccbAgendaDoula_ConsultaPreNatal.Location = new Point(3, 24);
            ccbAgendaDoula_ConsultaPreNatal.Name = "ccbAgendaDoula_ConsultaPreNatal";
            ccbAgendaDoula_ConsultaPreNatal.Size = new Size(111, 19);
            ccbAgendaDoula_ConsultaPreNatal.TabIndex = 2;
            ccbAgendaDoula_ConsultaPreNatal.Text = "pré-natal  R$100\r\n";
            ccbAgendaDoula_ConsultaPreNatal.UseVisualStyleBackColor = true;
            ccbAgendaDoula_ConsultaPreNatal.CheckedChanged += ccbAgendaDoula_CheckedChanged;
            // 
            // ccbAgendaDoula_PosParto
            // 
            ccbAgendaDoula_PosParto.AutoSize = true;
            ccbAgendaDoula_PosParto.Location = new Point(3, 44);
            ccbAgendaDoula_PosParto.Name = "ccbAgendaDoula_PosParto";
            ccbAgendaDoula_PosParto.Size = new Size(115, 19);
            ccbAgendaDoula_PosParto.TabIndex = 3;
            ccbAgendaDoula_PosParto.Text = "Pós-parto  R$150";
            ccbAgendaDoula_PosParto.UseVisualStyleBackColor = true;
            ccbAgendaDoula_PosParto.CheckedChanged += ccbAgendaDoula_CheckedChanged;
            // 
            // ccbAgendaDoula_Amamentacao
            // 
            ccbAgendaDoula_Amamentacao.AutoSize = true;
            ccbAgendaDoula_Amamentacao.Location = new Point(3, 64);
            ccbAgendaDoula_Amamentacao.Name = "ccbAgendaDoula_Amamentacao";
            ccbAgendaDoula_Amamentacao.Size = new Size(144, 19);
            ccbAgendaDoula_Amamentacao.TabIndex = 4;
            ccbAgendaDoula_Amamentacao.Text = "Amamentação  R$120 ";
            ccbAgendaDoula_Amamentacao.UseVisualStyleBackColor = true;
            ccbAgendaDoula_Amamentacao.CheckedChanged += ccbAgendaDoula_CheckedChanged;
            // 
            // pnlAgendamentoDoula_Horarios
            // 
            pnlAgendamentoDoula_Horarios.BackColor = Color.Transparent;
            pnlAgendamentoDoula_Horarios.Location = new Point(0, 124);
            pnlAgendamentoDoula_Horarios.Name = "pnlAgendamentoDoula_Horarios";
            pnlAgendamentoDoula_Horarios.Size = new Size(161, 109);
            pnlAgendamentoDoula_Horarios.TabIndex = 5;
            // 
            // btnDoula_Agendar
            // 
            btnDoula_Agendar.BackColor = Color.Transparent;
            btnDoula_Agendar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            btnDoula_Agendar.Image = (Image)resources.GetObject("btnDoula_Agendar.Image");
            btnDoula_Agendar.ImageAlign = ContentAlignment.MiddleLeft;
            btnDoula_Agendar.Location = new Point(124, 478);
            btnDoula_Agendar.Name = "btnDoula_Agendar";
            btnDoula_Agendar.Size = new Size(98, 30);
            btnDoula_Agendar.TabIndex = 6;
            btnDoula_Agendar.Text = "Agendar";
            btnDoula_Agendar.TextAlign = ContentAlignment.MiddleRight;
            btnDoula_Agendar.UseVisualStyleBackColor = false;
            btnDoula_Agendar.Click += btnDoula_Agendar_Click;
            // 
            // btnDoula_Voltar
            // 
            btnDoula_Voltar.BackColor = Color.Transparent;
            btnDoula_Voltar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            btnDoula_Voltar.Image = (Image)resources.GetObject("btnDoula_Voltar.Image");
            btnDoula_Voltar.ImageAlign = ContentAlignment.MiddleLeft;
            btnDoula_Voltar.Location = new Point(5, 524);
            btnDoula_Voltar.Name = "btnDoula_Voltar";
            btnDoula_Voltar.Size = new Size(75, 30);
            btnDoula_Voltar.TabIndex = 7;
            btnDoula_Voltar.Text = "Voltar";
            btnDoula_Voltar.TextAlign = ContentAlignment.MiddleRight;
            btnDoula_Voltar.UseVisualStyleBackColor = false;
            btnDoula_Voltar.Click += btnDoula_Voltar_Click;
            // 
            // btnDoula_Limpar
            // 
            btnDoula_Limpar.BackColor = Color.Transparent;
            btnDoula_Limpar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            btnDoula_Limpar.Image = (Image)resources.GetObject("btnDoula_Limpar.Image");
            btnDoula_Limpar.ImageAlign = ContentAlignment.MiddleLeft;
            btnDoula_Limpar.Location = new Point(278, 524);
            btnDoula_Limpar.Name = "btnDoula_Limpar";
            btnDoula_Limpar.Size = new Size(75, 30);
            btnDoula_Limpar.TabIndex = 8;
            btnDoula_Limpar.Text = "Limpar";
            btnDoula_Limpar.TextAlign = ContentAlignment.MiddleRight;
            btnDoula_Limpar.UseVisualStyleBackColor = false;
            btnDoula_Limpar.Click += btnDoula_Limpar_Click;
            // 
            // lblAgendaDoula_ValorTotal
            // 
            lblAgendaDoula_ValorTotal.AutoSize = true;
            lblAgendaDoula_ValorTotal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgendaDoula_ValorTotal.Location = new Point(141, 448);
            lblAgendaDoula_ValorTotal.Name = "lblAgendaDoula_ValorTotal";
            lblAgendaDoula_ValorTotal.Size = new Size(71, 17);
            lblAgendaDoula_ValorTotal.TabIndex = 9;
            lblAgendaDoula_ValorTotal.Text = "Valor Total";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 5);
            label1.Name = "label1";
            label1.Size = new Size(139, 17);
            label1.TabIndex = 10;
            label1.Text = "Agendamento Doula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 9F, FontStyle.Bold);
            label2.Location = new Point(4, 6);
            label2.Name = "label2";
            label2.Size = new Size(104, 17);
            label2.TabIndex = 11;
            label2.Text = "Furo de Orelha";
            // 
            // ccbAgendaFuro_Titanio
            // 
            ccbAgendaFuro_Titanio.AutoSize = true;
            ccbAgendaFuro_Titanio.Location = new Point(12, 26);
            ccbAgendaFuro_Titanio.Name = "ccbAgendaFuro_Titanio";
            ccbAgendaFuro_Titanio.Size = new Size(141, 19);
            ccbAgendaFuro_Titanio.TabIndex = 12;
            ccbAgendaFuro_Titanio.Text = "Joias de Titânio   R$80";
            ccbAgendaFuro_Titanio.UseVisualStyleBackColor = true;
            // 
            // ccbAgendaFuro_Aco
            // 
            ccbAgendaFuro_Aco.AutoSize = true;
            ccbAgendaFuro_Aco.Location = new Point(12, 47);
            ccbAgendaFuro_Aco.Name = "ccbAgendaFuro_Aco";
            ccbAgendaFuro_Aco.Size = new Size(133, 19);
            ccbAgendaFuro_Aco.TabIndex = 13;
            ccbAgendaFuro_Aco.Text = "Aço Cirúrgico   R$60";
            ccbAgendaFuro_Aco.UseVisualStyleBackColor = true;
            // 
            // ccbAgendaFuro_Ouro
            // 
            ccbAgendaFuro_Ouro.AutoSize = true;
            ccbAgendaFuro_Ouro.Location = new Point(12, 68);
            ccbAgendaFuro_Ouro.Name = "ccbAgendaFuro_Ouro";
            ccbAgendaFuro_Ouro.Size = new Size(158, 19);
            ccbAgendaFuro_Ouro.TabIndex = 14;
            ccbAgendaFuro_Ouro.Text = "Joias de Ouro 18k   R$150";
            ccbAgendaFuro_Ouro.UseVisualStyleBackColor = true;
            // 
            // ccbAgendaFuro_Prata
            // 
            ccbAgendaFuro_Prata.AutoSize = true;
            ccbAgendaFuro_Prata.Location = new Point(12, 88);
            ccbAgendaFuro_Prata.Name = "ccbAgendaFuro_Prata";
            ccbAgendaFuro_Prata.Size = new Size(137, 19);
            ccbAgendaFuro_Prata.TabIndex = 15;
            ccbAgendaFuro_Prata.Text = "Joias de Prata   R$100";
            ccbAgendaFuro_Prata.UseVisualStyleBackColor = true;
            // 
            // pnl_GrupoDoula
            // 
            pnl_GrupoDoula.BackColor = Color.Transparent;
            pnl_GrupoDoula.Controls.Add(label1);
            pnl_GrupoDoula.Controls.Add(ccbAgendaDoula_ConsultaPreNatal);
            pnl_GrupoDoula.Controls.Add(ccbAgendaDoula_PosParto);
            pnl_GrupoDoula.Controls.Add(ccbAgendaDoula_Amamentacao);
            pnl_GrupoDoula.Controls.Add(ccbAgendaDoula_AcompanhamentoParto);
            pnl_GrupoDoula.Controls.Add(pnlAgendamentoDoula_Horarios);
            pnl_GrupoDoula.Location = new Point(5, 175);
            pnl_GrupoDoula.Name = "pnl_GrupoDoula";
            pnl_GrupoDoula.Size = new Size(161, 233);
            pnl_GrupoDoula.TabIndex = 16;
            // 
            // pnl_GrupoFuroDeOrelha
            // 
            pnl_GrupoFuroDeOrelha.BackColor = Color.Transparent;
            pnl_GrupoFuroDeOrelha.Controls.Add(pnlAgendamentoFuro_Horarios);
            pnl_GrupoFuroDeOrelha.Controls.Add(ccbAgendaFuro_Titanio);
            pnl_GrupoFuroDeOrelha.Controls.Add(label2);
            pnl_GrupoFuroDeOrelha.Controls.Add(ccbAgendaFuro_Prata);
            pnl_GrupoFuroDeOrelha.Controls.Add(ccbAgendaFuro_Aco);
            pnl_GrupoFuroDeOrelha.Controls.Add(ccbAgendaFuro_Ouro);
            pnl_GrupoFuroDeOrelha.Location = new Point(171, 175);
            pnl_GrupoFuroDeOrelha.Name = "pnl_GrupoFuroDeOrelha";
            pnl_GrupoFuroDeOrelha.Size = new Size(182, 233);
            pnl_GrupoFuroDeOrelha.TabIndex = 17;
            // 
            // pnlAgendamentoFuro_Horarios
            // 
            pnlAgendamentoFuro_Horarios.BackColor = Color.Transparent;
            pnlAgendamentoFuro_Horarios.Location = new Point(2, 124);
            pnlAgendamentoFuro_Horarios.Name = "pnlAgendamentoFuro_Horarios";
            pnlAgendamentoFuro_Horarios.Size = new Size(182, 109);
            pnlAgendamentoFuro_Horarios.TabIndex = 16;
            // 
            // cbbQuantidadeFuro_Pessoas
            // 
            cbbQuantidadeFuro_Pessoas.FormattingEnabled = true;
            cbbQuantidadeFuro_Pessoas.Items.AddRange(new object[] { "1", "2", "3" });
            cbbQuantidadeFuro_Pessoas.Location = new Point(157, 414);
            cbbQuantidadeFuro_Pessoas.Name = "cbbQuantidadeFuro_Pessoas";
            cbbQuantidadeFuro_Pessoas.Size = new Size(33, 23);
            cbbQuantidadeFuro_Pessoas.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 422);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 17;
            label3.Text = "Quantidade de pessoas :";
            // 
            // btnDoula_Historico
            // 
            btnDoula_Historico.BackColor = Color.Transparent;
            btnDoula_Historico.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            btnDoula_Historico.Image = (Image)resources.GetObject("btnDoula_Historico.Image");
            btnDoula_Historico.ImageAlign = ContentAlignment.MiddleLeft;
            btnDoula_Historico.Location = new Point(96, 524);
            btnDoula_Historico.Name = "btnDoula_Historico";
            btnDoula_Historico.Size = new Size(163, 30);
            btnDoula_Historico.TabIndex = 19;
            btnDoula_Historico.Text = "Historico de Compras";
            btnDoula_Historico.TextAlign = ContentAlignment.MiddleRight;
            btnDoula_Historico.UseVisualStyleBackColor = false;
            btnDoula_Historico.Click += btnDoula_Historico_Click;
            // 
            // PaginaAgendamentoDoula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(353, 566);
            Controls.Add(btnDoula_Historico);
            Controls.Add(cbbQuantidadeFuro_Pessoas);
            Controls.Add(pnl_GrupoFuroDeOrelha);
            Controls.Add(label3);
            Controls.Add(pnl_GrupoDoula);
            Controls.Add(lblAgendaDoula_ValorTotal);
            Controls.Add(btnDoula_Limpar);
            Controls.Add(btnDoula_Voltar);
            Controls.Add(btnDoula_Agendar);
            Controls.Add(monthCalendar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaginaAgendamentoDoula";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagina de Agendamento";
            Load += PaginaAgendamentoDoula_Load;
            pnl_GrupoDoula.ResumeLayout(false);
            pnl_GrupoDoula.PerformLayout();
            pnl_GrupoFuroDeOrelha.ResumeLayout(false);
            pnl_GrupoFuroDeOrelha.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar1;
        private CheckBox ccbAgendaDoula_AcompanhamentoParto;
        private CheckBox ccbAgendaDoula_ConsultaPreNatal;
        private CheckBox ccbAgendaDoula_PosParto;
        private CheckBox ccbAgendaDoula_Amamentacao;
        private FlowLayoutPanel pnlAgendamentoDoula_Horarios;
        private Button btnDoula_Agendar;
        private Button btnDoula_Voltar;
        private Button btnDoula_Limpar;
        private Label lblAgendaDoula_ValorTotal;
        private Label label1;
        private Label label2;
        private CheckBox ccbAgendaFuro_Titanio;
        private CheckBox ccbAgendaFuro_Aco;
        private CheckBox ccbAgendaFuro_Ouro;
        private CheckBox ccbAgendaFuro_Prata;
        private Panel pnl_GrupoDoula;
        private Panel pnl_GrupoFuroDeOrelha;
        private FlowLayoutPanel pnlAgendamentoFuro_Horarios;
        private Label label3;
        private ComboBox cbbQuantidadeFuro_Pessoas;
        private Button btnDoula_Historico;
    }
}