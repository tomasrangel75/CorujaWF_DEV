using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class FormQuestionario : MetroForm
    {
        private string caminhoVideo;
        private string caminhoVideoFechamento;
        private Color corSelecionada;
        private Questionario questionarioAtual;

        public FormQuestionario()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ControlBox = false;

            WindowState = FormWindowState.Maximized;
            BringToFront();

            carregar();
        }

        private void carregar()
        {
            ddlNivel.DataSource = Nivel.obterTodos();
            ddlNivel.DisplayMember = "Nome";

            painelBotoesQuestionario.Controls.Clear();

            foreach (Questionario q in Questionario.obterTodos().OrderBy(q => q.Nome))
            {
                var botaoQuestionario = new MetroTile();
                botaoQuestionario.Width = 235;
                botaoQuestionario.Text = q.Nome;
                botaoQuestionario.Name = q.idQuestionario.ToString();
                botaoQuestionario.Margin = new Padding(5);
                botaoQuestionario.Click += btnQuestionario_Click;
                painelBotoesQuestionario.Controls.Add(botaoQuestionario);
            }
        }

        private void btnQuestionario_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((MetroTile) sender).Name);
            Questionario questionario = Questionario.get(id);

            txtNome.Text = questionario.Nome;
            txtDesc.Text = questionario.Descricao;
            ddlNivel.SelectedItem = questionario.Nivel;
            colorDialog.Color = ColorTranslator.FromHtml(questionario.Cor);
            pnlCor.BackColor = ColorTranslator.FromHtml(questionario.Cor);
            if (questionario.RepetePergunta != null) ckRepetePergunta.Checked = (bool) questionario.RepetePergunta;
            questionarioAtual = questionario;

            if (questionario.Arquivo != null)
            {
                lblVideoCadastrado.Text = questionario.Arquivo.Nome;
                btnExcluirVideo.Enabled = true;
            }
            else
            {
                lblVideoCadastrado.Text = "";
                btnExcluirVideo.Enabled = false;
            }

             string[] files = Directory.GetFiles(questionarioAtual.Diretorio, "VideoEncerramento*");
             bool exists = files.Length > 0;

             if (exists)
             {
                 lblVideoEncCadastrado.Text = "VideoEncerramento";
                 btnExcluirVideoEncerramento.Enabled = true;
             }

            btnLimpar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 3)
            {
                ((Master) MdiParent).MensagemAlerta("Digite um nome para o questionário.");
                return;
            }

            if (txtDesc.Text.Length < 3)
            {
                ((Master) MdiParent).MensagemAlerta("Digite uma descrição para o questionário.");
                return;
            }

            try
            {
                Questionario questionario;

                if (questionarioAtual == null)
                {
                    questionario = new Questionario
                    {
                        Nome = txtNome.Text,
                        Descricao = txtDesc.Text,
                        Nivel = (Nivel) ddlNivel.SelectedItem,
                        Cor = ColorTranslator.ToHtml(corSelecionada),
                        RepetePergunta = ckRepetePergunta.Checked
                    };

                    questionario.adicionar(questionario);

                    string dirQuest = questionario.Diretorio;

                    if (!Directory.Exists(dirQuest))
                    {
                        Directory.CreateDirectory(dirQuest);
                    }

                    criarVideo(questionario);
                    criarVideoFechamento(questionario);
                    

                    ((Master)MdiParent).MensagemSucesso("Questionário Cadastrado!");
                }
                else
                {
                    questionario = questionarioAtual;
                    questionario.Nome = txtNome.Text;
                    questionario.Descricao = txtDesc.Text;
                    questionario.Nivel = (Nivel) ddlNivel.SelectedItem;
                    questionario.Disciplina.Clear();
                    questionario.Cor = ColorTranslator.ToHtml(pnlCor.BackColor);
                    questionario.RepetePergunta = ckRepetePergunta.Checked;

                    questionario.atualizar(questionario);

                    string dirQuest = questionario.Diretorio;

                    if (!Directory.Exists(dirQuest))
                    {
                        Directory.CreateDirectory(dirQuest);
                    }

                    criarVideo(questionario);
                    criarVideoFechamento(questionario);

                    ((Master)MdiParent).MensagemSucesso("Questionário Atualizado!");
                }

                limpar();

                carregar();

                questionarioAtual = null;
            }
            catch
            {
                ((Master) MdiParent).MensagemErro(
                    "Ocorreu um erro ao Salvar o Questionário, verifique o banco de dados.");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult di;

            if (questionarioAtual.Questao.Count > 0)
            {
                di =
                    ((Master) MdiParent).MensagemValidarExclusao(questionarioAtual.Resultado.Count > 0
                        ? "Esse questionário possúi questões e resultados associados! Tem certeza que deseja excluir esse questionário e todas as questões e resultados?"
                        : "Esse questionário possúi questões associadas! Tem certeza que deseja excluir esse questionário e todas as questões dele?");
            }
            else
            {
                di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir esse questionário?");
            }

            if (di == DialogResult.OK)
            {
                questionarioAtual.deletar(questionarioAtual);

                limpar();
                questionarioAtual = null;
                caminhoVideo = null;
                caminhoVideoFechamento = null;
                btnLimpar.Enabled = false;

                ((Master) MdiParent).MensagemSucesso("Questionário excluido!");

                carregar();
            }
        }

        private void limpar()
        {
            txtNome.Text = "";
            txtDesc.Text = "";
            ddlNivel.SelectedIndex = 0;
            ckRepetePergunta.Checked = true;
            pnlCor.BackColor = Color.White;
            lblVideoCadastrado.Text = "";
            lblVideoEncCadastrado.Text = "";
            btnExcluirVideo.Enabled = false;
            btnLimpar.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            questionarioAtual = null;
            limpar();
        }

        private void pnlCor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                corSelecionada = colorDialog.Color;
                pnlCor.BackColor = corSelecionada;
                pnlCor.UseCustomBackColor = true;
            }
        }

        private void btnVideoIntro_Click(object sender, EventArgs e)
        {
            caminhoVideo = ((Master) MdiParent).envioVideo();
        }

        private void btnVideoFechamento_Click(object sender, EventArgs e)
        {
            caminhoVideoFechamento = ((Master)MdiParent).envioVideo();
        }

        private void btnExcluirVideo_Click(object sender, EventArgs e)
        {
            if (questionarioAtual != null)
            {
                if (questionarioAtual.Arquivo != null)
                {
                    Arquivo videoCad = questionarioAtual.Arquivo;

                    string caminhoAnterior = questionarioAtual.Diretorio + videoCad.NomeFisico;

                    questionarioAtual.Arquivo = null;
                    questionarioAtual.Arquivo_id = null;

                    questionarioAtual.atualizar(questionarioAtual);

                    videoCad.deletar(videoCad);

                    File.Delete(caminhoAnterior);

                    lblVideoCadastrado.Text = "";
                    btnExcluirVideo.Enabled = false;

                    ((Master) MdiParent).MensagemSucesso("Vídeo excluido!");
                }
            }
        }

        private void criarVideo(Questionario questionario)
        {
            if (caminhoVideo != null)
            {
                string nome = caminhoVideo;

                var info = new FileInfo(nome);

                string nomeArquivo = info.Name;
                // Trata tamanho do nome
                if (nomeArquivo.Length > 200)
                {
                    nomeArquivo = nomeArquivo.Remove(200);
                }

                if (info.Exists)
                {
                    // Verifica se ja existe para atualizar
                    Arquivo arquivoVideo = questionario.Arquivo;

                    if (arquivoVideo == null)
                    {
                        arquivoVideo = new Arquivo
                        {
                            Nome = nomeArquivo,
                            NomeFisico = "Video" + questionario.idQuestionario + info.Extension,
                            Extensao = info.Extension,
                            TipoArquivo = TipoArquivo.video
                        };

                        questionario.Arquivo = arquivoVideo;

                        arquivoVideo.adicionar(arquivoVideo);
                    }
                    else
                    {
                        // Apaga o arquivo antigo da pasta
                        string caminhoAnterior = questionario.Diretorio + arquivoVideo.NomeFisico;
                        File.Delete(caminhoAnterior);

                        // Atualiza as informações do novo
                        arquivoVideo.Nome = nomeArquivo;
                        arquivoVideo.NomeFisico = "Video" + questionario.idQuestionario + info.Extension;
                        arquivoVideo.Extensao = info.Extension;

                        arquivoVideo.atualizar(arquivoVideo);
                    }

                    string caminhoFisico = questionario.Diretorio + arquivoVideo.NomeFisico;

                    File.Copy(caminhoVideo, caminhoFisico, true);

                    lblVideoCadastrado.Text = arquivoVideo.Nome;
                    btnExcluirVideo.Enabled = true;
                }
            }
        }

        private void criarVideoFechamento(Questionario questionario)
        {
            if (caminhoVideoFechamento != null)
            {
                string nome = caminhoVideoFechamento;

                var info = new FileInfo(nome);

                string nomeArquivo = info.Name;
                // Trata tamanho do nome
                if (nomeArquivo.Length > 200)
                {
                    nomeArquivo = nomeArquivo.Remove(200);
                }

                if (info.Exists)
                {
                    string nomeFisico = "VideoEncerramento" + info.Extension;

                    string caminhoFisico = questionario.Diretorio + nomeFisico;

                    File.Copy(caminhoVideoFechamento, caminhoFisico, true);

                    lblVideoEncCadastrado.Text = nomeFisico;
                    
                    btnExcluirVideoEncerramento.Enabled = true;
                }
            }
        }

        private void btnExcluirVideoEncerramento_Click(object sender, EventArgs e)
        {
            if (questionarioAtual != null)
            {

                string[] files = Directory.GetFiles(questionarioAtual.Diretorio, "VideoEncerramento*");
                bool exists = files.Length > 0;

                if (exists)
                {
                    FileInfo fi = new FileInfo(files[0]);

                    fi.Delete();
                    lblVideoEncCadastrado.Text = "";
                    btnExcluirVideoEncerramento.Enabled = false;
                    ((Master)MdiParent).MensagemSucesso("Vídeo excluido!");
                }
            }
        }
    }
}