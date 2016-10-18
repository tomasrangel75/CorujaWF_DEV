using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Library.Persistencia;
using MetroFramework;
using MetroFramework.Controls;
using Prova.Properties;
using WMPLib;
using ContentAlignment = System.Drawing.ContentAlignment;
using System.Configuration;
using AxWMPLib;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Security;
using System.IO.Compression;
using System.Threading;
using Library.Persistencia_DbCentral;
using Library.Persistencia_DbCentral.Models;
using System.Data;
using System.Globalization;
using System.Diagnostics;

namespace Prova
{
    public partial class ProvaAluno : Form
    {

        #region vars
      
        private string esp;
        private string idPac;
        private string pac;
        private string sex;
        private DateTime dt;
        private string avalFullPath;
        private string pacFileName;

        private string novaAval;
        private string prova;
        private string idTipoProva;
        private string idAval;
        private byte iniciada = 0;
        private byte finalizada = 0;

        bool contemVideo;
        private Control painelHabilitar;
        private Questao questaoAtual;
        private Aluno alunoAtual;
        private Turma turmaAtual;
        private Instituicao escolaAtual;

        private long idEscola;
        private long idTurma;

        private Label tituloForca;
        private List<string> vetOpcoesCorretaForca;
        private List<int> vetOpcoesCorretaOrdenacao;
        private int indiceForcaAtual;
        private bool trocarQuestaoDepoisDoAudio;
        private bool parouAudio;
        private bool audioTocando;
        private ItemQuestao ultimoItemClicado;
        private DateTime tempoQuestao;
        private bool terminouProva;
        private bool acertouUltima;
        private Control botaoConfirmarPsicogenese;

        private string palavraPsicogenese;
        private string variacoesPsicogenese;
        private string palavraAluno;
        private long? ordemUltimaQuestao;

        private Image bmpBackground;

        private System.Windows.Forms.Timer timerAjuda;

        private waitform formEsperaAudio;
        private waitform formEsperaAjuda;
        private waitform formEsperaErroPsico;
        private waitform formEsperaFimPsico;
        private waitform formEsperaVideo;

        private bool ativarPararAudio = false;

        // parametros para nova questão, quando deve esconder a imagem de pergunta após um tempo Ex. tempo = 5000 (ms)
        private bool enfileirada = false;
        private Point localImagemPergunta;
        private Size tamanhoImagemPergunta;
        private Point localResposta;
        private Size tamanhoResposta;
        private int tempo = 5000;
        private int tempoApagarNomes = 1;
        private DateTime nascimento;
        private string sexo;

        //FormProvas formProvas = new FormProvas();
        FormAdm formAdmin = new FormAdm();
        WaitLoad waitLoad = new WaitLoad();

        private bool permitePular;

        private Dictionary<string, Image> vetImagensOriginais;
        private Dictionary<string, Bitmap> vetImagensPequenas;

        #endregion

        #region Useless

        #region Mensagens

