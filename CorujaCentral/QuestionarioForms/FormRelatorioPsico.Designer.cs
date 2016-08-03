namespace QuestionarioForms
{
    partial class FormRelatorioPsico
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
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.comboAluno = new MetroFramework.Controls.MetroComboBox();
            this.lblAlunoTx = new MetroFramework.Controls.MetroLabel();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewPsico = new System.Windows.Forms.DataGridView();
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPsico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPDF);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.comboAluno);
            this.panel1.Controls.Add(this.lblAlunoTx);
            this.panel1.Controls.Add(this.comboQuestionario);
            this.panel1.Controls.Add(this.lblQuestionario);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Controls.Add(this.comboTurma);
            this.panel1.Controls.Add(this.lblTurma);
            this.panel1.Controls.Add(this.comboEscola);
            this.panel1.Controls.Add(this.lblEscola);
            this.panel1.Location = new System.Drawing.Point(23, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCSV.Enabled = false;
            this.btnCSV.Location = new System.Drawing.Point(1101, 3);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(39, 37);
            this.btnCSV.TabIndex = 30;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseCustomBackColor = true;
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // comboAluno
            // 
            this.comboAluno.Enabled = false;
            this.comboAluno.FormattingEnabled = true;
            this.comboAluno.ItemHeight = 23;
            this.comboAluno.Location = new System.Drawing.Point(501, 7);
            this.comboAluno.Name = "comboAluno";
            this.comboAluno.Size = new System.Drawing.Size(198, 29);
            this.comboAluno.TabIndex = 25;
            this.comboAluno.UseSelectable = true;
            this.comboAluno.SelectedIndexChanged += new System.EventHandler(this.comboAluno_SelectedIndexChanged);
            // 
            // lblAlunoTx
            // 
            this.lblAlunoTx.AutoSize = true;
            this.lblAlunoTx.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAlunoTx.Location = new System.Drawing.Point(451, 15);
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
            this.comboQuestionario.Location = new System.Drawing.Point(807, 7);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(195, 29);
            this.comboQuestionario.TabIndex = 23;
            this.comboQuestionario.UseSelectable = true;
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(705, 15);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 22;
            this.lblQuestionario.Text = "Questionário";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(1006, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(92, 37);
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
            this.comboTurma.Location = new System.Drawing.Point(250, 7);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(193, 29);
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
            this.comboEscola.Size = new System.Drawing.Size(133, 29);
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
            // dataGridViewPsico
            // 
            this.dataGridViewPsico.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewPsico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPsico.Location = new System.Drawing.Point(251, 123);
            this.dataGridViewPsico.Name = "dataGridViewPsico";
            this.dataGridViewPsico.Size = new System.Drawing.Size(702, 309);
            this.dataGridViewPsico.TabIndex = 8;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(1145, 3);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(33, 37);
            this.btnPDF.TabIndex = 31;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // FormRelatorioPsico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 438);
            this.Controls.Add(this.dataGridViewPsico);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioPsico";
            this.Text = "Relatório da Psicogêse da Língua Escrita";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPsico)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dataGridViewPsico;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroButton btnPDF;
    }
}