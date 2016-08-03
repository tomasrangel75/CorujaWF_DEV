namespace QuestionarioForms
{
    partial class FormAlunos
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
            this.lblCadastro = new MetroFramework.Controls.MetroLabel();
            this.pnlCadastro = new MetroFramework.Controls.MetroPanel();
            this.dtDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.lblDataNascimento = new MetroFramework.Controls.MetroLabel();
            this.ckFeminino = new MetroFramework.Controls.MetroCheckBox();
            this.ckMasculino = new MetroFramework.Controls.MetroCheckBox();
            this.lblSexo = new MetroFramework.Controls.MetroLabel();
            this.comboTurma = new MetroFramework.Controls.MetroComboBox();
            this.lblTurma = new MetroFramework.Controls.MetroLabel();
            this.btnSalvar = new MetroFramework.Controls.MetroButton();
            this.txtNome = new MetroFramework.Controls.MetroTextBox();
            this.lblNome = new MetroFramework.Controls.MetroLabel();
            this.lblEdicao = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dtDataNascimentoEdit = new System.Windows.Forms.DateTimePicker();
            this.ckFemininoEdit = new MetroFramework.Controls.MetroCheckBox();
            this.lblDataNascimentoEdit = new MetroFramework.Controls.MetroLabel();
            this.btnExcluir = new MetroFramework.Controls.MetroButton();
            this.ckMasculinoEdit = new MetroFramework.Controls.MetroCheckBox();
            this.comboAluno = new MetroFramework.Controls.MetroComboBox();
            this.lblSexoEdit = new MetroFramework.Controls.MetroLabel();
            this.lblAluno = new MetroFramework.Controls.MetroLabel();
            this.comboTUrmaEdit = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnEdicao = new MetroFramework.Controls.MetroButton();
            this.txtNomeEdit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.comboTurmaArquivo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnimportarAlunos = new MetroFramework.Controls.MetroButton();
            this.btnSelecaoArquivoAlunos = new MetroFramework.Controls.MetroButton();
            this.pnlCadastro.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCadastro.Location = new System.Drawing.Point(300, 17);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(69, 19);
            this.lblCadastro.TabIndex = 3;
            this.lblCadastro.Text = "Cadastro";
            // 
            // pnlCadastro
            // 
            this.pnlCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCadastro.Controls.Add(this.dtDataNascimento);
            this.pnlCadastro.Controls.Add(this.lblDataNascimento);
            this.pnlCadastro.Controls.Add(this.ckFeminino);
            this.pnlCadastro.Controls.Add(this.ckMasculino);
            this.pnlCadastro.Controls.Add(this.lblSexo);
            this.pnlCadastro.Controls.Add(this.comboTurma);
            this.pnlCadastro.Controls.Add(this.lblTurma);
            this.pnlCadastro.Controls.Add(this.btnSalvar);
            this.pnlCadastro.Controls.Add(this.txtNome);
            this.pnlCadastro.Controls.Add(this.lblNome);
            this.pnlCadastro.HorizontalScrollbarBarColor = true;
            this.pnlCadastro.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCadastro.HorizontalScrollbarSize = 10;
            this.pnlCadastro.Location = new System.Drawing.Point(300, 42);
            this.pnlCadastro.Name = "pnlCadastro";
            this.pnlCadastro.Size = new System.Drawing.Size(404, 222);
            this.pnlCadastro.TabIndex = 2;
            this.pnlCadastro.VerticalScrollbarBarColor = true;
            this.pnlCadastro.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCadastro.VerticalScrollbarSize = 10;
            // 
            // dtDataNascimento
            // 
            this.dtDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataNascimento.Location = new System.Drawing.Point(168, 166);
            this.dtDataNascimento.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtDataNascimento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDataNascimento.Name = "dtDataNascimento";
            this.dtDataNascimento.Size = new System.Drawing.Size(108, 20);
            this.dtDataNascimento.TabIndex = 13;
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDataNascimento.Location = new System.Drawing.Point(18, 166);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(144, 19);
            this.lblDataNascimento.TabIndex = 12;
            this.lblDataNascimento.Text = "Data de Nascimento";
            // 
            // ckFeminino
            // 
            this.ckFeminino.AutoSize = true;
            this.ckFeminino.Location = new System.Drawing.Point(174, 123);
            this.ckFeminino.Name = "ckFeminino";
            this.ckFeminino.Size = new System.Drawing.Size(73, 15);
            this.ckFeminino.TabIndex = 11;
            this.ckFeminino.Text = "Feminino";
            this.ckFeminino.UseSelectable = true;
            // 
            // ckMasculino
            // 
            this.ckMasculino.AutoSize = true;
            this.ckMasculino.Location = new System.Drawing.Point(77, 122);
            this.ckMasculino.Name = "ckMasculino";
            this.ckMasculino.Size = new System.Drawing.Size(78, 15);
            this.ckMasculino.TabIndex = 10;
            this.ckMasculino.Text = "Masculino";
            this.ckMasculino.UseSelectable = true;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSexo.Location = new System.Drawing.Point(18, 119);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(42, 19);
            this.lblSexo.TabIndex = 9;
            this.lblSexo.Text = "Sexo";
            // 
            // comboTurma
            // 
            this.comboTurma.FormattingEnabled = true;
            this.comboTurma.ItemHeight = 23;
            this.comboTurma.Location = new System.Drawing.Point(77, 24);
            this.comboTurma.Name = "comboTurma";
            this.comboTurma.Size = new System.Drawing.Size(309, 29);
            this.comboTurma.TabIndex = 8;
            this.comboTurma.UseSelectable = true;
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTurma.Location = new System.Drawing.Point(19, 24);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(51, 19);
            this.lblTurma.TabIndex = 7;
            this.lblTurma.Text = "Turma";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalvar.Location = new System.Drawing.Point(311, 188);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseCustomBackColor = true;
            this.btnSalvar.UseSelectable = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Lines = new string[0];
            this.txtNome.Location = new System.Drawing.Point(75, 78);
            this.txtNome.MaxLength = 200;
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
            this.lblNome.Location = new System.Drawing.Point(19, 78);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // lblEdicao
            // 
            this.lblEdicao.AutoSize = true;
            this.lblEdicao.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEdicao.Location = new System.Drawing.Point(784, 17);
            this.lblEdicao.Name = "lblEdicao";
            this.lblEdicao.Size = new System.Drawing.Size(53, 19);
            this.lblEdicao.TabIndex = 5;
            this.lblEdicao.Text = "Edicao";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.dtDataNascimentoEdit);
            this.metroPanel1.Controls.Add(this.ckFemininoEdit);
            this.metroPanel1.Controls.Add(this.lblDataNascimentoEdit);
            this.metroPanel1.Controls.Add(this.btnExcluir);
            this.metroPanel1.Controls.Add(this.ckMasculinoEdit);
            this.metroPanel1.Controls.Add(this.comboAluno);
            this.metroPanel1.Controls.Add(this.lblSexoEdit);
            this.metroPanel1.Controls.Add(this.lblAluno);
            this.metroPanel1.Controls.Add(this.comboTUrmaEdit);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.btnEdicao);
            this.metroPanel1.Controls.Add(this.txtNomeEdit);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(784, 42);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(404, 291);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dtDataNascimentoEdit
            // 
            this.dtDataNascimentoEdit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataNascimentoEdit.Location = new System.Drawing.Point(174, 201);
            this.dtDataNascimentoEdit.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtDataNascimentoEdit.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDataNascimentoEdit.Name = "dtDataNascimentoEdit";
            this.dtDataNascimentoEdit.Size = new System.Drawing.Size(108, 20);
            this.dtDataNascimentoEdit.TabIndex = 18;
            // 
            // ckFemininoEdit
            // 
            this.ckFemininoEdit.AutoSize = true;
            this.ckFemininoEdit.Location = new System.Drawing.Point(180, 158);
            this.ckFemininoEdit.Name = "ckFemininoEdit";
            this.ckFemininoEdit.Size = new System.Drawing.Size(73, 15);
            this.ckFemininoEdit.TabIndex = 16;
            this.ckFemininoEdit.Text = "Feminino";
            this.ckFemininoEdit.UseSelectable = true;
            // 
            // lblDataNascimentoEdit
            // 
            this.lblDataNascimentoEdit.AutoSize = true;
            this.lblDataNascimentoEdit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDataNascimentoEdit.Location = new System.Drawing.Point(24, 201);
            this.lblDataNascimentoEdit.Name = "lblDataNascimentoEdit";
            this.lblDataNascimentoEdit.Size = new System.Drawing.Size(144, 19);
            this.lblDataNascimentoEdit.TabIndex = 17;
            this.lblDataNascimentoEdit.Text = "Data de Nascimento";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(18, 248);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseCustomBackColor = true;
            this.btnExcluir.UseSelectable = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ckMasculinoEdit
            // 
            this.ckMasculinoEdit.AutoSize = true;
            this.ckMasculinoEdit.Location = new System.Drawing.Point(83, 157);
            this.ckMasculinoEdit.Name = "ckMasculinoEdit";
            this.ckMasculinoEdit.Size = new System.Drawing.Size(78, 15);
            this.ckMasculinoEdit.TabIndex = 15;
            this.ckMasculinoEdit.Text = "Masculino";
            this.ckMasculinoEdit.UseSelectable = true;
            // 
            // comboAluno
            // 
            this.comboAluno.FormattingEnabled = true;
            this.comboAluno.ItemHeight = 23;
            this.comboAluno.Location = new System.Drawing.Point(76, 72);
            this.comboAluno.Name = "comboAluno";
            this.comboAluno.Size = new System.Drawing.Size(309, 29);
            this.comboAluno.TabIndex = 10;
            this.comboAluno.UseSelectable = true;
            this.comboAluno.SelectedIndexChanged += new System.EventHandler(this.comboAluno_SelectedIndexChanged);
            // 
            // lblSexoEdit
            // 
            this.lblSexoEdit.AutoSize = true;
            this.lblSexoEdit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSexoEdit.Location = new System.Drawing.Point(24, 154);
            this.lblSexoEdit.Name = "lblSexoEdit";
            this.lblSexoEdit.Size = new System.Drawing.Size(42, 19);
            this.lblSexoEdit.TabIndex = 14;
            this.lblSexoEdit.Text = "Sexo";
            // 
            // lblAluno
            // 
            this.lblAluno.AutoSize = true;
            this.lblAluno.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAluno.Location = new System.Drawing.Point(18, 72);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(48, 19);
            this.lblAluno.TabIndex = 9;
            this.lblAluno.Text = "Aluno";
            // 
            // comboTUrmaEdit
            // 
            this.comboTUrmaEdit.FormattingEnabled = true;
            this.comboTUrmaEdit.ItemHeight = 23;
            this.comboTUrmaEdit.Location = new System.Drawing.Point(77, 24);
            this.comboTUrmaEdit.Name = "comboTUrmaEdit";
            this.comboTUrmaEdit.Size = new System.Drawing.Size(309, 29);
            this.comboTUrmaEdit.TabIndex = 8;
            this.comboTUrmaEdit.UseSelectable = true;
            this.comboTUrmaEdit.SelectedIndexChanged += new System.EventHandler(this.comboTUrmaEdit_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(19, 24);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Turma";
            // 
            // btnEdicao
            // 
            this.btnEdicao.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEdicao.Enabled = false;
            this.btnEdicao.Location = new System.Drawing.Point(298, 248);
            this.btnEdicao.Name = "btnEdicao";
            this.btnEdicao.Size = new System.Drawing.Size(75, 23);
            this.btnEdicao.TabIndex = 6;
            this.btnEdicao.Text = "Salvar";
            this.btnEdicao.UseCustomBackColor = true;
            this.btnEdicao.UseSelectable = true;
            this.btnEdicao.Click += new System.EventHandler(this.btnEdicao_Click);
            // 
            // txtNomeEdit
            // 
            this.txtNomeEdit.Enabled = false;
            this.txtNomeEdit.Lines = new string[0];
            this.txtNomeEdit.Location = new System.Drawing.Point(75, 115);
            this.txtNomeEdit.MaxLength = 200;
            this.txtNomeEdit.Name = "txtNomeEdit";
            this.txtNomeEdit.PasswordChar = '\0';
            this.txtNomeEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNomeEdit.SelectedText = "";
            this.txtNomeEdit.Size = new System.Drawing.Size(311, 23);
            this.txtNomeEdit.TabIndex = 3;
            this.txtNomeEdit.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(19, 115);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(50, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Nome";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.btnSelecaoArquivoAlunos);
            this.metroPanel2.Controls.Add(this.comboTurmaArquivo);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.btnimportarAlunos);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(300, 260);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(404, 133);
            this.metroPanel2.TabIndex = 14;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // comboTurmaArquivo
            // 
            this.comboTurmaArquivo.FormattingEnabled = true;
            this.comboTurmaArquivo.ItemHeight = 23;
            this.comboTurmaArquivo.Location = new System.Drawing.Point(77, 24);
            this.comboTurmaArquivo.Name = "comboTurmaArquivo";
            this.comboTurmaArquivo.Size = new System.Drawing.Size(309, 29);
            this.comboTurmaArquivo.TabIndex = 8;
            this.comboTurmaArquivo.UseSelectable = true;
            this.comboTurmaArquivo.SelectedIndexChanged += new System.EventHandler(this.comboTurmaArquivo_SelectedIndexChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(19, 24);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Turma";
            // 
            // btnimportarAlunos
            // 
            this.btnimportarAlunos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnimportarAlunos.Enabled = false;
            this.btnimportarAlunos.Location = new System.Drawing.Point(18, 98);
            this.btnimportarAlunos.Name = "btnimportarAlunos";
            this.btnimportarAlunos.Size = new System.Drawing.Size(75, 23);
            this.btnimportarAlunos.TabIndex = 6;
            this.btnimportarAlunos.Text = "Importar";
            this.btnimportarAlunos.UseCustomBackColor = true;
            this.btnimportarAlunos.UseSelectable = true;
            this.btnimportarAlunos.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnSelecaoArquivoAlunos
            // 
            this.btnSelecaoArquivoAlunos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelecaoArquivoAlunos.Enabled = false;
            this.btnSelecaoArquivoAlunos.Location = new System.Drawing.Point(19, 59);
            this.btnSelecaoArquivoAlunos.Name = "btnSelecaoArquivoAlunos";
            this.btnSelecaoArquivoAlunos.Size = new System.Drawing.Size(182, 23);
            this.btnSelecaoArquivoAlunos.TabIndex = 15;
            this.btnSelecaoArquivoAlunos.Text = "Selecione o arquivo de Alunos";
            this.btnSelecaoArquivoAlunos.UseCustomBackColor = true;
            this.btnSelecaoArquivoAlunos.UseSelectable = true;
            this.btnSelecaoArquivoAlunos.Click += new System.EventHandler(this.btnSelecaoArquivoAlunos_Click);
            // 
            // FormAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.lblEdicao);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblCadastro);
            this.Controls.Add(this.pnlCadastro);
            this.Name = "FormAlunos";
            this.Text = "Cadastro de Aluno";
            this.pnlCadastro.ResumeLayout(false);
            this.pnlCadastro.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblCadastro;
        private MetroFramework.Controls.MetroPanel pnlCadastro;
        private MetroFramework.Controls.MetroComboBox comboTurma;
        private MetroFramework.Controls.MetroLabel lblTurma;
        private MetroFramework.Controls.MetroButton btnSalvar;
        private MetroFramework.Controls.MetroTextBox txtNome;
        private MetroFramework.Controls.MetroLabel lblNome;
        private MetroFramework.Controls.MetroLabel lblEdicao;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox comboAluno;
        private MetroFramework.Controls.MetroLabel lblAluno;
        private MetroFramework.Controls.MetroComboBox comboTUrmaEdit;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnEdicao;
        private MetroFramework.Controls.MetroTextBox txtNomeEdit;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnExcluir;
        private System.Windows.Forms.DateTimePicker dtDataNascimento;
        private MetroFramework.Controls.MetroLabel lblDataNascimento;
        private MetroFramework.Controls.MetroCheckBox ckFeminino;
        private MetroFramework.Controls.MetroCheckBox ckMasculino;
        private MetroFramework.Controls.MetroLabel lblSexo;
        private System.Windows.Forms.DateTimePicker dtDataNascimentoEdit;
        private MetroFramework.Controls.MetroCheckBox ckFemininoEdit;
        private MetroFramework.Controls.MetroLabel lblDataNascimentoEdit;
        private MetroFramework.Controls.MetroCheckBox ckMasculinoEdit;
        private MetroFramework.Controls.MetroLabel lblSexoEdit;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroComboBox comboTurmaArquivo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnimportarAlunos;
        private MetroFramework.Controls.MetroButton btnSelecaoArquivoAlunos;
    }
}