        public void MensagemAlerta(string texto)
        {
            MessageBox.Show(this, texto, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void MensagemErro(string texto)
        {
            MessageBox.Show(this, texto, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MensagemSucesso(string texto)
        {
            MessageBox.Show(this, texto, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult MensagemValidarExclusao(string texto)
        {
            return MessageBox.Show(this, texto, "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        #endregion

        private void maximizarFormPrincipal()
        {
            // this.TopMost = true;
            //  this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Focus();
        }

        private void showCoverForm(Form form)
        {
            // form.TopMost = true;
            form.Visible = true;
            form.WindowState = FormWindowState.Maximized;
        }

        private void hideCoverForm(Form form)
        {
            //  form.TopMost = false;
            form.Visible = false;
            maximizarFormPrincipal();
        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                Instituicao escola = comboEscola.SelectedItem as Instituicao;
                comboTurma.Items.Clear();
                comboTurma.Enabled = true;

                foreach (var turma in escola.Turma)
                {
                    comboTurma.Items.Add(turma);
                }
                comboTurma.DisplayMember = "Nome";
            }
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                Turma turma = comboTurma.SelectedItem as Turma;

                if (turma.Aluno.Count > 0)
                {
                    comboAluno.Items.Clear();
                    comboAluno.Enabled = true;

                    foreach (var aluno in turma.Aluno)
                    {
                        comboAluno.Items.Add(aluno);
                    }

                    comboAluno.DisplayMember = "Nome";
                }
            }
            else
            {
                comboAluno.Enabled = false;
            }
        }

        private void ckOutroAluno_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOutroAluno.Checked)
            {
                txtNomeEscola.Visible = false;
                txtTurma.Visible = false;
                lblAluno.Visible = false;
                comboAluno.Visible = false;
                comboTurma.Visible = false;
                comboEscola.Visible = false;

                txtNomeEscola.Visible = true;
                txtTurma.Visible = true;
                lblnomeAlunoTxt.Visible = true;
                txtNomeAluno.Visible = true;
            }
            else
            {
                lblAluno.Visible = true;
                comboAluno.Visible = true;
                comboTurma.Visible = true;
                comboEscola.Visible = true;
                txtTurma.Visible = false;
                txtNomeEscola.Visible = false;
                lblnomeAlunoTxt.Visible = false;
                txtNomeAluno.Visible = false;
            }
        }

        public void adicionarFontes()
        {
            ////Create your private font collection object.
            //pfc = new PrivateFontCollection();

            //byte[] fontData = Resource1.SassoonPrimary;
            //IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            //System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            //uint dummy = 0;
            //pfc.AddMemoryFont(fontPtr, Resource1.SassoonPrimary.Length);

            //AddFontMemResourceEx(fontPtr, (uint)Resource1.SassoonPrimary.Length, IntPtr.Zero, ref dummy);
            //System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

        }

        public override Image BackgroundImage
        {
            get
            {
                return bmpBackground;
            }
            set
            {
                if (value != null)
                {
                    //Create new BitMap Object of the size 
                    bmpBackground = new Bitmap(value.Width, value.Height);

                    //Create graphics from image
                    System.Drawing.Graphics g =
                       System.Drawing.Graphics.FromImage(bmpBackground);

                    //set the graphics interpolation mode to heigh
                    g.InterpolationMode =
                       System.Drawing.Drawing2D.InterpolationMode.High;

                    //draw the image to the graphics to create the new image 
                    //which will be used in the onpaint background
                    g.DrawImage(value, new Rectangle(0, 0, bmpBackground.Width,
                                bmpBackground.Height));
                }
                else
                    bmpBackground = null;
            }
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            ItemQuestao pergunta = questaoAtual.ItemQuestao.ToList().Find(i => i.EPergunta == true);

            if (pergunta.ContemAudio != null && (bool)pergunta.ContemAudio)
            {
                Control painelRespostas = flowLayoutPanelPrincipal;

                painelRespostas.Enabled = false;
                painelHabilitar = painelRespostas;
                btnRepetir.Enabled = false;

                ItemArquivo arquivoAudio = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                string path = pergunta.Questao.DiretorioProva + arquivoAudio.Arquivo.NomeFisico;

                playerAudio.URL = path;
                parouAudio = false;
                audioTocando = true;

                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;

                if (!ativarPararAudio) showCoverForm(formEsperaAudio);
            }
        }

        private void btnPularVideo_Click(object sender, EventArgs e)
        {
            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;
            PlayerVideo.Ctlcontrols.stop();

            Questao questao1 = questionario.Questao.OrderBy(q => q.Ordem).First();
            pnlAlto.Controls.Clear();
            pnlBaixo.Controls.Clear();
            carregarQuestao(questao1);
            hideCoverForm(formEsperaVideo);
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            if (PlayerVideo.playState == WMPPlayState.wmppsPlaying)
            {
                PlayerVideo.Ctlcontrols.stop();
                PlayerVideo.Visible = false;
                hideCoverForm(formEsperaVideo);
            }

            if (alunoAtual == null)
            {
                alunoAtual = new Aluno();
                alunoAtual.Nome = txtNomeAluno.Text;
                alunoAtual.DataCadastro = DateTime.Now;
                Controlador.getControlador().incluirAluno(alunoAtual);
            }

            if (comboTesteQuestao.SelectedIndex >= 0)
            {
                Questao questao = comboTesteQuestao.SelectedItem as Questao;

                carregarQuestao(questao);
            }
        }

        #region metodos_genericos

        private void carregarQuestao(Questao questao)
        {
            timerAjuda.Enabled = false;
            permitePular = false;
            flowLayoutPanelPrincipal.Visible = false;
            pnlPrincipal.Visible = false;
            this.SuspendLayout();

            if ((questaoAtual == null) || (!questaoAtual.idQuestao.Equals(questao.idQuestao)))
            {
                tempoQuestao = DateTime.Now;
            }

            pnlAlto.BorderStyle = BorderStyle.None;
            questaoAtual = questao;
            limparTela();


            btnRepetir.Visible = true;


            if (questao.TipoQuestao.idTipoQuestao == 1)
            {
                carregarQuestaoMultiplaEscolha(questao);
            }
            else if (questao.TipoQuestao.idTipoQuestao == 2)
            {
                carregarQuestaoForca(questao);
            }
            else if (questao.TipoQuestao.idTipoQuestao == 3)
            {
                carregarQuestaoOrdencao(questao);
            }
            else if (questao.TipoQuestao.idTipoQuestao == 4)
            {
                carregarQuestaoPsicogenese(questao);
            }

            flowLayoutPanelPrincipal.Visible = true;
            pnlPrincipal.Visible = true;

            ItemQuestao perguntaQuest = questao.ItemQuestao.ToList().Find(i => (i.EPergunta != null) && (bool)(i.EPergunta));
            if (perguntaQuest.ContemAudio == null || ((perguntaQuest.ContemAudio != null && !(bool)perguntaQuest.ContemAudio)))
            {
                inicializaContadorAjuda();
            }

            // Para completar com as questões na parte teste.
            txtQuestaoAnterior.Text = txtQuestaoAtual.Text;
            if (questaoAtual != null)
                txtQuestaoAtual.Text = questaoAtual.Ordem.Value.ToString() + " " + questaoAtual.Competencia.ToString();

            this.ResumeLayout();
        }

        private void inicializaContadorAjuda()
        {

            // Trata a ajuda da questão
            if (timerAjuda.Enabled == false)
            {

                TimeSpan tempoAjuda = TimeSpan.FromMinutes(2);
                //TimeSpan tempoAjuda = TimeSpan.FromSeconds(5);


                timerAjuda.Enabled = true;
                timerAjuda.Interval = Convert.ToInt32(tempoAjuda.TotalMilliseconds);
                // timerAjuda.Start();

            }
        }

        public void exibeOpcaoPularAjuda(object source, EventArgs e)
        {
            if (!audioTocando)
            {
                this.Enabled = false;
                waitform wform = null;

                foreach (Form form in this.OwnedForms)
                {
                    if (form.Name == "formpular")
                    {
                        wform = (waitform)form;
                    }
                }

                if (wform == null)
                {
                    wform = new waitform(this, false);
                }
                else
                {
                    wform.reabrirPular();
                }

                wform.Owner = this;
                wform.Name = "formpular";

                showCoverForm(wform);

                //timerAjuda.Interval = Int32.MaxValue;
                timerAjuda.Stop();
            }
        }

        public void retornaDoFormPular()
        {
            this.Enabled = true;

            foreach (Form form in this.OwnedForms)
            {
                if (form.Name == "formpular")
                {

                    hideCoverForm(form);

                }

            }

            permitePular = true;
            timerAjuda.Start();
        }

        // Clicou no Pular
        private void imgLogo_Click(object sender, EventArgs e)
        {
            if (permitePular)
            {
                Pontuacao pontuacao = Controlador.getControlador()
               .getPontuacaoAluno(alunoAtual.idAluno, questaoAtual.idQuestao);

                bool acertou = false;

                // Contabiliza o tempo
                DateTime myDate2 = DateTime.Now;
                TimeSpan tsAgora = myDate2.Subtract(tempoQuestao);

                TimeSpan totalTempo = tsAgora;

                // Verifica se deve criar a pontuação
                if (pontuacao == null)
                {
                    pontuacao = new Pontuacao();
                    pontuacao.Aluno = alunoAtual;
                    pontuacao.Questao = questaoAtual;

                    pontuacao.Acertou = acertou;
                    pontuacao.Tentativas = 1;
                    pontuacao.DataHora = DateTime.Now;
                    pontuacao.Tempo = totalTempo.TotalSeconds;

                    pontuacao.adicionar(pontuacao);
                }
                else
                {
                    pontuacao.Acertou = acertou;
                    pontuacao.Tentativas = pontuacao.Tentativas + 1;
                    pontuacao.Tempo = totalTempo.TotalSeconds;

                    pontuacao.atualizar(pontuacao);
                }

                // Grava o resultado
                Resultado resultado = Controlador.getControlador().getResultadoAluno(alunoAtual.idAluno);

                if (resultado == null)
                {
                    resultado = new Resultado();
                    resultado.Aluno = alunoAtual;
                    resultado.Questionario = Controlador.getControlador().questionario;
                    resultado.TotalAcertos = 0;
                    resultado.TotalErros = 0;

                    resultado.adicionar(resultado);
                }


                resultado.atualizar(resultado);

                // Carrega a próxima questão
                Questao questao = getProximaQuestaoCasoPular();

                if (questao != null)
                {
                    this.carregarQuestao(questao);
                }
                else
                {
                    resultado.Questao = null;
                    resultado.atualizar(resultado);


                    System.Threading.Thread.Sleep(1000);
                    finalizaProva();
                }

            }
        }

        private Control redimensionaOrdenacao(Questao questao, bool contemTexto, bool contemImagem, out bool vertical)
        {
            bool verticalP, verticalR = false;
            Control painelPergunta = getPainelPelaPosicao(questao, true, out verticalP);
            Control painelRespostas = getPainelPelaPosicao(questao, false, out verticalR);

            vertical = verticalR;

            if (!verticalP && !verticalR)
            {
                // Pergunta que so tem os botões
                if (!contemTexto && !contemImagem)
                {
                    pnlDireita.Visible = false;

                    pnlDireita.Size = new Size(0, 0);
                    pnlAlto.Size = new Size(850, 300);
                    pnlBaixo.Size = new Size(850, 300);
                    pnlTopo.Size = new Size(0, 0);
                    pnlEsquerda.Size = new Size(50, 0);
                }
                else if (!(contemImagem && contemTexto)) // Contem ou texto ou imagem
                {

                    pnlDireita.Visible = false;

                    pnlDireita.Size = new Size(0, 0);
                    pnlAlto.Size = new Size(850, 250);
                    pnlBaixo.Size = new Size(850, 250);
                    pnlTopo.Size = new Size(850, 100);
                    pnlEsquerda.Size = new Size(50, 0);

                    // painelRespostas = pnlEsquerda;
                }
                else
                {
                    painelPergunta.Size = new Size(556, 216);
                }
            }

            return painelRespostas;
        }

        private Control redimensionaPsicogenese(Questao questao, bool contemTexto, bool contemImagem, out bool vertical)
        {
            bool verticalP, verticalR = false;
            Control painelPergunta = getPainelPelaPosicao(questao, true, out verticalP);
            Control painelRespostas = getPainelPelaPosicao(questao, false, out verticalR);

            vertical = verticalR;

            if (!verticalP && !verticalR)
            {
                pnlDireita.Visible = true;

                // pnlDireita.Size = new Size(0, 0);
                pnlAlto.Size = new Size(850, 300);
                pnlBaixo.Size = new Size(850, 300);
                pnlTopo.Size = new Size(0, 0);
                pnlEsquerda.Size = new Size(50, 0);
            }

            return painelRespostas;
        }

        private Control redimensionarPaineis(Questao questao, bool contemTexto, bool contemImagem, out bool vertical, out bool forcarTelaGrande)
        {
            bool verticalP, verticalR = false;
            Control painelPergunta = getPainelPelaPosicao(questao, true, out verticalP);
            Control painelRespostas = getPainelPelaPosicao(questao, false, out verticalR);

            forcarTelaGrande = false;
            vertical = verticalR;

            //pnlDireita.BorderStyle = BorderStyle.FixedSingle;
            //pnlEsquerda.BorderStyle = BorderStyle.FixedSingle;
            //pnlAlto.BorderStyle = BorderStyle.FixedSingle;
            //pnlBaixo.BorderStyle = BorderStyle.FixedSingle;
            //pnlTopo.BorderStyle = BorderStyle.FixedSingle;

            if (!verticalP && !verticalR)
            {
                // Pergunta que so tem os botões
                if (!contemTexto && !contemImagem)
                {

                    pnlDireita.Visible = false;
                    pnlAlto.Visible = false;
                    pnlBaixo.Visible = false;
                    pnlTopo.Visible = false;

                    pnlDireita.Size = new Size(0, 0);
                    pnlAlto.Size = new Size(0, 0);
                    pnlBaixo.Size = new Size(0, 0);
                    pnlTopo.Size = new Size(0, 0);
                    pnlEsquerda.Size = new Size(1100, 600);

                    painelRespostas = pnlEsquerda;
                    forcarTelaGrande = true;
                }
                else if (!(contemImagem && contemTexto)) // Contem ou texto ou imagem
                {

                    pnlDireita.Visible = false;
                    pnlTopo.Visible = false;
                    //pnlEsquerda.Visible = false;

                    pnlDireita.Size = new Size(0, 0);
                    pnlAlto.Size = new Size(800, 300);
                    pnlBaixo.Size = new Size(800, 300);
                    pnlTopo.Size = new Size(0, 0);
                    pnlEsquerda.Size = new Size(100, 0);

                    // painelRespostas = pnlEsquerda;
                    forcarTelaGrande = false;
                }
                else
                {
                    painelPergunta.Size = new Size(556, 216);
                }
            }

            return painelRespostas;
        }

        private void limparTela()
        {
            pnlAlto.Controls.Clear();
            pnlBaixo.Controls.Clear();
            pnlDireita.Controls.Clear();
            pnlEsquerda.Controls.Clear();
            pnlTopo.Controls.Clear();
            pnlAlto.Enabled = true;
            pnlBaixo.Enabled = true;
            pnlDireita.Enabled = true;
            pnlEsquerda.Enabled = true;

            pnlAlto.Size = new Size(556, 268);
            pnlBaixo.Size = new Size(556, 268);
            pnlDireita.Size = new Size(221, 599);
            pnlEsquerda.Size = new Size(221, 599);
            pnlTopo.Size = new Size(556, 100);

            pnlDireita.Visible = true;
            pnlAlto.Visible = true;
            pnlBaixo.Visible = true;
            pnlTopo.Visible = true;
            pnlEsquerda.Visible = true;

        }

        private string wrapTexto(string texto, int tamanho)
        {
            string retorno = texto;

            if ((texto.Length + tamanho / 2) > tamanho)
            {

                if ((texto.Length > tamanho) || (texto.Contains(" ")))
                {
                    retorno = "";

                    int pedacos = 1;
                    if (texto.Length > tamanho)
                    {
                        pedacos = texto.Length / tamanho + 1;
                    }
                    else
                    {
                        string[] teste = texto.Split(" ".ToCharArray());

                        int qtdPalavras = teste.Count();

                        pedacos = qtdPalavras;
                    }
                    int contadorPerdas = 0;

                    for (int i = 0; i < pedacos; i++)
                    {
                        if (!String.IsNullOrEmpty(texto))
                        {
                            int tamanhoAutal = tamanho;
                            string temp = texto;

                            if (texto.Length > tamanho)
                            {
                                temp = texto.Substring(0, tamanho);
                            }

                            if (temp.Contains(" "))
                            {
                                int indiceEspaco = temp.LastIndexOf(" ");

                                if (indiceEspaco < (tamanhoAutal - 1))
                                {
                                    contadorPerdas += tamanhoAutal - indiceEspaco;
                                    if (contadorPerdas >= tamanho)
                                        pedacos++;
                                }

                                tamanhoAutal = indiceEspaco;
                                temp = texto.Substring(0, tamanhoAutal);
                            }

                            texto = texto.Remove(texto.IndexOf(temp), temp.Length).TrimStart();

                            retorno += temp.TrimEnd() + "\n";
                        }
                    }

                    // Verifica se faltou pedaço
                    if (texto.Length > 0)
                    {
                        retorno += texto.TrimEnd();
                    }

                }
            }

            return retorno;
        }

        private void PlayerVideoFechamentoOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {
            playerAudioHover.Ctlcontrols.stop();

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {
                PlayerVideo.Visible = false;

                flowLayoutPanelPrincipal.Visible = true;
                imgLogo.Visible = true;

                pnlAlto.Controls.Clear();
                pnlBaixo.Controls.Clear();
                pnlDireita.Controls.Clear();
                pnlEsquerda.Controls.Clear();
                pnlTopo.Controls.Clear();

                Label lblFIm = new Label();
                lblFIm.Font = new Font("HelveticaRounded LT Std Bd", 50, FontStyle.Bold);
                lblFIm.Text = "FIM DA PROVA!";
                lblFIm.Dock = DockStyle.Fill;
                lblFIm.TextAlign = ContentAlignment.MiddleCenter;
                pnlAlto.Controls.Add(lblFIm);

                btnRepetir.Visible = false;
                hideCoverForm(formEsperaVideo);

                finalizada = 1;
                CloseMethod();
                terminouProva = true;
            }
        }

        private void PlayerVideoAberturaOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {
            playerAudioHover.Ctlcontrols.stop();


            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {
                PlayerVideo.Visible = false;

                flowLayoutPanelPrincipal.Visible = true;
                imgLogo.Visible = true;
                contemVideo = false;
                hideCoverForm(formEsperaVideo);

                IniciarProva();

            }
        }

        private void PlayerAudioOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {
            playerAudioHover.Ctlcontrols.stop();

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {

                painelHabilitar.Enabled = true;
                btnRepetir.Enabled = true;

                if (botaoConfirmarPsicogenese != null)
                    botaoConfirmarPsicogenese.Enabled = true;

                parouAudio = true;
                audioTocando = false;

                if (!ativarPararAudio) hideCoverForm(formEsperaAudio);

                tempoQuestao = DateTime.Now;

                if (enfileirada)
                {
                    //cobre a resposta
                    imgCobre.Location = localResposta;
                    imgCobre.Size = tamanhoResposta;
                    imgCobre.Update();
                    painelHabilitar.Update();
                    pnlBaixo.Update();
                    flowLayoutPanelPrincipal.Update();

                    // tempo que a pergunta vai ficar exposta em ms Ex: 5000ms=5
                    Thread.Sleep(tempo);

                    imgCobre.Size = new Size(tamanhoImagemPergunta.Width, tamanhoImagemPergunta.Height + 50);
                    imgCobre.Location = new Point(localResposta.X, localResposta.Y - tamanhoImagemPergunta.Height - 50);
                    imgCobre.Update();
                    painelHabilitar.Update();

                    enfileirada = false;
                }

                inicializaContadorAjuda();


            }
        }

        private void PlayerAudioAjudaOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {


            playerAudioHover.Ctlcontrols.stop();

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {
                if (!parouAudio)
                {
                    btnRepetir.Enabled = true;

                    parouAudio = true;
                    audioTocando = false;
                    painelHabilitar.Enabled = true;

                    if (trocarQuestaoDepoisDoAudio)
                    {
                        contabilizarClick();
                        trocarQuestaoDepoisDoAudio = false;
                    }

                    hideCoverForm(formEsperaAjuda);

                    //if (botaoConfirmarPsicogenese != null)
                    //    botaoConfirmarPsicogenese.Enabled = true;

                }

            }
        }

        private void PlayerAudioHoverOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {
                audioTocando = false;
            }
        }


        private void PlayerAudioFimPsicoOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {


            playerAudioHover.Ctlcontrols.stop();

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {

                if (!parouAudio)
                {
                    if (trocarQuestaoDepoisDoAudio)
                    {
                        btnRepetir.Enabled = true;

                        painelHabilitar.Enabled = true;

                        parouAudio = true;
                        audioTocando = false;
                        contabilizarClickPsico();
                    }
                }

                if (botaoConfirmarPsicogenese != null)
                    botaoConfirmarPsicogenese.Enabled = true;
                hideCoverForm(formEsperaFimPsico);


            }
        }

        private void PlayerAudioErroPsicoOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent wmpocxEventsPlayStateChangeEvent)
        {


            playerAudioHover.Ctlcontrols.stop();

            if ((WMPLib.WMPPlayState)wmpocxEventsPlayStateChangeEvent.newState == WMPLib.WMPPlayState.wmppsStopped)
            {
                if (!parouAudio)
                {
                    btnRepetir.Enabled = true;
                    audioTocando = false;

                    painelHabilitar.Enabled = true;

                    hideCoverForm(formEsperaErroPsico);

                    if (botaoConfirmarPsicogenese != null)
                        botaoConfirmarPsicogenese.Enabled = true;
                }
            }
        }


        private Control getPainelPelaPosicao(Questao questao, bool pergunta, out bool vertical)
        {
            Questao.Posicao posicao;

            if (pergunta)
            {
                posicao = (Questao.Posicao)Enum.Parse(typeof(Questao.Posicao), questao.PosicaoPergunta.ToString());
            }
            else
            {
                posicao = (Questao.Posicao)Enum.Parse(typeof(Questao.Posicao), questao.PosicaoRespostas.ToString());
            }

            if (posicao == Questao.Posicao.Acima)
            {
                vertical = false;
                return pnlAlto;
            }
            else if (posicao == Questao.Posicao.Abaixo)
            {
                vertical = false;
                return pnlBaixo;
            }
            else if (posicao == Questao.Posicao.Direita)
            {
                vertical = true;
                return pnlDireita;
            }
            else if (posicao == Questao.Posicao.Esquerda)
            {
                vertical = true;
                return pnlEsquerda;
            }
            else
            {
                vertical = false;
                return pnlBaixo;
            }
        }

        private Questao getProximaQuestaoCasoPular()
        {
            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;

            bool temSalto = false;

            if (questaoAtual.TipoQuestao_id != 4)
            {
                ItemQuestao itemComSalto = null;

                // procura uma alternativa errada com salto
                foreach (var itemQuestao in questaoAtual.ItemQuestao.ToList().OrderBy(q => q.OrdemTela))
                {
                    if (itemQuestao.Eresposta != null && itemQuestao.Eresposta == true)
                    {
                        if (itemQuestao.Salto != null && itemQuestao.Salto.Count > 0)
                        {
                            if (itemQuestao.Salto.ToList().Exists(s => s.SaltarAoErrar == true))
                            {
                                itemComSalto = itemQuestao;
                                break;
                            }
                        }
                    }
                }

                if (itemComSalto != null)
                {
                    Salto salto = null;


                    salto = itemComSalto.Salto.ToList().Find(s => s.SaltarAoErrar == true);


                    if (salto != null)
                    {
                        temSalto = true;

                        if (salto.Questao != null && salto.VoltarDoSalto == null)
                        {
                            return salto.Questao;
                        }
                    }
                }
            }

            if (!temSalto)
            {
                List<Questao> vetQuestoesOrdenadas = questionario.Questao.OrderBy(q => q.Ordem).ToList();

                int indiceAtual = vetQuestoesOrdenadas.IndexOf(questaoAtual);

                if (vetQuestoesOrdenadas.Count > indiceAtual + 1)
                {
                    Questao proxima = vetQuestoesOrdenadas[indiceAtual + 1];
                    return proxima;
                }
            }

            trocarQuestaoDepoisDoAudio = false;

            return null;
        }


        private Questao getProximaQuestao()
        {
            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;

            bool temSalto = false;

            if (questaoAtual.TipoQuestao_id == 2 || questaoAtual.TipoQuestao_id == 3)
            {
                ItemQuestao itemComSalto = null;

                // procura uma alternativa com salto
                foreach (var itemQuestao in questaoAtual.ItemQuestao.ToList().OrderBy(q => q.OrdemTela))
                {
                    if (itemQuestao.Eresposta != null && itemQuestao.Eresposta == true)
                    {
                        if (itemQuestao.Salto != null && itemQuestao.Salto.Count > 0)
                        {
                            itemComSalto = itemQuestao;
                            break;
                        }
                    }
                }

                if (itemComSalto != null)
                {
                    Salto salto = null;

                    if (acertouUltima)
                    {
                        salto = itemComSalto.Salto.ToList().Find(s => s.SaltarAoErrar == false);
                    }
                    else
                    {
                        salto = itemComSalto.Salto.ToList().Find(s => s.SaltarAoErrar == true);
                    }

                    if (salto != null)
                    {
                        temSalto = true;

                        if (salto.Questao != null && salto.VoltarDoSalto == null)
                        {
                            return salto.Questao;
                        }
                    }
                }
            }
            else if ((ultimoItemClicado != null) && (ultimoItemClicado.Salto != null && ultimoItemClicado.Salto.Count > 0))
            {
                temSalto = true;
                Salto salto = ultimoItemClicado.Salto.ToList()[0];

                if (salto.Questao != null && salto.VoltarDoSalto == null)
                {
                    return salto.Questao;
                }
            }

            if (!temSalto)
            {
                List<Questao> vetQuestoesOrdenadas = questionario.Questao.OrderBy(q => q.Ordem).ToList();

                int indiceAtual = vetQuestoesOrdenadas.IndexOf(questaoAtual);

                if (vetQuestoesOrdenadas.Count > indiceAtual + 1)
                {
                    Questao proxima = vetQuestoesOrdenadas[indiceAtual + 1];
                    return proxima;
                }
            }

            trocarQuestaoDepoisDoAudio = false;

            return null;
        }

        private void contabilizarClick()
        {
            Pontuacao pontuacao = Controlador.getControlador()
                .getPontuacaoAluno(alunoAtual.idAluno, questaoAtual.idQuestao);

            // Verifica se acertou
            bool acertou = acertouUltima;

            // Contabiliza o tempo

            DateTime myDate2 = DateTime.Now;
            TimeSpan tsAgora = myDate2.Subtract(tempoQuestao);

            TimeSpan totalTempo = tsAgora;

            // Verifica se deve criar a pontuação
            if (pontuacao == null)
            {
                pontuacao = new Pontuacao();
                pontuacao.Aluno = alunoAtual;
                pontuacao.Questao = questaoAtual;

                pontuacao.Acertou = acertou;
                pontuacao.Tentativas = 1;
                pontuacao.Clicks = ultimoItemClicado.OrdemTela.ToString() + ",";
                pontuacao.DataHora = DateTime.Now;
                pontuacao.Tempo = totalTempo.TotalSeconds;

                pontuacao.adicionar(pontuacao);
            }
            else
            {
                pontuacao.Acertou = acertou;
                pontuacao.Tentativas = pontuacao.Tentativas + 1;
                pontuacao.Clicks = pontuacao.Clicks + ultimoItemClicado.OrdemTela.ToString() + ",";
                pontuacao.Tempo = totalTempo.TotalSeconds;

                pontuacao.atualizar(pontuacao);
            }

            // Grava o resultado
            Resultado resultado = Controlador.getControlador().getResultadoAluno(alunoAtual.idAluno);

            if (resultado == null)
            {
                resultado = new Resultado();
                resultado.Aluno = alunoAtual;
                resultado.Questionario = Controlador.getControlador().questionario;
                resultado.TotalAcertos = 0;
                resultado.TotalErros = 0;

                resultado.adicionar(resultado);
            }

            bool pularParaProxima = false;

            if (!acertou)
            {
                resultado.UltimaQuestao_id = questaoAtual.idQuestao;

                if (questaoAtual.Tentativas <= pontuacao.Tentativas)
                {
                    pularParaProxima = true;
                    resultado.TotalErros = resultado.TotalErros + 1;
                }
                else
                {
                    pularParaProxima = false;
                }
            }
            else
            {
                resultado.TotalAcertos = resultado.TotalAcertos + 1;
                pularParaProxima = true;
            }

            resultado.atualizar(resultado);

            if (pularParaProxima)
            {
                // Carrega a próxima questão
                Questao questao = getProximaQuestao();

                if (acertou && questao != null)
                {
                    resultado.UltimaQuestao_id = questao.idQuestao;
                    resultado.atualizar(resultado);
                }

                if (questao != null)
                {
                    this.carregarQuestao(questao);
                }
                else
                {
                    resultado.Questao = null;
                    resultado.atualizar(resultado);

                    System.Threading.Thread.Sleep(1000);
                    finalizaProva();
                }
            }
        }

        public Bitmap GrayScaleFilter(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            /*
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();*/
            return newBitmap;

        }

        #endregion

        #region botao

        public class BotaoArredondado : Button
        {
            private int _FontSize;

            public BotaoArredondado()
            {
                this.Font = new Font("HelveticaRounded LT Std Bd", (float)10, FontStyle.Bold);
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
            }

            public int FontSize
            {
                get { return _FontSize; }
                set
                {
                    _FontSize = value;
                    this.Font = new Font("HelveticaRounded LT Std Bd", (float)_FontSize - 4, FontStyle.Bold);
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                System.Drawing.Drawing2D.GraphicsPath buttonPath =
                                 new System.Drawing.Drawing2D.GraphicsPath();

                // Set a new rectangle to the same size as the button's 
                // ClientRectangle property.
                System.Drawing.Rectangle newRectangle = this.ClientRectangle;

                // Decrease the size of the rectangle.
                newRectangle.Inflate(-10, -10);



                // Draw the button's border.
                e.Graphics.DrawEllipse(System.Drawing.Pens.Transparent, newRectangle);

                // Increase the size of the rectangle to include the border.
                newRectangle.Inflate(1, 1);

                buttonPath.StartFigure();

                buttonPath.AddArc(0, 0, 25, 25, 180, 90);

                buttonPath.AddLine(25, 0, this.Width - 25, 0);

                buttonPath.AddArc(this.Width - 25, 0, 25, 25, 270, 90);

                buttonPath.AddLine(this.Width, 25, this.Width, this.Height - 25);

                buttonPath.AddArc(this.Width - 25, this.Height - 25, 25, 25, 0, 90);

                buttonPath.AddLine(this.Width - 25, this.Height, 25, this.Height);

                buttonPath.AddArc(0, this.Height - 25, 25, 25, 90, 90);

                buttonPath.CloseFigure();


                // Create a circle within the new rectangle.
                // buttonPath.AddEllipse(newRectangle);

                // Set the button's Region property to the newly created 
                // circle region.
                this.Region = new System.Drawing.Region(buttonPath);
                base.OnPaint(e);
            }

        }

        #endregion

        #endregion

        #region inicializacao

        // 1 - Já escolheu a prova (vem do formProvas)        
        public ProvaAluno()
        {
            //formProvas.ShowDialog();
            formAdmin.ShowDialog();

            if (ConfigurationManager.AppSettings["escolheu"] != "0")
            {
                waitLoad.Show();
            }
            InitializeComponent();
           

            ///////////////////////////////////////////////////////////////////

            esp = ConfigurationManager.AppSettings["esp"];
            pac = ConfigurationManager.AppSettings["pac"];
            idPac = ConfigurationManager.AppSettings["idPac"];
            sex = ConfigurationManager.AppSettings["sexo"];
            string d = ConfigurationManager.AppSettings["d"];
            string m = ConfigurationManager.AppSettings["m"];
            string y = ConfigurationManager.AppSettings["y"];

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["d"]))
            {
                //var newDate = Convert.ToDateTime(d + "/" + m + "/" + y);
                // dt = newDate;

                dt = DateTime.ParseExact((d + "/" + m + "/" + y), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                dtNascimento.Value = dt;
            }
            else { dtNascimento.Value = DateTime.Now; }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["dt"]))
            {
                //DateTime dt = DateTime.ParseExact(ConfigurationManager.AppSettings["dt"], "ddMMyyyy HHmmss", null);
            }


            novaAval = ConfigurationManager.AppSettings["novaAval"];
            prova = ConfigurationManager.AppSettings["nomeProva"];
            idTipoProva = ConfigurationManager.AppSettings["idTipoProva"];
            idAval = ConfigurationManager.AppSettings["idAval"];

            avalFullPath = ConfigurationManager.AppSettings["avalFullPath"];
            pacFileName = idPac + pac + idTipoProva;

            ///// Interface
            lblNomeQuestionario.Text = prova;
            txtTurma.Text = esp;
            txtNomeAluno.Text = pac;
            if (ConfigurationManager.AppSettings["sexo"] == "M") { rdMacho.Checked = true; } else { rdFemea.Checked = true; };

        }

