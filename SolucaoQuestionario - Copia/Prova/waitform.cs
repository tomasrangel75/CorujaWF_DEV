using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;



namespace Prova
{
    public partial class waitform : Form
    {
        public waitform(Form main, bool somenteFundo)
        {
            InitializeComponent();
            this.Opacity = 0.8;


            this.Owner = main;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            if (somenteFundo)
            {
                imgLogo.Visible = false;
            }
            else
            {
                imgLogo.Location = new Point(this.Width / 2 - imgLogo.Size.Width / 2, this.Height / 2 - imgLogo.Size.Height / 2);



                string resFolder = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources");



                playerAudio.URL = resFolder + "\\" + "pular.wav";


                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;
            }
        }

        public void abrirModoEspera()
        {
            imgLogo.Visible = false;
            this.Opacity = 0.8;
        }

        public void abrirModoInvisivel()
        {
            imgLogo.Visible = false;
            this.Opacity = 0.1;
        }

        public void reabrirPular()
        {
            imgLogo.Visible = true;
            this.Opacity = 0.8;

            imgLogo.Location = new Point(this.Width / 2 - imgLogo.Size.Width / 2, this.Height / 2 - imgLogo.Size.Height / 2);

            string resFolder = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources");

            playerAudio.URL = resFolder + "\\" + "pular.wav";

            playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }




        private void PlayerAudioOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {
            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {

                playerAudio.URL = null;

                ProvaAluno parent = (ProvaAluno)this.Owner;
                parent.retornaDoFormPular();
             
            }
        }

        
    }
}
