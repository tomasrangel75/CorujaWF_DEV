using System;
using System.IO;
using System.Security;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;

namespace QuestionarioForms.Audio
{
    public partial class FormAudio : MetroForm
    {

        public string caminhoAudioFinal;

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);


        public FormAudio()
        {
            InitializeComponent();
            lblGravando.Visible = false;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            
            lblGravando.Visible = true;
            mciSendString("open new type waveaudio alias Som", "<span id=\"IL_AD10\" class=\"IL_AD\">null</span>", 0, 0);
            mciSendString("record Som", null, 0, 0);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
             lblGravando.Visible = false;
            mciSendString("pause Som", null, 0, 0);           
 
            var save = new SaveFileDialog();
 
            save.Filter = @"wave|*.wav";
 
 
            if (save.ShowDialog() == DialogResult.OK)
            {
 
                mciSendString("save Som " + save.FileName, null, 0, 0);
                mciSendString("close Som", null, 0, 0);

                caminhoAudioFinal = save.FileName;
            }
        }

        private void btnTocar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(caminhoAudioFinal))
            {
                string musica = caminhoAudioFinal;

                var open = new OpenFileDialog();
                open.Filter = @"Wave|*.wav";
                if (open.ShowDialog() == DialogResult.OK) { musica = open.FileName; }

                mciSendString("play " + musica, null, 0, 0);
            }
            else
            {
                mciSendString("play " + caminhoAudioFinal, null, 0, 0);
            }
        }


        public string envioAudio()
        {
            string retorno = null;

            OpenFileDialog dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = @"Localizar Áudio",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Filter = @"Arquivos de Áudio|*.mp3;*.wav;*.wmp;*.wma"
            };
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    string nome = dialog.FileName;

                    FileInfo info = new FileInfo(nome);

                    const long megaInBytes = 20 * 1024 * 1024;

                    if (info.Length > megaInBytes)
                    {
                        
                        MensagemErro("Erro! Arquivo de áudio maior que 20MB.");
                    }
                    else
                    {
                        retorno = nome;
                    }
                }
                catch (SecurityException ex)
                {
                    // O usuário  não possui permissão para ler arquivos
                    MensagemErro("Erro de segurança na hora de ler o arquivo Contate o administrador de segurança da rede.\n\n" +
                                                "Mensagem : " + ex.Message + "\n\n" +
                                                "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);

                    return retorno;
                }
                catch (Exception ex)
                {
                    MensagemErro("Erro ao tentar ler o arquivo.");

                    return retorno;
                }
            }

            return retorno;
        }

        private void btnEnvioAudio_Click(object sender, EventArgs e)
        {
            caminhoAudioFinal = envioAudio();
        }

        public void MensagemErro(string texto)
        {
            MetroMessageBox.Show(this, texto, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