        // 2 - Load Layout and SetUp DbINI
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region Layout
            this.SuspendLayout();

            flowLayoutPanelPrincipal.Visible = false;
            pnlPrincipal.Visible = false;

            //Carrega imagem de fundo de nome BG.jpg em Resources/ Load Background Image of name BG.jpg on Resources
            this.BackgroundImage = Resources.fundos_A5_fichas_laranja;

            maximizarFormPrincipal();
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(pnlTopo);
            pnlPrincipal.Controls.Add(pnlAlto);
            pnlPrincipal.Controls.Add(pnlBaixo);
            pnlAlto.BorderStyle = BorderStyle.FixedSingle;

            lblNomeQuestionario.Font = new Font("HelveticaRounded LT Std Bd", (float)lblNomeQuestionario.FontSize, FontStyle.Bold);
            lblnomeAlunoTxt.Font = new Font("HelveticaRounded LT Std Bd", (float)lblNomeQuestionario.FontSize, FontStyle.Bold);
            lblAvisoInicial.Font = new Font("HelveticaRounded LT Std Bd", (float)lblNomeQuestionario.FontSize, FontStyle.Bold);

            flowLayoutPanelPrincipal.BackColor = Color.Transparent;
            pnlPrincipal.BackColor = Color.Transparent;

            flowLayoutPanelPrincipal.Visible = true;
            pnlPrincipal.Visible = true;
            this.ResumeLayout();

            permitePular = false;

            timerAjuda = new System.Windows.Forms.Timer();
            timerAjuda.Tick += exibeOpcaoPularAjuda;

            formEsperaAudio = new waitform(this, true);
            formEsperaAudio.Owner = this;
            formEsperaAudio.Name = "formEsperaAudio";
            hideCoverForm(formEsperaAudio);

            formEsperaAjuda = new waitform(this, true);
            formEsperaAjuda.Name = "formEsperaAjuda";
            formEsperaAjuda.Owner = this;
            hideCoverForm(formEsperaAjuda);

            formEsperaErroPsico = new waitform(this, true);
            formEsperaErroPsico.Name = "formEsperaErroPsico";
            formEsperaErroPsico.Owner = this;
            hideCoverForm(formEsperaErroPsico);

            formEsperaFimPsico = new waitform(this, true);
            formEsperaFimPsico.Name = "formEsperaFimPsico";
            formEsperaFimPsico.Owner = this;
            hideCoverForm(formEsperaFimPsico);

            formEsperaVideo = new waitform(this, true);
            formEsperaVideo.Owner = this;
            formEsperaVideo.Name = "formEsperaVideo";
            formEsperaVideo.abrirModoInvisivel();

            hideCoverForm(formEsperaVideo);
            waitLoad.Hide();

            #endregion
            /////////////////////////////////////////////////
            ManageDbIni();
            /////////////////////////////////////////////////
            SetUpAval();
            /////////////////////////////////////////////////

            btnIniciarProva.Focus();
        }

        // 2.1 -  Manage Db copy and paste e setup INI state 
        public void ManageDbIni()
        {
            if (novaAval.Equals("1"))
            {
                if (File.Exists(avalFullPath + "\\DBQUEST"))
                {
                    File.Delete(avalFullPath + "\\DBQUEST");
                }
                File.Copy(avalFullPath + "\\DbStorage" + "\\DBQUEST", avalFullPath + "\\DBQUEST",true);
            }
            else
            {   // continua prova => ja tem db com nome e id + idAval
                // Gets db Id + Nome + IdAval e transforma em dbQuest
                if (File.Exists(avalFullPath + "\\DbTemp" + "\\" + pacFileName))
                {
                    // @@@@@@@@@@@@@@@ ??????? 

                    if (File.Exists(avalFullPath + "\\DBQUEST"))
                    {
                        File.Delete(avalFullPath + "\\DBQUEST");
                    }

                    File.Move(avalFullPath + "\\DbTemp" + "\\" + pacFileName, avalFullPath + "\\DBQUEST");
                    File.Delete(avalFullPath + "\\DbTemp" + "\\" + pacFileName);
                }
                else
                {
                    if (File.Exists(avalFullPath + "\\DBQUEST"))
                    {
                        string localBanco = avalFullPath + "\\DbQuest";

                        string conn = ConfigurationManager.
                             ConnectionStrings["Banco"].ConnectionString;

                        conn = conn.Replace("#PARAMETRO#", localBanco);

                        QuestEntities qEntities = new QuestEntities(conn);
                        var esps = qEntities.Turma.ToList();
                        var pacs = qEntities.Aluno.ToList();
                        var qs = qEntities.Questionario.ToList();
                        var result = (
                            from e in esps
                            join p in pacs on e.idTurma equals p.Turma_id
                            where e.Nome.Equals(esp) && p.Nome.Equals(pac)
                            select p.idAluno).Count();
                        var quest = (from q in qs
                                     where q.Nome.Equals(prova)
                                     select q.idQuestionario).Count();
                        if (result == 0 || quest == 0)
                        {
                            MessageBox.Show("Arquivo da criança não encontrado, favor iniciar uma nova avaliação", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            int idAva = Convert.ToInt32(idAval);
                            var av = new Avaliacao();
                            av.id = idAva;
                            av.DelAval();
                            Process.GetCurrentProcess().Kill();
                        }

                    }
                }

            }
        }

        // 2.2 - Verifica se tem aluno e configura tela -  Monta o questionario
        public void SetUpAval()
        {
            if (ConfigurationManager.AppSettings["escolheu"] == "0") return;

            string localBanco = avalFullPath + "\\DbQuest";

            string conn = ConfigurationManager.
                 ConnectionStrings["Banco"].ConnectionString;

            conn = conn.Replace("#PARAMETRO#", localBanco);


            Controlador.getControlador().inicializaAplicacao(conn);

            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            #region SetUp (Altera tela se Continua ou Finalizada) 

            lblNomeQuestionario.Text = questionario.Nome;

            // GET aluno com data de cadastro mais recente + Resultado aluno atual
            Resultado resultadoAlunoAtual = null;
            alunoAtual = Controlador.getControlador().getAluno();
            if (alunoAtual != null)
            {
                resultadoAlunoAtual = questionario.Resultado.ToList().Find(a => a.Aluno_id == alunoAtual.idAluno);
            }

            // Se houver Aluno/Resultado roda
            if (questionario.Resultado != null && questionario.Resultado.Count > 0 && resultadoAlunoAtual != null)
            {
                Questao questao = resultadoAlunoAtual.Questao;

                if (questao != null)
                {
                    contemVideo = false;
                    lblAvisoInicial.Text = "Continuar prova na questão: " + questao.Ordem;
                    btnIniciarProva.Text = "Continuar";
                    btnIniciarProva.Enabled = true;
                }

            }
            else
            {
                if (questionario.Arquivo_id != null)
                {
                   // pnlBaixo.Visible = true;
                   // pnlBaixo.BringToFront();
                    pnlAlto.Visible = true;
                    // pnlAlto.Controls.Add(PlayerVideo);
                    PlayerVideo.Location = new Point(0, 0);
                    PlayerVideo.enableContextMenu = false;
                    //  PlayerVideo.Size = new Size(699, 337);
                    PlayerVideo.uiMode = "none";
                    contemVideo = true;
                    // showCoverForm(formEsperaVideo);
                }
                else
                {
                    contemVideo = false;
                }
            }

            #endregion

            #region SetUp Questionario - questoes 

            comboTesteQuestao.DisplayMember = "Ordem";

            foreach (var questao in questionario.Questao.OrderBy(q => q.Ordem))
            {
                comboTesteQuestao.Items.Add(questao);
            }

            #endregion

            Gerenciador.atualizaBanco();
        }

        #endregion

        #region botoes_aplicacao

        // 4 - INICIA PROVA
        private void btnIniciarProva_Click(object sender, EventArgs e)
        {
            iniciada = 1;
            IncluiAluno();
            IniciarProva();
        }

        private void IncluiAluno()
        {
            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Cadastra avaliação, status and dtIni		
            if (novaAval.Equals("1"))
            {

                Avaliacao aval = new Avaliacao();
                aval.Aluno_id = Convert.ToInt32(idPac);
                aval.DtIni = DateTime.Now;
                aval.Prova_id = Convert.ToInt32(idTipoProva);
                aval.Status = "Iniciada";
                aval.AddAval();
                aval.GetId();
                idAval = aval.id.ToString();


                //ALUNO ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // Cadastro aluno novo no DbQuest
                Instituicao inst = new Instituicao() { Nome = "Coruja", Descricao = "Coruja Educação" };
                Controlador.getControlador().incluirEscola(inst);
                var escola = Controlador.getControlador().getEscola();
                var idEsc = (from e in escola
                             where e.Nome.Equals("Coruja")
                             select e.idInstituicao).First();

                Turma turma = new Turma() { Nome = esp, Instituicao_id = idEsc };
                Controlador.getControlador().incluirTurma(turma);

                var turmas = Controlador.getControlador().getTurmas();
                var idTur = (from t in turmas
                             where t.Nome.Equals(esp)
                             select t.idTurma).First();

                alunoAtual = new Aluno();
                alunoAtual.Nome = pac;
                alunoAtual.Sexo = sex;
                alunoAtual.DataNascimento = dt;
                alunoAtual.DataCadastro = DateTime.Now;
                alunoAtual.Turma_id = idTur;
                Controlador.getControlador().incluirAluno(alunoAtual);
            }

        }

        private void IniciarProva()
        {

            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;
            Resultado resultadoAlunoAtual = questionario.Resultado.ToList().Find(a => a.Aluno_id == alunoAtual.idAluno);

            if (questionario.Resultado != null && questionario.Resultado.Count > 0 && resultadoAlunoAtual != null)
            {
                Questao questao = resultadoAlunoAtual.Questao;

                pnlAlto.Controls.Clear();
                pnlBaixo.Controls.Clear();

                carregarQuestao(questao);
            }
            else
            {
                if (contemVideo)
                {
                    lblAvisoInicial.Visible = false;
                    lblNomeQuestionario.Visible = false;

                    Screen myScreen = Screen.FromControl(this);
                    Rectangle area = myScreen.Bounds;

                    flowLayoutPanelPrincipal.Visible = false;
                    imgLogo.Visible = false;


                    PlayerVideo.Visible = true;
                    PlayerVideo.URL = questionario.DiretorioProva + questionario.Arquivo.NomeFisico;

                    PlayerVideo.Width = area.Width;
                    PlayerVideo.Height = area.Height;

                    PlayerVideo.PlayStateChange += PlayerVideoAberturaOnPlayStateChange;
                    PlayerVideo.enableContextMenu = false;
                    PlayerVideo.uiMode = "none";
                    showCoverForm(formEsperaVideo);

                    // btnPularVideo.Visible = true;
                    btnIniciarProva.Visible = false;
                    pnlComecar.Visible = false;
                }
                else
                {
                    Questao questao1 = questionario.Questao.OrderBy(q => q.Ordem).First();

                    pnlAlto.Controls.Clear();
                    pnlBaixo.Controls.Clear();

                    carregarQuestao(questao1);
                }
            }
        }
        // -----------------------------------------------------------------

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (!terminouProva)
            {
                DialogResult result = MensagemValidarExclusao("Tem certeza que deseja sair da prova?");

                if (result.Equals(DialogResult.OK))
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }

            this.Close();
        }

