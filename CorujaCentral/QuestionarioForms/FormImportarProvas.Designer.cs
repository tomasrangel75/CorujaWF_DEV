namespace QuestionarioForms
{
    partial class FormImportarProvas
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
            this.pnlImportacaoProva = new MetroFramework.Controls.MetroPanel();
            this.comboEscola = new MetroFramework.Controls.MetroComboBox();
            this.lblEscola = new MetroFramework.Controls.MetroLabel();
            this.btnImportarProva = new MetroFramework.Controls.MetroButton();
            this.pnlDestinoProva = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridTotal = new System.Windows.Forms.DataGridView();
            this.lblInfo = new MetroFramework.Controls.MetroLabel();
            this.btnSelecaoBancoProva = new MetroFramework.Controls.MetroButton();
            this.lblBancoProva = new MetroFramework.Controls.MetroLabel();
            this.pnlImportacaoProva.SuspendLayout();
            this.pnlDestinoProva.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImportacaoProva
            // 
            this.pnlImportacaoProva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImportacaoProva.Controls.Add(this.comboEscola);
            this.pnlImportacaoProva.Controls.Add(this.lblEscola);
            this.pnlImportacaoProva.Controls.Add(this.btnImportarProva);
            this.pnlImportacaoProva.Controls.Add(this.pnlDestinoProva);
            this.pnlImportacaoProva.Controls.Add(this.btnSelecaoBancoProva);
            this.pnlImportacaoProva.Controls.Add(this.lblBancoProva);
            this.pnlImportacaoProva.HorizontalScrollbarBarColor = true;
            this.pnlImportacaoProva.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlImportacaoProva.HorizontalScrollbarSize = 10;
            this.pnlImportacaoProva.Location = new System.Drawing.Point(92, 53);
            this.pnlImportacaoProva.Name = "pnlImportacaoProva";
            this.pnlImportacaoProva.Size = new System.Drawing.Size(997, 460);
            this.pnlImportacaoProva.TabIndex = 1;
            this.pnlImportacaoProva.VerticalScrollbarBarColor = true;
            this.pnlImportacaoProva.VerticalScrollbarHighlightOnWheel = false;
            this.pnlImportacaoProva.VerticalScrollbarSize = 10;
            // 
            // comboEscola
            // 
            this.comboEscola.FormattingEnabled = true;
            this.comboEscola.ItemHeight = 23;
            this.comboEscola.Location = new System.Drawing.Point(66, 3);
            this.comboEscola.Name = "comboEscola";
            this.comboEscola.Size = new System.Drawing.Size(238, 29);
            this.comboEscola.TabIndex = 7;
            this.comboEscola.UseSelectable = true;
            this.comboEscola.SelectedIndexChanged += new System.EventHandler(this.comboEscola_SelectedIndexChanged);
            // 
            // lblEscola
            // 
            this.lblEscola.AutoSize = true;
            this.lblEscola.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEscola.Location = new System.Drawing.Point(9, 11);
            this.lblEscola.Name = "lblEscola";
            this.lblEscola.Size = new System.Drawing.Size(50, 19);
            this.lblEscola.TabIndex = 6;
            this.lblEscola.Text = "Escola";
            // 
            // btnImportarProva
            // 
            this.btnImportarProva.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnImportarProva.Enabled = false;
            this.btnImportarProva.Location = new System.Drawing.Point(744, 432);
            this.btnImportarProva.Name = "btnImportarProva";
            this.btnImportarProva.Size = new System.Drawing.Size(213, 23);
            this.btnImportarProva.TabIndex = 9;
            this.btnImportarProva.Text = "Importar Resultado da Prova";
            this.btnImportarProva.UseCustomBackColor = true;
            this.btnImportarProva.UseSelectable = true;
            this.btnImportarProva.Click += new System.EventHandler(this.btnImportarProva_Click);
            // 
            // pnlDestinoProva
            // 
            this.pnlDestinoProva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDestinoProva.Controls.Add(this.panel1);
            this.pnlDestinoProva.Controls.Add(this.lblInfo);
            this.pnlDestinoProva.Enabled = false;
            this.pnlDestinoProva.HorizontalScrollbarBarColor = true;
            this.pnlDestinoProva.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDestinoProva.HorizontalScrollbarSize = 10;
            this.pnlDestinoProva.Location = new System.Drawing.Point(7, 38);
            this.pnlDestinoProva.Name = "pnlDestinoProva";
            this.pnlDestinoProva.Size = new System.Drawing.Size(985, 388);
            this.pnlDestinoProva.TabIndex = 13;
            this.pnlDestinoProva.VerticalScrollbarBarColor = true;
            this.pnlDestinoProva.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDestinoProva.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridTotal);
            this.panel1.Location = new System.Drawing.Point(8, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 357);
            this.panel1.TabIndex = 28;
            // 
            // gridTotal
            // 
            this.gridTotal.AllowUserToAddRows = false;
            this.gridTotal.AllowUserToDeleteRows = false;
            this.gridTotal.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTotal.Location = new System.Drawing.Point(3, 3);
            this.gridTotal.Name = "gridTotal";
            this.gridTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridTotal.Size = new System.Drawing.Size(938, 351);
            this.gridTotal.TabIndex = 27;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(4, 4);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(393, 19);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = "Para cada Arquivo, selecione um Aluno da Turma  para importar:";
            // 
            // btnSelecaoBancoProva
            // 
            this.btnSelecaoBancoProva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelecaoBancoProva.Enabled = false;
            this.btnSelecaoBancoProva.Location = new System.Drawing.Point(388, 6);
            this.btnSelecaoBancoProva.Name = "btnSelecaoBancoProva";
            this.btnSelecaoBancoProva.Size = new System.Drawing.Size(182, 23);
            this.btnSelecaoBancoProva.TabIndex = 11;
            this.btnSelecaoBancoProva.Text = "Selecione os arquivos DBQUEST";
            this.btnSelecaoBancoProva.UseCustomBackColor = true;
            this.btnSelecaoBancoProva.UseSelectable = true;
            this.btnSelecaoBancoProva.Click += new System.EventHandler(this.btnSelecaoBancoProva_Click);
            // 
            // lblBancoProva
            // 
            this.lblBancoProva.AutoSize = true;
            this.lblBancoProva.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblBancoProva.Location = new System.Drawing.Point(326, 11);
            this.lblBancoProva.Name = "lblBancoProva";
            this.lblBancoProva.Size = new System.Drawing.Size(56, 19);
            this.lblBancoProva.TabIndex = 11;
            this.lblBancoProva.Text = "Bancos";
            // 
            // FormImportarProvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 516);
            this.Controls.Add(this.pnlImportacaoProva);
            this.Name = "FormImportarProvas";
            this.Text = "Importar Arquivos de Provas";
            this.pnlImportacaoProva.ResumeLayout(false);
            this.pnlImportacaoProva.PerformLayout();
            this.pnlDestinoProva.ResumeLayout(false);
            this.pnlDestinoProva.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlImportacaoProva;
        private MetroFramework.Controls.MetroButton btnSelecaoBancoProva;
        private MetroFramework.Controls.MetroLabel lblBancoProva;
        private MetroFramework.Controls.MetroPanel pnlDestinoProva;
        private MetroFramework.Controls.MetroButton btnImportarProva;
        private MetroFramework.Controls.MetroLabel lblInfo;
        private System.Windows.Forms.DataGridView gridTotal;
        private MetroFramework.Controls.MetroComboBox comboEscola;
        private MetroFramework.Controls.MetroLabel lblEscola;
        private System.Windows.Forms.Panel panel1;
    }
}