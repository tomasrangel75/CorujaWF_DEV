namespace QuestionarioForms
{
    partial class FormRelatorioReportTurma
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
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.gridPortugues = new System.Windows.Forms.DataGridView();
            this.lblPortugues = new MetroFramework.Controls.MetroLabel();
            this.lblMatematica = new MetroFramework.Controls.MetroLabel();
            this.gridMatematica = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlLegenda = new System.Windows.Forms.Panel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridAprendizagem = new System.Windows.Forms.DataGridView();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.txtEscola = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAplic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPortugues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatematica)).BeginInit();
            this.pnlLegenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAprendizagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPDFMt);
            this.panel1.Controls.Add(this.btnPDF);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.comboQuestionario);
            this.panel1.Controls.Add(this.lblQuestionario);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Controls.Add(this.comboTurma);
            this.panel1.Controls.Add(this.lblTurma);
            this.panel1.Controls.Add(this.comboEscola);
            this.panel1.Controls.Add(this.lblEscola);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 45);
            this.panel1.TabIndex = 2;
            // 
            // btnPDFMt
            // 
            this.btnPDFMt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDFMt.Enabled = false;
            this.btnPDFMt.Location = new System.Drawing.Point(1086, 1);
            this.btnPDFMt.Name = "btnPDFMt";
            this.btnPDFMt.Size = new System.Drawing.Size(52, 37);
            this.btnPDFMt.TabIndex = 34;
            this.btnPDFMt.Text = "PDF-MT";
            this.btnPDFMt.UseCustomBackColor = true;
            this.btnPDFMt.UseSelectable = true;
            this.btnPDFMt.Click += new System.EventHandler(this.btnPDFMt_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(1034, 1);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(47, 37);
            this.btnPDF.TabIndex = 33;
            this.btnPDF.Text = "PDF-PT";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCSV.Enabled = false;
            this.btnCSV.Location = new System.Drawing.Point(989, 1);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(39, 37);
            this.btnCSV.TabIndex = 25;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseCustomBackColor = true;
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.Enabled = false;
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(613, 7);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(210, 29);
            this.comboQuestionario.TabIndex = 23;
            this.comboQuestionario.UseSelectable = true;
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(512, 15);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 22;
            this.lblQuestionario.Text = "Questionário";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(829, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(110, 37);
            this.btnGerarRelatorio.TabIndex = 21;
            this.btnGerarRelatorio.Text = "Gerar Relatório";
            this.btnGerarRelatorio.UseCustomBackColor = true;
            this.btnGerarRelatorio.UseSelectable = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // comboTurma
            // 
            this.comboTurma.Enabled = false;
            this.comboTurma.FormattingEnabled = true;
            this.comboTurma.ItemHeight = 23;
            this.comboTurma.Location = new System.Drawing.Point(284, 7);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(222, 29);
            this.comboTurma.TabIndex = 5;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(227, 15);
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
            this.comboEscola.Size = new System.Drawing.Size(150, 29);
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
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.metroButton1.Location = new System.Drawing.Point(9, 59);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(153, 37);
            this.metroButton1.TabIndex = 35;
            this.metroButton1.Text = "PDF Rel. Esc/Tur. LP/MAT";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // gridPortugues
            // 
            this.gridPortugues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridPortugues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPortugues.Location = new System.Drawing.Point(247, 85);
            this.gridPortugues.Name = "gridPortugues";
            this.gridPortugues.Size = new System.Drawing.Size(702, 149);
            this.gridPortugues.TabIndex = 26;
            // 
            // lblPortugues
            // 
            this.lblPortugues.AutoSize = true;
            this.lblPortugues.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPortugues.Location = new System.Drawing.Point(247, 63);
            this.lblPortugues.Name = "lblPortugues";
            this.lblPortugues.Size = new System.Drawing.Size(156, 19);
            this.lblPortugues.TabIndex = 26;
            this.lblPortugues.Text = "Português / Literatura";
            // 
            // lblMatematica
            // 
            this.lblMatematica.AutoSize = true;
            this.lblMatematica.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblMatematica.Location = new System.Drawing.Point(247, 243);
            this.lblMatematica.Name = "lblMatematica";
            this.lblMatematica.Size = new System.Drawing.Size(88, 19);
            this.lblMatematica.TabIndex = 27;
            this.lblMatematica.Text = "Matemática";
            // 
            // gridMatematica
            // 
            this.gridMatematica.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridMatematica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatematica.Location = new System.Drawing.Point(247, 265);
            this.gridMatematica.Name = "gridMatematica";
            this.gridMatematica.Size = new System.Drawing.Size(702, 149);
            this.gridMatematica.TabIndex = 28;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1006, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 32;
            this.metroLabel1.Text = "Legenda";
            // 
            // pnlLegenda
            // 
            this.pnlLegenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegenda.Controls.Add(this.metroLabel5);
            this.pnlLegenda.Controls.Add(this.metroLabel4);
            this.pnlLegenda.Controls.Add(this.metroLabel3);
            this.pnlLegenda.Controls.Add(this.metroLabel2);
            this.pnlLegenda.Controls.Add(this.panel5);
            this.pnlLegenda.Controls.Add(this.panel4);
            this.pnlLegenda.Controls.Add(this.panel3);
            this.pnlLegenda.Controls.Add(this.panel2);
            this.pnlLegenda.Location = new System.Drawing.Point(1006, 85);
            this.pnlLegenda.Name = "pnlLegenda";
            this.pnlLegenda.Size = new System.Drawing.Size(153, 149);
            this.pnlLegenda.TabIndex = 31;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(49, 106);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(63, 19);
            this.metroLabel5.TabIndex = 35;
            this.metroLabel5.Text = "75 - 100";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(49, 77);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(55, 19);
            this.metroLabel4.TabIndex = 34;
            this.metroLabel4.Text = "50 - 75";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(49, 48);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(55, 19);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "25 - 50";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(49, 19);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 19);
            this.metroLabel2.TabIndex = 31;
            this.metroLabel2.Text = "0 - 25";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(6, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(32, 23);
            this.panel5.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(235)))), ((int)(((byte)(108)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(6, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 23);
            this.panel4.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(6, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 23);
            this.panel3.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tomato;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 23);
            this.panel2.TabIndex = 31;
            // 
            // gridAprendizagem
            // 
            this.gridAprendizagem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridAprendizagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAprendizagem.Location = new System.Drawing.Point(247, 458);
            this.gridAprendizagem.Name = "gridAprendizagem";
            this.gridAprendizagem.Size = new System.Drawing.Size(702, 149);
            this.gridAprendizagem.TabIndex = 28;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(247, 436);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(108, 19);
            this.metroLabel6.TabIndex = 27;
            this.metroLabel6.Text = "Aprendizagem";
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.metroButton2.Location = new System.Drawing.Point(9, 120);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(153, 37);
            this.metroButton2.TabIndex = 35;
            this.metroButton2.Text = "PDF Rel. Esc/Tur. APR";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtEscola
            // 
            this.txtEscola.Location = new System.Drawing.Point(9, 192);
            this.txtEscola.Name = "txtEscola";
            this.txtEscola.Size = new System.Drawing.Size(153, 20);
            this.txtEscola.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Escola";
            // 
            // txtAplic
            // 
            this.txtAplic.Location = new System.Drawing.Point(9, 240);
            this.txtAplic.Name = "txtAplic";
            this.txtAplic.Size = new System.Drawing.Size(153, 20);
            this.txtAplic.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Data de Aplicação";
            // 
            // FormRelatorioReportTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 744);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAplic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEscola);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pnlLegenda);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.lblMatematica);
            this.Controls.Add(this.gridAprendizagem);
            this.Controls.Add(this.gridMatematica);
            this.Controls.Add(this.lblPortugues);
            this.Controls.Add(this.gridPortugues);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioReportTurma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPortugues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatematica)).EndInit();
            this.pnlLegenda.ResumeLayout(false);
            this.pnlLegenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAprendizagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView gridPortugues;
        private MetroFramework.Controls.MetroLabel lblPortugues;
        private MetroFramework.Controls.MetroLabel lblMatematica;
        private System.Windows.Forms.DataGridView gridMatematica;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel pnlLegenda;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btnPDFMt;
        private MetroFramework.Controls.MetroButton btnPDF;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridView gridAprendizagem;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TextBox txtEscola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAplic;
        private System.Windows.Forms.Label label2;
    }
}