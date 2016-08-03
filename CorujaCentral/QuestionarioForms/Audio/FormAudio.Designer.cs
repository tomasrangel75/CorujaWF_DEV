namespace QuestionarioForms.Audio
{
    partial class FormAudio
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
            this.btnGravar = new MetroFramework.Controls.MetroTile();
            this.btnSalvar = new MetroFramework.Controls.MetroTile();
            this.btnTocar = new MetroFramework.Controls.MetroTile();
            this.lblGravando = new MetroFramework.Controls.MetroLabel();
            this.pnlAudioExistente = new MetroFramework.Controls.MetroPanel();
            this.btnEnvioAudio = new MetroFramework.Controls.MetroButton();
            this.lblopcao1 = new MetroFramework.Controls.MetroLabel();
            this.lblGravacao = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnOk = new MetroFramework.Controls.MetroButton();
            this.pnlAudioExistente.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.ActiveControl = null;
            this.btnGravar.Location = new System.Drawing.Point(3, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(97, 63);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseSelectable = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.ActiveControl = null;
            this.btnSalvar.Location = new System.Drawing.Point(128, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 63);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Parar e Salvar";
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnTocar
            // 
            this.btnTocar.ActiveControl = null;
            this.btnTocar.Location = new System.Drawing.Point(260, 3);
            this.btnTocar.Name = "btnTocar";
            this.btnTocar.Size = new System.Drawing.Size(92, 63);
            this.btnTocar.TabIndex = 2;
            this.btnTocar.Text = "Play";
            this.btnTocar.UseSelectable = true;
            this.btnTocar.Click += new System.EventHandler(this.btnTocar_Click);
            // 
            // lblGravando
            // 
            this.lblGravando.AutoSize = true;
            this.lblGravando.BackColor = System.Drawing.Color.Red;
            this.lblGravando.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblGravando.ForeColor = System.Drawing.Color.Red;
            this.lblGravando.Location = new System.Drawing.Point(3, 75);
            this.lblGravando.Name = "lblGravando";
            this.lblGravando.Size = new System.Drawing.Size(87, 19);
            this.lblGravando.TabIndex = 3;
            this.lblGravando.Text = "Gravando...";
            this.lblGravando.UseCustomForeColor = true;
            // 
            // pnlAudioExistente
            // 
            this.pnlAudioExistente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAudioExistente.Controls.Add(this.btnEnvioAudio);
            this.pnlAudioExistente.HorizontalScrollbarBarColor = true;
            this.pnlAudioExistente.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlAudioExistente.HorizontalScrollbarSize = 10;
            this.pnlAudioExistente.Location = new System.Drawing.Point(54, 80);
            this.pnlAudioExistente.Name = "pnlAudioExistente";
            this.pnlAudioExistente.Size = new System.Drawing.Size(362, 46);
            this.pnlAudioExistente.TabIndex = 4;
            this.pnlAudioExistente.VerticalScrollbarBarColor = true;
            this.pnlAudioExistente.VerticalScrollbarHighlightOnWheel = false;
            this.pnlAudioExistente.VerticalScrollbarSize = 10;
            // 
            // btnEnvioAudio
            // 
            this.btnEnvioAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEnvioAudio.Location = new System.Drawing.Point(117, 18);
            this.btnEnvioAudio.Name = "btnEnvioAudio";
            this.btnEnvioAudio.Size = new System.Drawing.Size(127, 23);
            this.btnEnvioAudio.TabIndex = 5;
            this.btnEnvioAudio.Text = "Enviar Áudio";
            this.btnEnvioAudio.UseCustomBackColor = true;
            this.btnEnvioAudio.UseSelectable = true;
            this.btnEnvioAudio.Click += new System.EventHandler(this.btnEnvioAudio_Click);
            // 
            // lblopcao1
            // 
            this.lblopcao1.AutoSize = true;
            this.lblopcao1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblopcao1.Location = new System.Drawing.Point(54, 60);
            this.lblopcao1.Name = "lblopcao1";
            this.lblopcao1.Size = new System.Drawing.Size(160, 19);
            this.lblopcao1.TabIndex = 5;
            this.lblopcao1.Text = "Áudio do Computador";
            // 
            // lblGravacao
            // 
            this.lblGravacao.AutoSize = true;
            this.lblGravacao.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblGravacao.Location = new System.Drawing.Point(54, 160);
            this.lblGravacao.Name = "lblGravacao";
            this.lblGravacao.Size = new System.Drawing.Size(166, 19);
            this.lblGravacao.TabIndex = 7;
            this.lblGravacao.Text = "Gravar um áudio agora";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.lblGravando);
            this.metroPanel1.Controls.Add(this.btnGravar);
            this.metroPanel1.Controls.Add(this.btnTocar);
            this.metroPanel1.Controls.Add(this.btnSalvar);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(54, 180);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(362, 99);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Lime;
            this.btnOk.Location = new System.Drawing.Point(445, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 46);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseCustomBackColor = true;
            this.btnOk.UseSelectable = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 295);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblGravacao);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblopcao1);
            this.Controls.Add(this.pnlAudioExistente);
            this.Name = "FormAudio";
            this.Text = "Envio de Áudio";
            this.pnlAudioExistente.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnGravar;
        private MetroFramework.Controls.MetroTile btnSalvar;
        private MetroFramework.Controls.MetroTile btnTocar;
        private MetroFramework.Controls.MetroLabel lblGravando;
        private MetroFramework.Controls.MetroPanel pnlAudioExistente;
        private MetroFramework.Controls.MetroLabel lblopcao1;
        private MetroFramework.Controls.MetroButton btnEnvioAudio;
        private MetroFramework.Controls.MetroLabel lblGravacao;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnOk;
    }
}