namespace QuestionarioForms
{
    partial class FormRelatorioTurma
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
            this.btnPdfApr = new MetroFramework.Controls.MetroButton();
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.txtDtAplic = new System.Windows.Forms.TextBox();
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridAlunos = new System.Windows.Forms.DataGridView();
            this.btnPDFMt = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPDFMt);
            this.panel1.Controls.Add(this.btnPdfApr);
            this.panel1.Controls.Add(this.btnPDF);
            this.panel1.Controls.Add(this.txtDtAplic);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.comboQuestionario);
            this.panel1.Controls.Add(this.lblQuestionario);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Controls.Add(this.comboTurma);
            this.panel1.Controls.Add(this.lblTurma);
            this.panel1.Controls.Add(this.comboEscola);
            this.panel1.Controls.Add(this.lblEscola);
            this.panel1.Location = new System.Drawing.Point(167, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 88);
            this.panel1.TabIndex = 0;
            // 
            // btnPdfApr
            // 
            this.btnPdfApr.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPdfApr.Enabled = false;
            this.btnPdfApr.Location = new System.Drawing.Point(834, 44);
            this.btnPdfApr.Name = "btnPdfApr";
            this.btnPdfApr.Size = new System.Drawing.Size(74, 37);
            this.btnPdfApr.TabIndex = 28;
            this.btnPdfApr.Text = "PDF-APR";
            this.btnPdfApr.UseCustomBackColor = true;
            this.btnPdfApr.UseSelectable = true;
            this.btnPdfApr.Click += new System.EventHandler(this.btnPdfApr_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(669, 44);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(74, 37);
            this.btnPDF.TabIndex = 25;
            this.btnPDF.Text = "PDF-LP";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // txtDtAplic
            // 
            this.txtDtAplic.Location = new System.Drawing.Point(140, 50);
            this.txtDtAplic.Name = "txtDtAplic";
            this.txtDtAplic.Size = new System.Drawing.Size(139, 20);
            this.txtDtAplic.TabIndex = 27;
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.Yellow;
            this.btnCSV.Enabled = false;
            this.btnCSV.Location = new System.Drawing.Point(869, 3);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(39, 37);
            this.btnCSV.TabIndex = 24;
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
            this.comboQuestionario.Location = new System.Drawing.Point(566, 7);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(199, 29);
            this.comboQuestionario.TabIndex = 23;
            this.comboQuestionario.UseSelectable = true;
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(470, 15);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 22;
            this.lblQuestionario.Text = "Questionário";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 50);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(131, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Data de Aplicação";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(771, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(94, 37);
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
            this.comboTurma.Location = new System.Drawing.Point(258, 7);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(208, 29);
            this.comboTurma.TabIndex = 5;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(207, 15);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(51, 19);
            this.lblTurma.TabIndex = 4;
            this.lblTurma.Text = "Turma";
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(53, 7);
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
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.gridAlunos);
            this.pnlGrid.Location = new System.Drawing.Point(23, 150);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1151, 402);
            this.pnlGrid.TabIndex = 1;
            // 
            // gridAlunos
            // 
            this.gridAlunos.BackgroundColor = System.Drawing.Color.White;
            this.gridAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlunos.Location = new System.Drawing.Point(3, 17);
            this.gridAlunos.Name = "gridAlunos";
            this.gridAlunos.Size = new System.Drawing.Size(1143, 396);
            this.gridAlunos.TabIndex = 0;
            this.gridAlunos.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.gridAlunos_CellStateChanged);
            // 
            // btnPDFMt
            // 
            this.btnPDFMt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDFMt.Enabled = false;
            this.btnPDFMt.Location = new System.Drawing.Point(752, 44);
            this.btnPDFMt.Name = "btnPDFMt";
            this.btnPDFMt.Size = new System.Drawing.Size(74, 37);
            this.btnPDFMt.TabIndex = 26;
            this.btnPDFMt.Text = "PDF-MT";
            this.btnPDFMt.UseCustomBackColor = true;
            this.btnPDFMt.UseSelectable = true;
            this.btnPDFMt.Click += new System.EventHandler(this.btnPDFMt_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(27, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(233, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Ordem de Carregamento do Grid";
            // 
            // FormRelatorioTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 574);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioTurma";
            this.Text = "Perfil Corujão";
            this.Load += new System.EventHandler(this.FormRelatorioTurma_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox comboTurma;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private MetroFramework.Controls.MetroComboBox comboEscola;
        private MetroFramework.Controls.MetroLabel lblEscola;
        private System.Windows.Forms.Panel pnlGrid;
        private MetroFramework.Controls.MetroButton btnGerarRelatorio;
        private System.Windows.Forms.DataGridView gridAlunos;
        private MetroFramework.Controls.MetroComboBox comboQuestionario;
        private MetroFramework.Controls.MetroLabel lblQuestionario;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroButton btnPDF;
        private MetroFramework.Controls.MetroButton btnPDFMt;
        private System.Windows.Forms.TextBox txtDtAplic;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnPdfApr;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}