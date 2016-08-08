namespace Prova
{
    partial class FormProvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProvas));
            this.comboProvas = new MetroFramework.Controls.MetroComboBox();
            this.lblProvas = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.chkHabilitaRemocao = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProvas
            // 
            this.comboProvas.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.comboProvas.FormattingEnabled = true;
            this.comboProvas.ItemHeight = 29;
            this.comboProvas.Location = new System.Drawing.Point(23, 34);
            this.comboProvas.Name = "comboProvas";
            this.comboProvas.Size = new System.Drawing.Size(368, 35);
            this.comboProvas.TabIndex = 4;
            this.comboProvas.UseSelectable = true;
            this.comboProvas.SelectedIndexChanged += new System.EventHandler(this.comboProvas_SelectedIndexChanged);
            this.comboProvas.SelectionChangeCommitted += new System.EventHandler(this.comboProvas_SelectionChangeCommitted);
            this.comboProvas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboProvas_KeyDown);
            // 
            // lblProvas
            // 
            this.lblProvas.AutoSize = true;
            this.lblProvas.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvas.Location = new System.Drawing.Point(20, 13);
            this.lblProvas.Name = "lblProvas";
            this.lblProvas.Size = new System.Drawing.Size(292, 18);
            this.lblProvas.TabIndex = 5;
            this.lblProvas.Text = "Selecione uma Avaliação Coruja:\r\n";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Enabled = false;
            this.btnAbrir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Location = new System.Drawing.Point(331, 188);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(60, 34);
            this.btnAbrir.TabIndex = 7;
            this.btnAbrir.Text = "ABRIR";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnOkProvas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(74, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.ForeColor = System.Drawing.Color.Red;
            this.btnDeletar.Location = new System.Drawing.Point(23, 188);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(73, 34);
            this.btnDeletar.TabIndex = 8;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // chkHabilitaRemocao
            // 
            this.chkHabilitaRemocao.AutoSize = true;
            this.chkHabilitaRemocao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabilitaRemocao.Location = new System.Drawing.Point(23, 165);
            this.chkHabilitaRemocao.Name = "chkHabilitaRemocao";
            this.chkHabilitaRemocao.Size = new System.Drawing.Size(206, 17);
            this.chkHabilitaRemocao.TabIndex = 10;
            this.chkHabilitaRemocao.Text = "Marque para habilitar remoção.";
            this.chkHabilitaRemocao.UseVisualStyleBackColor = true;
            this.chkHabilitaRemocao.CheckedChanged += new System.EventHandler(this.chkHabilitaRemocao_CheckedChanged);
            // 
            // FormProvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 235);
            this.Controls.Add(this.chkHabilitaRemocao);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblProvas);
            this.Controls.Add(this.comboProvas);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(12000, 5000);
            this.Name = "FormProvas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicação Coruja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProvas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox comboProvas;
        private System.Windows.Forms.Label lblProvas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.CheckBox chkHabilitaRemocao;
    }
}