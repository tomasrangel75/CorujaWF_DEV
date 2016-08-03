namespace QuestionarioForms
{
    partial class FormPDFEspecialista
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
            this.lblProfessor = new MetroFramework.Controls.MetroLabel();
            this.btnPDF = new MetroFramework.Controls.MetroButton();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.txtano = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblProfessor.Location = new System.Drawing.Point(27, 9);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(90, 19);
            this.lblProfessor.TabIndex = 5;
            this.lblProfessor.Text = "Observação";
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Location = new System.Drawing.Point(244, 113);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(107, 37);
            this.btnPDF.TabIndex = 26;
            this.btnPDF.Text = "Gerar PDF";
            this.btnPDF.UseCustomBackColor = true;
            this.btnPDF.UseSelectable = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // txtProfessor
            // 
            this.txtProfessor.Location = new System.Drawing.Point(27, 31);
            this.txtProfessor.MaxLength = 220;
            this.txtProfessor.Multiline = true;
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(526, 66);
            this.txtProfessor.TabIndex = 27;
            this.txtProfessor.TextChanged += new System.EventHandler(this.txtProfessor_TextChanged);
            // 
            // txtano
            // 
            this.txtano.Location = new System.Drawing.Point(27, 130);
            this.txtano.MaxLength = 200;
            this.txtano.Name = "txtano";
            this.txtano.Size = new System.Drawing.Size(118, 20);
            this.txtano.TabIndex = 29;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(27, 108);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(87, 19);
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "Ano Escolar";
            // 
            // FormPDFEspecialista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 224);
            this.Controls.Add(this.txtano);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtProfessor);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.lblProfessor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPDFEspecialista";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblProfessor;
        private MetroFramework.Controls.MetroButton btnPDF;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.TextBox txtano;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}