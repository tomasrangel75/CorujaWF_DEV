namespace QuestionarioForms
{
    partial class FormRelatorioReportAluno
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
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.comboAluno = new MetroFramework.Controls.MetroComboBox();
            this.lblAlunoTx = new MetroFramework.Controls.MetroLabel();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.gridPortugues = new System.Windows.Forms.DataGridView();
            this.lblPortugues = new MetroFramework.Controls.MetroLabel();
            this.lblMatematica = new MetroFramework.Controls.MetroLabel();
            this.gridMatematica = new System.Windows.Forms.DataGridView();
            this.pnlLegenda = new System.Windows.Forms.Panel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnEspecialista = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.gridtreino = new System.Windows.Forms.DataGridView();
            this.gridpsico = new System.Windows.Forms.DataGridView();
            this.btnEspecRel = new MetroFramework.Controls.MetroButton();
            this.btnTdsAlunosEscola = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtDtAplic = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPortugues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatematica)).BeginInit();
            this.pnlLegenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtreino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridpsico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPDFMt);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.btnPDF);
            this.panel1.Controls.Add(this.comboAluno);
            this.panel1.Controls.Add(this.lblAlunoTx);
            this.panel1.Controls.Add(this.comboQuestionario);
            this.panel1.Controls.Add(this.lblQuestionario);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Controls.Add(this.comboTurma);
            this.panel1.Controls.Add(this.lblTurma);
            this.panel1.Controls.Add(this.comboEscola);
            this.panel1.Controls.Add(this.lblEscola);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1189, 45);
            this.panel1.TabIndex = 2;
            // 
            // btnPDFMt
            // 
            this.btnPDFMt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDFMt.Enabled = false;
            this.btnPDFMt.Location = new System.Drawing.Point(1127, 3);
            this.btnPDFMt.Name = "btnPDFMt";
            this.btnPDFMt.Size = new System.Drawing.Size(52, 37);
            this.btnPDFMt.TabIndex = 32;
            this.btnPDFMt.Text = "PDF-MT";
            this.btnPDFMt.UseCustomBackColor = true;
            this.btnPDFMt.UseSelectable = true;
            this.btnPDFMt.Click += new System.EventHandler(this.btnPDFMt_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCSV.Enabled = false;
            this.btnCSV.Location = new System.Drawing.Point(1029, 3);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(39, 37);
            this.btnCSV.TabIndex = 29;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseCustomBackColor = true;
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(1075, 3);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(47, 37);
            this.btnPDF.TabIndex = 31;
            this.btnPDF.Text = "PDF-PT";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // comboAluno
            // 
            this.comboAluno.Enabled = false;
            this.comboAluno.FormattingEnabled = true;
            this.comboAluno.ItemHeight = 23;
            this.comboAluno.Location = new System.Drawing.Point(486, 7);
            this.comboAluno.Name = "comboAluno";
            this.comboAluno.Size = new System.Drawing.Size(194, 29);
            this.comboAluno.TabIndex = 25;
            this.comboAluno.UseSelectable = true;
            this.comboAluno.SelectedIndexChanged += new System.EventHandler(this.comboAluno_SelectedIndexChanged);
            // 
            // lblAlunoTx
            // 
            this.lblAlunoTx.AutoSize = true;
            this.lblAlunoTx.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAlunoTx.Location = new System.Drawing.Point(439, 15);
            this.lblAlunoTx.Name = "lblAlunoTx";
            this.lblAlunoTx.Size = new System.Drawing.Size(48, 19);
            this.lblAlunoTx.TabIndex = 24;
            this.lblAlunoTx.Text = "Aluno";
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.Enabled = false;
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(780, 7);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(176, 29);
            this.comboQuestionario.TabIndex = 23;
            this.comboQuestionario.UseSelectable = true;
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(685, 15);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 22;
            this.lblQuestionario.Text = "Questionário";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(961, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(62, 37);
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
            this.comboTurma.Location = new System.Drawing.Point(249, 7);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(185, 29);
            this.comboTurma.TabIndex = 5;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(198, 15);
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
            this.comboEscola.Size = new System.Drawing.Size(132, 29);
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
            // gridPortugues
            // 
            this.gridPortugues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridPortugues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPortugues.Location = new System.Drawing.Point(247, 141);
            this.gridPortugues.Name = "gridPortugues";
            this.gridPortugues.Size = new System.Drawing.Size(702, 116);
            this.gridPortugues.TabIndex = 26;
            // 
            // lblPortugues
            // 
            this.lblPortugues.AutoSize = true;
            this.lblPortugues.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPortugues.Location = new System.Drawing.Point(247, 119);
            this.lblPortugues.Name = "lblPortugues";
            this.lblPortugues.Size = new System.Drawing.Size(156, 19);
            this.lblPortugues.TabIndex = 26;
            this.lblPortugues.Text = "Português / Literatura";
            // 
            // lblMatematica
            // 
            this.lblMatematica.AutoSize = true;
            this.lblMatematica.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblMatematica.Location = new System.Drawing.Point(247, 266);
            this.lblMatematica.Name = "lblMatematica";
            this.lblMatematica.Size = new System.Drawing.Size(88, 19);
            this.lblMatematica.TabIndex = 27;
            this.lblMatematica.Text = "Matemática";
            // 
            // gridMatematica
            // 
            this.gridMatematica.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridMatematica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatematica.Location = new System.Drawing.Point(247, 287);
            this.gridMatematica.Name = "gridMatematica";
            this.gridMatematica.Size = new System.Drawing.Size(702, 116);
            this.gridMatematica.TabIndex = 28;
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
            this.pnlLegenda.Location = new System.Drawing.Point(989, 141);
            this.pnlLegenda.Name = "pnlLegenda";
            this.pnlLegenda.Size = new System.Drawing.Size(153, 149);
            this.pnlLegenda.TabIndex = 29;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(49, 106);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(63, 19);
            this.metroLabel5.TabIndex = 35;
            this.metroLabel5.Text = "76 - 100";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(49, 77);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(55, 19);
            this.metroLabel4.TabIndex = 34;
            this.metroLabel4.Text = "51 - 75";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(49, 48);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(55, 19);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "26 - 50";
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
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(989, 119);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "Legenda";
            // 
            // btnEspecialista
            // 
            this.btnEspecialista.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEspecialista.Location = new System.Drawing.Point(9, 132);
            this.btnEspecialista.Name = "btnEspecialista";
            this.btnEspecialista.Size = new System.Drawing.Size(193, 37);
            this.btnEspecialista.TabIndex = 33;
            this.btnEspecialista.Text = "Relatório Escola";
            this.btnEspecialista.UseCustomBackColor = true;
            this.btnEspecialista.UseSelectable = true;
            this.btnEspecialista.Click += new System.EventHandler(this.btnEspecialista_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(247, 412);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(213, 19);
            this.metroLabel6.TabIndex = 34;
            this.metroLabel6.Text = "Habilidades de Aprendizagem";
            // 
            // gridtreino
            // 
            this.gridtreino.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridtreino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridtreino.Location = new System.Drawing.Point(249, 435);
            this.gridtreino.Name = "gridtreino";
            this.gridtreino.Size = new System.Drawing.Size(702, 116);
            this.gridtreino.TabIndex = 35;
            // 
            // gridpsico
            // 
            this.gridpsico.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridpsico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridpsico.Location = new System.Drawing.Point(23, 435);
            this.gridpsico.Name = "gridpsico";
            this.gridpsico.Size = new System.Drawing.Size(174, 116);
            this.gridpsico.TabIndex = 36;
            this.gridpsico.Visible = false;
            // 
            // btnEspecRel
            // 
            this.btnEspecRel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEspecRel.Location = new System.Drawing.Point(9, 248);
            this.btnEspecRel.Name = "btnEspecRel";
            this.btnEspecRel.Size = new System.Drawing.Size(193, 37);
            this.btnEspecRel.TabIndex = 37;
            this.btnEspecRel.Text = "Relatório Especialista";
            this.btnEspecRel.UseCustomBackColor = true;
            this.btnEspecRel.UseSelectable = true;
            this.btnEspecRel.Click += new System.EventHandler(this.btnEspecRel_Click);
            // 
            // btnTdsAlunosEscola
            // 
            this.btnTdsAlunosEscola.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTdsAlunosEscola.Location = new System.Drawing.Point(9, 190);
            this.btnTdsAlunosEscola.Name = "btnTdsAlunosEscola";
            this.btnTdsAlunosEscola.Size = new System.Drawing.Size(193, 37);
            this.btnTdsAlunosEscola.TabIndex = 38;
            this.btnTdsAlunosEscola.Text = "Todos da Escola";
            this.btnTdsAlunosEscola.UseCustomBackColor = true;
            this.btnTdsAlunosEscola.UseSelectable = true;
            this.btnTdsAlunosEscola.Click += new System.EventHandler(this.btnTdsAlunosEscola_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.metroButton1.Location = new System.Drawing.Point(13, 307);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(193, 37);
            this.metroButton1.TabIndex = 37;
            this.metroButton1.Text = "Relat Escola Aluno MAT ou APR";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.metroButton2.Location = new System.Drawing.Point(13, 366);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(193, 37);
            this.metroButton2.TabIndex = 37;
            this.metroButton2.Text = "Relat Escola Aluno LP ou Híbrido";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(9, 74);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(131, 19);
            this.metroLabel7.TabIndex = 39;
            this.metroLabel7.Text = "Data de Aplicação";
            // 
            // txtDtAplic
            // 
            this.txtDtAplic.Location = new System.Drawing.Point(9, 97);
            this.txtDtAplic.Name = "txtDtAplic";
            this.txtDtAplic.Size = new System.Drawing.Size(131, 20);
            this.txtDtAplic.TabIndex = 40;
            // 
            // FormRelatorioReportAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 564);
            this.Controls.Add(this.txtDtAplic);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.btnTdsAlunosEscola);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnEspecRel);
            this.Controls.Add(this.gridpsico);
            this.Controls.Add(this.gridtreino);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.btnEspecialista);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pnlLegenda);
            this.Controls.Add(this.lblMatematica);
            this.Controls.Add(this.gridMatematica);
            this.Controls.Add(this.lblPortugues);
            this.Controls.Add(this.gridPortugues);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioReportAluno";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPortugues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatematica)).EndInit();
            this.pnlLegenda.ResumeLayout(false);
            this.pnlLegenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtreino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridpsico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox comboAluno;
        private MetroFramework.Controls.MetroLabel lblAlunoTx;
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
        private System.Windows.Forms.Panel pnlLegenda;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnPDFMt;
        private MetroFramework.Controls.MetroButton btnPDF;
        private MetroFramework.Controls.MetroButton btnEspecialista;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.DataGridView gridtreino;
        private System.Windows.Forms.DataGridView gridpsico;
        private MetroFramework.Controls.MetroButton btnEspecRel;
        private MetroFramework.Controls.MetroButton btnTdsAlunosEscola;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.TextBox txtDtAplic;
    }
}