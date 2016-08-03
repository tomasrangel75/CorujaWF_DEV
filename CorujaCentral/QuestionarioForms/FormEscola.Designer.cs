namespace QuestionarioForms
{
    partial class FormEscola
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
            this.pnlCadastro = new MetroFramework.Controls.MetroPanel();
            this.btnSalvar = new MetroFramework.Controls.MetroButton();
            this.txtDesc = new MetroFramework.Controls.MetroTextBox();
            this.lblDesc = new MetroFramework.Controls.MetroLabel();
            this.txtNome = new MetroFramework.Controls.MetroTextBox();
            this.lblNome = new MetroFramework.Controls.MetroLabel();
            this.lblCadastroEscola = new MetroFramework.Controls.MetroLabel();
            this.lblEdicao = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblSelecao = new MetroFramework.Controls.MetroLabel();
            this.pnlDados = new MetroFramework.Controls.MetroPanel();
            this.btnExcluir = new MetroFramework.Controls.MetroButton();
            this.btnEditar = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtDescEdit = new MetroFramework.Controls.MetroTextBox();
            this.txtNomeEdit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pnlCadastro.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.pnlDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCadastro
            // 
            this.pnlCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCadastro.Controls.Add(this.btnSalvar);
            this.pnlCadastro.Controls.Add(this.txtDesc);
            this.pnlCadastro.Controls.Add(this.lblDesc);
            this.pnlCadastro.Controls.Add(this.txtNome);
            this.pnlCadastro.Controls.Add(this.lblNome);
            this.pnlCadastro.HorizontalScrollbarBarColor = true;
            this.pnlCadastro.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCadastro.HorizontalScrollbarSize = 10;
            this.pnlCadastro.Location = new System.Drawing.Point(377, 56);
            this.pnlCadastro.Name = "pnlCadastro";
            this.pnlCadastro.Size = new System.Drawing.Size(404, 173);
            this.pnlCadastro.TabIndex = 0;
            this.pnlCadastro.VerticalScrollbarBarColor = true;
            this.pnlCadastro.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCadastro.VerticalScrollbarSize = 10;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalvar.Location = new System.Drawing.Point(311, 145);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseCustomBackColor = true;
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Lines = new string[0];
            this.txtDesc.Location = new System.Drawing.Point(99, 74);
            this.txtDesc.MaxLength = 300;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.PasswordChar = '\0';
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDesc.SelectedText = "";
            this.txtDesc.Size = new System.Drawing.Size(287, 52);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.UseSelectable = true;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDesc.Location = new System.Drawing.Point(19, 74);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(74, 19);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Lines = new string[0];
            this.txtNome.Location = new System.Drawing.Point(75, 24);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNome.SelectedText = "";
            this.txtNome.Size = new System.Drawing.Size(311, 23);
            this.txtNome.TabIndex = 3;
            this.txtNome.UseSelectable = true;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNome.Location = new System.Drawing.Point(19, 24);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // lblCadastroEscola
            // 
            this.lblCadastroEscola.AutoSize = true;
            this.lblCadastroEscola.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCadastroEscola.Location = new System.Drawing.Point(377, 31);
            this.lblCadastroEscola.Name = "lblCadastroEscola";
            this.lblCadastroEscola.Size = new System.Drawing.Size(69, 19);
            this.lblCadastroEscola.TabIndex = 1;
            this.lblCadastroEscola.Text = "Cadastro";
            // 
            // lblEdicao
            // 
            this.lblEdicao.AutoSize = true;
            this.lblEdicao.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEdicao.Location = new System.Drawing.Point(377, 284);
            this.lblEdicao.Name = "lblEdicao";
            this.lblEdicao.Size = new System.Drawing.Size(53, 19);
            this.lblEdicao.TabIndex = 3;
            this.lblEdicao.Text = "Edição";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.comboEscola);
            this.metroPanel1.Controls.Add(this.lblSelecao);
            this.metroPanel1.Controls.Add(this.pnlDados);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(377, 309);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(404, 201);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(65, 6);
            this.comboEscola.Name = "comboEscola";
            this.comboEscola.Size = new System.Drawing.Size(311, 29);
            this.comboEscola.TabIndex = 8;
            this.comboEscola.UseSelectable = true;
            this.comboEscola.SelectedIndexChanged += new System.EventHandler(this.comboEscola_SelectedIndexChanged);
            // 
            // lblSelecao
            // 
            this.lblSelecao.AutoSize = true;
            this.lblSelecao.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSelecao.Location = new System.Drawing.Point(9, 9);
            this.lblSelecao.Name = "lblSelecao";
            this.lblSelecao.Size = new System.Drawing.Size(50, 19);
            this.lblSelecao.TabIndex = 7;
            this.lblSelecao.Text = "Escola";
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.btnExcluir);
            this.pnlDados.Controls.Add(this.btnEditar);
            this.pnlDados.Controls.Add(this.metroLabel3);
            this.pnlDados.Controls.Add(this.txtDescEdit);
            this.pnlDados.Controls.Add(this.txtNomeEdit);
            this.pnlDados.Controls.Add(this.metroLabel2);
            this.pnlDados.Enabled = false;
            this.pnlDados.HorizontalScrollbarBarColor = true;
            this.pnlDados.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDados.HorizontalScrollbarSize = 10;
            this.pnlDados.Location = new System.Drawing.Point(9, 31);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(377, 165);
            this.pnlDados.TabIndex = 7;
            this.pnlDados.VerticalScrollbarBarColor = true;
            this.pnlDados.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDados.VerticalScrollbarSize = 10;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluir.Location = new System.Drawing.Point(3, 134);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseCustomBackColor = true;
            this.btnExcluir.UseSelectable = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditar.Location = new System.Drawing.Point(292, 134);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "Salvar";
            this.btnEditar.UseCustomBackColor = true;
            this.btnEditar.UseSelectable = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(0, 13);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(50, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Nome";
            // 
            // txtDescEdit
            // 
            this.txtDescEdit.Lines = new string[0];
            this.txtDescEdit.Location = new System.Drawing.Point(80, 63);
            this.txtDescEdit.MaxLength = 300;
            this.txtDescEdit.Multiline = true;
            this.txtDescEdit.Name = "txtDescEdit";
            this.txtDescEdit.PasswordChar = '\0';
            this.txtDescEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescEdit.SelectedText = "";
            this.txtDescEdit.Size = new System.Drawing.Size(287, 52);
            this.txtDescEdit.TabIndex = 5;
            this.txtDescEdit.UseSelectable = true;
            // 
            // txtNomeEdit
            // 
            this.txtNomeEdit.Lines = new string[0];
            this.txtNomeEdit.Location = new System.Drawing.Point(56, 13);
            this.txtNomeEdit.MaxLength = 100;
            this.txtNomeEdit.Name = "txtNomeEdit";
            this.txtNomeEdit.PasswordChar = '\0';
            this.txtNomeEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNomeEdit.SelectedText = "";
            this.txtNomeEdit.Size = new System.Drawing.Size(311, 23);
            this.txtNomeEdit.TabIndex = 3;
            this.txtNomeEdit.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(0, 63);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Descrição";
            // 
            // FormEscola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.lblEdicao);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblCadastroEscola);
            this.Controls.Add(this.pnlCadastro);
            this.Name = "FormEscola";
            this.Text = "Cadastro de Escola";
            this.pnlCadastro.ResumeLayout(false);
            this.pnlCadastro.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.pnlDados.ResumeLayout(false);
            this.pnlDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlCadastro;
        private MetroFramework.Controls.MetroButton btnSalvar;
        private MetroFramework.Controls.MetroTextBox txtDesc;
        private MetroFramework.Controls.MetroLabel lblDesc;
        private MetroFramework.Controls.MetroTextBox txtNome;
        private MetroFramework.Controls.MetroLabel lblNome;
        private MetroFramework.Controls.MetroLabel lblCadastroEscola;
        private MetroFramework.Controls.MetroLabel lblEdicao;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox comboEscola;
        private MetroFramework.Controls.MetroLabel lblSelecao;
        private MetroFramework.Controls.MetroPanel pnlDados;
        private MetroFramework.Controls.MetroButton btnExcluir;
        private MetroFramework.Controls.MetroButton btnEditar;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtDescEdit;
        private MetroFramework.Controls.MetroTextBox txtNomeEdit;
        private MetroFramework.Controls.MetroLabel metroLabel2;

    }
}