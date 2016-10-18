namespace Prova
{
    partial class FormSenhaTeste
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
            this.btnSenhaOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.AutoSize = true;
            this.lblTit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTit.Location = new System.Drawing.Point(17, 21);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(301, 19);
            this.lblTit.TabIndex = 0;
            this.lblTit.Text = "Qual é a senha para ativar o menu de teste?";
            // 
            // txtSenha
            // 
            this.txtSenha.Lines = new string[0];
            this.txtSenha.Location = new System.Drawing.Point(76, 55);
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
            this.lblSenha.Location = new System.Drawing.Point(21, 55);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(49, 19);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha";
            // 
            // btnSenhaOk
            // 
            this.btnSenhaOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSenhaOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSenhaOk.Location = new System.Drawing.Point(261, 55);
            this.btnSenhaOk.Name = "btnSenhaOk";
            this.btnSenhaOk.Size = new System.Drawing.Size(40, 23);
            this.btnSenhaOk.TabIndex = 3;
            this.btnSenhaOk.Text = "Ok";
            this.btnSenhaOk.UseVisualStyleBackColor = true;
            this.btnSenhaOk.Click += new System.EventHandler(this.btnSenhaOk_Click);
            // 
            // FormSenhaTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 96);
            this.Controls.Add(this.btnSenhaOk);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblTit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSenhaTeste";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTit;
        private MetroFramework.Controls.MetroTextBox txtSenha;
        private MetroFramework.Controls.MetroLabel lblSenha;
        private System.Windows.Forms.Button btnSenhaOk;
    }
}