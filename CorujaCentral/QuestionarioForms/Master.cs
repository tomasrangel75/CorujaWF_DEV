using System;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Security;
using Library.Persistencia;
using MetroFramework.Forms;
using MetroMessageBox = MetroFramework.MetroMessageBox;
using System.Drawing.Printing;
using System.Drawing;

namespace QuestionarioForms
{
    public partial class Master : MetroForm
    {
        private PrintDocument printDocument1 = new PrintDocument();

        public Master()
        {

            InitializeComponent();

            verificaPastas();
            atualizaBanco();
        }

        public void atualizaBanco()
        {
            Gerenciador.atualizaBanco();
        }

        private void verificaPastas()
        {
            string raiz = ConfigurationManager.AppSettings["diretorio"];
            raiz = @"C:\";
            if (!Directory.Exists(raiz))
            {
                Directory.CreateDirectory(raiz);
            }

            // Verificar o local do Banco
            string localBancoAplicacao = AppDomain.CurrentDomain.BaseDirectory + "\\Banco\\DBQUEST"; 

            string localBancoUsuario = ConfigurationManager.AppSettings["localbanco"] + "\\DBQUEST";

            // Cria o Banco pela primeira vez se ele não existe ainda na maquina do usuario
            if(!File.Exists(localBancoUsuario))
            {
                if (!Directory.Exists(ConfigurationManager.AppSettings["localbanco"]))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["localbanco"]);
                }

                File.Copy(localBancoAplicacao, localBancoUsuario);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ControlBox = false;

            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                if (f.GetType() == typeof(Default))
                {
                    f.Activate();
                    return;
                }
            }
            MetroForm form1 = new Default();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.WindowState = FormWindowState.Maximized;
            form1.BringToFront();
            form1.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                f.Close();
            }
        }


        #region botoes

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                if (f.GetType() == typeof(Default))
                {
                    ((Default) f).refaz();
                    f.Activate();
                    return;
                }
            }
            MetroForm form1 = new Default();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.WindowState = FormWindowState.Maximized;
            form1.BringToFront();
            form1.Show();
        }


        private void btnQuestionario_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                if (f.GetType() == typeof(FormQuestionario))
                {
                    f.Close();
                    break;
                }
            }
            MetroForm form1 = new FormQuestionario();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnCadQuestao_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                if (f.GetType() == typeof(FormQuestao))
                {
                    f.Close();
                    break;
                }
            }
            MetroForm form1 = new FormQuestao();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm) form;
                if (f.GetType() == typeof(FormArea))
                {
                    f.Close();
                    break;
                }
            }
            MetroForm form1 = new FormArea();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }


        private void btnEscolas_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormEscola))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormEscola();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnTurma_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormTurma))
                {
                    f.Activate();
                    ((FormTurma)f).carregar();
                    return;
                }
            }
            Form form1 = new FormTurma();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnAluno_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormAlunos))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormAlunos();
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormExportar))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormExportar();
            
            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormImportar))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormImportar();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnImportarBatch_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormImportarProvas))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormImportarProvas();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnProvaAluno_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioAluno))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioAluno();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }


        private void ribbonRelatorioTurma_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioTurma))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioTurma();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void ribbonRelDistrib_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioEixos))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioEixos();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnAuxilioCadastro_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormAuxilioQuestionario))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormAuxilioQuestionario();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnPsicoAluno_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioPsico))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioPsico();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnReportAluno_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioReportAluno))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioReportAluno();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnReportTurma_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioReportTurma))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioReportTurma();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        private void btnReportTotal_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                var f = (MetroForm)form;
                if (f.GetType() == typeof(FormRelatorioReportTotal))
                {
                    f.Close();
                    break;
                }
            }
            Form form1 = new FormRelatorioReportTotal();

            form1.MdiParent = this;
            form1.ControlBox = false;
            form1.Show();
        }

        #endregion

        #region Mensagens

        public void MensagemAlerta(string texto)
        {
            MetroMessageBox.Show(this, texto, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void MensagemErro(string texto)
        {
            MetroMessageBox.Show(this, texto, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MensagemSucesso(string texto)
        {
            MetroMessageBox.Show(this, texto, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult MensagemValidarExclusao(string texto)
        {
           return  MetroMessageBox.Show(this, texto, "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        #endregion

        #region Arquivos

        public string envioImagem()
        {
            string retorno = null;

            OpenFileDialog dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = @"Localizar Imagem",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*"
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
                        MensagemErro("Erro! Arquivo de imagem maior que 20MB.");
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

        public string localizarCsv()
        {
            string retorno = null;

            OpenFileDialog dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = @"Localizar .qcsv ou .acsv",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Filter =
                    @"Texto (*.qcsv ou *.acsv)|*.qcsv; *.acsv"
            };
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    string nome = dialog.FileName;

                    FileInfo info = new FileInfo(nome);
                    
                    retorno = nome;
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

        public string envioVideo()
        {
            string retorno = null;

            OpenFileDialog dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = @"Localizar Vídeo",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    string nome = dialog.FileName;

                    FileInfo info = new FileInfo(nome);

                    const long megaInBytes = 700 * 1024 * 1024;

                    if (info.Length > megaInBytes)
                    {
                       MensagemErro("Erro! Arquivo de vídeo maior que 700MB.");
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



        #endregion

        //Bitmap memoryImage;

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            var PrintDialog1 = new PrintDialog();

            PrintDocument docToPrint =
                new PrintDocument();

            docToPrint.PrintPage += printDocument1_PrintPage;

            // Allow the user to choose the page range he or she would
            // like to print.
            PrintDialog1.AllowSomePages = true;

            // Show the help button.
            PrintDialog1.ShowHelp = true;


            PrintDialog1.Document = docToPrint;

            DialogResult result = PrintDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.DefaultPageSettings.Landscape = true;

                docToPrint.Print();
            }
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(1213, 516);

            this.ActiveMdiChild.DrawToBitmap(bmp, new Rectangle(0, 0, 1213, 516));


            Rectangle m = e.MarginBounds;

            if ((double)bmp.Width / (double)bmp.Height > (double)m.Width / (double)m.Height) // image is wider
            {
                m.Height = (int)((double)bmp.Height / (double)bmp.Width * (double)m.Width);
            }
            else
            {
                m.Width = (int)((double)bmp.Width / (double)bmp.Height * (double)m.Height);
            }
            e.Graphics.DrawImage(bmp, m);




            
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            ImportaProcessaDados newForm = new ImportaProcessaDados();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