        private void btnSalvarNome_Click(object sender, EventArgs e)
        {
            // salva quando o campo já está seleciondao________________________________
            //Controlador.getControlador().limparAlunosAtuais();
            //if (comboEscola.Visible)
            //{
            //    escolaAtual = comboEscola.SelectedItem as Instituicao;
            //    idEscola = escolaAtual.idInstituicao;
            //}
            //if (comboTurma.Visible)
            //{
            //    turmaAtual = comboTurma.SelectedItem as Turma;
            //    idTurma = turmaAtual.idTurma;
            //}
            //if (comboAluno.Visible)
            //{
            //    alunoAtual = comboAluno.SelectedItem as Aluno;
            //}
            //_________________________________________________________________________

            //salva quando o campo é preenchido com um novo dado_________________________
            if (txtNomeAluno.Visible | txtNomeEscola.Visible | txtTurma.Visible)
            {

                #region ESCOLA
                if (String.IsNullOrEmpty(txtNomeEscola.Text) && comboEscola.SelectedItem == null)
                {
                    MensagemAlerta("Escreva o nome da escola antes de salvar.");
                    return;
                }
                else
                {
                    //Verifica se existe a escola que esta sendo cadastrada, se não existir cria nova e pega o idInstituicao, se existir só pega o id.
                    Instituicao escolaAtual = new Instituicao();
                    if (txtNomeEscola.Visible && txtNomeEscola != null)
                    {
                        escolaAtual.Nome = txtNomeEscola.Text;
                        int linhaEscolaTabela = Controlador.getControlador().getEscola().FindIndex(q => q.Nome == escolaAtual.Nome);

                        if (linhaEscolaTabela < 0)
                        {
                            Controlador.getControlador().incluirEscola(escolaAtual);
                            linhaEscolaTabela = Controlador.getControlador().getEscola().FindIndex(q => q.Nome == escolaAtual.Nome);
                            comboEscola.Items.Add(escolaAtual);
                        }
                        idEscola = Controlador.getControlador().getEscola()[linhaEscolaTabela].idInstituicao;
                    }
                }
                #endregion

                #region TURMA
                if (String.IsNullOrEmpty(txtTurma.Text) && comboTurma.SelectedItem == null)
                {
                    MensagemAlerta("Escreva a turma antes de salvar");
                    return;
                }
                else
                {
                    //Verifica se existe a turma que esta sendo cadastrada, se não existir cria nova e pega o idTurma, se existir só pega o id.
                    Turma turmaAtual = new Turma();
                    if (txtTurma.Visible && txtTurma != null)
                    {
                        turmaAtual.Nome = txtTurma.Text;
                        turmaAtual.Instituicao_id = idEscola;
                        Turma turmaTabela = Controlador.getControlador().getTurmas().Find(q => q.Nome == turmaAtual.Nome);
                        int linhaTurmaTabela = Controlador.getControlador().getTurmas().FindIndex(q => q.Nome == turmaAtual.Nome);

                        if (linhaTurmaTabela < 0)
                        {
                            Controlador.getControlador().incluirTurma(turmaAtual);
                            linhaTurmaTabela = Controlador.getControlador().getTurmas().FindIndex(q => q.Nome == turmaAtual.Nome);
                            comboTurma.Items.Add(turmaAtual);
                        }
                        else if (idEscola != turmaTabela.Instituicao_id)
                        {
                            Controlador.getControlador().incluirTurma(turmaAtual);
                            linhaTurmaTabela = Controlador.getControlador().getTurmas().FindIndex(q => q.Nome == turmaAtual.Nome);
                            comboTurma.Items.Add(turmaAtual);
                        }
                        idTurma = Controlador.getControlador().getTurmas()[linhaTurmaTabela].idTurma;
                    }
                }
                #endregion


                // ALUNO
                if (String.IsNullOrEmpty(txtNomeAluno.Text) && comboAluno.SelectedItem == null)
                {
                    MensagemAlerta("Escreva o nome antes de salvar.");
                    return;
                }
                else
                {
                    #region NOVO_ALUNO

                    //Verifica se existe o aluno que esta sendo cadastrada, se não existir cria novo e pega o idAluno, se existir só pega o id.
                    alunoAtual = new Aluno();
                    if (txtNomeAluno.Visible && txtNomeAluno.Text != "")
                    {
                        alunoAtual.Nome = txtNomeAluno.Text;
                        alunoAtual.Turma_id = idTurma;
                        alunoAtual.DataCadastro = DateTime.Now;
                        alunoAtual.DataNascimento = nascimento;
                        alunoAtual.Sexo = sexo;
                        Aluno alunoTabela = Controlador.getControlador().getAlunos().Find(q => q.Nome == alunoAtual.Nome);
                        int indexAlunoTabela = Controlador.getControlador().getAlunos().FindIndex(q => q.Nome == alunoAtual.Nome);

                        if (indexAlunoTabela < 0) Controlador.getControlador().incluirAluno(alunoAtual);
                        else if (idTurma != alunoTabela.Turma_id) Controlador.getControlador().incluirAluno(alunoAtual);

                        comboAluno.Items.Add(alunoAtual);
                        MensagemSucesso("Criado com sucesso!");
                    }

                    #endregion

                }
            }
            else
            {

                #region ALUNO JÁ NO BANCO

                if (comboAluno.SelectedIndex >= 0)
                {
                    alunoAtual = comboAluno.SelectedItem as Aluno;
                    alunoAtual.DataCadastro = DateTime.Now;
                    alunoAtual.atualizar(alunoAtual);
                    MensagemSucesso("Aluno Selecionado!");
                }
                else
                {
                    MensagemAlerta("Selecione um aluno antes de salvar.");
                    return;
                }

                #endregion

            }

            //comboEscola.Update();
            //comboTurma.Update();
            //comboAluno.Update();


            // atualEscola, atualTurma e atualAluno Setup

            btnIniciarProva.Enabled = true;
        }

        private void finalizaProva()
        {
            timerAjuda.Enabled = false;

            // Verifica se tem video de encerrramento
            string localProva = ConfigurationManager.AppSettings["avalFullPath"];

            string[] files = Directory.GetFiles(localProva, "VideoEncerramento*");
            bool exists = files.Length > 0;

            if (exists)
            {
                FileInfo fi = new FileInfo(files[0]);

                Screen myScreen = Screen.FromControl(this);
                Rectangle area = myScreen.Bounds;

                flowLayoutPanelPrincipal.Visible = false;
                imgLogo.Visible = false;
                PlayerVideo.enableContextMenu = false;


                PlayerVideo.Visible = true;
                PlayerVideo.URL = fi.FullName;

                PlayerVideo.Width = area.Width;
                PlayerVideo.Height = area.Height;

                PlayerVideo.PlayStateChange += PlayerVideoFechamentoOnPlayStateChange;
                PlayerVideo.enableContextMenu = false;
                PlayerVideo.stretchToFit = true;

                btnPularVideo.Visible = false;
                btnIniciarProva.Visible = false;
                pnlComecar.Visible = false;
                btnRepetir.Visible = false;
                showCoverForm(formEsperaVideo);

            }
            else
            {
                pnlAlto.Controls.Clear();
                pnlBaixo.Controls.Clear();
                pnlDireita.Controls.Clear();
                pnlEsquerda.Controls.Clear();
                pnlTopo.Controls.Clear();

                Label lblFIm = new Label();
                lblFIm.Font = new Font("HelveticaRounded LT Std Bd", 50, FontStyle.Bold);
                lblFIm.Text = "FIM DA PROVA!";
                lblFIm.Dock = DockStyle.Fill;
                lblFIm.TextAlign = ContentAlignment.MiddleCenter;
                pnlAlto.Controls.Add(lblFIm);

                btnRepetir.Visible = false;

                terminouProva = true;
            }

            this.BackgroundImage = Resources.BG_Final;

        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)

        {
            if (keyData == Keys.Escape)
            {

                if (finalizada == 1)
                {
                    MessageBox.Show("A prova foi finalizada, tecle Control + S e salve o resultado", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                };

                System.Windows.Forms.DialogResult result = MessageBox.Show(this, "Tem certeza que deseja sair da prova?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                if (result.Equals(DialogResult.OK))
                {
             
                    if (iniciada != 0)
                    {


                        // =================================================================================================================

                        ManageFile mf = new ManageFile();

                        mf.idProva = Convert.ToInt32(idTipoProva);
                        mf.idAluno = Convert.ToInt32(idPac);
                        mf.NomeAluno = pac;
                        mf.closeF = 1;
                        mf.UpdClose();
                       

                        // =================================================================================================================



                        // Manda banco para o storage
                        File.Copy(avalFullPath + "\\DBQUEST", avalFullPath + "\\DbTemp" + "\\" + pacFileName);
                    }

                    this.Close();
                }

                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                return true;
            }

            if (keyData == (Keys.Control | Keys.T))
            {
                if (pnlTestes.Visible.Equals(false))
                {
                    FormSenhaTeste formSenhaTeste = new FormSenhaTeste();
                    formSenhaTeste.ShowDialog();
                    if (ConfigurationManager.AppSettings["teste"] == "1")
                    {
                        pnlTestes.Visible = true;
                    }
                }
                else
                {
                    pnlTestes.Visible = false;
                }
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                //if (btnNovaTurma.Visible)
                //{
                //    btnNovaTurma.Visible = false;
                //    btnNovaEscola.Visible = false;
                //    btnNovoAluno.Visible = false;
                //    btnApagarAluno.Visible = false;
                //    btnApagarEscola.Visible = false;
                //    btnApagarTurma.Visible = false;
                //}
                //else
                //{
                //    btnNovaTurma.Visible = true;
                //    btnNovaEscola.Visible = true;
                //    btnNovoAluno.Visible = true;
                //    btnApagarAluno.Visible = true;
                //    btnApagarEscola.Visible = true;
                //    btnApagarTurma.Visible = true;
                //}
            }

            if (keyData == (Keys.Control | Keys.Q))
            {
                if (audioTocando)
                {
                    playerAudioHover.Ctlcontrols.stop();
                    playerAudio.Ctlcontrols.stop();
                }
            }

            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            if (keyData == (Keys.Control | Keys.S))
            {
                if (iniciada == 0) return true;

                CloseMethod();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CloseMethod()
        {
            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;

            string nomeAluno = "";
            string nomeEscola = "";
            string nomeTurma = "";

            if (alunoAtual != null)
            {
                if (!String.IsNullOrEmpty(alunoAtual.Nome))
                {
                    nomeAluno = alunoAtual.Nome;

                    if (alunoAtual.Turma != null)
                    {
                        nomeTurma = alunoAtual.Turma.Nome;

                        if (alunoAtual.Turma.Instituicao != null)
                        {
                            nomeEscola = alunoAtual.Turma.Instituicao.Nome;
                        }
                    }
                }


                string nome = nomeTurma.Replace("_", "") + "_" + questionario.Nome.Replace("_", "") + "_" + nomeAluno.Replace("_", "") + "_" +
                              DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute;

                FormSalvarResultado form = new FormSalvarResultado(nome, alunoAtual.Nome);

                form.ShowDialog();

                if (form.exportou)
                {
                    // Update ctx.Avaliacoes
                    var aval = new Avaliacao();
                    if (string.IsNullOrEmpty(idAval)) idAval = "0";
                    int _idAval = Convert.ToInt32(idAval);
                    aval.id = _idAval;
                    aval.Status = "Finalizada";
                    aval.DtFim = DateTime.Now;
                    aval.UpdStatus();

                    finalizada = 1;


                    // =================================================================================================================

                    ManageFile mf = new ManageFile();

                    mf.idProva = Convert.ToInt32(idTipoProva);
                    mf.idAluno = Convert.ToInt32(idPac);
                    mf.NomeAluno = pac;
                    mf.DelAval(); ;

                    // =================================================================================================================


                    Application.Exit();
                }
            }
        }

        #region Useless2
        // QUESTOES ///////////////////////////////////////////////////////////

        #region Questao Multipla Escolha

        public void VerificaQuestionario()
        {
            string localBanco = ConfigurationManager.AppSettings[""] + ConfigurationManager.AppSettings["dbquest"];

            string conn = ConfigurationManager.
                 ConnectionStrings["Banco"].ConnectionString;

            conn = conn.Replace("#PARAMETRO#", localBanco);

            string mensagemErro;
            // Essa partepode ser melhorada para garantir uma melhor integridade da prova aberta!!______________________________________________________
            bool questVerificado = Controlador.getControlador().verificaQuestionario(conn, out mensagemErro);

            if (questVerificado)
            {
                //InicializaQuestionario(conn);
            }
            else
            {
                MensagemErro(mensagemErro);
            }
        }

        private static Size ExpandToBound(Size image, Size boundingBox)
        {
            double widthScale = 0, heightScale = 0;
            if (image.Width != 0)
                widthScale = (double)boundingBox.Width / (double)image.Width;
            if (image.Height != 0)
                heightScale = (double)boundingBox.Height / (double)image.Height;

            double scale = Math.Min(widthScale, heightScale);

            Size result = new Size((int)(image.Width * scale),
                                (int)(image.Height * scale));
            return result;
        }

        private void carregarQuestaoMultiplaEscolha(Questao questao)
        {
            ItemQuestao pergunta = questao.ItemQuestao.ToList().Find(i => (i.EPergunta != null) && (bool)(i.EPergunta));
            bool contemAudio = false;

            bool contemTexto = (pergunta.Titulo != null && !String.IsNullOrEmpty(pergunta.Titulo));
            bool contemImagem = (pergunta.ContemImagem != null && pergunta.ContemImagem == true);

            // Redimensiona os paineis para caber a questão e retorna o painel de respostas
            bool vertical;
            bool forcarTelaGrande;
            Control painel = redimensionarPaineis(questao, contemImagem, contemTexto, out vertical, out forcarTelaGrande);

            // Carrega a Pergunta
            carregarPergunta(pergunta, out contemAudio);

            // Carrega as respostas
            painel.Visible = true;
            painel.Controls.Clear();

            FlowLayoutPanel painelRespostas = new FlowLayoutPanel();
            painelRespostas.AutoSize = true;
            int larguraBotoes = 0;

            int qtdBotoes = (questao.ItemQuestao.ToList().FindAll(i => i.Eresposta != null && (bool)i.Eresposta).Count);
            int qtdBotoesPadrao = (questao.ItemQuestao.ToList().FindAll(i => i.Eresposta != null && (bool)i.Eresposta && !String.IsNullOrEmpty(i.Titulo)).Count);
            int larguraPainelTela = painel.Width;


            Color corBotao = new Color();
            if (this.BackColor == Color.White)
            {
                corBotao = Color.LightSkyBlue;
            }
            else
            {
                corBotao = ColorTranslator.FromHtml("#D7D7D7");
            }

            int fatorAumentoImagem = 0;
            int divisaoBotoes = qtdBotoes;

            // Decide como criar os botoes em linhas
            if (contemImagem || contemTexto)
            {
                if (qtdBotoes > 4)
                    divisaoBotoes = divisaoBotoes / 2 + (divisaoBotoes % 2 > 0 ? 1 : 0);
            }
            else
            {
                if (qtdBotoes > 3)
                    divisaoBotoes = divisaoBotoes / 2 + (divisaoBotoes % 2 > 0 ? 1 : 0);
            }

            if (!vertical)
            {
                painelRespostas.FlowDirection = FlowDirection.LeftToRight;
                painelRespostas.MaximumSize = new Size(larguraPainelTela, painel.Height);
                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Width;
                if (divisaoBotoes > 0)
                    larguraBotoes = (largurapainel / divisaoBotoes) - 10;
                else
                {
                    larguraBotoes = largurapainel;
                }
            }
            else
            {
                painelRespostas.FlowDirection = FlowDirection.TopDown;
                painelRespostas.MaximumSize = new Size(larguraPainelTela, painel.Height);
                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Height;
                larguraBotoes = (largurapainel / divisaoBotoes) - 10;
            }

            bool imagensNaHorizontal = true;

            foreach (var itemQuestao in questao.ItemQuestao.OrderBy(q => q.OrdemTela))
            {
                if (itemQuestao.Eresposta != null && (bool)itemQuestao.Eresposta)
                {
                     if (itemQuestao.ContemImagem != null && (bool)itemQuestao.ContemImagem)
                    {
                        ItemArquivo arquivoImagem = itemQuestao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                        string path = itemQuestao.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                        Image imagem = new Bitmap(path);

                        if (imagem.Width / imagem.Height > 0.6)
                        {
                            imagensNaHorizontal = false;
                        }
                    }
                }
            }

            int menorTamanhoBotoes = 11;

            vetImagensOriginais = new Dictionary<string, Image>();
            vetImagensPequenas = new Dictionary<string, Bitmap>();


            foreach (var itemQuestao in questao.ItemQuestao.OrderBy(q => q.OrdemTela))
            {
                if (itemQuestao.Eresposta != null && (bool)itemQuestao.Eresposta)
                {
                    Control botao = null;
                    if (itemQuestao.ContemImagem != null && (bool)itemQuestao.ContemImagem)
                    {
                        // Cria a imagem a partir do caminho fisico
                        ItemArquivo arquivoImagem = itemQuestao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                        string path = itemQuestao.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                        Image imagem = new Bitmap(path);
                        Size tamanhoBotao = new Size(0, 0);
                        Size novoTamanho = new Size(0, 0);

                        tamanhoBotao = new Size(larguraBotoes + fatorAumentoImagem, larguraBotoes + fatorAumentoImagem - 10);

                        /*if (questao.Enfileirada == true && imagem.Size.Height >= 500)
                        {
                            tamanhoBotao.Height = 500;
                        }*/

                        novoTamanho = ExpandToBound(imagem.Size, tamanhoBotao);

                        // Imagem ficou muito alta, recalcula
                        if (/*questao.Enfileirada == false &&*/ novoTamanho.Height > 127)
                        {
                            tamanhoBotao = new Size(larguraBotoes + fatorAumentoImagem, 127);
                            novoTamanho = ExpandToBound(imagem.Size, tamanhoBotao);
                        }

                        botao = new Button();

                        if (/*questao.Enfileirada == false &&*/ forcarTelaGrande)
                        {
                            botao.Margin = new Padding(10);
                            int largura, altura = 0;
                            largura = tamanhoBotao.Width;
                            largura -= 40;
                            altura = tamanhoBotao.Width - 40;

                            if (qtdBotoes > 3)
                            {
                                altura = painel.Height / 2 - 30;
                            }

                            if (imagensNaHorizontal)
                            {
                                altura = painel.Height - 30;
                                largura = largura / 2 - 10;
                            }


                            tamanhoBotao = new Size(largura, altura);
                            novoTamanho = ExpandToBound(imagem.Size, tamanhoBotao);
                        }


                        Image redimensionada = imagem.GetThumbnailImage(novoTamanho.Width, novoTamanho.Height, null,
                            IntPtr.Zero);

                        if (forcarTelaGrande) novoTamanho.Height = tamanhoBotao.Height;


                        (botao as Button).FlatStyle = FlatStyle.Flat;
                        (botao as Button).FlatAppearance.BorderSize = 0;
                        // (botao as Button).FlatAppearance.BorderColor = Color.Yellow;
                        (botao as Button).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                        (botao).Width = tamanhoBotao.Width;
                        (botao).Height = novoTamanho.Height;
                        (botao).Name = itemQuestao.idItemQuestao.ToString();
                        (botao).Click += AlternativaClick;
                        (botao).MouseHover += AlternativaHover;
                        (botao).MouseLeave += AlternativaLeave;
                        (botao).BackgroundImage = redimensionada;
                        (botao).BackgroundImageLayout = ImageLayout.Center;


                        // Cria a imagem de Hover
                        vetImagensOriginais.Add(botao.Name, redimensionada);

                        Image imgPequena = redimensionada.GetThumbnailImage((int)(redimensionada.Width * 0.9),
                            (int)(redimensionada.Height * 0.9), null, new IntPtr());

                        Bitmap imgBitMap = new Bitmap(imgPequena);
                        // Bitmap imagBitPequena = GrayScaleFilter(imgBitMap);
                        vetImagensPequenas.Add(botao.Name, imgBitMap);



                    }
                    else if (!String.IsNullOrEmpty(itemQuestao.Titulo))
                    {

                        botao = new BotaoArredondado();
                        int larguraAtual = larguraBotoes;
                        int altura = larguraAtual - 10;

                        if (!forcarTelaGrande)
                        {
                            if (qtdBotoes > 4)
                            {
                                // Verifica se o botao ficara grande
                                if (larguraAtual > 175)
                                {
                                    larguraAtual = larguraAtual / 2 - 10;
                                    altura = larguraAtual - 10;
                                }
                                else if (larguraAtual > 137)
                                {
                                    if (qtdBotoes > 3)
                                    {
                                        altura = painel.Height / 2 - 10;
                                    }
                                }
                            }
                        }
                        else
                        {
                            botao.Margin = new Padding(10);
                            larguraAtual -= 40;
                            altura = larguraAtual - 20;
                            if (qtdBotoes > 3)
                            {
                                altura = painel.Height / 2 - 30;
                            }
                        }

                        (botao as BotaoArredondado).FontSize = 20;

                        // Verifica o tamanho do texto a inserir
                        if (itemQuestao.Titulo.Length < larguraAtual / 15)
                        {
                            float largura = (larguraAtual / 12);
                            float tam = itemQuestao.Titulo.Length;

                            if (itemQuestao.Titulo.Length == 1)
                                (botao as BotaoArredondado).FontSize = 50;
                            else if ((tam / largura) > 0.6)
                                (botao as BotaoArredondado).FontSize = 21;
                            else if ((tam / largura) > 0.4)
                                (botao as BotaoArredondado).FontSize = 25;
                            else if ((tam / largura) > 0.3)
                                (botao as BotaoArredondado).FontSize = 28;
                            else if ((tam / largura) > 0.1)
                                (botao as BotaoArredondado).FontSize = 38;
                            else if ((tam / largura) > 0.04)
                                (botao as BotaoArredondado).FontSize = 50;
                        }

                        int tamanhoLocal = (botao as BotaoArredondado).FontSize;

                        if (menorTamanhoBotoes == 11)
                        {
                            menorTamanhoBotoes = tamanhoLocal;
                        }
                        else
                        {
                            if (tamanhoLocal < menorTamanhoBotoes)
                            {
                                menorTamanhoBotoes = tamanhoLocal;
                            }
                        }

                        // Verifica se o tamanho continua grande
                        int pedacos = itemQuestao.Titulo.Length / (larguraAtual / 17) + 1;

                        int larguraParaCalculo = larguraAtual;

                        if (pedacos > 5)
                        {
                            menorTamanhoBotoes = menorTamanhoBotoes - 4;
                            larguraParaCalculo += 60;
                        }
                        else if (pedacos > 4)
                        {
                            menorTamanhoBotoes = menorTamanhoBotoes - 3;
                            larguraParaCalculo += 40;
                        }
                        botao.Text = wrapTexto(itemQuestao.Titulo, larguraParaCalculo / 17);

                        if (botao.Text.Contains("%%"))
                        {
                            botao.Text = botao.Text.Replace("\n", "").Replace("%%", "");
                        }

                        if (botao.Text.Contains("--"))
                        {
                            botao.Text = botao.Text.Replace("\n", "").Replace("--", "\n");
                        }


                        botao.Width = larguraAtual;
                        botao.Height = altura;
                        botao.Name = itemQuestao.idItemQuestao.ToString();
                        botao.Click += AlternativaClick;
                        botao.MouseHover += AlternativaHover;
                        botao.MouseLeave += AlternativaLeave;
                        botao.BackColor = corBotao;

                        (botao as BotaoArredondado).FlatStyle = FlatStyle.Flat;
                        (botao as BotaoArredondado).FlatAppearance.BorderSize = 2;
                        (botao as BotaoArredondado).FlatAppearance.BorderColor = corBotao;

                        botao.Anchor = AnchorStyles.None;

                    }

                    painelRespostas.Controls.Add(botao);
                }
            }

            if (menorTamanhoBotoes >= 11)
            {
                foreach (var control in painelRespostas.Controls)
                {
                    if (control.GetType().Name == "BotaoArredondado")
                        (control as BotaoArredondado).FontSize = menorTamanhoBotoes;
                }
            }
            else
            {
                foreach (var control in painelRespostas.Controls)
                {
                    if (control.GetType().Name == "BotaoArredondado")
                        (control as BotaoArredondado).FontSize = 15;
                }
            }

            if (contemAudio)
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = false;
                btnRepetir.Enabled = false;
                parouAudio = true;
                audioTocando = true;
            }
            else
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = true;
                btnRepetir.Enabled = true;
                parouAudio = false;

            }

            painel.Height = painelRespostas.Height;


            if (questao.Enfileirada == true)
            {
                enfileirada = true;
                // primeira tela: cobre pergunta e resposta
                imgCobre.BringToFront();
                imgCobre.Location = flowLayoutPanelPrincipal.Location;
                imgCobre.Size = flowLayoutPanelPrincipal.Size;
                imgCobre.Visible = true;

                // segunda tela: cobre as respostas
                tamanhoResposta = new Size(larguraBotoes * qtdBotoes + 100, painelRespostas.Height + 100);
                localResposta = new Point(imgCobre.Location.X + pnlEsquerda.Width, imgCobre.Location.Y + pnlAlto.Height);

            }

            else
            {
                //enfil fix 2
                tamanhoResposta = new Size(0, 0);
                localResposta = new Point(0, 0);
                imgCobre.SendToBack();
                imgCobre.Update();
                painelHabilitar.Update();
                pnlBaixo.Update();
                flowLayoutPanelPrincipal.Update();

                enfileirada = false;
                imgCobre.Visible = false;
            }
        }

        private void AlternativaLeave(object sender, EventArgs eventArgs)
        {
            string indice = (sender as Button).Name;

            if (vetImagensOriginais != null)
            {
                Image imgOut;
                vetImagensOriginais.TryGetValue(indice, out imgOut);
                (sender as Button).BackgroundImage = imgOut;

                (sender as Button).Refresh();
            }
        }

        private void AlternativaHover(object sender, EventArgs eventArgs)
        {
            string indice = (sender as Button).Name;
            Bitmap imgOut;
            if (vetImagensPequenas != null)
            {
                vetImagensPequenas.TryGetValue(indice, out imgOut);
                (sender as Button).BackgroundImage = imgOut;

                (sender as Button).Refresh();
            }


            string idItem = (sender as Control).Name;
            ItemQuestao alternativa = questaoAtual.ItemQuestao.ToList().Find(i => i.idItemQuestao.ToString() == idItem);

            if (alternativa != null)
            {
                ItemArquivo itemAudioHover =
                    alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioLeitura);

                if (itemAudioHover != null)
                {
                    string path = alternativa.Questao.DiretorioProva + itemAudioHover.Arquivo.NomeFisico;
                    playerAudioHover.PlayStateChange += PlayerAudioHoverOnPlayStateChange;
                    playerAudioHover.URL = path;
                    audioTocando = true;
                }
            }
        }

        private void AlternativaClick(object sender, EventArgs eventArgs)
        {
            string idItem = (sender as Control).Name;
            ItemQuestao alternativa = questaoAtual.ItemQuestao.ToList().Find(i => i.idItemQuestao.ToString() == idItem);
            trocarQuestaoDepoisDoAudio = false;
            ultimoItemClicado = alternativa;

            //enfileirada fix 3 - deve ter update desnecessário. Atentar.
            /*if (questaoAtual.Enfileirada == true)
            {   
                tamanhoResposta = new Size(0, 0);
                localResposta = new Point(0, 0);
                imgCobre.Visible = false;
                imgCobre.SendToBack();
                imgCobre.Update();
                painelHabilitar.Update();
                pnlBaixo.Update();
                flowLayoutPanelPrincipal.Update();
            }*/


            if (alternativa.OpcaoCorreta != null && (bool)alternativa.OpcaoCorreta)
            {
                acertouUltima = true;
                // Procura um áudio especifico para esse item
                ItemArquivo itemAudioArquivo =
                    alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioSucessoOpcao);

                if (itemAudioArquivo == null)
                {
                    // Procura Audio sucesso
                    ItemQuestao audioPadrao =
                        alternativa.Questao.ItemQuestao.ToList()
                            .Find(i => (i.ETentativa != null && (bool)i.ETentativa) &&
                                       (i.OpcaoCorreta != null && (bool)i.OpcaoCorreta) &&
                                       (i.ContemAudio != null && (bool)i.ContemAudio));

                    if (audioPadrao != null)
                        itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                }

                if (itemAudioArquivo != null)
                {
                    string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                    playerAudioAlternativas.URL = path;


                    painelHabilitar = flowLayoutPanelPrincipal;
                    painelHabilitar.Enabled = false;
                    btnRepetir.Enabled = false;

                    playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                    parouAudio = false;
                    audioTocando = true;
                    trocarQuestaoDepoisDoAudio = true;
                    showCoverForm(formEsperaAjuda);
                }
                else
                {
                    trocarQuestaoDepoisDoAudio = false;
                    contabilizarClick();
                }
            }
            else
            {
                acertouUltima = false;
                // Procura um áudio especifico para esse item
                ItemArquivo itemAudioArquivo =
                    alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioErroOpcao);

                if (itemAudioArquivo == null)
                {
                    // Procura Audio Erro Padrao
                    ItemQuestao audioPadrao =
                      alternativa.Questao.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa)
                          && (i.OpcaoCorreta != null && !(bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));


                    if (audioPadrao != null)
                        itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                }

