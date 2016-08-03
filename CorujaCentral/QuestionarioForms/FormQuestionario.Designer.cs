namespace QuestionarioForms
{
    partial class FormQuestionario
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnExcluirVideo = new MetroFramework.Controls.MetroButton();
            this.lblVideoCadastrado = new MetroFramework.Controls.MetroLabel();
            this.btnVideoIntro = new MetroFramework.Controls.MetroButton();
            this.lblVideo = new MetroFramework.Controls.MetroLabel();
            this.btnNovo = new MetroFramework.Controls.MetroButton();
            this.pnlCor = new MetroFramework.Controls.MetroPanel();
            this.btnLimpar = new MetroFramework.Controls.MetroButton();
            this.ddlNivel = new MetroFramework.Controls.MetroComboBox();
            this.lblNivel = new MetroFramework.Controls.MetroLabel();
            this.btnSalvar = new MetroFramework.Controls.MetroButton();
            this.ckRepetePergunta = new MetroFramework.Controls.MetroCheckBox();
            this.lblCor = new MetroFramework.Controls.MetroLabel();
            this.txtDesc = new MetroFramework.Controls.MetroTextBox();
            this.lblDesc = new MetroFramework.Controls.MetroLabel();
            this.txtNome = new MetroFramework.Controls.MetroTextBox();
            this.lblNome = new MetroFramework.Controls.MetroLabel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pnlQuestionarios = new MetroFramework.Controls.MetroPanel();
            this.painelBotoesQuestionario = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVideoFechamento = new MetroFramework.Controls.MetroButton();
            this.lblVideoFechamento = new MetroFramework.Controls.MetroLabel();
            this.lblVideoEncCadastrado = new MetroFramework.Controls.MetroLabel();
            this.btnExcluirVideoEncerramento = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.pnlQuestionarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.btnExcluirVideoEncerramento);
            this.metroPanel1.Controls.Add(this.lblVideoEncCadastrado);
            this.metroPanel1.Controls.Add(this.btnVideoFechamento);
            this.metroPanel1.Controls.Add(this.lblVideoFechamento);
            this.metroPanel1.Controls.Add(this.btnExcluirVideo);
            this.metroPanel1.Controls.Add(this.lblVideoCadastrado);
            this.metroPanel1.Controls.Add(this.btnVideoIntro);
            this.metroPanel1.Controls.Add(this.lblVideo);
            this.metroPanel1.Controls.Add(this.btnNovo);
            this.metroPanel1.Controls.Add(this.pnlCor);
            this.metroPanel1.Controls.Add(this.btnLimpar);
            this.metroPanel1.Controls.Add(this.ddlNivel);
            this.metroPanel1.Controls.Add(this.lblNivel);
            this.metroPanel1.Controls.Add(this.btnSalvar);
            this.metroPanel1.Controls.Add(this.lblCor);
            this.metroPanel1.Controls.Add(this.txtDesc);
            this.metroPanel1.Controls.Add(this.lblDesc);
            this.metroPanel1.Controls.Add(this.txtNome);
            this.metroPanel1.Controls.Add(this.lblNome);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(344, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(564, 397);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnExcluirVideo
            // 
            this.btnExcluirVideo.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluirVideo.Enabled = false;
            this.btnExcluirVideo.Location = new System.Drawing.Point(403, 273);
            this.btnExcluirVideo.Name = "btnExcluirVideo";
            this.btnExcluirVideo.Size = new System.Drawing.Size(156, 23);
            this.btnExcluirVideo.TabIndex = 20;
            this.btnExcluirVideo.Text = "Excluir Vídeo Introdução";
            this.btnExcluirVideo.UseCustomBackColor = true;
            this.btnExcluirVideo.UseSelectable = true;
            this.btnExcluirVideo.Click += new System.EventHandler(this.btnExcluirVideo_Click);
            // 
            // lblVideoCadastrado
            // 
            this.lblVideoCadastrado.AutoSize = true;
            this.lblVideoCadastrado.Location = new System.Drawing.Point(258, 313);
            this.lblVideoCadastrado.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblVideoCadastrado.Name = "lblVideoCadastrado";
            this.lblVideoCadastrado.Size = new System.Drawing.Size(0, 0);
            this.lblVideoCadastrado.TabIndex = 19;
            // 
            // btnVideoIntro
            // 
            this.btnVideoIntro.BackColor = System.Drawing.Color.Salmon;
            this.btnVideoIntro.Location = new System.Drawing.Point(177, 309);
            this.btnVideoIntro.Name = "btnVideoIntro";
            this.btnVideoIntro.Size = new System.Drawing.Size(75, 23);
            this.btnVideoIntro.TabIndex = 18;
            this.btnVideoIntro.Text = "Vídeo Int.";
            this.btnVideoIntro.UseCustomBackColor = true;
            this.btnVideoIntro.UseSelectable = true;
            this.btnVideoIntro.Click += new System.EventHandler(this.btnVideoIntro_Click);
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblVideo.Location = new System.Drawing.Point(10, 309);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(146, 19);
            this.lblVideo.TabIndex = 17;
            this.lblVideo.Text = "Vídeo de Introdução";
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.Yellow;
            this.btnNovo.Location = new System.Drawing.Point(12, 25);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseCustomBackColor = true;
            this.btnNovo.UseCustomForeColor = true;
            this.btnNovo.UseSelectable = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pnlCor
            // 
            this.pnlCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCor.HorizontalScrollbarBarColor = true;
            this.pnlCor.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCor.HorizontalScrollbarSize = 10;
            this.pnlCor.Location = new System.Drawing.Point(81, 273);
            this.pnlCor.Name = "pnlCor";
            this.pnlCor.Size = new System.Drawing.Size(57, 22);
            this.pnlCor.TabIndex = 16;
            this.pnlCor.UseCustomBackColor = true;
            this.pnlCor.VerticalScrollbarBarColor = true;
            this.pnlCor.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCor.VerticalScrollbarSize = 10;
            this.pnlCor.Click += new System.EventHandler(this.pnlCor_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Crimson;
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(430, 25);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(116, 23);
            this.btnLimpar.TabIndex = 15;
            this.btnLimpar.Text = "Excluir Questionário";
            this.btnLimpar.UseCustomBackColor = true;
            this.btnLimpar.UseSelectable = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // ddlNivel
            // 
            this.ddlNivel.FormattingEnabled = true;
            this.ddlNivel.ItemHeight = 23;
            this.ddlNivel.Location = new System.Drawing.Point(81, 226);
            this.ddlNivel.Name = "ddlNivel";
            this.ddlNivel.Size = new System.Drawing.Size(187, 29);
            this.ddlNivel.TabIndex = 14;
            this.ddlNivel.UseSelectable = true;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNivel.Location = new System.Drawing.Point(12, 226);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(36, 19);
            this.lblNivel.TabIndex = 11;
            this.lblNivel.Text = "Ano";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalvar.Location = new System.Drawing.Point(421, 369);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(138, 23);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar Questionário";
            this.btnSalvar.UseCustomBackColor = true;
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // ckRepetePergunta
            // 
            this.ckRepetePergunta.AutoSize = true;
            this.ckRepetePergunta.Checked = true;
            this.ckRepetePergunta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckRepetePergunta.Location = new System.Drawing.Point(340, 478);
            this.ckRepetePergunta.Name = "ckRepetePergunta";
            this.ckRepetePergunta.Size = new System.Drawing.Size(161, 15);
            this.ckRepetePergunta.TabIndex = 9;
            this.ckRepetePergunta.Text = "Permite repetir a pergunta";
            this.ckRepetePergunta.UseSelectable = true;
            this.ckRepetePergunta.Visible = false;
            // 
            // lblCor
            // 
            this.lblCor.AutoSize = true;
            this.lblCor.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCor.Location = new System.Drawing.Point(12, 273);
            this.lblCor.Name = "lblCor";
            this.lblCor.Size = new System.Drawing.Size(33, 19);
            this.lblCor.TabIndex = 6;
            this.lblCor.Text = "Cor";
            // 
            // txtDesc
            // 
            this.txtDesc.Lines = new string[0];
            this.txtDesc.Location = new System.Drawing.Point(82, 116);
            this.txtDesc.MaxLength = 450;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.PasswordChar = '\0';
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDesc.SelectedText = "";
            this.txtDesc.Size = new System.Drawing.Size(465, 88);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.UseSelectable = true;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDesc.Location = new System.Drawing.Point(10, 116);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(74, 19);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Lines = new string[0];
            this.txtNome.Location = new System.Drawing.Point(81, 74);
            this.txtNome.MaxLength = 250;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNome.SelectedText = "";
            this.txtNome.Size = new System.Drawing.Size(465, 23);
            this.txtNome.TabIndex = 3;
            this.txtNome.UseSelectable = true;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNome.Location = new System.Drawing.Point(10, 78);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // pnlQuestionarios
            // 
            this.pnlQuestionarios.AutoScroll = true;
            this.pnlQuestionarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuestionarios.Controls.Add(this.painelBotoesQuestionario);
            this.pnlQuestionarios.HorizontalScrollbar = true;
            this.pnlQuestionarios.HorizontalScrollbarBarColor = true;
            this.pnlQuestionarios.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlQuestionarios.HorizontalScrollbarSize = 10;
            this.pnlQuestionarios.Location = new System.Drawing.Point(24, 63);
            this.pnlQuestionarios.Name = "pnlQuestionarios";
            this.pnlQuestionarios.Size = new System.Drawing.Size(263, 429);
            this.pnlQuestionarios.TabIndex = 0;
            this.pnlQuestionarios.VerticalScrollbar = true;
            this.pnlQuestionarios.VerticalScrollbarBarColor = true;
            this.pnlQuestionarios.VerticalScrollbarHighlightOnWheel = false;
            this.pnlQuestionarios.VerticalScrollbarSize = 10;
            // 
            // painelBotoesQuestionario
            // 
            this.painelBotoesQuestionario.AutoSize = true;
            this.painelBotoesQuestionario.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.painelBotoesQuestionario.Location = new System.Drawing.Point(4, 4);
            this.painelBotoesQuestionario.Name = "painelBotoesQuestionario";
            this.painelBotoesQuestionario.Size = new System.Drawing.Size(234, 420);
            this.painelBotoesQuestionario.TabIndex = 2;
            // 
            // btnVideoFechamento
            // 
            this.btnVideoFechamento.BackColor = System.Drawing.Color.Salmon;
            this.btnVideoFechamento.Location = new System.Drawing.Point(179, 352);
            this.btnVideoFechamento.Name = "btnVideoFechamento";
            this.btnVideoFechamento.Size = new System.Drawing.Size(75, 23);
            this.btnVideoFechamento.TabIndex = 22;
            this.btnVideoFechamento.Text = "Vídeo Fec.";
            this.btnVideoFechamento.UseCustomBackColor = true;
            this.btnVideoFechamento.UseSelectable = true;
            this.btnVideoFechamento.Click += new System.EventHandler(this.btnVideoFechamento_Click);
            // 
            // lblVideoFechamento
            // 
            this.lblVideoFechamento.AutoSize = true;
            this.lblVideoFechamento.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblVideoFechamento.Location = new System.Drawing.Point(12, 352);
            this.lblVideoFechamento.Name = "lblVideoFechamento";
            this.lblVideoFechamento.Size = new System.Drawing.Size(154, 19);
            this.lblVideoFechamento.TabIndex = 21;
            this.lblVideoFechamento.Text = "Vídeo de Fechamento";
            // 
            // lblVideoEncCadastrado
            // 
            this.lblVideoEncCadastrado.AutoSize = true;
            this.lblVideoEncCadastrado.Location = new System.Drawing.Point(258, 352);
            this.lblVideoEncCadastrado.Name = "lblVideoEncCadastrado";
            this.lblVideoEncCadastrado.Size = new System.Drawing.Size(0, 0);
            this.lblVideoEncCadastrado.TabIndex = 23;
            // 
            // btnExcluirVideoEncerramento
            // 
            this.btnExcluirVideoEncerramento.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluirVideoEncerramento.Enabled = false;
            this.btnExcluirVideoEncerramento.Location = new System.Drawing.Point(403, 309);
            this.btnExcluirVideoEncerramento.Name = "btnExcluirVideoEncerramento";
            this.btnExcluirVideoEncerramento.Size = new System.Drawing.Size(156, 23);
            this.btnExcluirVideoEncerramento.TabIndex = 24;
            this.btnExcluirVideoEncerramento.Text = "Excluir Vídeo Encerramento";
            this.btnExcluirVideoEncerramento.UseCustomBackColor = true;
            this.btnExcluirVideoEncerramento.UseSelectable = true;
            this.btnExcluirVideoEncerramento.Click += new System.EventHandler(this.btnExcluirVideoEncerramento_Click);
            // 
            // FormQuestionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.ControlBox = false;
            this.Controls.Add(this.pnlQuestionarios);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.ckRepetePergunta);
            this.Name = "FormQuestionario";
            this.Text = "Gerenciar Questionários";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.pnlQuestionarios.ResumeLayout(false);
            this.pnlQuestionarios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnSalvar;
        private MetroFramework.Controls.MetroCheckBox ckRepetePergunta;
        private MetroFramework.Controls.MetroLabel lblCor;
        private MetroFramework.Controls.MetroTextBox txtDesc;
        private MetroFramework.Controls.MetroLabel lblDesc;
        private MetroFramework.Controls.MetroTextBox txtNome;
        private MetroFramework.Controls.MetroLabel lblNome;
        private System.Windows.Forms.ColorDialog colorDialog;
        private MetroFramework.Controls.MetroComboBox ddlNivel;
        private MetroFramework.Controls.MetroLabel lblNivel;
        private MetroFramework.Controls.MetroButton btnLimpar;
        private MetroFramework.Controls.MetroPanel pnlCor;
        private MetroFramework.Controls.MetroPanel pnlQuestionarios;
        private System.Windows.Forms.FlowLayoutPanel painelBotoesQuestionario;
        private MetroFramework.Controls.MetroButton btnNovo;
        private MetroFramework.Controls.MetroButton btnVideoIntro;
        private MetroFramework.Controls.MetroLabel lblVideo;
        private MetroFramework.Controls.MetroButton btnExcluirVideo;
        private MetroFramework.Controls.MetroLabel lblVideoCadastrado;
        private MetroFramework.Controls.MetroButton btnVideoFechamento;
        private MetroFramework.Controls.MetroLabel lblVideoFechamento;
        private MetroFramework.Controls.MetroLabel lblVideoEncCadastrado;
        private MetroFramework.Controls.MetroButton btnExcluirVideoEncerramento;

    }
}