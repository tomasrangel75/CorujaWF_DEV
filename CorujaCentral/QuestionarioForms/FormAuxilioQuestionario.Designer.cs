namespace QuestionarioForms
{
    partial class FormAuxilioQuestionario
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
            this.lblAuxilioSaltos = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewSaltos = new System.Windows.Forms.DataGridView();
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.btnGerar = new MetroFramework.Controls.MetroButton();
            this.lblPontuacao = new MetroFramework.Controls.MetroLabel();
            this.gridGrafo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaltos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrafo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAuxilioSaltos
            // 
            this.lblAuxilioSaltos.AutoSize = true;
            this.lblAuxilioSaltos.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAuxilioSaltos.Location = new System.Drawing.Point(23, 60);
            this.lblAuxilioSaltos.Name = "lblAuxilioSaltos";
            this.lblAuxilioSaltos.Size = new System.Drawing.Size(193, 19);
            this.lblAuxilioSaltos.TabIndex = 5;
            this.lblAuxilioSaltos.Text = "Saltos (Menos Psicogenese)";
            // 
            // dataGridViewSaltos
            // 
            this.dataGridViewSaltos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewSaltos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSaltos.Location = new System.Drawing.Point(23, 82);
            this.dataGridViewSaltos.Name = "dataGridViewSaltos";
            this.dataGridViewSaltos.Size = new System.Drawing.Size(287, 375);
            this.dataGridViewSaltos.TabIndex = 6;
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(455, 19);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(259, 29);
            this.comboQuestionario.TabIndex = 25;
            this.comboQuestionario.UseSelectable = true;
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(354, 27);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 24;
            this.lblQuestionario.Text = "Questionário";
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerar.Location = new System.Drawing.Point(720, 11);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(110, 37);
            this.btnGerar.TabIndex = 26;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseCustomBackColor = true;
            this.btnGerar.UseSelectable = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // lblPontuacao
            // 
            this.lblPontuacao.AutoSize = true;
            this.lblPontuacao.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPontuacao.Location = new System.Drawing.Point(354, 108);
            this.lblPontuacao.Name = "lblPontuacao";
            this.lblPontuacao.Size = new System.Drawing.Size(206, 19);
            this.lblPontuacao.TabIndex = 27;
            this.lblPontuacao.Text = "Cálculo Pontuação da Árvore";
            // 
            // gridGrafo
            // 
            this.gridGrafo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridGrafo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrafo.Location = new System.Drawing.Point(354, 141);
            this.gridGrafo.Name = "gridGrafo";
            this.gridGrafo.Size = new System.Drawing.Size(576, 296);
            this.gridGrafo.TabIndex = 28;
            this.gridGrafo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGrafo_CellContentClick);
            // 
            // FormAuxilioQuestionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 477);
            this.Controls.Add(this.gridGrafo);
            this.Controls.Add(this.lblPontuacao);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.comboQuestionario);
            this.Controls.Add(this.lblQuestionario);
            this.Controls.Add(this.dataGridViewSaltos);
            this.Controls.Add(this.lblAuxilioSaltos);
            this.Name = "FormAuxilioQuestionario";
            this.Text = "Auxílio Cadastro Questionário";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSaltos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrafo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblAuxilioSaltos;
        private System.Windows.Forms.DataGridView dataGridViewSaltos;
        private MetroFramework.Controls.MetroComboBox comboQuestionario;
        private MetroFramework.Controls.MetroLabel lblQuestionario;
        private MetroFramework.Controls.MetroButton btnGerar;
        private MetroFramework.Controls.MetroLabel lblPontuacao;
        private System.Windows.Forms.DataGridView gridGrafo;
    }
}