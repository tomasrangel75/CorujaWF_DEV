namespace Prova
{
    partial class waitform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(waitform));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.playerAudio = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgLogo.BackgroundImage = global::Prova.Properties.Resources.selo_logo;
            this.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgLogo.Location = new System.Drawing.Point(70, 57);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(139, 106);
            this.imgLogo.TabIndex = 13;
            this.imgLogo.TabStop = false;
            // 
            // playerAudio
            // 
            this.playerAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerAudio.Enabled = true;
            this.playerAudio.Location = new System.Drawing.Point(12, 191);
            this.playerAudio.Name = "playerAudio";
            this.playerAudio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playerAudio.OcxState")));
            this.playerAudio.Size = new System.Drawing.Size(52, 58);
            this.playerAudio.TabIndex = 14;
            this.playerAudio.Visible = false;
            // 
            // waitform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.playerAudio);
            this.Controls.Add(this.imgLogo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "waitform";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerAudio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private AxWMPLib.AxWindowsMediaPlayer playerAudio;
    }
}