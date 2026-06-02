namespace teste_de_designe
{
    partial class PainelAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PainelAdmin));
            dgvPainelAdm_Agendamentos = new DataGridView();
            btnPainelAdmin_Reagendar = new Button();
            btnPainelAdmin_Reembolsar = new Button();
            btnPainelAdmin_Banir_Usuario = new Button();
            txtPainelAdm_Nome = new TextBox();
            txtPainelAdm_Email = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            mskPainelAdm_Telefone = new MaskedTextBox();
            mskPainelAdm_CPF = new MaskedTextBox();
            dtpPainelAdm_NovaData = new DateTimePicker();
            cbbPainelAdm_NovoHorario = new ComboBox();
            btnPainelAdmin_DesbanirUsuario = new Button();
            btnPainelAdmin_Atualizar = new Button();
            btnPainelAdmin_Reagendar_completo = new Button();
            btnPainelAdmin_Sair = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPainelAdm_Agendamentos).BeginInit();
            SuspendLayout();
            // 
            // dgvPainelAdm_Agendamentos
            // 
            dgvPainelAdm_Agendamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPainelAdm_Agendamentos.Location = new Point(2, 98);
            dgvPainelAdm_Agendamentos.Name = "dgvPainelAdm_Agendamentos";
            dgvPainelAdm_Agendamentos.Size = new Size(795, 273);
            dgvPainelAdm_Agendamentos.TabIndex = 0;
            dgvPainelAdm_Agendamentos.CellClick += dgvPainelAdm_Agendamentos_CellClick;
            dgvPainelAdm_Agendamentos.RowPrePaint += dgvPainelAdm_Agendamentos_RowPrePaint;
            // 
            // btnPainelAdmin_Reagendar
            // 
            btnPainelAdmin_Reagendar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Reagendar.Image = (Image)resources.GetObject("btnPainelAdmin_Reagendar.Image");
            btnPainelAdmin_Reagendar.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Reagendar.Location = new Point(12, 415);
            btnPainelAdmin_Reagendar.Name = "btnPainelAdmin_Reagendar";
            btnPainelAdmin_Reagendar.Size = new Size(109, 30);
            btnPainelAdmin_Reagendar.TabIndex = 1;
            btnPainelAdmin_Reagendar.Text = "Reagendar";
            btnPainelAdmin_Reagendar.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Reagendar.UseVisualStyleBackColor = true;
            btnPainelAdmin_Reagendar.Click += btnPainelAdmin_Reagendar_Click;
            // 
            // btnPainelAdmin_Reembolsar
            // 
            btnPainelAdmin_Reembolsar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Reembolsar.Image = (Image)resources.GetObject("btnPainelAdmin_Reembolsar.Image");
            btnPainelAdmin_Reembolsar.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Reembolsar.Location = new Point(138, 415);
            btnPainelAdmin_Reembolsar.Name = "btnPainelAdmin_Reembolsar";
            btnPainelAdmin_Reembolsar.Size = new Size(114, 30);
            btnPainelAdmin_Reembolsar.TabIndex = 2;
            btnPainelAdmin_Reembolsar.Text = "Reembolsar";
            btnPainelAdmin_Reembolsar.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Reembolsar.UseVisualStyleBackColor = true;
            btnPainelAdmin_Reembolsar.Click += btnPainelAdmin_Reembolsar_Click;
            // 
            // btnPainelAdmin_Banir_Usuario
            // 
            btnPainelAdmin_Banir_Usuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Banir_Usuario.Image = (Image)resources.GetObject("btnPainelAdmin_Banir_Usuario.Image");
            btnPainelAdmin_Banir_Usuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Banir_Usuario.Location = new Point(271, 415);
            btnPainelAdmin_Banir_Usuario.Name = "btnPainelAdmin_Banir_Usuario";
            btnPainelAdmin_Banir_Usuario.Size = new Size(112, 30);
            btnPainelAdmin_Banir_Usuario.TabIndex = 3;
            btnPainelAdmin_Banir_Usuario.Text = "Banir Usuário";
            btnPainelAdmin_Banir_Usuario.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Banir_Usuario.UseVisualStyleBackColor = true;
            btnPainelAdmin_Banir_Usuario.Click += btnPainelAdmin_Banir_Usuario_Click;
            // 
            // txtPainelAdm_Nome
            // 
            txtPainelAdm_Nome.Location = new Point(8, 71);
            txtPainelAdm_Nome.Name = "txtPainelAdm_Nome";
            txtPainelAdm_Nome.Size = new Size(244, 23);
            txtPainelAdm_Nome.TabIndex = 4;
            // 
            // txtPainelAdm_Email
            // 
            txtPainelAdm_Email.Location = new Point(258, 71);
            txtPainelAdm_Email.Name = "txtPainelAdm_Email";
            txtPainelAdm_Email.Size = new Size(188, 23);
            txtPainelAdm_Email.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 53);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 8;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(258, 53);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 9;
            label2.Text = "E-mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(456, 53);
            label3.Name = "label3";
            label3.Size = new Size(61, 17);
            label3.TabIndex = 10;
            label3.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(636, 53);
            label4.Name = "label4";
            label4.Size = new Size(31, 17);
            label4.TabIndex = 11;
            label4.Text = "CPF";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(327, 9);
            label5.Name = "label5";
            label5.Size = new Size(146, 17);
            label5.TabIndex = 12;
            label5.Text = "Painel Adiministrativo";
            // 
            // mskPainelAdm_Telefone
            // 
            mskPainelAdm_Telefone.Location = new Point(456, 71);
            mskPainelAdm_Telefone.Name = "mskPainelAdm_Telefone";
            mskPainelAdm_Telefone.Size = new Size(170, 23);
            mskPainelAdm_Telefone.TabIndex = 13;
            // 
            // mskPainelAdm_CPF
            // 
            mskPainelAdm_CPF.Location = new Point(636, 73);
            mskPainelAdm_CPF.Name = "mskPainelAdm_CPF";
            mskPainelAdm_CPF.Size = new Size(156, 23);
            mskPainelAdm_CPF.TabIndex = 14;
            // 
            // dtpPainelAdm_NovaData
            // 
            dtpPainelAdm_NovaData.Format = DateTimePickerFormat.Short;
            dtpPainelAdm_NovaData.Location = new Point(588, 377);
            dtpPainelAdm_NovaData.Name = "dtpPainelAdm_NovaData";
            dtpPainelAdm_NovaData.Size = new Size(200, 23);
            dtpPainelAdm_NovaData.TabIndex = 15;
            // 
            // cbbPainelAdm_NovoHorario
            // 
            cbbPainelAdm_NovoHorario.FormattingEnabled = true;
            cbbPainelAdm_NovoHorario.Location = new Point(456, 377);
            cbbPainelAdm_NovoHorario.Name = "cbbPainelAdm_NovoHorario";
            cbbPainelAdm_NovoHorario.Size = new Size(121, 23);
            cbbPainelAdm_NovoHorario.TabIndex = 16;
            // 
            // btnPainelAdmin_DesbanirUsuario
            // 
            btnPainelAdmin_DesbanirUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_DesbanirUsuario.Image = (Image)resources.GetObject("btnPainelAdmin_DesbanirUsuario.Image");
            btnPainelAdmin_DesbanirUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_DesbanirUsuario.Location = new Point(190, 380);
            btnPainelAdmin_DesbanirUsuario.Name = "btnPainelAdmin_DesbanirUsuario";
            btnPainelAdmin_DesbanirUsuario.Size = new Size(138, 30);
            btnPainelAdmin_DesbanirUsuario.TabIndex = 17;
            btnPainelAdmin_DesbanirUsuario.Text = "Desbanir Usuário";
            btnPainelAdmin_DesbanirUsuario.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_DesbanirUsuario.UseVisualStyleBackColor = true;
            btnPainelAdmin_DesbanirUsuario.Click += btnPainelAdmin_DesbanirUsuario_Click;
            // 
            // btnPainelAdmin_Atualizar
            // 
            btnPainelAdmin_Atualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Atualizar.Image = (Image)resources.GetObject("btnPainelAdmin_Atualizar.Image");
            btnPainelAdmin_Atualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Atualizar.Location = new Point(401, 415);
            btnPainelAdmin_Atualizar.Name = "btnPainelAdmin_Atualizar";
            btnPainelAdmin_Atualizar.Size = new Size(101, 30);
            btnPainelAdmin_Atualizar.TabIndex = 18;
            btnPainelAdmin_Atualizar.Text = "Atualizar";
            btnPainelAdmin_Atualizar.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Atualizar.UseVisualStyleBackColor = true;
            btnPainelAdmin_Atualizar.Click += btnPainelAdmin_Atualizar_Click;
            // 
            // btnPainelAdmin_Reagendar_completo
            // 
            btnPainelAdmin_Reagendar_completo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Reagendar_completo.Image = (Image)resources.GetObject("btnPainelAdmin_Reagendar_completo.Image");
            btnPainelAdmin_Reagendar_completo.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Reagendar_completo.Location = new Point(12, 380);
            btnPainelAdmin_Reagendar_completo.Name = "btnPainelAdmin_Reagendar_completo";
            btnPainelAdmin_Reagendar_completo.Size = new Size(162, 30);
            btnPainelAdmin_Reagendar_completo.TabIndex = 19;
            btnPainelAdmin_Reagendar_completo.Text = "Reagendar Completo";
            btnPainelAdmin_Reagendar_completo.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Reagendar_completo.UseVisualStyleBackColor = true;
            btnPainelAdmin_Reagendar_completo.Click += btnPainelAdmin_Reagendar_completo_Click;
            // 
            // btnPainelAdmin_Sair
            // 
            btnPainelAdmin_Sair.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPainelAdmin_Sair.Image = (Image)resources.GetObject("btnPainelAdmin_Sair.Image");
            btnPainelAdmin_Sair.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainelAdmin_Sair.Location = new Point(724, 415);
            btnPainelAdmin_Sair.Name = "btnPainelAdmin_Sair";
            btnPainelAdmin_Sair.Size = new Size(64, 30);
            btnPainelAdmin_Sair.TabIndex = 20;
            btnPainelAdmin_Sair.Text = "Sair";
            btnPainelAdmin_Sair.TextAlign = ContentAlignment.MiddleRight;
            btnPainelAdmin_Sair.UseVisualStyleBackColor = true;
            btnPainelAdmin_Sair.Click += btnPainelAdmin_Sair_Click;
            // 
            // PainelAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPainelAdmin_Sair);
            Controls.Add(btnPainelAdmin_Reagendar_completo);
            Controls.Add(btnPainelAdmin_Atualizar);
            Controls.Add(btnPainelAdmin_DesbanirUsuario);
            Controls.Add(cbbPainelAdm_NovoHorario);
            Controls.Add(dtpPainelAdm_NovaData);
            Controls.Add(mskPainelAdm_CPF);
            Controls.Add(mskPainelAdm_Telefone);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPainelAdm_Email);
            Controls.Add(txtPainelAdm_Nome);
            Controls.Add(btnPainelAdmin_Banir_Usuario);
            Controls.Add(btnPainelAdmin_Reembolsar);
            Controls.Add(btnPainelAdmin_Reagendar);
            Controls.Add(dgvPainelAdm_Agendamentos);
            Name = "PainelAdmin";
            Text = "PainelAdmin";
            ((System.ComponentModel.ISupportInitialize)dgvPainelAdm_Agendamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPainelAdm_Agendamentos;
        private Button btnPainelAdmin_Reagendar;
        private Button btnPainelAdmin_Reembolsar;
        private Button btnPainelAdmin_Banir_Usuario;
        private TextBox txtPainelAdm_Nome;
        private TextBox txtPainelAdm_Email;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox mskPainelAdm_Telefone;
        private MaskedTextBox mskPainelAdm_CPF;
        private DateTimePicker dtpPainelAdm_NovaData;
        private ComboBox cbbPainelAdm_NovoHorario;
        private Button btnPainelAdmin_DesbanirUsuario;
        private Button btnPainelAdmin_Atualizar;
        private Button btnPainelAdmin_Reagendar_completo;
        private Button btnPainelAdmin_Sair;
    }
}