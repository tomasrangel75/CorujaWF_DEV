namespace QuestionarioForms
{
    partial class FormRelatorioAluno
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
            this.comboQuestionario = new MetroFramework.Controls.MetroComboBox();
            this.lblQuestionario = new MetroFramework.Controls.MetroLabel();
            this.pnlResultado = new MetroFramework.Controls.MetroPanel();
            this.btnExportarTurma = new MetroFramework.Controls.MetroButton();
            this.btnExportarCsv = new MetroFramework.Controls.MetroButton();
            this.pnlGrid = new MetroFramework.Controls.MetroPanel();
            this.gridPontuacao = new System.Windows.Forms.DataGridView();
            this.lblFinalizadoTxt = new MetroFramework.Controls.MetroLabel();
            this.lblFinalizado = new MetroFramework.Controls.MetroLabel();
            this.txtErros = new MetroFramework.Controls.MetroTextBox();
            this.lblErros = new MetroFramework.Controls.MetroLabel();
            this.txtAcertos = new MetroFramework.Controls.MetroTextBox();
            this.lblAcertos = new MetroFramework.Controls.MetroLabel();
            this.txtCaminho = new MetroFramework.Controls.MetroTextBox();
            this.lblOrdemResposta = new MetroFramework.Controls.MetroLabel();
            this.lblQuestionarioNomeTxt = new MetroFramework.Controls.MetroLabel();
            this.lblQuestionL = new MetroFramework.Controls.MetroLabel();
            this.lblNomeAlunoTxt = new MetroFramework.Controls.MetroLabel();
            this.lblNomeAluno = new MetroFramework.Controls.MetroLabel();
            this.comboAluno = new MetroFramework.Controls.MetroComboBox();
            this.lblAluno = new MetroFramework.Controls.MetroLabel();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.pnlPrincipal.SuspendLayout();
            this.pnlResultado.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPontuacao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.comboQuestionario);
            this.pnlPrincipal.Controls.Add(this.lblQuestionario);
            this.pnlPrincipal.Controls.Add(this.pnlResultado);
            this.pnlPrincipal.Controls.Add(this.comboAluno);
            this.pnlPrincipal.Controls.Add(this.lblAluno);
            this.pnlPrincipal.Controls.Add(this.comboTurma);
            this.pnlPrincipal.Controls.Add(this.lblTurma);
            this.pnlPrincipal.HorizontalScrollbarBarColor = true;
            this.pnlPrincipal.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.HorizontalScrollbarSize = 10;
            this.pnlPrincipal.Location = new System.Drawing.Point(23, 63);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1180, 418);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.VerticalScrollbarBarColor = true;
            this.pnlPrincipal.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.VerticalScrollbarSize = 10;
            // 
            // comboQuestionario
            // 
            this.comboQuestionario.FormattingEnabled = true;
            this.comboQuestionario.ItemHeight = 23;
            this.comboQuestionario.Location = new System.Drawing.Point(860, 5);
            this.comboQuestionario.Name = "comboQuestionario";
            this.comboQuestionario.Size = new System.Drawing.Size(304, 29);
            this.comboQuestionario.TabIndex = 8;
            this.comboQuestionario.UseSelectable = true;
            this.comboQuestionario.SelectedIndexChanged += new System.EventHandler(this.comboQuestionario_SelectedIndexChanged);
            // 
            // lblQuestionario
            // 
            this.lblQuestionario.AutoSize = true;
            this.lblQuestionario.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionario.Location = new System.Drawing.Point(759, 11);
            this.lblQuestionario.Name = "lblQuestionario";
            this.lblQuestionario.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionario.TabIndex = 7;
            this.lblQuestionario.Text = "Questionário";
            // 
            // pnlResultado
            // 
            this.pnlResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResultado.Controls.Add(this.btnExportarTurma);
            this.pnlResultado.Controls.Add(this.btnExportarCsv);
            this.pnlResultado.Controls.Add(this.pnlGrid);
            this.pnlResultado.Controls.Add(this.lblFinalizadoTxt);
            this.pnlResultado.Controls.Add(this.lblFinalizado);
            this.pnlResultado.Controls.Add(this.txtErros);
            this.pnlResultado.Controls.Add(this.lblErros);
            this.pnlResultado.Controls.Add(this.txtAcertos);
            this.pnlResultado.Controls.Add(this.lblAcertos);
            this.pnlResultado.Controls.Add(this.txtCaminho);
            this.pnlResultado.Controls.Add(this.lblOrdemResposta);
            this.pnlResultado.Controls.Add(this.lblQuestionarioNomeTxt);
            this.pnlResultado.Controls.Add(this.lblQuestionL);
            this.pnlResultado.Controls.Add(this.lblNomeAlunoTxt);
            this.pnlResultado.Controls.Add(this.lblNomeAluno);
            this.pnlResultado.HorizontalScrollbarBarColor = true;
            this.pnlResultado.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlResultado.HorizontalScrollbarSize = 10;
            this.pnlResultado.Location = new System.Drawing.Point(12, 50);
            this.pnlResultado.Name = "pnlResultado";
            this.pnlResultado.Size = new System.Drawing.Size(1154, 363);
            this.pnlResultado.TabIndex = 6;
            this.pnlResultado.VerticalScrollbarBarColor = true;
            this.pnlResultado.VerticalScrollbarHighlightOnWheel = false;
            this.pnlResultado.VerticalScrollbarSize = 10;
            // 
            // btnExportarTurma
            // 
            this.btnExportarTurma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportarTurma.Enabled = false;
            this.btnExportarTurma.Location = new System.Drawing.Point(15, 334);
            this.btnExportarTurma.Name = "btnExportarTurma";
            this.btnExportarTurma.Size = new System.Drawing.Size(308, 23);
            this.btnExportarTurma.TabIndex = 21;
            this.btnExportarTurma.Text = "Exportar CSV TURMA";
            this.btnExportarTurma.UseCustomBackColor = true;
            this.btnExportarTurma.UseSelectable = true;
            this.btnExportarTurma.Click += new System.EventHandler(this.btnExportarTurma_Click);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportarCsv.Enabled = false;
            this.btnExportarCsv.Location = new System.Drawing.Point(15, 305);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(308, 23);
            this.btnExportarCsv.TabIndex = 20;
            this.btnExportarCsv.Text = "Exportar CSV";
            this.btnExportarCsv.UseCustomBackColor = true;
            this.btnExportarCsv.UseSelectable = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.gridPontuacao);
            this.pnlGrid.HorizontalScrollbarBarColor = true;
            this.pnlGrid.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlGrid.HorizontalScrollbarSize = 10;
            this.pnlGrid.Location = new System.Drawing.Point(462, 3);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(682, 359);
            this.pnlGrid.TabIndex = 19;
            this.pnlGrid.VerticalScrollbarBarColor = true;
            this.pnlGrid.VerticalScrollbarHighlightOnWheel = false;
            this.pnlGrid.VerticalScrollbarSize = 10;
            // 
            // gridPontuacao
            // 
            this.gridPontuacao.AllowUserToAddRows = false;
            this.gridPontuacao.AllowUserToDeleteRows = false;
            this.gridPontuacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPontuacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPontuacao.GridColor = System.Drawing.Color.White;
            this.gridPontuacao.Location = new System.Drawing.Point(3, 3);
            this.gridPontuacao.Name = "gridPontuacao";
            this.gridPontuacao.ReadOnly = true;
            this.gridPontuacao.Size = new System.Drawing.Size(674, 351);
            this.gridPontuacao.TabIndex = 3;
            // 
            // lblFinalizadoTxt
            // 
            this.lblFinalizadoTxt.AutoSize = true;
            this.lblFinalizadoTxt.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblFinalizadoTxt.ForeColor = System.Drawing.Color.Crimson;
            this.lblFinalizadoTxt.Location = new System.Drawing.Point(120, 204);
            this.lblFinalizadoTxt.Name = "lblFinalizadoTxt";
            this.lblFinalizadoTxt.Size = new System.Drawing.Size(77, 19);
            this.lblFinalizadoTxt.TabIndex = 18;
            this.lblFinalizadoTxt.Text = "Finalizado";
            this.lblFinalizadoTxt.UseCustomForeColor = true;
            // 
            // lblFinalizado
            // 
            this.lblFinalizado.AutoSize = true;
            this.lblFinalizado.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblFinalizado.Location = new System.Drawing.Point(3, 204);
            this.lblFinalizado.Name = "lblFinalizado";
            this.lblFinalizado.Size = new System.Drawing.Size(77, 19);
            this.lblFinalizado.TabIndex = 17;
            this.lblFinalizado.Text = "Finalizado";
            // 
            // txtErros
            // 
            this.txtErros.Lines = new string[0];
            this.txtErros.Location = new System.Drawing.Point(121, 169);
            this.txtErros.MaxLength = 32767;
            this.txtErros.Name = "txtErros";
            this.txtErros.PasswordChar = '\0';
            this.txtErros.ReadOnly = true;
            this.txtErros.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtErros.SelectedText = "";
            this.txtErros.Size = new System.Drawing.Size(95, 23);
            this.txtErros.TabIndex = 16;
            this.txtErros.UseSelectable = true;
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblErros.Location = new System.Drawing.Point(3, 169);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(43, 19);
            this.lblErros.TabIndex = 15;
            this.lblErros.Text = "Erros";
            // 
            // txtAcertos
            // 
            this.txtAcertos.Lines = new string[0];
            this.txtAcertos.Location = new System.Drawing.Point(121, 133);
            this.txtAcertos.MaxLength = 32767;
            this.txtAcertos.Name = "txtAcertos";
            this.txtAcertos.PasswordChar = '\0';
            this.txtAcertos.ReadOnly = true;
            this.txtAcertos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAcertos.SelectedText = "";
            this.txtAcertos.Size = new System.Drawing.Size(95, 23);
            this.txtAcertos.TabIndex = 14;
            this.txtAcertos.UseSelectable = true;
            // 
            // lblAcertos
            // 
            this.lblAcertos.AutoSize = true;
            this.lblAcertos.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAcertos.Location = new System.Drawing.Point(3, 133);
            this.lblAcertos.Name = "lblAcertos";
            this.lblAcertos.Size = new System.Drawing.Size(60, 19);
            this.lblAcertos.TabIndex = 13;
            this.lblAcertos.Text = "Acertos";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Lines = new string[0];
            this.txtCaminho.Location = new System.Drawing.Point(121, 97);
            this.txtCaminho.MaxLength = 32767;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.PasswordChar = '\0';
            this.txtCaminho.ReadOnly = true;
            this.txtCaminho.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCaminho.SelectedText = "";
            this.txtCaminho.Size = new System.Drawing.Size(335, 23);
            this.txtCaminho.TabIndex = 12;
            this.txtCaminho.UseSelectable = true;
            // 
            // lblOrdemResposta
            // 
            this.lblOrdemResposta.AutoSize = true;
            this.lblOrdemResposta.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblOrdemResposta.Location = new System.Drawing.Point(3, 97);
            this.lblOrdemResposta.Name = "lblOrdemResposta";
            this.lblOrdemResposta.Size = new System.Drawing.Size(112, 19);
            this.lblOrdemResposta.TabIndex = 11;
            this.lblOrdemResposta.Text = "Caminho Prova";
            // 
            // lblQuestionarioNomeTxt
            // 
            this.lblQuestionarioNomeTxt.AutoSize = true;
            this.lblQuestionarioNomeTxt.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionarioNomeTxt.Location = new System.Drawing.Point(105, 40);
            this.lblQuestionarioNomeTxt.Name = "lblQuestionarioNomeTxt";
            this.lblQuestionarioNomeTxt.Size = new System.Drawing.Size(137, 19);
            this.lblQuestionarioNomeTxt.TabIndex = 10;
            this.lblQuestionarioNomeTxt.Text = "aaaaaaaaaaaaaaaa";
            // 
            // lblQuestionL
            // 
            this.lblQuestionL.AutoSize = true;
            this.lblQuestionL.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblQuestionL.Location = new System.Drawing.Point(3, 40);
            this.lblQuestionL.Name = "lblQuestionL";
            this.lblQuestionL.Size = new System.Drawing.Size(95, 19);
            this.lblQuestionL.TabIndex = 9;
            this.lblQuestionL.Text = "Questionário";
            // 
            // lblNomeAlunoTxt
            // 
            this.lblNomeAlunoTxt.AutoSize = true;
            this.lblNomeAlunoTxt.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNomeAlunoTxt.Location = new System.Drawing.Point(70, 14);
            this.lblNomeAlunoTxt.Name = "lblNomeAlunoTxt";
            this.lblNomeAlunoTxt.Size = new System.Drawing.Size(137, 19);
            this.lblNomeAlunoTxt.TabIndex = 8;
            this.lblNomeAlunoTxt.Text = "aaaaaaaaaaaaaaaa";
            // 
            // lblNomeAluno
            // 
            this.lblNomeAluno.AutoSize = true;
            this.lblNomeAluno.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNomeAluno.Location = new System.Drawing.Point(3, 14);
            this.lblNomeAluno.Name = "lblNomeAluno";
            this.lblNomeAluno.Size = new System.Drawing.Size(50, 19);
            this.lblNomeAluno.TabIndex = 7;
            this.lblNomeAluno.Text = "Nome";
            // 
            // comboAluno
            // 
            this.comboAluno.FormattingEnabled = true;
            this.comboAluno.ItemHeight = 23;
            this.comboAluno.Location = new System.Drawing.Point(398, 6);
            this.comboAluno.Name = "comboAluno";
            this.comboAluno.Size = new System.Drawing.Size(355, 29);
            this.comboAluno.TabIndex = 5;
            this.comboAluno.UseSelectable = true;
            this.comboAluno.SelectedIndexChanged += new System.EventHandler(this.comboAluno_SelectedIndexChanged);
            // 
            // lblAluno
            // 
            this.lblAluno.AutoSize = true;
            this.lblAluno.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAluno.Location = new System.Drawing.Point(344, 16);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(48, 19);
            this.lblAluno.TabIndex = 4;
            this.lblAluno.Text = "Aluno";
            // 
            // comboTurma
            // 
            this.comboTurma.FormattingEnabled = true;
            this.comboTurma.ItemHeight = 23;
            this.comboTurma.Location = new System.Drawing.Point(60, 5);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(263, 29);
            this.comboTurma.TabIndex = 3;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(3, 11);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(51, 19);
            this.lblTurma.TabIndex = 2;
            this.lblTurma.Text = "Turma";
            // 
            // FormRelatorioAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "FormRelatorioAluno";
            this.Text = "Relatório Aluno";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlResultado.ResumeLayout(false);
            this.pnlResultado.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPontuacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlPrincipal;
        private MetroFramework.Controls.MetroComboBox comboQuestionario;
        private MetroFramework.Controls.MetroLabel lblQuestionario;
        private MetroFramework.Controls.MetroPanel pnlResultado;
        private MetroFramework.Controls.MetroPanel pnlGrid;
        private MetroFramework.Controls.MetroLabel lblFinalizadoTxt;
        private MetroFramework.Controls.MetroLabel lblFinalizado;
        private MetroFramework.Controls.MetroTextBox txtErros;
        private MetroFramework.Controls.MetroLabel lblErros;
        private MetroFramework.Controls.MetroTextBox txtAcertos;
        private MetroFramework.Controls.MetroLabel lblAcertos;
        private MetroFramework.Controls.MetroTextBox txtCaminho;
        private MetroFramework.Controls.MetroLabel lblOrdemResposta;
        private MetroFramework.Controls.MetroLabel lblQuestionarioNomeTxt;
        private MetroFramework.Controls.MetroLabel lblQuestionL;
        private MetroFramework.Controls.MetroLabel lblNomeAlunoTxt;
        private MetroFramework.Controls.MetroLabel lblNomeAluno;
        private MetroFramework.Controls.MetroComboBox comboAluno;
        private MetroFramework.Controls.MetroLabel lblAluno;
        private MetroFramework.Controls.MetroComboBox comboTurma;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private System.Windows.Forms.DataGridView gridPontuacao;
        private MetroFramework.Controls.MetroButton btnExportarCsv;
        private MetroFramework.Controls.MetroButton btnExportarTurma;
    }
}