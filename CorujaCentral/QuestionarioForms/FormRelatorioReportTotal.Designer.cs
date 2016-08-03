namespace QuestionarioForms
{
    partial class FormRelatorioReportTotal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckAlunos = new System.Windows.Forms.CheckBox();
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.btnGerarRelatorio = new MetroFramework.Controls.MetroButton();
            this.gridTotal = new System.Windows.Forms.DataGridView();
            this.lblPortugues = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlLegenda = new System.Windows.Forms.Panel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTotal)).BeginInit();
            this.pnlLegenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckAlunos);
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.btnGerarRelatorio);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 45);
            this.panel1.TabIndex = 2;
            // 
            // ckAlunos
            // 
            this.ckAlunos.AutoSize = true;
            this.ckAlunos.Location = new System.Drawing.Point(243, 21);
            this.ckAlunos.Name = "ckAlunos";
            this.ckAlunos.Size = new System.Drawing.Size(100, 17);
            this.ckAlunos.TabIndex = 51;
            this.ckAlunos.Text = "Listar Por Aluno";
            this.ckAlunos.UseVisualStyleBackColor = true;
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCSV.Enabled = false;
            this.btnCSV.Location = new System.Drawing.Point(478, 3);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(39, 37);
            this.btnCSV.TabIndex = 20;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseCustomBackColor = true;
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(349, 3);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(110, 37);
            this.btnGerarRelatorio.TabIndex = 50;
            this.btnGerarRelatorio.TabStop = false;
            this.btnGerarRelatorio.Text = "Gerar Relatório";
            this.btnGerarRelatorio.UseCustomBackColor = true;
            this.btnGerarRelatorio.UseSelectable = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // gridTotal
            // 
            this.gridTotal.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTotal.Location = new System.Drawing.Point(9, 85);
            this.gridTotal.Name = "gridTotal";
            this.gridTotal.Size = new System.Drawing.Size(983, 336);
            this.gridTotal.TabIndex = 26;
            // 
            // lblPortugues
            // 
            this.lblPortugues.AutoSize = true;
            this.lblPortugues.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPortugues.Location = new System.Drawing.Point(9, 63);
            this.lblPortugues.Name = "lblPortugues";
            this.lblPortugues.Size = new System.Drawing.Size(75, 19);
            this.lblPortugues.TabIndex = 26;
            this.lblPortugues.Text = "Resultado";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1006, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Legenda";
            // 
            // pnlLegenda
            // 
            this.pnlLegenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegenda.Controls.Add(this.metroLabel5);
            this.pnlLegenda.Controls.Add(this.metroLabel4);
            this.pnlLegenda.Controls.Add(this.metroLabel3);
            this.pnlLegenda.Controls.Add(this.metroLabel2);
            this.pnlLegenda.Controls.Add(this.panel5);
            this.pnlLegenda.Controls.Add(this.panel4);
            this.pnlLegenda.Controls.Add(this.panel3);
            this.pnlLegenda.Controls.Add(this.panel2);
            this.pnlLegenda.Location = new System.Drawing.Point(1006, 85);
            this.pnlLegenda.Name = "pnlLegenda";
            this.pnlLegenda.Size = new System.Drawing.Size(153, 149);
            this.pnlLegenda.TabIndex = 31;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(49, 106);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(63, 19);
            this.metroLabel5.TabIndex = 35;
            this.metroLabel5.Text = "75 - 100";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(49, 77);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(55, 19);
            this.metroLabel4.TabIndex = 34;
            this.metroLabel4.Text = "50 - 75";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(49, 48);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(55, 19);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "25 - 50";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(49, 19);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 19);
            this.metroLabel2.TabIndex = 31;
            this.metroLabel2.Text = "0 - 25";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(6, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(32, 23);
            this.panel5.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(235)))), ((int)(((byte)(108)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(6, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 23);
            this.panel4.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(6, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 23);
            this.panel3.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tomato;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 23);
            this.panel2.TabIndex = 31;
            // 
            // FormRelatorioReportTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 426);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pnlLegenda);
            this.Controls.Add(this.lblPortugues);
            this.Controls.Add(this.gridTotal);
            this.Controls.Add(this.panel1);
            this.Name = "FormRelatorioReportTotal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTotal)).EndInit();
            this.pnlLegenda.ResumeLayout(false);
            this.pnlLegenda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnGerarRelatorio;
        private System.Windows.Forms.DataGridView gridTotal;
        private MetroFramework.Controls.MetroLabel lblPortugues;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel pnlLegenda;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckAlunos;
    }
}