namespace Prova
{
    partial class WaitLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitLoad));
            this.lblImgLoad = new System.Windows.Forms.Label();
            this.imgLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImgLoad
            // 
            this.lblImgLoad.AutoSize = true;
            this.lblImgLoad.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgLoad.Location = new System.Drawing.Point(71, 9);
            this.lblImgLoad.Name = "lblImgLoad";
            this.lblImgLoad.Size = new System.Drawing.Size(301, 23);
            this.lblImgLoad.TabIndex = 4;
            this.lblImgLoad.Text = "Aplicação Coruja abrindo...";
            // 
            // imgLoad
            // 
            this.imgLoad.ErrorImage = null;
            this.imgLoad.Image = ((System.Drawing.Image)(resources.GetObject("imgLoad.Image")));
            this.imgLoad.InitialImage = null;
            this.imgLoad.Location = new System.Drawing.Point(-3, -6);
            this.imgLoad.Name = "imgLoad";
            this.imgLoad.Size = new System.Drawing.Size(450, 225);
            this.imgLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLoad.TabIndex = 3;
            this.imgLoad.TabStop = false;
            // 
            // WaitLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 152);
            this.ControlBox = false;
            this.Controls.Add(this.lblImgLoad);
            this.Controls.Add(this.imgLoad);
            this.Name = "WaitLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.imgLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblImgLoad;
        public System.Windows.Forms.PictureBox imgLoad;
    }
}