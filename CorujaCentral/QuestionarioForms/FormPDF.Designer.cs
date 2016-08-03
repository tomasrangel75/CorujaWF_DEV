namespace QuestionarioForms
{
    partial class FormPDF
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
            this.SuspendLayout();
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblProfessor.Location = new System.Drawing.Point(27, 37);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(73, 19);
            this.lblProfessor.TabIndex = 5;
            this.lblProfessor.Text = "Professor";
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPDF.Location = new System.Drawing.Point(253, 90);
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
            this.txtProfessor.Location = new System.Drawing.Point(27, 60);
            this.txtProfessor.MaxLength = 200;
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(333, 20);
            this.txtProfessor.TabIndex = 27;
            // 
            // FormPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 144);
            this.Controls.Add(this.txtProfessor);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.lblProfessor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPDF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblProfessor;
        private MetroFramework.Controls.MetroButton btnPDF;
        private System.Windows.Forms.TextBox txtProfessor;
    }
}