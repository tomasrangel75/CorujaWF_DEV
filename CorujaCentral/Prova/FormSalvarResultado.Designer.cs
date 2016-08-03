namespace Prova
{
    partial class FormSalvarResultado
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
            this.lblTit = new MetroFramework.Controls.MetroLabel();
            this.txtSenha = new MetroFramework.Controls.MetroTextBox();
            this.lblSenha = new MetroFramework.Controls.MetroLabel();
            this.btnSalvar = new MetroFramework.Controls.MetroButton();
            this.lblAlunoExportado = new System.Windows.Forms.Label();
            this.lblSalvou = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.btnFechar = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.AutoSize = true;
            this.lblTit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTit.Location = new System.Drawing.Point(9, 21);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(275, 25);
            this.lblTit.TabIndex = 0;
            this.lblTit.Text = "Exportar o resultado do Aluno:";
            // 
            // txtSenha
            // 
            this.txtSenha.Lines = new string[0];
            this.txtSenha.Location = new System.Drawing.Point(63, 82);
            this.txtSenha.MaxLength = 32767;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '\0';
            this.txtSenha.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSenha.SelectedText = "";
            this.txtSenha.Size = new System.Drawing.Size(179, 23);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.UseSelectable = true;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSenha.Location = new System.Drawing.Point(12, 82);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(49, 19);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Red;
            this.btnSalvar.FontSize = MetroFramework.MetroButtonSize.Tall2;
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalvar.Location = new System.Drawing.Point(12, 112);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(113, 38);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Exportar";
            this.btnSalvar.UseCustomBackColor = true;
            this.btnSalvar.UseCustomForeColor = true;
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblAlunoExportado
            // 
            this.lblAlunoExportado.AutoSize = true;
            this.lblAlunoExportado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlunoExportado.Location = new System.Drawing.Point(12, 50);
            this.lblAlunoExportado.Name = "lblAlunoExportado";
            this.lblAlunoExportado.Size = new System.Drawing.Size(131, 17);
            this.lblAlunoExportado.TabIndex = 4;
            this.lblAlunoExportado.Text = "Aluno Exportado!";
            // 
            // lblSalvou
            // 
            this.lblSalvou.AutoSize = true;
            this.lblSalvou.Location = new System.Drawing.Point(65, 47);
            this.lblSalvou.Name = "lblSalvou";
            this.lblSalvou.Size = new System.Drawing.Size(30, 13);
            this.lblSalvou.TabIndex = 4;
            this.lblSalvou.Text = "temp";
            this.lblSalvou.Visible = false;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(208, 86);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(154, 13);
            this.lblLink.TabIndex = 5;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "http://canal.corujaedu.com.br/";
            this.lblLink.Visible = false;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Red;
            this.btnFechar.DisplayFocus = true;
            this.btnFechar.FontSize = MetroFramework.MetroButtonSize.Tall2;
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFechar.Location = new System.Drawing.Point(424, 112);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(113, 38);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseCustomBackColor = true;
            this.btnFechar.UseCustomForeColor = true;
            this.btnFechar.UseSelectable = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormSalvarResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 173);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblSalvou);
            this.Controls.Add(this.lblAlunoExportado);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblTit);
            this.Name = "FormSalvarResultado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTit;
        private MetroFramework.Controls.MetroTextBox txtSenha;
        private MetroFramework.Controls.MetroLabel lblSenha;
        private MetroFramework.Controls.MetroButton btnSalvar;
        private System.Windows.Forms.Label lblAlunoExportado;
        private System.Windows.Forms.Label lblSalvou;
        private System.Windows.Forms.LinkLabel lblLink;
        private MetroFramework.Controls.MetroButton btnFechar;
    }
}