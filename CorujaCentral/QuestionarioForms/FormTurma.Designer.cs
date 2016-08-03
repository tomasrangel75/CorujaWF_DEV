namespace QuestionarioForms
{
    partial class FormTurma
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
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.btnExcluir = new MetroFramework.Controls.MetroButton();
            this.btnSalvar = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlAlunos = new MetroFramework.Controls.MetroPanel();
            this.gridAlunos = new System.Windows.Forms.DataGridView();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.txtNome = new MetroFramework.Controls.MetroTextBox();
            this.lblNomeTurma = new MetroFramework.Controls.MetroLabel();
            this.btnNova = new MetroFramework.Controls.MetroButton();
            this.pnlPrincipal.SuspendLayout();
            this.pnlAlunos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.lblEscola);
            this.pnlPrincipal.Controls.Add(this.comboEscola);
            this.pnlPrincipal.Controls.Add(this.btnExcluir);
            this.pnlPrincipal.Controls.Add(this.btnSalvar);
            this.pnlPrincipal.Controls.Add(this.metroLabel1);
            this.pnlPrincipal.Controls.Add(this.pnlAlunos);
            this.pnlPrincipal.Controls.Add(this.lblTurma);
            this.pnlPrincipal.Controls.Add(this.comboTurma);
            this.pnlPrincipal.Controls.Add(this.txtNome);
            this.pnlPrincipal.Controls.Add(this.lblNomeTurma);
            this.pnlPrincipal.Controls.Add(this.btnNova);
            this.pnlPrincipal.HorizontalScrollbarBarColor = true;
            this.pnlPrincipal.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.HorizontalScrollbarSize = 10;
            this.pnlPrincipal.Location = new System.Drawing.Point(206, 37);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(744, 474);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.VerticalScrollbarBarColor = true;
            this.pnlPrincipal.VerticalScrollbarHighlightOnWheel = false;
            this.pnlPrincipal.VerticalScrollbarSize = 10;
            // 
            // lblEscola
            // 
            this.lblEscola.AutoSize = true;
            this.lblEscola.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEscola.Location = new System.Drawing.Point(20, 34);
            this.lblEscola.Name = "lblEscola";
            this.lblEscola.Size = new System.Drawing.Size(50, 19);
            this.lblEscola.TabIndex = 12;
            this.lblEscola.Text = "Escola";
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(77, 34);
            this.comboEscola.Name = "comboEscola";
            this.comboEscola.Size = new System.Drawing.Size(325, 29);
            this.comboEscola.TabIndex = 0;
            this.comboEscola.UseSelectable = true;
            this.comboEscola.SelectedIndexChanged += new System.EventHandler(this.comboEscola_SelectedIndexChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(664, 4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseCustomBackColor = true;
            this.btnExcluir.UseSelectable = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(419, 116);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseCustomBackColor = true;
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(37, 143);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Alunos";
            // 
            // pnlAlunos
            // 
            this.pnlAlunos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlunos.Controls.Add(this.gridAlunos);
            this.pnlAlunos.HorizontalScrollbarBarColor = true;
            this.pnlAlunos.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlAlunos.HorizontalScrollbarSize = 10;
            this.pnlAlunos.Location = new System.Drawing.Point(37, 165);
            this.pnlAlunos.Name = "pnlAlunos";
            this.pnlAlunos.Size = new System.Drawing.Size(670, 301);
            this.pnlAlunos.TabIndex = 7;
            this.pnlAlunos.VerticalScrollbarBarColor = true;
            this.pnlAlunos.VerticalScrollbarHighlightOnWheel = false;
            this.pnlAlunos.VerticalScrollbarSize = 10;
            // 
            // gridAlunos
            // 
            this.gridAlunos.AllowUserToAddRows = false;
            this.gridAlunos.AllowUserToDeleteRows = false;
            this.gridAlunos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlunos.GridColor = System.Drawing.Color.White;
            this.gridAlunos.Location = new System.Drawing.Point(68, 28);
            this.gridAlunos.Name = "gridAlunos";
            this.gridAlunos.ReadOnly = true;
            this.gridAlunos.Size = new System.Drawing.Size(542, 256);
            this.gridAlunos.TabIndex = 2;
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(20, 69);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(51, 19);
            this.lblTurma.TabIndex = 6;
            this.lblTurma.Text = "Turma";
            // 
            // comboTurma
            // 
            this.comboTurma.Enabled = false;
            this.comboTurma.FormattingEnabled = true;
            this.comboTurma.ItemHeight = 23;
            this.comboTurma.Location = new System.Drawing.Point(77, 69);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(325, 29);
            this.comboTurma.TabIndex = 0;
            this.comboTurma.UseSelectable = true;
            this.comboTurma.SelectedIndexChanged += new System.EventHandler(this.comboTurma_SelectedIndexChanged);
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Lines = new string[0];
            this.txtNome.Location = new System.Drawing.Point(76, 116);
            this.txtNome.MaxLength = 150;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNome.SelectedText = "";
            this.txtNome.Size = new System.Drawing.Size(326, 23);
            this.txtNome.TabIndex = 4;
            this.txtNome.UseSelectable = true;
            // 
            // lblNomeTurma
            // 
            this.lblNomeTurma.AutoSize = true;
            this.lblNomeTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNomeTurma.Location = new System.Drawing.Point(20, 116);
            this.lblNomeTurma.Name = "lblNomeTurma";
            this.lblNomeTurma.Size = new System.Drawing.Size(50, 19);
            this.lblNomeTurma.TabIndex = 3;
            this.lblNomeTurma.Text = "Nome";
            // 
            // btnNova
            // 
            this.btnNova.BackColor = System.Drawing.Color.Yellow;
            this.btnNova.Location = new System.Drawing.Point(20, 4);
            this.btnNova.Name = "btnNova";
            this.btnNova.Size = new System.Drawing.Size(75, 23);
            this.btnNova.TabIndex = 2;
            this.btnNova.Text = "Nova Turma";
            this.btnNova.UseCustomBackColor = true;
            this.btnNova.UseSelectable = true;
            this.btnNova.Click += new System.EventHandler(this.btnNova_Click);
            // 
            // FormTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "FormTurma";
            this.Text = "Turma";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlAlunos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlPrincipal;
        private MetroFramework.Controls.MetroButton btnNova;
        private MetroFramework.Controls.MetroButton btnExcluir;
        private MetroFramework.Controls.MetroButton btnSalvar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel pnlAlunos;
        private System.Windows.Forms.DataGridView gridAlunos;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private MetroFramework.Controls.MetroComboBox comboTurma;
        private MetroFramework.Controls.MetroTextBox txtNome;
        private MetroFramework.Controls.MetroLabel lblNomeTurma;
        private MetroFramework.Controls.MetroLabel lblEscola;
        private MetroFramework.Controls.MetroComboBox comboEscola;
    }
}