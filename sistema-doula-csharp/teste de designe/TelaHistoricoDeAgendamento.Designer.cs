namespace teste_de_designe
{
    partial class TelaHistoricoDeAgendamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaHistoricoDeAgendamento));
            label1 = new Label();
            btnHistorico_Buscar = new Button();
            pnlHistorico_Filtro = new Panel();
            txtHistorico_Filtro = new TextBox();
            dtpHistorico_Filtro = new DateTimePicker();
            pnlHistorico_Tabela = new Panel();
            dgvHistorico_Tabela = new DataGridView();
            pnlHistorico_Resumo = new Panel();
            lblHistorico_Total = new Label();
            lblHistorico_Reembolso = new Label();
            btnHistorico_Voltar = new Button();
            label3 = new Label();
            label2 = new Label();
            pnlHistorico_Filtro.SuspendLayout();
            pnlHistorico_Tabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico_Tabela).BeginInit();
            pnlHistorico_Resumo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(139, 9);
            label1.Name = "label1";
            label1.Size = new Size(156, 15);
            label1.TabIndex = 0;
            label1.Text = "Histórico de Agendamento";
            // 
            // btnHistorico_Buscar
            // 
            btnHistorico_Buscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHistorico_Buscar.ForeColor = Color.Black;
            btnHistorico_Buscar.Image = (Image)resources.GetObject("btnHistorico_Buscar.Image");
            btnHistorico_Buscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico_Buscar.Location = new Point(442, 0);
            btnHistorico_Buscar.Name = "btnHistorico_Buscar";
            btnHistorico_Buscar.Size = new Size(73, 26);
            btnHistorico_Buscar.TabIndex = 4;
            btnHistorico_Buscar.Text = "Buscar";
            btnHistorico_Buscar.TextAlign = ContentAlignment.MiddleRight;
            btnHistorico_Buscar.UseVisualStyleBackColor = true;
            // 
            // pnlHistorico_Filtro
            // 
            pnlHistorico_Filtro.BackColor = Color.Transparent;
            pnlHistorico_Filtro.Controls.Add(txtHistorico_Filtro);
            pnlHistorico_Filtro.Controls.Add(dtpHistorico_Filtro);
            pnlHistorico_Filtro.Controls.Add(btnHistorico_Buscar);
            pnlHistorico_Filtro.ForeColor = Color.White;
            pnlHistorico_Filtro.Location = new Point(2, 27);
            pnlHistorico_Filtro.Name = "pnlHistorico_Filtro";
            pnlHistorico_Filtro.Size = new Size(519, 44);
            pnlHistorico_Filtro.TabIndex = 10;
            // 
            // txtHistorico_Filtro
            // 
            txtHistorico_Filtro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHistorico_Filtro.Location = new Point(249, 3);
            txtHistorico_Filtro.Name = "txtHistorico_Filtro";
            txtHistorico_Filtro.Size = new Size(187, 23);
            txtHistorico_Filtro.TabIndex = 1;
            txtHistorico_Filtro.TextChanged += txtHistorico_Filtro_TextChanged;
            // 
            // dtpHistorico_Filtro
            // 
            dtpHistorico_Filtro.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dtpHistorico_Filtro.Location = new Point(3, 3);
            dtpHistorico_Filtro.Name = "dtpHistorico_Filtro";
            dtpHistorico_Filtro.Size = new Size(240, 23);
            dtpHistorico_Filtro.TabIndex = 0;
            // 
            // pnlHistorico_Tabela
            // 
            pnlHistorico_Tabela.Controls.Add(dgvHistorico_Tabela);
            pnlHistorico_Tabela.Location = new Point(2, 77);
            pnlHistorico_Tabela.Name = "pnlHistorico_Tabela";
            pnlHistorico_Tabela.Size = new Size(542, 217);
            pnlHistorico_Tabela.TabIndex = 11;
            // 
            // dgvHistorico_Tabela
            // 
            dgvHistorico_Tabela.AllowUserToAddRows = false;
            dgvHistorico_Tabela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorico_Tabela.Dock = DockStyle.Fill;
            dgvHistorico_Tabela.Location = new Point(0, 0);
            dgvHistorico_Tabela.MultiSelect = false;
            dgvHistorico_Tabela.Name = "dgvHistorico_Tabela";
            dgvHistorico_Tabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico_Tabela.Size = new Size(542, 217);
            dgvHistorico_Tabela.TabIndex = 0;
            dgvHistorico_Tabela.CellContentClick += dgvHistorico_Tabela_CellContentClick;
            // 
            // pnlHistorico_Resumo
            // 
            pnlHistorico_Resumo.BackColor = Color.Transparent;
            pnlHistorico_Resumo.Controls.Add(lblHistorico_Total);
            pnlHistorico_Resumo.Controls.Add(lblHistorico_Reembolso);
            pnlHistorico_Resumo.Controls.Add(btnHistorico_Voltar);
            pnlHistorico_Resumo.Controls.Add(label3);
            pnlHistorico_Resumo.Controls.Add(label2);
            pnlHistorico_Resumo.Location = new Point(2, 297);
            pnlHistorico_Resumo.Name = "pnlHistorico_Resumo";
            pnlHistorico_Resumo.Size = new Size(418, 146);
            pnlHistorico_Resumo.TabIndex = 11;
            // 
            // lblHistorico_Total
            // 
            lblHistorico_Total.AutoSize = true;
            lblHistorico_Total.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblHistorico_Total.Location = new Point(76, 24);
            lblHistorico_Total.Name = "lblHistorico_Total";
            lblHistorico_Total.Size = new Size(34, 17);
            lblHistorico_Total.TabIndex = 4;
            lblHistorico_Total.Text = "R$ 0";
            // 
            // lblHistorico_Reembolso
            // 
            lblHistorico_Reembolso.AutoSize = true;
            lblHistorico_Reembolso.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblHistorico_Reembolso.Location = new Point(120, 65);
            lblHistorico_Reembolso.Name = "lblHistorico_Reembolso";
            lblHistorico_Reembolso.Size = new Size(34, 17);
            lblHistorico_Reembolso.TabIndex = 3;
            lblHistorico_Reembolso.Text = "R$ 0";
            // 
            // btnHistorico_Voltar
            // 
            btnHistorico_Voltar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorico_Voltar.Image = (Image)resources.GetObject("btnHistorico_Voltar.Image");
            btnHistorico_Voltar.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico_Voltar.Location = new Point(328, 107);
            btnHistorico_Voltar.Name = "btnHistorico_Voltar";
            btnHistorico_Voltar.Size = new Size(72, 30);
            btnHistorico_Voltar.TabIndex = 2;
            btnHistorico_Voltar.Text = "Voltar";
            btnHistorico_Voltar.TextAlign = ContentAlignment.MiddleRight;
            btnHistorico_Voltar.UseVisualStyleBackColor = true;
            btnHistorico_Voltar.Click += btnHistorico_Voltar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(23, 65);
            label3.Name = "label3";
            label3.Size = new Size(91, 17);
            label3.TabIndex = 1;
            label3.Text = "Reembolsado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(23, 24);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 0;
            label2.Text = "Total :";
            // 
            // TelaHistoricoDeAgendamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(544, 450);
            Controls.Add(pnlHistorico_Tabela);
            Controls.Add(pnlHistorico_Resumo);
            Controls.Add(pnlHistorico_Filtro);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaHistoricoDeAgendamento";
            Text = "TelaHistoricoDeAgendamento";
            Load += TelaHistoricoDeAgendamento_Load;
            pnlHistorico_Filtro.ResumeLayout(false);
            pnlHistorico_Filtro.PerformLayout();
            pnlHistorico_Tabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorico_Tabela).EndInit();
            pnlHistorico_Resumo.ResumeLayout(false);
            pnlHistorico_Resumo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnHistorico_Buscar;
        private Panel pnlHistorico_Filtro;
        private DateTimePicker dtpHistorico_Filtro;
        private Panel pnlHistorico_Tabela;
        private Panel pnlHistorico_Resumo;
        private TextBox txtHistorico_Filtro;
        private DataGridView dgvHistorico_Tabela;
        private Button btnHistorico_Voltar;
        private Label label3;
        private Label label2;
        private Label lblHistorico_Total;
        private Label lblHistorico_Reembolso;
    }
}