                if (itemAudioArquivo != null)
                {
                    string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                    playerAudioAlternativas.URL = path;


                    painelHabilitar = flowLayoutPanelPrincipal;
                    painelHabilitar.Enabled = false;
                    btnRepetir.Enabled = false;

                    playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                    parouAudio = false;
                    audioTocando = true;
                    trocarQuestaoDepoisDoAudio = true;

                    showCoverForm(formEsperaAjuda);
                }
                else
                {
                    trocarQuestaoDepoisDoAudio = false;
                    contabilizarClick();
                }
            }
        }

        private void carregarPergunta(ItemQuestao pergunta, out bool contemAudio)
        {
            bool vertical;
            bool contemImagem = false;
            Control painel = getPainelPelaPosicao(pergunta.Questao, true, out vertical);

            painel.Controls.Clear();
            contemAudio = false;

            if (pergunta.ContemImagem != null && (bool)pergunta.ContemImagem)
            {
                // Cria a imagem a partir do caminho fisico
                ItemArquivo arquivoImagem = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                string path = pergunta.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                Image imagem = new Bitmap(path);
                contemImagem = true;

                // Cria o controle de tela para exibir a imagem
                PictureBox boxImagem = new PictureBox();
                boxImagem.Width = imagem.Width;
                boxImagem.Height = imagem.Height;

                if (pergunta.Titulo != null && pergunta.Titulo.Length > 1)
                {
                    if (imagem.Height > 200)
                    {
                        boxImagem.Height = 200;
                    }

                    if (imagem.Width > 500)
                    {
                        boxImagem.Width = 500;
                    }
                }
                else
                {
                    if (imagem.Height > 290)
                    {
                        boxImagem.Height = 290;
                    }

                    if (imagem.Width > 800)
                    {
                        boxImagem.Width = 800;
                    }
                }

                boxImagem.SizeMode = PictureBoxSizeMode.Zoom;

                // Seta a posicao da imagem
                if ((painel.Width / 2 - boxImagem.Width / 2) > 0)
                    boxImagem.Location = new Point(painel.Width / 2 - boxImagem.Width / 2, 0);
                else
                    boxImagem.Location = new Point(0, 0);

                boxImagem.Image = imagem;
                painel.Controls.Add(boxImagem);


                tamanhoImagemPergunta = boxImagem.Size;
                localImagemPergunta = flowLayoutPanelPrincipal.Location;

                if (painel.Height < boxImagem.Height)
                    painel.Height = boxImagem.Height;


                if (painel.Width < boxImagem.Width)
                {
                    painel.Width = boxImagem.Width;
                    pnlPrincipal.Width = boxImagem.Width;
                }

            }

            if (pergunta.Titulo != null && pergunta.Titulo.Length > 1)
            {
                var labelTitulo = new Label();

                // Verifica se contem partes sublinhadas na pergunta
                if (pergunta.Titulo.Contains("#S"))
                {
                    labelTitulo = new LinkLabel();
                    (labelTitulo as LinkLabel).Links.Clear();
                    (labelTitulo as LinkLabel).LinkColor = labelTitulo.ForeColor;
                    (labelTitulo as LinkLabel).DisabledLinkColor = labelTitulo.ForeColor;

                    string textTemp = pergunta.Titulo;

                    bool continuarProcurando = true;

                    while (continuarProcurando)
                    {
                        int start = textTemp.IndexOf("#S");
                        if (start >= 0)
                        {
                            textTemp = textTemp.Remove(start, 2);

                            int end = textTemp.IndexOf("#S");
                            if (end >= 0)
                            {
                                textTemp = textTemp.Remove(end, 2);
                                pergunta.Titulo = textTemp;

                                (labelTitulo as LinkLabel).Links.Add(start, (end - start)).Enabled = false;
                            }
                        }

                        int teste = textTemp.IndexOf("#S");
                        if (teste < 0)
                        {
                            continuarProcurando = false;
                        }
                    }
                }


                labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 20, FontStyle.Bold);
                labelTitulo.TextAlign = ContentAlignment.MiddleCenter;

                if (pergunta.Titulo.Length < 40)
                {
                    labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
                    labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 30, FontStyle.Bold);
                }
                else if (pergunta.Titulo.Length > 400)
                {
                    labelTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                }
                else if (pergunta.Titulo.Length > 200)
                {
                    labelTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 15, FontStyle.Bold);
                }

                labelTitulo.Text = pergunta.Titulo;

                labelTitulo.Dock = DockStyle.Fill;


                // Se a pergunta tambem contem imagem joga o texto para cima
                if (pergunta.ContemImagem != null && (bool)pergunta.ContemImagem)
                {
                    pnlTopo.Controls.Add(labelTitulo);
                }
                else
                {
                    painel.Controls.Add(labelTitulo);
                }

            }


            if (pergunta.ContemAudio != null && (bool)pergunta.ContemAudio)
            {
                ItemArquivo arquivoAudio = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                string path = pergunta.Questao.DiretorioProva + arquivoAudio.Arquivo.NomeFisico;

                playerAudio.URL = path;
                contemAudio = true;
                parouAudio = false;
                audioTocando = true;

                if (!ativarPararAudio) showCoverForm(formEsperaAudio);

                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;

            }

        }

        #endregion

        #region Questao Forca

        private void carregarQuestaoForca(Questao questao)
        {
            ItemQuestao pergunta = questao.ItemQuestao.ToList().Find(i => (i.EPergunta != null) && (bool)(i.EPergunta));
            bool contemAudio = false;
            carregarPerguntaForca(pergunta, out contemAudio);

            // Carrega as respostas
            bool vertical;
            Control painel = getPainelPelaPosicao(questao, false, out vertical);
            painel.Controls.Clear();

            FlowLayoutPanel painelRespostas = new FlowLayoutPanel();
            painelRespostas.AutoSize = true;
            int larguraBotoes;


            // Conta quantos botoes aparecerao na tela para calcular a largura deles
            List<string> vetOpcoesBotoes = new List<string>();
            int qtd = 0;
            foreach (var itemBotao in questao.ItemQuestao)
            {
                if (itemBotao.Eresposta != null && (bool)itemBotao.Eresposta)
                {
                    if (!vetOpcoesBotoes.Contains(itemBotao.Titulo))
                    {
                        qtd++;
                        vetOpcoesBotoes.Add(itemBotao.Titulo);
                    }
                }
            }

            Color corBotao = new Color();
            if (this.BackColor == Color.White)
            {
                corBotao = Color.LightSkyBlue;
            }
            else
            {
                corBotao = ColorTranslator.FromHtml("#D7D7D7");
            }

            tituloForca.Text = "";

            if (!vertical)
            {
                painelRespostas.FlowDirection = FlowDirection.LeftToRight;

                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Width;
                larguraBotoes = (largurapainel / qtd) - 3;
            }
            else
            {
                painelRespostas.FlowDirection = FlowDirection.TopDown;

                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Height;
                larguraBotoes = (largurapainel / qtd) - 3;
            }

            // Verifica se deve criar duas linhas de botoes
            if (questao.Enfileirada == null || !(bool)questao.Enfileirada)
            {
                int largurapainel = painel.Height;

                if (qtd > 3)
                    larguraBotoes = (largurapainel / (qtd / 2 + (qtd % 2 > 0 ? 1 : 0))) - 3;
            }


            List<string> vetOpcoesForca = new List<string>();
            vetOpcoesCorretaForca = new List<string>();
            indiceForcaAtual = 0;

            foreach (var itemCorreto in questao.ItemQuestao.OrderBy(q => q.OrdemResposta))
            {
                if (itemCorreto.Eresposta != null && (bool)itemCorreto.Eresposta)
                {
                    if (itemCorreto.OpcaoCorreta != null && (bool)itemCorreto.OpcaoCorreta)
                    {
                        if (itemCorreto.OrdemResposta != null && itemCorreto.OrdemResposta >= 0)
                        {
                            vetOpcoesCorretaForca.Add(itemCorreto.Titulo);
                        }
                    }
                }
            }

            foreach (var itemQuestao in questao.ItemQuestao.OrderBy(q => q.OrdemTela))
            {
                if (itemQuestao.Eresposta != null && (bool)itemQuestao.Eresposta)
                {
                    if (itemQuestao.OpcaoCorreta != null && (bool)itemQuestao.OpcaoCorreta)
                    {
                        tituloForca.Text += "_ ";
                    }

                    if (!vetOpcoesForca.Contains(itemQuestao.Titulo))
                    {
                        vetOpcoesForca.Add(itemQuestao.Titulo);

                        Control botao = null;
                        if (!String.IsNullOrEmpty(itemQuestao.Titulo))
                        {
                            int larguraAtual = larguraBotoes;

                            int altura = larguraAtual - 10;

                            // Verifica se o botao ficara grande
                            if (larguraAtual > 175)
                            {
                                larguraAtual = larguraAtual / 2 - 10;
                                altura = larguraAtual - 10;
                            }
                            else if (larguraAtual > 137)
                            {
                                if (qtd > 3)
                                {
                                    altura = painel.Height / 2 - 10;
                                }
                            }

                            botao = new BotaoArredondado();

                            (botao as BotaoArredondado).FontSize = 16;

                            // Verifica o tamanho do texto a inserir
                            if (itemQuestao.Titulo.Length < larguraAtual / 10)
                            {
                                float largura = (larguraAtual / 10);
                                float tam = itemQuestao.Titulo.Length;

                                if (itemQuestao.Titulo.Length == 1)
                                    (botao as BotaoArredondado).FontSize = 50;
                                else if ((tam / largura) > 0.55)
                                    (botao as BotaoArredondado).FontSize = 16;
                                else if ((tam / largura) > 0.4)
                                    (botao as BotaoArredondado).FontSize = 19;
                                else if ((tam / largura) > 0.3)
                                    (botao as BotaoArredondado).FontSize = 25;
                                else if ((tam / largura) > 0.2)
                                    (botao as BotaoArredondado).FontSize = 30;
                                else if ((tam / largura) > 0.1)
                                    (botao as BotaoArredondado).FontSize = 40;

                            }

                            botao.Text = wrapTexto(itemQuestao.Titulo, larguraAtual / 10);

                            if (botao.Text.Contains("%%"))
                            {
                                botao.Text = botao.Text.Replace("\n", "").Replace("%%", "");
                            }

                            if (botao.Text.Contains("--"))
                            {
                                botao.Text = botao.Text.Replace("\n", "").Replace("--", "\n");
                            }


                            botao.Width = larguraAtual;
                            botao.Height = altura;
                            botao.Name = itemQuestao.idItemQuestao.ToString();
                            botao.Click += AlternativaForcaClick;
                            botao.MouseHover += AlternativaHover;
                            botao.BackColor = corBotao;
                            (botao as BotaoArredondado).FlatAppearance.BorderSize = 2;
                            (botao as BotaoArredondado).FlatAppearance.BorderColor = corBotao;
                        }

                        painelRespostas.Controls.Add(botao);
                    }
                }
            }

            if (contemAudio)
            {

                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = false;
                btnRepetir.Enabled = false;
            }
            else
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = true;
                btnRepetir.Enabled = true;
            }
        }

        private void AlternativaForcaClick(object sender, EventArgs eventArgs)
        {
            bool errou;
            string idItem = (sender as Control).Name;
            ItemQuestao alternativa = questaoAtual.ItemQuestao.ToList().Find(i => i.idItemQuestao.ToString() == idItem);
            ultimoItemClicado = alternativa;

            if (alternativa.OpcaoCorreta != null && (bool)alternativa.OpcaoCorreta)
            {
                if (alternativa.Titulo.Equals(vetOpcoesCorretaForca[0]))
                {
                    //ACERTOU
                    acertouUltima = true;

                    errou = false;

                    string titForcaTela = tituloForca.Text;

                    titForcaTela = titForcaTela.Remove(indiceForcaAtual, 1);
                    titForcaTela = titForcaTela.Insert(indiceForcaAtual, alternativa.Titulo);

                    tituloForca.Text = titForcaTela;
                    this.Refresh();
                    indiceForcaAtual += 2;

                    vetOpcoesCorretaForca.RemoveAt(0);




                    // Procura um áudio especifico para esse item
                    ItemArquivo itemAudioArquivo =
                        alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioSucessoOpcao);

                    if (itemAudioArquivo == null)
                    {
                        // Procura Audio sucesso Padrao
                        ItemQuestao audioPadrao =
                                alternativa.Questao.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa)
                                    && (i.OpcaoCorreta != null && (bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));

                        if (audioPadrao != null)
                            itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                    }

                    if (itemAudioArquivo != null)
                    {
                        string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                        playerAudioAlternativas.URL = path;


                        painelHabilitar = flowLayoutPanelPrincipal;
                        painelHabilitar.Enabled = false;
                        btnRepetir.Enabled = false;

                        playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                        parouAudio = false;
                        audioTocando = true;
                        trocarQuestaoDepoisDoAudio = false;

                        if (vetOpcoesCorretaForca.Count == 0)
                        {
                            trocarQuestaoDepoisDoAudio = true;
                            indiceForcaAtual = 0;
                        }

                        showCoverForm(formEsperaAjuda);
                    }
                    else
                    {
                        trocarQuestaoDepoisDoAudio = false;
                        if (vetOpcoesCorretaForca.Count == 0)
                        {
                            indiceForcaAtual = 0;
                            contabilizarClick();
                        }
                    }

                }
                else
                {
                    //ERROU
                    errou = true;
                }
            }
            else
            {
                //errou
                errou = true;
            }

            if (errou)
            {
                acertouUltima = false;
                // Procura um áudio especifico para esse item
                ItemArquivo itemAudioArquivo =
                    alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioErroOpcao);

                if (itemAudioArquivo == null)
                {
                    // Procura Audio Erro Padrao
                    ItemQuestao audioPadrao =
                        alternativa.Questao.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa) && (i.OpcaoCorreta != null
                            && !(bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));

                    if (audioPadrao != null)
                        itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                }

                if (itemAudioArquivo != null)
                {
                    string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                    playerAudioAlternativas.URL = path;


                    painelHabilitar = flowLayoutPanelPrincipal;
                    painelHabilitar.Enabled = false;
                    btnRepetir.Enabled = false;

                    playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                    parouAudio = false;
                    audioTocando = true;
                    trocarQuestaoDepoisDoAudio = true;

                    showCoverForm(formEsperaAjuda);
                }
                else
                {
                    trocarQuestaoDepoisDoAudio = false;
                    contabilizarClick();
                }
            }
        }

        private void carregarPerguntaForca(ItemQuestao pergunta, out bool contemAudio)
        {
            bool vertical;
            Control painel = getPainelPelaPosicao(pergunta.Questao, true, out vertical);
            painel.Controls.Clear();

            tituloForca = new Label();
            tituloForca.Font = new Font("HelveticaRounded LT Std Bd", 30, FontStyle.Bold);
            tituloForca.Dock = DockStyle.Fill;
            tituloForca.TextAlign = ContentAlignment.MiddleCenter;
            painel.Controls.Add(tituloForca);

            contemAudio = false;

            painel.Size = new Size(556, 216);


            if (pergunta.ContemImagem != null && (bool)pergunta.ContemImagem)
            {
                // Cria a imagem a partir do caminho fisico
                ItemArquivo arquivoImagem = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                string path = pergunta.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                Image imagem = new Bitmap(path);

                // Cria o controle de tela para exibir a imagem
                PictureBox boxImagem = new PictureBox();
                boxImagem.Width = imagem.Width;
                boxImagem.Height = imagem.Height;

                boxImagem.Image = imagem;
                pnlTopo.Controls.Add(boxImagem);

                if (imagem.Height > 200)
                {
                    boxImagem.Height = 200;
                }

                if (imagem.Width > 500)
                {
                    boxImagem.Width = 500;
                }

                boxImagem.SizeMode = PictureBoxSizeMode.Zoom;

                // Seta a posicao da imagem
                if ((painel.Width / 2 - boxImagem.Width / 2) > 0)
                    boxImagem.Location = new Point(painel.Width / 2 - boxImagem.Width / 2, 0);
                else
                    boxImagem.Location = new Point(0, 0);
            }
            else
            {
                if (pergunta.Titulo != null && pergunta.Titulo.Length > 1)
                {
                    Label labelTitulo = new Label();
                    labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 20, FontStyle.Bold);

                    if (pergunta.Titulo.Length < 40)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 20, FontStyle.Bold);
                    }
                    else if (pergunta.Titulo.Length > 400)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                    }
                    else if (pergunta.Titulo.Length > 200)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                    }

                    labelTitulo.Text = pergunta.Titulo;
                    labelTitulo.Dock = DockStyle.Fill;
                    labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
                    pnlTopo.Controls.Add(labelTitulo);
                }
            }

            if (pergunta.ContemAudio != null && (bool)pergunta.ContemAudio)
            {
                ItemArquivo arquivoAudio = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                string path = pergunta.Questao.DiretorioProva + arquivoAudio.Arquivo.NomeFisico;

                playerAudio.URL = path;
                contemAudio = true;
                parouAudio = false;
                audioTocando = true;

                if (!ativarPararAudio) showCoverForm(formEsperaAudio);

                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;
            }
        }

        #endregion

        #region Questao Ordenacao

        private void carregarQuestaoOrdencao(Questao questao)
        {
            ItemQuestao pergunta = questao.ItemQuestao.ToList().Find(i => (i.EPergunta != null) && (bool)(i.EPergunta));

            bool contemTexto = (pergunta.Titulo != null && !String.IsNullOrEmpty(pergunta.Titulo));
            bool contemImagem = (pergunta.ContemImagem != null && pergunta.ContemImagem == true);

            // Redimensiona os paineis para caber a questão e retorna o painel de respostas
            bool vertical;
            Control painel = redimensionaOrdenacao(questao, contemImagem, contemTexto, out vertical);

            bool contemAudio = false;
            carregarPerguntaOrdencao(pergunta, out contemAudio);

            // Carrega as respostas
            //bool vertical;
            //Control painel = getPainelPelaPosicao(questao, false, out vertical);
            painel.Controls.Clear();

            FlowLayoutPanel painelRespostas = new FlowLayoutPanel();
            painelRespostas.AutoSize = true;
            int larguraBotoes = 0;


            // Conta quantos botoes aparecerao na tela para calcular a largura deles
            List<string> vetOpcoesBotoes = new List<string>();
            int qtdBotoes = (questao.ItemQuestao.ToList().FindAll(i => i.Eresposta != null && (bool)i.Eresposta).Count);

            Color corBotao = new Color();
            if (this.BackColor == Color.White)
            {
                corBotao = Color.LightSkyBlue;
            }
            else
            {
                corBotao = ColorTranslator.FromHtml("#D7D7D7");
            }

            if (!vertical)
            {
                painelRespostas.FlowDirection = FlowDirection.LeftToRight;

                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Width;
                larguraBotoes = (largurapainel / qtdBotoes) - 3;
            }
            else
            {
                painelRespostas.FlowDirection = FlowDirection.TopDown;

                painel.Controls.Add(painelRespostas);

                int largurapainel = painel.Height;
                larguraBotoes = (largurapainel / qtdBotoes) - 3;
            }

            vetOpcoesCorretaOrdenacao = new List<int>();
            indiceForcaAtual = 0;

            foreach (var itemCorreto in questao.ItemQuestao.OrderBy(q => q.OrdemResposta))
            {
                if (itemCorreto.Eresposta != null && (bool)itemCorreto.Eresposta)
                {
                    if (itemCorreto.OpcaoCorreta != null && (bool)itemCorreto.OpcaoCorreta)
                    {
                        if (itemCorreto.OrdemResposta != null && itemCorreto.OrdemResposta >= 0)
                        {
                            vetOpcoesCorretaOrdenacao.Add((int)itemCorreto.OrdemTela);
                        }
                    }
                }
            }

            var fatorAumentoImagem = 0;
            int menorTamanhoBotoes = 11;

            vetImagensOriginais = new Dictionary<string, Image>();
            vetImagensPequenas = new Dictionary<string, Bitmap>();

            foreach (var itemQuestao in questao.ItemQuestao.OrderBy(q => q.OrdemTela))
            {
                if (itemQuestao.Eresposta != null && (bool)itemQuestao.Eresposta)
                {
                    Control botao = null;
                    if (itemQuestao.ContemImagem != null && (bool)itemQuestao.ContemImagem)
                    {
                        // Cria a imagem a partir do caminho fisico
                        ItemArquivo arquivoImagem = itemQuestao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                        string path = itemQuestao.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                        Image imagem = new Bitmap(path);

                        Size tamanhoBotao = new Size(larguraBotoes + fatorAumentoImagem - 8, larguraBotoes + fatorAumentoImagem - 10);
                        Size novoTamanho = ExpandToBound(imagem.Size, tamanhoBotao);

                        // Imagem ficou muito alta, recalcula
                        if (novoTamanho.Height > 280)
                        {
                            tamanhoBotao = new Size(larguraBotoes + fatorAumentoImagem, 280);
                            novoTamanho = ExpandToBound(imagem.Size, tamanhoBotao);
                        }

                        Image redimensionada = imagem.GetThumbnailImage(novoTamanho.Width, novoTamanho.Height, null,
                            IntPtr.Zero);

                        botao = new Button();
                        (botao as Button).FlatStyle = FlatStyle.Flat;
                        (botao as Button).FlatAppearance.BorderSize = 0;
                        // (botao as Button).FlatAppearance.BorderColor = Color.Yellow;
                        (botao).Width = tamanhoBotao.Width;
                        (botao).Height = novoTamanho.Height;
                        (botao).Name = itemQuestao.idItemQuestao.ToString();
                        (botao).Click += AlternativaOrdencaoClick;
                        (botao).MouseHover += AlternativaHover;
                        (botao).MouseLeave += AlternativaLeave;
                        (botao).BackgroundImage = redimensionada;
                        (botao).BackgroundImageLayout = ImageLayout.Center;
                        (botao as Button).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

                        // Cria a imagem de Hover
                        vetImagensOriginais.Add(botao.Name, redimensionada);

                        Image imgPequena = redimensionada.GetThumbnailImage((int)(redimensionada.Width * 0.9),
                            (int)(redimensionada.Height * 0.9), null, new IntPtr());

                        Bitmap imgBitMap = new Bitmap(imgPequena);
                        //  Bitmap imagBitPequena = GrayScaleFilter(imgBitMap);
                        vetImagensPequenas.Add(botao.Name, imgBitMap);

                    }
                    else if (!String.IsNullOrEmpty(itemQuestao.Titulo))
                    {
                        int larguraAtual = larguraBotoes;
                        int altura = larguraAtual - 10;

                        // Verifica se o botao ficara grande
                        if (larguraAtual > 200)
                        {
                            larguraAtual = 200;
                            altura = larguraAtual - 10;
                        }
                        else if (larguraAtual > 180)
                        {
                            if (qtdBotoes > 3)
                            {
                                altura = painel.Height / 2 - 10;
                            }
                        }

                        botao = new BotaoArredondado();

                        (botao as BotaoArredondado).FontSize = 16;

                        // Verifica o tamanho do texto a inserir
                        if (itemQuestao.Titulo.Length < larguraAtual / 10)
                        {
                            float largura = (larguraAtual / 10);
                            float tam = itemQuestao.Titulo.Length;

                            if (itemQuestao.Titulo.Length == 1)
                                (botao as BotaoArredondado).FontSize = 50;
                            else if ((tam / largura) > 0.55)
                                (botao as BotaoArredondado).FontSize = 16;
                            else if ((tam / largura) > 0.4)
                                (botao as BotaoArredondado).FontSize = 19;
                            else if ((tam / largura) > 0.3)
                                (botao as BotaoArredondado).FontSize = 25;
                            else if ((tam / largura) > 0.2)
                                (botao as BotaoArredondado).FontSize = 30;
                            else if ((tam / largura) > 0.1)
                                (botao as BotaoArredondado).FontSize = 40;

                        }

                        int tamanhoLocal = (botao as BotaoArredondado).FontSize;

                        if (menorTamanhoBotoes == 11)
                        {
                            menorTamanhoBotoes = tamanhoLocal;
                        }
                        else
                        {
                            if (tamanhoLocal < menorTamanhoBotoes)
                            {
                                menorTamanhoBotoes = tamanhoLocal;
                            }
                        }


                        botao.Text = wrapTexto(itemQuestao.Titulo, larguraAtual / 10);

                        if (botao.Text.Contains("%%"))
                        {
                            botao.Text = botao.Text.Replace("\n", "").Replace("%%", "");
                        }

                        if (botao.Text.Contains("--"))
                        {
                            botao.Text = botao.Text.Replace("\n", "").Replace("--", "\n");
                        }

                        botao.Width = larguraAtual;
                        botao.Height = altura;
                        botao.Name = itemQuestao.idItemQuestao.ToString();
                        botao.Click += AlternativaOrdencaoClick;
                        botao.MouseHover += AlternativaHover;
                        botao.MouseLeave += AlternativaLeave;
                        botao.BackColor = corBotao;
                        (botao as BotaoArredondado).FlatStyle = FlatStyle.Flat;
                        (botao as BotaoArredondado).FlatAppearance.BorderSize = 2;
                        (botao as BotaoArredondado).FlatAppearance.BorderColor = corBotao;
                        botao.Anchor = AnchorStyles.None;


                    }

                    painelRespostas.Controls.Add(botao);
                }
            }

            if (menorTamanhoBotoes > 11)
            {
                foreach (var control in painelRespostas.Controls)
                {
                    (control as BotaoArredondado).FontSize = menorTamanhoBotoes;
                }
            }

            if (contemAudio)
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = false;
                btnRepetir.Enabled = false;
                parouAudio = true;
                audioTocando = true;
            }
            else
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = true;
                btnRepetir.Enabled = true;
                parouAudio = false;
            }

            //int qtdBotoes = painelRespostas.Controls.Count;

            for (int i = 0; i < qtdBotoes; i++)
            {
                // Create the empty button inside the question panel to help students understand how it works
                Control exampleButton = painelRespostas.Controls[0];

                Button botaoExemplo = new BotaoArredondado();
                botaoExemplo.Width = exampleButton.Width;
                botaoExemplo.Height = exampleButton.Height;
                botaoExemplo.Enabled = false;
                botaoExemplo.FlatAppearance.BorderSize = 1;

                Control painelPergunta = getPainelPelaPosicao(pergunta.Questao, true, out vertical);
                Control painelOrdencao = painelPergunta.Controls[0] as Control;
                painelOrdencao.Controls.Add(botaoExemplo);
                painelPergunta.Visible = true;
                painelOrdencao.Visible = true;
                painelPergunta.Refresh();
                painelOrdencao.Refresh();
            }

            //enfileirada fix 4
            if (questaoAtual.Enfileirada == false)
            {
                tamanhoResposta = new Size(0, 0);
                localResposta = new Point(0, 0);
                imgCobre.Visible = false;
                imgCobre.SendToBack();
                imgCobre.Update();
                painelHabilitar.Update();
                pnlBaixo.Update();
                flowLayoutPanelPrincipal.Update();
            }
        }

        private void AlternativaOrdencaoClick(object sender, EventArgs eventArgs)
        {
            bool errou;
            string idItem = (sender as Control).Name;
            ItemQuestao alternativa = questaoAtual.ItemQuestao.ToList().Find(i => i.idItemQuestao.ToString() == idItem);
            ultimoItemClicado = alternativa;

            if (alternativa.OpcaoCorreta != null && (bool)alternativa.OpcaoCorreta)
            {
                if (Convert.ToInt32(alternativa.OrdemTela).Equals(vetOpcoesCorretaOrdenacao[0]))
                {
                    //ACERTOU
                    acertouUltima = true;

                    errou = false;

                    vetOpcoesCorretaOrdenacao.RemoveAt(0);

                    bool vert = false;

                    Control pnlResp = (sender as Control).Parent;

                    Control painelPergunta = getPainelPelaPosicao(alternativa.Questao, true, out vert);
                    Control painelOrdencao = painelPergunta.Controls[0] as Control;

                    // Switch button position to question panel
                    Control botaoOriginal = (sender as Control);
                    int indice = pnlResp.Controls.GetChildIndex(botaoOriginal);
                    (sender as Control).Enabled = false;


                    // Create one empty panel to replace the original button and creates a blank space in the position
                    Panel pnlBotaoVizualizacao = new Panel();
                    pnlBotaoVizualizacao.Width = (sender as Control).Width;
                    pnlBotaoVizualizacao.Height = (sender as Control).Height;
                    pnlBotaoVizualizacao.Enabled = false;

                    pnlResp.Controls.Add(pnlBotaoVizualizacao);
                    pnlResp.Controls.SetChildIndex(pnlBotaoVizualizacao, indice);

                    painelOrdencao.Controls.RemoveAt(painelOrdencao.Controls.Count - 1);
                    painelOrdencao.Controls.Add(botaoOriginal);
                    painelOrdencao.Controls.SetChildIndex(botaoOriginal, pnlResp.Controls.Count - (vetOpcoesCorretaOrdenacao.Count + 1));
                    painelPergunta.Visible = true;
                    painelPergunta.Enabled = false;
                    painelPergunta.Refresh();

                    pnlResp.Refresh();



                    indiceForcaAtual = 0;

                    // Procura um áudio especifico para esse item
                    ItemArquivo itemAudioArquivo =
                        alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioSucessoOpcao);

                    if (itemAudioArquivo == null)
                    {
                        // Procura Audio sucesso Padrao
                        ItemQuestao audioPadrao =
                                alternativa.Questao.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa)
                                    && (i.OpcaoCorreta != null && (bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));

                        if (audioPadrao != null)
                            itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                    }

                    if (itemAudioArquivo != null)
                    {
                        string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                        playerAudioAlternativas.URL = path;


                        painelHabilitar = flowLayoutPanelPrincipal;
                        painelHabilitar.Enabled = false;
                        btnRepetir.Enabled = false;

                        playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                        parouAudio = false;
                        audioTocando = true;
                        trocarQuestaoDepoisDoAudio = false;

                        if (vetOpcoesCorretaOrdenacao.Count == 0)
                        {
                            trocarQuestaoDepoisDoAudio = true;
                        }

                        showCoverForm(formEsperaAjuda);
                    }
                    else
                    {
                        trocarQuestaoDepoisDoAudio = false;
                        if (vetOpcoesCorretaOrdenacao.Count == 0)
                        {
                            contabilizarClick();
                        }
                    }

                }
                else
                {
                    //ERROU
                    errou = true;
                }
            }
            else
            {
                //errou
                errou = true;
            }

            if (errou)
            {
                acertouUltima = false;
                // Procura um áudio especifico para esse item
                ItemArquivo itemAudioArquivo =
                    alternativa.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioErroOpcao);

                if (itemAudioArquivo == null)
                {
                    // Procura Audio Erro Padrao
                    ItemQuestao audioPadrao =
                        alternativa.Questao.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa) && (i.OpcaoCorreta != null
                            && !(bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));

                    if (audioPadrao != null)
                        itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                }

                if (itemAudioArquivo != null)
                {
                    string path = alternativa.Questao.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                    playerAudioAlternativas.URL = path;


                    painelHabilitar = flowLayoutPanelPrincipal;
                    painelHabilitar.Enabled = false;
                    btnRepetir.Enabled = false;

                    playerAudioAlternativas.PlayStateChange += PlayerAudioAjudaOnPlayStateChange;
                    parouAudio = false;
                    audioTocando = true;
                    trocarQuestaoDepoisDoAudio = true;

                    showCoverForm(formEsperaAjuda);
                }
                else
                {
                    trocarQuestaoDepoisDoAudio = false;
                    contabilizarClick();
                }
            }
        }

        private void carregarPerguntaOrdencao(ItemQuestao pergunta, out bool contemAudio)
        {
            bool vertical;
            Control painel = getPainelPelaPosicao(pergunta.Questao, true, out vertical);
            painel.Controls.Clear();

            FlowLayoutPanel painelOrdenacao = new FlowLayoutPanel();
            painelOrdenacao.Width = painel.Width;
            painelOrdenacao.Height = painel.Height;
            painelOrdenacao.FlowDirection = FlowDirection.LeftToRight;
            painel.Controls.Clear();
            painel.Controls.Add(painelOrdenacao);

            //  painel.Size = new Size(556, 216);

            contemAudio = false;

            if (pergunta.ContemImagem != null && (bool)pergunta.ContemImagem)
            {
                // Cria a imagem a partir do caminho fisico
                ItemArquivo arquivoImagem = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 1);
                string path = pergunta.Questao.DiretorioProva + arquivoImagem.Arquivo.NomeFisico;
                Image imagem = new Bitmap(path);

                // Cria o controle de tela para exibir a imagem
                PictureBox boxImagem = new PictureBox();
                boxImagem.Width = imagem.Width;
                boxImagem.Height = imagem.Height;

                boxImagem.Image = imagem;
                pnlTopo.Controls.Add(boxImagem);

                if (imagem.Height > 200)
                {
                    boxImagem.Height = 200;
                }

                if (imagem.Width > 500)
                {
                    boxImagem.Width = 500;
                }

                boxImagem.SizeMode = PictureBoxSizeMode.Zoom;

                // Seta a posicao da imagem
                if ((painel.Width / 2 - boxImagem.Width / 2) > 0)
                    boxImagem.Location = new Point(painel.Width / 2 - boxImagem.Width / 2, 0);
                else
                    boxImagem.Location = new Point(0, 0);
            }
            else
            {
                if (pergunta.Titulo != null && pergunta.Titulo.Length > 1)
                {
                    Label labelTitulo = new Label();
                    labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 20, FontStyle.Bold);

                    if (pergunta.Titulo.Length < 40)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 20, FontStyle.Bold);
                    }
                    else if (pergunta.Titulo.Length > 400)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                    }
                    else if (pergunta.Titulo.Length > 200)
                    {
                        labelTitulo.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                    }

                    labelTitulo.Text = pergunta.Titulo;
                    labelTitulo.Dock = DockStyle.Fill;
                    labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
                    pnlTopo.Controls.Add(labelTitulo);
                }
            }

            if (pergunta.ContemAudio != null && (bool)pergunta.ContemAudio)
            {
                ItemArquivo arquivoAudio = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                string path = pergunta.Questao.DiretorioProva + arquivoAudio.Arquivo.NomeFisico;

                playerAudio.URL = path;
                contemAudio = true;
                parouAudio = false;
                audioTocando = true;

                if (!ativarPararAudio) showCoverForm(formEsperaAudio);

                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;
            }
        }

        #endregion

        #region Questao Psicogenese

        private void carregarQuestaoPsicogenese(Questao questao)
        {
            ItemQuestao pergunta = questao.ItemQuestao.ToList().Find(i => (i.EPergunta != null) && (bool)(i.EPergunta));
            palavraAluno = "";

            palavraPsicogenese = pergunta.Titulo;
            variacoesPsicogenese = "";

            if (pergunta.Titulo.Contains("("))
            {
                int posicaoParenteses = pergunta.Titulo.IndexOf("(");

                string palavra = pergunta.Titulo.Substring(0, posicaoParenteses);
                string variacoes = pergunta.Titulo.Remove(0, posicaoParenteses + 1);
                variacoes = variacoes.Substring(0, variacoes.Length - 1);

                palavraPsicogenese = palavra;
                variacoesPsicogenese = variacoes;
            }



            bool contemTexto = (palavraPsicogenese != null && !String.IsNullOrEmpty(palavraPsicogenese));
            bool contemImagem = (pergunta.ContemImagem != null && pergunta.ContemImagem == true);

            // Redimensiona os paineis para caber a questão e retorna o painel de respostas
            bool vertical;
            Control painel = redimensionaPsicogenese(questao, contemImagem, contemTexto, out vertical);

            bool contemAudio = false;
            carregarPerguntaPsicogenese(pergunta, out contemAudio);

            // Carrega as letras do alfabeto para o aluno clicar

            painel.Controls.Clear();

            FlowLayoutPanel painelRespostas = new FlowLayoutPanel();
            painelRespostas.AutoSize = true;

            Color corBotao = ColorTranslator.FromHtml("#D7D7D7"); ;

            painelRespostas.FlowDirection = FlowDirection.LeftToRight;
            painelRespostas.AutoSize = true;

            int larguraPainelTela = painel.Width;

            painelRespostas.MaximumSize = new Size(larguraPainelTela, painel.Height);

            painel.Controls.Add(painelRespostas);

            const string alfabetoCompleto = "A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z";

            List<string> vetAlfabeto = alfabetoCompleto.Split(";".ToCharArray()).ToList();

            foreach (var letra in vetAlfabeto)
            {
                Control botao = null;

                botao = new BotaoArredondado();

                (botao as BotaoArredondado).FontSize = 45;

                botao.Text = letra;
                botao.Width = 87;
                botao.Height = 87;
                botao.Name = vetAlfabeto.IndexOf(letra).ToString();
                botao.Click += AlternativaPsicogeneseClick;
                //  botao.MouseHover += AlternativaHover;
                // botao.MouseLeave += AlternativaLeave;
                botao.BackColor = corBotao;
                (botao as BotaoArredondado).FlatStyle = FlatStyle.Flat;
                (botao as BotaoArredondado).FlatAppearance.BorderSize = 2;
                (botao as BotaoArredondado).FlatAppearance.BorderColor = corBotao;
                botao.Anchor = AnchorStyles.None;

                painelRespostas.Controls.Add(botao);
            }

            // Adiciona o botão especial de apagar
            Control botaoApagar = null;
            botaoApagar = new BotaoArredondado();
            botaoApagar.BackgroundImage = Resources._87x87_PSICOGENESE_BORRACHA_LISO;
            botaoApagar.Width = 87;
            botaoApagar.Height = 87;
            botaoApagar.Name = "Apagar";
            botaoApagar.Click += BotaoApagarOnClick;
            //  botaoApagar.MouseHover += AlternativaHover;
            // botaoApagar.MouseLeave += AlternativaLeave;
            botaoApagar.BackColor = Color.White;
            (botaoApagar as BotaoArredondado).FlatStyle = FlatStyle.Flat;
            (botaoApagar as BotaoArredondado).FlatAppearance.BorderSize = 2;
            (botaoApagar as BotaoArredondado).FlatAppearance.BorderColor = corBotao;
            botaoApagar.Anchor = AnchorStyles.None;
            (botaoApagar as Button).FlatStyle = FlatStyle.Flat;
            (botaoApagar as Button).FlatAppearance.BorderSize = 0;
            (botaoApagar).BackgroundImageLayout = ImageLayout.Center;
            (botaoApagar as Button).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

            painelRespostas.Controls.Add(botaoApagar);


            // Adiciona o botão de confirmar
            Control botaoConfirmar = null;
            botaoConfirmar = new Button();
            botaoConfirmar.BackgroundImage = Resources.icon_confirm;
            botaoConfirmar.Width = 120;
            botaoConfirmar.Height = 120;
            botaoConfirmar.Name = "Apagar";
            botaoConfirmar.Click += BotaoConfirmarOnClick;
            botaoConfirmar.MouseHover += BotaoConfirmarOnMouseHover;
            botaoConfirmar.MouseLeave += BotaoConfirmarOnMouseLeave;
            botaoConfirmar.BackColor = Color.Transparent;
            botaoConfirmar.Anchor = AnchorStyles.None;
            (botaoConfirmar as Button).FlatStyle = FlatStyle.Flat;
            (botaoConfirmar as Button).FlatAppearance.BorderSize = 0;
            (botaoConfirmar).BackgroundImageLayout = ImageLayout.Center;
            (botaoConfirmar as Button).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            (botaoConfirmar as Button).Location = new Point(100, 460);
            botaoConfirmarPsicogenese = botaoConfirmar;

            pnlDireita.Controls.Add(botaoConfirmar);

            if (contemAudio)
            {
                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = false;
                btnRepetir.Enabled = false;
                parouAudio = true;
                audioTocando = true;
            }
            else
            {

                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = true;
                btnRepetir.Enabled = true;
            }
        }

        private void BotaoConfirmarOnMouseLeave(object sender, EventArgs eventArgs)
        {
            (sender as Button).BackgroundImage = Resources.icon_confirm;

            (sender as Button).Refresh();
        }

        private void BotaoConfirmarOnMouseHover(object sender, EventArgs eventArgs)
        {
            (sender as Button).BackgroundImage = Resources.confirm2;

            (sender as Button).Refresh();
        }

        private void AlternativaPsicogeneseClick(object sender, EventArgs eventArgs)
        {
            string letra = (sender as Button).Text;

            if (palavraAluno.Length + 1 > 15)
            {
                return;
            }

            palavraAluno += letra;

            // Cria a letra de resposta
            Control botao = null;
            botao = new BotaoArredondado();
            (botao as BotaoArredondado).FontSize = 48;

            botao.Text = letra;
            botao.Width = 70;
            botao.Height = 70;
            botao.Name = letra;
            botao.BackColor = Color.LightSkyBlue;
            (botao as BotaoArredondado).FlatStyle = FlatStyle.Flat;
            (botao as BotaoArredondado).FlatAppearance.BorderSize = 2;
            (botao as BotaoArredondado).FlatAppearance.BorderColor = Color.LightSkyBlue;
            botao.Anchor = AnchorStyles.None;

            bool vert;

            Control painelPergunta = getPainelPelaPosicao(questaoAtual, true, out vert);
            Control painelOrdencao = painelPergunta.Controls[0] as Control;

            painelOrdencao.Controls.Add(botao);
        }

        private void carregarPerguntaPsicogenese(ItemQuestao pergunta, out bool contemAudio)
        {
            bool vertical;
            Control painel = getPainelPelaPosicao(pergunta.Questao, true, out vertical);
            painel.Controls.Clear();

            FlowLayoutPanel painelOrdenacao = new FlowLayoutPanel();
            painelOrdenacao.Width = painel.Width;
            painelOrdenacao.Height = painel.Height;
            painelOrdenacao.FlowDirection = FlowDirection.LeftToRight;
            painel.Controls.Clear();
            painel.Controls.Add(painelOrdenacao);

            contemAudio = false;



            if (pergunta.ContemAudio != null && (bool)pergunta.ContemAudio)
            {
                ItemArquivo arquivoAudio = pergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);
                string path = pergunta.Questao.DiretorioProva + arquivoAudio.Arquivo.NomeFisico;

                playerAudio.URL = path;
                contemAudio = true;
                parouAudio = false;
                audioTocando = true;

                if (!ativarPararAudio) showCoverForm(formEsperaAudio);

                playerAudio.PlayStateChange += PlayerAudioOnPlayStateChange;
            }

            // Desabilita outros audios
            playerAudioAlternativas.close();
            ultimoItemClicado = null;
        }

        private void BotaoConfirmarOnClick(object sender, EventArgs eventArgs)
        {
            ultimoItemClicado = null;

            // Verifica se o aluno deixou a questão em branco
            if (String.IsNullOrEmpty(palavraAluno))
            {
                // Procura Audio Erro Padrao
                ItemArquivo itemAudioArquivoErro = null;
                ItemQuestao audioPadraoErro =
                  questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa != null && (bool)i.ETentativa)
                      && (i.OpcaoCorreta != null && !(bool)i.OpcaoCorreta) && (i.ContemAudio != null && (bool)i.ContemAudio));


                if (audioPadraoErro != null)
                    itemAudioArquivoErro = audioPadraoErro.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);


                if (itemAudioArquivoErro != null)
                {
                    string path = questaoAtual.DiretorioProva + itemAudioArquivoErro.Arquivo.NomeFisico;

                    Control painelRespostas = flowLayoutPanelPrincipal;

                    painelHabilitar = flowLayoutPanelPrincipal;
                    painelHabilitar.Enabled = false;
                    btnRepetir.Enabled = false;

                    playerAudioErroPsico.URL = path;
                    parouAudio = false;
                    audioTocando = true;
                    playerAudioErroPsico.PlayStateChange += PlayerAudioErroPsicoOnPlayStateChange;

                    trocarQuestaoDepoisDoAudio = false;

                    showCoverForm(formEsperaErroPsico);
                }

                return;
            }

            // Toca o audio de sucesso
            ItemArquivo itemAudioArquivo = null;
            ItemQuestao audioPadrao =
                questaoAtual.ItemQuestao.ToList()
                    .Find(i => (i.ETentativa != null && (bool)i.ETentativa) &&
                                (i.OpcaoCorreta != null && (bool)i.OpcaoCorreta) &&
                                (i.ContemAudio != null && (bool)i.ContemAudio));

            if (audioPadrao != null)
                itemAudioArquivo = audioPadrao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo.idTipoArquivo == 2);


            if (itemAudioArquivo != null)
            {
                string path = questaoAtual.DiretorioProva + itemAudioArquivo.Arquivo.NomeFisico;

                playerFImPsico.URL = path;

                painelHabilitar = flowLayoutPanelPrincipal;
                painelHabilitar.Enabled = false;
                btnRepetir.Enabled = false;

                parouAudio = false;
                audioTocando = true;
                playerFImPsico.PlayStateChange += PlayerAudioFimPsicoOnPlayStateChange;

                trocarQuestaoDepoisDoAudio = true;

                showCoverForm(formEsperaFimPsico);
            }
            else
            {
                btnRepetir.Enabled = true;
                trocarQuestaoDepoisDoAudio = false;

                parouAudio = true;

                painelHabilitar.Enabled = true;

                contabilizarClickPsico();

                if (botaoConfirmarPsicogenese != null)
                    botaoConfirmarPsicogenese.Enabled = true;
            }
        }

        private void contabilizarClickPsico()
        {
            int porcentagem;
            // Calcula o resultado da classificação
            TipoQuestao.TipoPsicogenese tipoClassificado = TipoQuestao.validarRepostaPsicogenese(palavraPsicogenese, palavraAluno, variacoesPsicogenese, out porcentagem);

            string classificacao = tipoClassificado.ToString();
            //  MensagemSucesso("Classificado como: " + classificacao + ", Acertou " + porcentagem + "% da palavra");


            // Armazena o resultado no banco

            Pontuacao pontuacao = Controlador.getControlador()
               .getPontuacaoAluno(alunoAtual.idAluno, questaoAtual.idQuestao);

            // Contabiliza o tempo
            DateTime myDate2 = DateTime.Now;
            TimeSpan tsAgora = myDate2.Subtract(tempoQuestao);

            TimeSpan totalTempo = tsAgora;

            // Verifica se deve criar a pontuação
            if (pontuacao == null)
            {
                pontuacao = new Pontuacao();
                pontuacao.Aluno = alunoAtual;
                pontuacao.Questao = questaoAtual;

                pontuacao.Tentativas = (int)tipoClassificado;
                pontuacao.Mouse = palavraAluno;
                pontuacao.Clicks = porcentagem.ToString();
                pontuacao.DataHora = DateTime.Now;
                pontuacao.Tempo = totalTempo.TotalSeconds;

                pontuacao.adicionar(pontuacao);
            }
            else
            {
                pontuacao.Tentativas = (int)tipoClassificado;
                pontuacao.Mouse = palavraAluno;
                pontuacao.Clicks = porcentagem.ToString();
                pontuacao.Tempo = totalTempo.TotalSeconds;

                pontuacao.atualizar(pontuacao);
            }

            // Grava o resultado
            Resultado resultado = Controlador.getControlador().getResultadoAluno(alunoAtual.idAluno);

            if (resultado == null)
            {
                resultado = new Resultado();
                resultado.Aluno = alunoAtual;
                resultado.Questionario = Controlador.getControlador().questionario;
                resultado.TotalAcertos = 0;
                resultado.TotalErros = 0;

                resultado.adicionar(resultado);
            }

            resultado.UltimaQuestao_id = questaoAtual.idQuestao;
            resultado.atualizar(resultado);

            // Carrega a próxima questão
            parouAudio = true;
            audioTocando = false;
            Questao questao = getProximaQuestao();
            parouAudio = true;

            if (questao != null)
            {
                resultado.UltimaQuestao_id = questao.idQuestao;
                resultado.atualizar(resultado);
            }

            if (questao != null)
            {
                this.carregarQuestao(questao);
            }
            else
            {
                resultado.Questao = null;
                resultado.atualizar(resultado);

                System.Threading.Thread.Sleep(1000);
                finalizaProva();
            }

            botaoConfirmarPsicogenese = null;
            parouAudio = true;
            trocarQuestaoDepoisDoAudio = false;

        }

        private void BotaoApagarOnClick(object sender, EventArgs eventArgs)
        {
            bool vert;

            Control painelPergunta = getPainelPelaPosicao(questaoAtual, true, out vert);

            Control.ControlCollection vetorLetras = painelPergunta.Controls[0].Controls;

            if (vetorLetras.Count > 0)
            {
                Control ultimaletra = vetorLetras[vetorLetras.Count - 1];

                painelPergunta.Controls[0].Controls.Remove(ultimaletra);

                palavraAluno = palavraAluno.Remove(palavraAluno.Length - 1);
            }
        }

        #endregion

        #region Events

        private void PlayerVideo_ClickEvent(object sender, _WMPOCXEvents_ClickEvent e)
        {
            // PlayerVideo.Ctlcontrols.play();
        }

        private void PlayerVideo_DoubleClickEvent(object sender, _WMPOCXEvents_DoubleClickEvent e)
        {
            // PlayerVideo.Ctlcontrols.play();
        }

        private void comboAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Library.Persistencia.Questionario questionario = Controlador.getControlador().questionario;

            alunoAtual = comboAluno.SelectedItem as Aluno;
            if (questionario.Resultado.ToList().Find(a => a.Aluno_id == alunoAtual.idAluno) != null)
            {
                Questao questao = questionario.Resultado.ToList().Find(a => a.Aluno_id == alunoAtual.idAluno).Questao;


                lblAvisoInicial.Text = "Continuar prova na questão: " + questao.Ordem;

                btnSalvarNome.Enabled = true;
                btnIniciarProva.Enabled = false;
            }
            else
            {
                lblAvisoInicial.Text = "Espere até que o professor peça para começar";
                contemVideo = true;
            }
        }

        private void btnNovoAluno_Click(object sender, EventArgs e)
        {
            if (btnNovoAluno.Text.ToString() == "Novo")
            {
                comboAluno.Visible = false;
                comboAluno.Enabled = false;
                txtNomeAluno.Visible = true;
                txtNomeAluno.Enabled = true;
                btnSalvarNome.Enabled = true;
                lblNascimento.Visible = true;
                dtNascimento.Visible = true;
                rdFemea.Visible = true;
                rdMacho.Visible = true;
                btnNovoAluno.Text = "Cancelar";
            }
            else
            {
                comboAluno.Visible = true;
                comboAluno.Enabled = true;
                txtNomeAluno.Visible = false;
                txtNomeAluno.Enabled = false;
                lblNascimento.Visible = false;
                dtNascimento.Visible = false;
                rdFemea.Visible = false;
                rdMacho.Visible = false;
                btnNovoAluno.Text = "Novo";
                comboEscola.Update();
                comboTurma.Update();
                comboAluno.Update();
                if (btnNovaTurma.Text == "Cancelar") btnNovaTurma.PerformClick();
            }
        }

        private void btnNovaTurma_Click(object sender, EventArgs e)
        {
            if (btnNovaTurma.Text.ToString() == "Novo")
            {
                comboTurma.Visible = false;
                comboTurma.Enabled = false;
                txtTurma.Visible = true;
                txtTurma.Enabled = true;
                btnSalvarNome.Enabled = true;
                if (btnNovoAluno.Text == "Novo") btnNovoAluno.PerformClick();
                btnNovaTurma.Text = "Cancelar";
            }
            else
            {
                comboTurma.Visible = true;
                comboTurma.Enabled = true;
                txtTurma.Visible = false;
                txtTurma.Enabled = false;
                btnNovaTurma.Text = "Novo";
                if (btnNovaEscola.Text == "Cancelar") btnNovaEscola.PerformClick();
                if (btnNovaEscola.Text == btnNovaTurma.Text && btnNovaTurma.Text == btnNovoAluno.Text && btnNovoAluno.Text == "Novo")
                {
                    btnSalvarNome.Enabled = false;
                }
            }
        }

        private void btnNovaEscola_Click(object sender, EventArgs e)
        {
            if (btnNovaEscola.Text.ToString() == "Novo")
            {
                comboEscola.Visible = false;
                comboEscola.Enabled = false;
                txtNomeEscola.Visible = true;
                txtNomeEscola.Enabled = true;
                btnSalvarNome.Enabled = true;
                if (btnNovaTurma.Text == "Novo") btnNovaTurma.PerformClick();
                btnNovaEscola.Text = "Cancelar";
            }
            else
            {
                comboEscola.Visible = true;
                comboEscola.Enabled = true;
                txtNomeEscola.Visible = false;
                txtNomeEscola.Enabled = false;
                btnNovaEscola.Text = "Novo";
                if (btnNovaEscola.Text == btnNovaTurma.Text && btnNovaTurma.Text == btnNovoAluno.Text && btnNovoAluno.Text == "Novo")
                {
                    btnSalvarNome.Enabled = false;
                }
            }
        }

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            if (comboAluno.SelectedItem != null)
            {
                Controlador.getControlador().limparAlunosAtuais();
                alunoAtual = comboAluno.SelectedItem as Aluno;
                alunoAtual.DataCadastro = DateTime.Now;
                Controlador.getControlador().apagarProvaAtual();
                Controlador.getControlador().apagarAluno(alunoAtual);
                comboAluno.Items.Remove(alunoAtual);
                comboAluno.Update();
                btnIniciarProva.Enabled = false;
                lblAlunosApagados.Visible = true;
                lblAlunosApagados.Text = "Aluno apagado: " + alunoAtual.Nome;
                DateTime agora = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while (agora.AddSeconds(tempoApagarNomes) > DateTime.Now);
                lblAlunosApagados.Visible = false;
            }
            else MensagemErro("Nenhum aluno selecionado.");
        }

        private void btnApagarTurma_Click(object sender, EventArgs e)
        {
            if (comboTurma.SelectedItem != null)
            {
                turmaAtual = comboTurma.SelectedItem as Turma;
                List<Aluno> alunos = Controlador.getControlador().getAlunos().FindAll(a => a.Turma_id == turmaAtual.idTurma);
                tempoApagarNomes = 1 / alunos.Count;
                foreach (var aluno in alunos)
                {
                    comboAluno.SelectedItem = aluno;
                    btnApagarAluno.PerformClick();
                }
                Controlador.getControlador().apagarTurma(turmaAtual);
                comboTurma.Items.Remove(turmaAtual);
                comboTurma.Update();
                lblAlunosApagados.Visible = true;
                lblAlunosApagados.Text = "Turma apagada: " + turmaAtual.Nome;
                DateTime agora = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while (agora.AddSeconds(1) > DateTime.Now);
                lblAlunosApagados.Visible = false;
            }
            else MensagemErro("Nenhuma Turma selecionada.");
        }

        private void btnApagarEscola_Click(object sender, EventArgs e)
        {
            if (comboEscola.SelectedItem != null)
            {
                escolaAtual = comboEscola.SelectedItem as Instituicao;
                List<Turma> turmas = Controlador.getControlador().getTurmas().FindAll(t => t.Instituicao_id == escolaAtual.idInstituicao);
                foreach (var turma in turmas)
                {
                    comboTurma.SelectedItem = turma;
                    btnApagarTurma.PerformClick();
                }
                Controlador.getControlador().apagarEscola(escolaAtual);
                comboEscola.Items.Remove(escolaAtual);
                comboEscola.Update();
                lblAlunosApagados.Visible = true;
                lblAlunosApagados.Text = "Escola apagada: " + turmaAtual.Nome;
                DateTime agora = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while (agora.AddSeconds(1) > DateTime.Now);
                lblAlunosApagados.Visible = false;
            }
            else MensagemErro("Nenhuma Escola selecionada.");
        }

        private void txtNomeAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                btnSalvarNome.PerformClick();
            }
        }

        private void dtNascimento_CloseUp(object sender, EventArgs e)
        {
            nascimento = Convert.ToDateTime(dtNascimento.Text);
        }

        private void rdMacho_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMacho.Checked == true)
            {
                sexo = "M";
            }
            else sexo = "F";
        }

        private void ckAtivarPararAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAtivarPararAudio.Checked)
            {
                ativarPararAudio = true;
            }
            else
            {
                ativarPararAudio = false;
            }
        }
    }

    #endregion

    #endregion
}
