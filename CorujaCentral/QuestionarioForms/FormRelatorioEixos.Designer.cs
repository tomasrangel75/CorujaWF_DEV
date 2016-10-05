namespace QuestionarioForms
{
    partial class FormRelatorioEixos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPDFMt = new MetroFramework.Controls.MetroButton();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlAzul = new System.Windows.Forms.Panel();
            this.listAzul = new System.Windows.Forms.ListBox();
            this.pnlVerde = new System.Windows.Forms.Panel();
            this.listVerde = new System.Windows.Forms.ListBox();
            this.pnlAmarelo = new System.Windows.Forms.Panel();
            this.listAmarelo = new System.Windows.Forms.ListBox();
            this.pnlVermelho = new System.Windows.Forms.Panel();
            this.listVermelho = new System.Windows.Forms.ListBox();
            this.pnlRadios = new System.Windows.Forms.Panel();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblMat = new MetroFramework.Controls.MetroLabel();
            this.lblPort = new MetroFramework.Controls.MetroLabel();
            this.txtDtAplic = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnPdfApr = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.pnlAzul.SuspendLayout();
            this.pnlVerde.SuspendLayout();
            this.pnlAmarelo.SuspendLayout();
            this.pnlVermelho.SuspendLayout();
            this.pnlRadios.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPdfApr);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.btnPDFMt);
            this.panel1.Controls.Add(this.txtDtAplic);
            this.panel1.Controls.Add(this.comboQuestionario);
            this.panel1.Controls.Add(this.btnPDF);
            this.panel1.Controls.Add(this.lblQuestionario);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Controls.Add(this.comboTurma);
            this.panel1.Controls.Add(this.lblTurma);
            this.panel1.Controls.Add(this.comboEscola);
            this.panel1.Controls.Add(this.lblEscola);
            this.panel1.Location = new System.Drawing.Point(273, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 89);
            this.panel1.TabIndex = 1;
            // 
            // btnPDFMt
            // 
            this.btnPDFMt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDFMt.Enabled = false;
            this.btnPDFMt.Location = new System.Drawing.Point(880, 3);
            this.btnPDFMt.Name = "btnPDFMt";
            this.btnPDFMt.Size = new System.Drawing.Size(52, 37);
            this.btnPDFMt.TabIndex = 31;
            this.btnPDFMt.Text = "PDF-MT";
            this.btnPDFMt.UseCustomBackColor = true;
            this.btnPDFMt.UseSelectable = true;
            this.btnPDFMt.Click += new System.EventHandler(this.btnPDFMt_Click);
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.Enabled = false;
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(558, 7);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(189, 29);
            this.comboQuestionario.TabIndex = 23;
            this.comboQuestionario.UseSelectable = true;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(826, 3);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(47, 37);
            this.btnPDF.TabIndex = 30;
            this.btnPDF.Text = "PDF-PT";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(462, 15);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 22;
            this.lblQuestionario.Text = "Questionário";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(754, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(66, 37);
            this.btnGerarRelatorio.TabIndex = 21;
            this.btnGerarRelatorio.Text = "Gerar";
            this.btnGerarRelatorio.UseCustomBackColor = true;
            this.btnGerarRelatorio.UseSelectable = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // comboTurma
            // 
            this.comboTurma.Enabled = false;
            this.comboTurma.FormattingEnabled = true;
            this.comboTurma.ItemHeight = 23;
            this.comboTurma.Location = new System.Drawing.Point(250, 7);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(207, 29);
            this.comboTurma.TabIndex = 5;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(199, 15);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(51, 19);
            this.lblTurma.TabIndex = 4;
            this.lblTurma.Text = "Turma";
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(60, 7);
            this.comboEscola.Name = "comboEscola";
            this.comboEscola.Size = new System.Drawing.Size(134, 29);
            this.comboEscola.TabIndex = 5;
            this.comboEscola.UseSelectable = true;
            this.comboEscola.SelectedIndexChanged += new System.EventHandler(this.comboEscola_SelectedIndexChanged);
            // 
            // lblEscola
            // 
            this.lblEscola.AutoSize = true;
            this.lblEscola.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEscola.Location = new System.Drawing.Point(3, 15);
            this.lblEscola.Name = "lblEscola";
            this.lblEscola.Size = new System.Drawing.Size(50, 19);
            this.lblEscola.TabIndex = 4;
            this.lblEscola.Text = "Escola";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.pnlAzul);
            this.pnlPrincipal.Controls.Add(this.pnlVerde);
            this.pnlPrincipal.Controls.Add(this.pnlAmarelo);
            this.pnlPrincipal.Controls.Add(this.pnlVermelho);
            this.pnlPrincipal.Controls.Add(this.pnlRadios);
            this.pnlPrincipal.Location = new System.Drawing.Point(23, 116);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1190, 375);
            this.pnlPrincipal.TabIndex = 2;
            this.pnlPrincipal.Visible = false;
            // 
            // pnlAzul
            // 
            this.pnlAzul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAzul.Controls.Add(this.listAzul);
            this.pnlAzul.Location = new System.Drawing.Point(680, 210);
            this.pnlAzul.Name = "pnlAzul";
            this.pnlAzul.Size = new System.Drawing.Size(497, 159);
            this.pnlAzul.TabIndex = 29;
            this.pnlAzul.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAzul_Paint);
            // 
            // listAzul
            // 
            this.listAzul.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAzul.FormattingEnabled = true;
            this.listAzul.Location = new System.Drawing.Point(12, 11);
            this.listAzul.Name = "listAzul";
            this.listAzul.Size = new System.Drawing.Size(471, 130);
            this.listAzul.TabIndex = 1;
            // 
            // pnlVerde
            // 
            this.pnlVerde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVerde.Controls.Add(this.listVerde);
            this.pnlVerde.Location = new System.Drawing.Point(680, 44);
            this.pnlVerde.Name = "pnlVerde";
            this.pnlVerde.Size = new System.Drawing.Size(497, 159);
            this.pnlVerde.TabIndex = 29;
            this.pnlVerde.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVerde_Paint);
            // 
            // listVerde
            // 
            this.listVerde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVerde.FormattingEnabled = true;
            this.listVerde.Location = new System.Drawing.Point(12, 11);
            this.listVerde.Name = "listVerde";
            this.listVerde.Size = new System.Drawing.Size(471, 130);
            this.listVerde.TabIndex = 1;
            // 
            // pnlAmarelo
            // 
            this.pnlAmarelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAmarelo.Controls.Add(this.listAmarelo);
            this.pnlAmarelo.Location = new System.Drawing.Point(6, 210);
            this.pnlAmarelo.Name = "pnlAmarelo";
            this.pnlAmarelo.Size = new System.Drawing.Size(497, 159);
            this.pnlAmarelo.TabIndex = 28;
            this.pnlAmarelo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAmarelo_Paint);
            // 
            // listAmarelo
            // 
            this.listAmarelo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAmarelo.FormattingEnabled = true;
            this.listAmarelo.Location = new System.Drawing.Point(12, 11);
            this.listAmarelo.Name = "listAmarelo";
            this.listAmarelo.Size = new System.Drawing.Size(471, 130);
            this.listAmarelo.TabIndex = 1;
            // 
            // pnlVermelho
            // 
            this.pnlVermelho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVermelho.Controls.Add(this.listVermelho);
            this.pnlVermelho.Location = new System.Drawing.Point(6, 44);
            this.pnlVermelho.Name = "pnlVermelho";
            this.pnlVermelho.Size = new System.Drawing.Size(497, 159);
            this.pnlVermelho.TabIndex = 27;
            this.pnlVermelho.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVermelho_Paint);
            // 
            // listVermelho
            // 
            this.listVermelho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVermelho.FormattingEnabled = true;
            this.listVermelho.Location = new System.Drawing.Point(12, 13);
            this.listVermelho.Name = "listVermelho";
            this.listVermelho.Size = new System.Drawing.Size(471, 130);
            this.listVermelho.TabIndex = 0;
            // 
            // pnlRadios
            // 
            this.pnlRadios.Controls.Add(this.radioButton8);
            this.pnlRadios.Controls.Add(this.radioButton7);
            this.pnlRadios.Controls.Add(this.radioButton6);
            this.pnlRadios.Controls.Add(this.radioButton5);
            this.pnlRadios.Controls.Add(this.radioButton4);
            this.pnlRadios.Controls.Add(this.radioButton3);
            this.pnlRadios.Controls.Add(this.radioButton2);
            this.pnlRadios.Controls.Add(this.radioButton1);
            this.pnlRadios.Controls.Add(this.lblMat);
            this.pnlRadios.Controls.Add(this.lblPort);
            this.pnlRadios.Location = new System.Drawing.Point(3, 3);
            this.pnlRadios.Name = "pnlRadios";
            this.pnlRadios.Size = new System.Drawing.Size(1174, 34);
            this.pnlRadios.TabIndex = 26;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8.Location = new System.Drawing.Point(1050, 10);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(97, 17);
            this.radioButton8.TabIndex = 35;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "radioButton8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(926, 10);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(97, 17);
            this.radioButton7.TabIndex = 34;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "radioButton7";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(801, 10);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(97, 17);
            this.radioButton6.TabIndex = 33;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(682, 10);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(97, 17);
            this.radioButton5.TabIndex = 32;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(429, 10);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(97, 17);
            this.radioButton4.TabIndex = 31;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(314, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(97, 17);
            this.radioButton3.TabIndex = 30;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(199, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 17);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(83, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblMat
            // 
            this.lblMat.AutoSize = true;
            this.lblMat.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblMat.Location = new System.Drawing.Point(581, 8);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(88, 19);
            this.lblMat.TabIndex = 27;
            this.lblMat.Text = "Matemática";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPort.Location = new System.Drawing.Point(3, 8);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(77, 19);
            this.lblPort.TabIndex = 25;
            this.lblPort.Text = "Português";
            // 
            // txtDtAplic
            // 
            this.txtDtAplic.Location = new System.Drawing.Point(140, 51);
            this.txtDtAplic.Name = "txtDtAplic";
            this.txtDtAplic.Size = new System.Drawing.Size(100, 20);
            this.txtDtAplic.TabIndex = 3;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 51);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(131, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Data de Aplicação";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // btnPdfApr
            // 
            this.btnPdfApr.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPdfApr.Enabled = false;
            this.btnPdfApr.Location = new System.Drawing.Point(754, 46);
            this.btnPdfApr.Name = "btnPdfApr";
            this.btnPdfApr.Size = new System.Drawing.Size(66, 37);
            this.btnPdfApr.TabIndex = 32;
            this.btnPdfApr.Text = "PDF-APR";
            this.btnPdfApr.UseCustomBackColor = true;
            this.btnPdfApr.UseSelectable = true;
            this.btnPdfApr.Click += new System.EventHandler(this.btnPdfApr_Click);
            // 
            // FormRelatorioEixos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 519);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioEixos";
            this.Text = "Distribuição dos Alunos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlAzul.ResumeLayout(false);
            this.pnlVerde.ResumeLayout(false);
            this.pnlAmarelo.ResumeLayout(false);
            this.pnlVermelho.ResumeLayout(false);
            this.pnlRadios.ResumeLayout(false);
            this.pnlRadios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox comboQuestionario;
        private MetroFramework.Controls.MetroLabel lblQuestionario;
        private MetroFramework.Controls.MetroButton btnGerarRelatorio;
        private MetroFramework.Controls.MetroComboBox comboTurma;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private MetroFramework.Controls.MetroComboBox comboEscola;
        private MetroFramework.Controls.MetroLabel lblEscola;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlRadios;
        private MetroFramework.Controls.MetroLabel lblPort;
        private System.Windows.Forms.Panel pnlAzul;
        private System.Windows.Forms.Panel pnlVerde;
        private System.Windows.Forms.Panel pnlAmarelo;
        private System.Windows.Forms.Panel pnlVermelho;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private MetroFramework.Controls.MetroLabel lblMat;
        private System.Windows.Forms.ListBox listVermelho;
        private System.Windows.Forms.ListBox listAzul;
        private System.Windows.Forms.ListBox listVerde;
        private System.Windows.Forms.ListBox listAmarelo;
        private MetroFramework.Controls.MetroButton btnPDFMt;
        private MetroFramework.Controls.MetroButton btnPDF;
        private System.Windows.Forms.TextBox txtDtAplic;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnPdfApr;
    }
}