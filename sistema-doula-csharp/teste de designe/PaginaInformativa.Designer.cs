namespace teste_de_designe
{
    partial class PaginaInformativa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaInformativa));
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            btnPaginaInformativa_Agendar = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(-1, 15);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(346, 215);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(-1, 254);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(346, 243);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, -2);
            label1.Name = "label1";
            label1.Size = new Size(122, 17);
            label1.TabIndex = 3;
            label1.Text = "Informações Doula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 234);
            label2.Name = "label2";
            label2.Size = new Size(154, 17);
            label2.TabIndex = 4;
            label2.Text = "Perfuração Humanizado";
            // 
            // btnPaginaInformativa_Agendar
            // 
            btnPaginaInformativa_Agendar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPaginaInformativa_Agendar.Image = (Image)resources.GetObject("btnPaginaInformativa_Agendar.Image");
            btnPaginaInformativa_Agendar.ImageAlign = ContentAlignment.MiddleLeft;
            btnPaginaInformativa_Agendar.Location = new Point(243, 500);
            btnPaginaInformativa_Agendar.Name = "btnPaginaInformativa_Agendar";
            btnPaginaInformativa_Agendar.Size = new Size(100, 30);
            btnPaginaInformativa_Agendar.TabIndex = 5;
            btnPaginaInformativa_Agendar.Text = "Agendar";
            btnPaginaInformativa_Agendar.TextAlign = ContentAlignment.MiddleRight;
            btnPaginaInformativa_Agendar.UseVisualStyleBackColor = true;
            btnPaginaInformativa_Agendar.Click += btnPaginaInformativa_Agendar_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 500);
            button3.Name = "button3";
            button3.Size = new Size(64, 30);
            button3.TabIndex = 6;
            button3.Text = "Sair";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PaginaInformativa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(345, 537);
            Controls.Add(button3);
            Controls.Add(btnPaginaInformativa_Agendar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaginaInformativa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaginaInformativa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label1;
        private Label label2;
        private Button btnPaginaInformativa_Agendar;
        private Button button3;
    }
}