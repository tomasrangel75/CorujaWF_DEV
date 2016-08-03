namespace QuestionarioForms
{
    partial class FormExportar
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
            this.pnlPrincipal = new MetroFramework.Controls.MetroPanel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.progress = new MetroFramework.Controls.MetroProgressBar();
            this.btnExportar = new MetroFramework.Controls.MetroButton();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ckTurmas = new System.Windows.Forms.CheckedListBox();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.ckTurmas);
            this.pnlPrincipal.Controls.Add(this.comboEscola);
            this.pnlPrincipal.Controls.Add(this.lblEscola);
            this.pnlPrincipal.Controls.Add(this.lblTurma);
            this.pnlPrincipal.Controls.Add(this.progress);
            this.pnlPrincipal.Controls.Add(this.btnExportar);
            this.pnlPrincipal.Controls.Add(this.comboQuestionario);
            this.pnlPrincipal.Controls.Add(this.lblQuestionario);
            this.pnlPrincipal.HorizontalScrollbarBarColor = true;
            this.pnlPrincipal.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.HorizontalScrollbarSize = 10;
            this.pnlPrincipal.Location = new System.Drawing.Point(186, 86);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(858, 272);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.VerticalScrollbarBarColor = true;
            this.pnlPrincipal.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.VerticalScrollbarSize = 10;
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(136, 83);
            this.comboEscola.Name = "comboEscola";
            this.comboEscola.Size = new System.Drawing.Size(355, 29);
            this.comboEscola.TabIndex = 9;
            this.comboEscola.UseSelectable = true;
            this.comboEscola.SelectedIndexChanged += new System.EventHandler(this.comboEscola_SelectedIndexChanged);
            // 
            // lblEscola
            // 
            this.lblEscola.AutoSize = true;
            this.lblEscola.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEscola.Location = new System.Drawing.Point(20, 86);
            this.lblEscola.Name = "lblEscola";
            this.lblEscola.Size = new System.Drawing.Size(50, 19);
            this.lblEscola.TabIndex = 8;
            this.lblEscola.Text = "Escola";
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(538, 0);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(57, 19);
            this.lblTurma.TabIndex = 6;
            this.lblTurma.Text = "Turmas";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(37, 226);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(603, 23);
            this.progress.TabIndex = 5;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(706, 213);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(127, 36);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseCustomBackColor = true;
            this.btnExportar.UseSelectable = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(136, 30);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(355, 29);
            this.comboQuestionario.TabIndex = 3;
            this.comboQuestionario.UseSelectable = true;
            this.comboQuestionario.SelectedIndexChanged += new System.EventHandler(this.comboQuestionario_SelectedIndexChanged);
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(20, 33);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 2;
            this.lblQuestionario.Text = "Questionário";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ckTurmas
            // 
            this.ckTurmas.Enabled = false;
            this.ckTurmas.FormattingEnabled = true;
            this.ckTurmas.Location = new System.Drawing.Point(538, 22);
            this.ckTurmas.Name = "ckTurmas";
            this.ckTurmas.Size = new System.Drawing.Size(210, 184);
            this.ckTurmas.TabIndex = 10;
            // 
            // FormExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "FormExportar";
            this.Text = "Exportar Questionário";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlPrincipal;
        private MetroFramework.Controls.MetroComboBox comboQuestionario;
        private MetroFramework.Controls.MetroLabel lblQuestionario;
        private MetroFramework.Controls.MetroButton btnExportar;
        private MetroFramework.Controls.MetroProgressBar progress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroComboBox comboEscola;
        private MetroFramework.Controls.MetroLabel lblEscola;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private System.Windows.Forms.CheckedListBox ckTurmas;
    }
}