using Library.Persistencia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using QuestionarioForms.Audio;

namespace QuestionarioForms
{
    public partial class FormQuestao : MetroForm
    {
        private Color corSelecionada;

        private Questao questaoAtual;
        private Questionario questionarioAtual;
        private ItemQuestao itemquestaoAtual;

        private string caminhoImagemPergunta;
        private string caminhoAudioPergunta;

        private string caminhoImagemResposta;

        private string caminhoAudioSucesso;
        private string caminhoAudioErro;

        private string caminhoAudioLeitura;
        private string caminhoAudioSucessoResposta;
        private string caminhoAudioErroResposta;

        #region Inicializacao

        public FormQuestao()
        {
            InitializeComponent();

            carregarTela();
        }


        private void carregarTela()
        {
            // Carrega os questionarios
            foreach (Questionario quest in Questionario.obterTodos().OrderBy(q => q.Nome))
            {
                comboQuestionario.Items.Add(quest);
            }
            comboQuestionario.DisplayMember = "Nome";

            comboDisciplina.DataSource = Disciplina.obterTodos();
            comboDisciplina.DisplayMember = "Nome";

            // Carrega a quantidade de tentativas
            for(int i=1; i<=4;i++)
            {
                comboTentativas.Items.Add(i);
            }

            // Carrega os Anos
            for (int i = 1; i <= 3; i++)
            {
                comboAno.Items.Add(i);
            }

            // Carrega os Semestres
            for (int i = 1; i <= 2; i++)
            {
                comboSemestre.Items.Add(i);
            }

            // Carrega as posicoes
            comboPosicaoPergunta.DataSource = Enum.GetNames(typeof(Questao.Posicao));
            comboposicaoRespostas.DataSource = Enum.GetNames(typeof(Questao.Posicao));


            pnlItensResposta.Visible = false;
            lblItensResposta.Visible = false;


            comboTipoQuestao.DataSource = TipoQuestao.obterTodos();
            comboTipoQuestao.DisplayMember = "Nome";
            comboTipoQuestao.Enabled = true;

            pnlAtributos.Visible = false;
        }

        private void limparTela()
        {
            txtTitulo.Text = "";
            txtVariacoes.Text = "";
            comboTentativas.SelectedIndex = -1;
            comboAno.SelectedIndex = -1;
            comboSemestre.SelectedIndex = -1;
            txtOrdem.Text = "";
            txtTag.Text = "";
            txtCompetencia.Text = "";

            corSelecionada = Color.White;
            pnlCor.BackColor = corSelecionada;
            pnlCor.UseCustomBackColor = true;

            comboTipoQuestao.SelectedIndex = 0;
            comboPosicaoPergunta.SelectedIndex = 0;
            comboposicaoRespostas.SelectedIndex = 0;
            

            txtTexto.Text = "";
            ckContemTexto.Checked = false;
            ckContemAudio.Checked = false;
            ckContemImagem.Checked = false;
            ckHint.Checked = false;
            ckEnfileirada.Checked = false;


            pnlItems.Controls.Clear();
            limparItemQuestao();
        }

        private void carregarQuestoesDestino(Questionario questionario)
        {
            comboQuestaoDestino.Items.Clear();
            comboOrdenacaoSaltoAcerto.Items.Clear();
            comboOrdenacaoSaltoErro.Items.Clear();

            foreach (var questao in questionario.Questao.OrderBy(q => q.Ordem).ToList<Questao>())
            {
                comboQuestaoDestino.Items.Add(questao.Ordem.ToString());
                comboOrdenacaoSaltoAcerto.Items.Add(questao.Ordem.ToString());
                comboOrdenacaoSaltoErro.Items.Add(questao.Ordem.ToString());
            }

            comboQuestaoDestino.Items.Add("FIM");
            comboOrdenacaoSaltoAcerto.Items.Add("FIM");
            comboOrdenacaoSaltoErro.Items.Add("FIM");
        }

        private void comboQuestionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboQuestionario.SelectedIndex >= 0)
            {
                btnNovaQuestao.Enabled = true;
                pnlInicioQuestao.Enabled = true;
                pnlAtributos.Enabled = false;
                PnlQuestao.Enabled = true;
                btnExcluirQuestao.Enabled = false;

                pnlQuestoesCadastradas.Enabled = true;
                questionarioAtual = comboQuestionario.SelectedItem as Questionario;

                pnlBotoesQuestoes.Controls.Clear();
                carregarQuestoesTela();

                pnlAtributos.Enabled = false;
                pnlAtributos.Visible = false;
                pnlItensResposta.Visible = false;
                lblItensResposta.Visible = false;

                this.Refresh();

            }
        }

        private void carregarQuestoesTela()
        {
            pnlBotoesQuestoes.Controls.Clear();

            foreach(Questao questao in questionarioAtual.Questao.OrderBy(q => q.Ordem))
            {
                MetroTile botaoQuestao = new MetroTile();
                botaoQuestao.Width = 290;
                botaoQuestao.Height = 55;
                botaoQuestao.TextAlign = ContentAlignment.MiddleLeft;
                botaoQuestao.Margin = new Padding(5);
                botaoQuestao.Text = questao.Ordem + @"- " + questao.Titulo;
                botaoQuestao.Name = questao.idQuestao.ToString();
                botaoQuestao.Click += new EventHandler(btnSelecaoQuestao_Click);

                pnlBotoesQuestoes.Controls.Add(botaoQuestao);
            }
        }

        #endregion

        #region Métodos de Questao

        private void btnSelecaoQuestao_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((MetroTile) sender).Name);
            Questao questaoSelecionada = Questao.get(id);

            questaoAtual = questaoSelecionada;

            // Carrega na tela
            txtTitulo.Text = questaoSelecionada.Titulo;
            comboTentativas.SelectedItem = Convert.ToInt32(questaoSelecionada.Tentativas);
            if (questaoSelecionada.Ano != null)
                comboAno.SelectedItem = Convert.ToInt32(questaoSelecionada.Ano);
            else
                comboAno.SelectedIndex = -1;

            if (questaoSelecionada.Semestre != null)
                comboSemestre.SelectedItem = Convert.ToInt32(questaoSelecionada.Semestre);
            else
                comboSemestre.SelectedIndex = -1;

            txtCompetencia.Text = "";
            txtTag.Text = "";
                
            
            txtOrdem.Text = questaoSelecionada.Ordem.ToString();
            if(questaoSelecionada.Competencia != null)
                 txtCompetencia.Text = questaoSelecionada.Competencia.ToString();

            txtTag.Text = questaoSelecionada.TAG;
            if (questaoSelecionada.Peso != null) 
                txtpeso.Text = questaoSelecionada.Peso.ToString();
            else
            {
                txtpeso.Text = "";
            }
            if (questaoSelecionada.Hint != null) 
                ckHint.Checked = (bool)questaoSelecionada.Hint;
            else
                ckHint.Checked = false;

            if (questaoSelecionada.Enfileirada != null)
                ckEnfileirada.Checked = (bool)questaoSelecionada.Enfileirada;
            else
                ckEnfileirada.Checked = false;

            corSelecionada = ColorTranslator.FromHtml(questaoSelecionada.Cor);
            pnlCor.BackColor = corSelecionada;
            pnlCor.UseCustomBackColor = true;

            comboTipoQuestao.SelectedItem = questaoSelecionada.TipoQuestao;
            comboPosicaoPergunta.SelectedItem = Enum.GetName(typeof(Questao.Posicao), questaoSelecionada.PosicaoPergunta);
            comboposicaoRespostas.SelectedItem = Enum.GetName(typeof(Questao.Posicao), questaoSelecionada.PosicaoRespostas);
            comboDisciplina.SelectedItem = questaoSelecionada.Disciplina;
            comboArea.SelectedItem = questaoSelecionada.Area;

            caminhoAudioPergunta = null;
            caminhoImagemPergunta = null;
            caminhoAudioSucessoResposta = null;
            caminhoAudioErroResposta = null;
            caminhoAudioLeitura = null;
           


            ItemQuestao pergunta = questaoSelecionada.ItemQuestao.ToList().Find(i => i.EPergunta == true);

            if (pergunta != null)
            {
                if (!string.IsNullOrEmpty(pergunta.Titulo))
                {
                    ckContemTexto.Checked = true;

                    if (comboTipoQuestao.SelectedIndex == 3)
                    {
                        txtTexto.Text = pergunta.Titulo;

                        if (pergunta.Titulo.Contains("("))
                        {
                            int posicaoParenteses = pergunta.Titulo.IndexOf("(");

                            string palavra = pergunta.Titulo.Substring(0, posicaoParenteses);
                            string variacoes = pergunta.Titulo.Remove(0, posicaoParenteses + 1);
                            variacoes = variacoes.Substring(0, variacoes.Length - 1);

                            txtVariacoes.Text = variacoes;
                            txtTexto.Text = palavra;
                        }
                    }
                    else
                    {
                        txtTexto.Text = pergunta.Titulo;
                    }
                }
                else
                {
                    ckContemTexto.Checked = false;
                }

                if (pergunta.ContemImagem != null && (bool) pergunta.ContemImagem)
                    ckContemImagem.Checked = true;
                else
                    ckContemImagem.Checked = false;

                if (pergunta.ContemAudio != null && (bool) pergunta.ContemAudio)
                    ckContemAudio.Checked = true;
                else
                    ckContemAudio.Checked = false;
            }

            TabControlRespostas.SelectedTab = tabRespostas;

            carregaItensQuestaoTela(questaoSelecionada);

            carregarAudiosTela();

            PnlQuestao.Enabled = true;
            pnlAtributos.Enabled = true;
            pnlAtributos.Visible = true;
            pnlItensResposta.Visible = true;
            lblItensResposta.Visible = true;
            btnExcluirQuestao.Enabled = true;

            carregarQuestoesDestino(questaoSelecionada.Questionario);

            limparItemQuestao();

            // Estrutura de Arquivos
            string dirQuest = ConfigurationManager.AppSettings["avalFullPath"] + "\\" + questionarioAtual.idQuestionario + "\\" + questaoSelecionada.idQuestao + "\\";

            if (!Directory.Exists(dirQuest))
            {
                ((Master) MdiParent).MensagemErro("Essa questão não existe na sua estrutura de arquivos! Verifique sua estrutura ou exclua essa questão.");
            }

            this.Refresh();

        }

        private void carregaItensQuestaoTela(Questao questao)
        {
            pnlItems.Controls.Clear();

            // Carrega as Respostas
            List<ItemQuestao> listaRespostas = questao.ItemQuestao.ToList().FindAll(i => i.Eresposta == true);
            foreach (ItemQuestao item in listaRespostas)
            {
                // Adiciona na interface
                var botaoOpcao = new MetroTile();
                botaoOpcao.Width = 103;
                botaoOpcao.Height = 60;
                botaoOpcao.TextAlign = ContentAlignment.MiddleLeft;
                botaoOpcao.Margin = new Padding(4);
                botaoOpcao.Text = item.OrdemTela + @"- " + item.Titulo;
                botaoOpcao.Name = item.idItemQuestao.ToString();
                botaoOpcao.Click += new EventHandler(btnSelecaoItem_Click);

                if (item.OpcaoCorreta != null && (bool)item.OpcaoCorreta)
                {
                    botaoOpcao.BackColor = Color.LightGreen;
                    botaoOpcao.UseCustomBackColor = true;
                }

                pnlItems.Controls.Add(botaoOpcao);
            }

        }

        private void btnNovaQuestao_Click(object sender, EventArgs e)
        {
            caminhoAudioPergunta = null;
            caminhoImagemPergunta = null;
            caminhoImagemResposta = null;
            caminhoAudioSucessoResposta = null;
            caminhoAudioErroResposta = null;
            caminhoAudioLeitura = null;

            questaoAtual = null;
            itemquestaoAtual = null;

            PnlQuestao.Enabled = true;
            pnlAtributos.Enabled = true;
            pnlAtributos.Visible = true;

            limparTela();
            pnlItensResposta.Visible = false;
            lblItensResposta.Visible = false;
            btnExcluirQuestao.Enabled = false;
        }

        static int ToInt(Color c)
        {
            return c.R + c.G * 0x100 + c.B * 0x10000;
        }

        private void pnlCor_Click(object sender, EventArgs e)
        {
            colorDialog1.AnyColor = false;
            colorDialog1.Color = Color.Blue;
            colorDialog1.CustomColors = new int[] { ToInt(Color.Blue), ToInt(Color.Green), ToInt(Color.Red), ToInt(Color.Yellow) };
            colorDialog1.SolidColorOnly = true;
           

            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if ((colorDialog1.Color == Color.Blue) || (colorDialog1.Color == Color.Green) ||
                    (colorDialog1.Color == Color.Red) || (colorDialog1.Color == Color.Yellow))
                {

                    corSelecionada = colorDialog1.Color;
                    pnlCor.BackColor = corSelecionada;
                    pnlCor.UseCustomBackColor = true;
                }
                else
                {
                    pnlCor.BackColor = Color.White;
                    pnlCor.UseCustomBackColor = true;
                    ((Master)MdiParent).MensagemErro("Cor selecionada não permitida.");
                }
            }

        }

        private void btnSalvarQuestao_Click(object sender, EventArgs e)
        {
            if(validarSalvarQuestao())
            {
                Questao questao = questaoAtual;

                if (questao == null)
                {
                    // Cria uma questao
                    questao = new Questao();
                }



                questao.Titulo = txtTitulo.Text;
                questao.Tentativas = Convert.ToInt32(comboTentativas.SelectedItem);
                questao.Ano = Convert.ToInt32(comboAno.SelectedItem);
                questao.Semestre = Convert.ToInt32(comboSemestre.SelectedItem);
                questao.Ordem = Convert.ToInt32(txtOrdem.Text);
                questao.Competencia = txtCompetencia.Text;
                questao.Cor = ColorTranslator.ToHtml(corSelecionada);
                questao.TipoQuestao = comboTipoQuestao.SelectedItem as TipoQuestao;
                questao.PosicaoPergunta = (int)(Enum.Parse(typeof(Questao.Posicao), comboPosicaoPergunta.SelectedItem.ToString()));
                questao.PosicaoRespostas = (int)(Enum.Parse(typeof(Questao.Posicao), comboposicaoRespostas.SelectedItem.ToString()));
                questao.Questionario = questionarioAtual;
                questao.Disciplina = comboDisciplina.SelectedItem as Disciplina;
                questao.Area = comboArea.SelectedItem as Area;
                questao.Hint = ckHint.Checked;
                questao.Enfileirada = ckEnfileirada.Checked;

                if (!String.IsNullOrEmpty(txtpeso.Text))
                {
                    questao.Peso = double.Parse(txtpeso.Text);
                }

                if (!String.IsNullOrEmpty(txtTag.Text))
                {
                    questao.TAG = txtTag.Text;
                }


                ItemQuestao itemPergunta;
                if(questaoAtual != null)
                {
                    itemPergunta = questao.ItemQuestao.ToList().Find(i => i.EPergunta == true);
                }
                else
                {
                     // Cria uma Resposta
                    itemPergunta = new ItemQuestao();
                }

                itemPergunta.EPergunta = true;
                itemPergunta.Questao = questao;

                

                if (comboTipoQuestao.SelectedIndex == 3)
                {
                    itemPergunta.Titulo = txtTexto.Text.ToUpper();

                    if (txtVariacoes.Text.Length > 0)
                    {
                        itemPergunta.Titulo = txtTexto.Text.ToUpper() + "(" + txtVariacoes.Text.ToUpper() + ")";
                    }
                }
                else
                {
                    itemPergunta.Titulo = txtTexto.Text;
                }

                // BANCO
                if(questaoAtual == null)
                {
                    // Salva tudo no Banco
                    questao.adicionar(questao);
                    itemPergunta.adicionar(itemPergunta);

                    MetroTile botaoQuestao = new MetroTile();
                    botaoQuestao.Width = 302;
                    botaoQuestao.Height = 55;
                    botaoQuestao.TextAlign = ContentAlignment.MiddleLeft;
                    botaoQuestao.Margin = new Padding(5);
                    botaoQuestao.Text = questao.Ordem + @"- " + questao.Titulo;
                    botaoQuestao.Name = questao.idQuestao.ToString();
                    botaoQuestao.Click += new EventHandler(btnSelecaoQuestao_Click);

                    pnlBotoesQuestoes.Controls.Add(botaoQuestao);
                    
                    // Estrutura de Arquivos
                    string dirQuest = questao.Diretorio;

                    if (!Directory.Exists(dirQuest))
                    {
                        Directory.CreateDirectory(dirQuest);
                    }

                    ((Master) MdiParent).MensagemSucesso("Questão Cadastrada!");
                }
                else
                {
                    // Estrutura de Arquivos
                    string dirQuest = ConfigurationManager.AppSettings["avalFullPath"] + "\\" + questionarioAtual.idQuestionario + "\\" + questao.idQuestao + "\\";

                    if (!Directory.Exists(dirQuest))
                    {
                        ((Master) MdiParent).MensagemErro("Essa questão não existe na sua estrutura de arquivos! Verifique sua estrutura ou exclua essa questão.");
                        return;
                    }

                    // Atualiza tudo no Banco
                    questao.atualizar(questao);
                    itemPergunta.atualizar(itemPergunta);

                    ((Master) MdiParent).MensagemSucesso("Questão Atualizada!");
                }

                // Trata os arquivos no diretorio
                if (ckContemImagem.Checked)
                {
                    if (caminhoImagemPergunta != null)
                        itemPergunta.criarImagem(caminhoImagemPergunta);
                }
                else
                {
                    // Apagou a imagem
                    if (itemPergunta.ContemImagem != null && (bool)itemPergunta.ContemImagem)
                    {
                        itemPergunta.apagarImagem();
                    }
                }

                if(ckContemAudio.Checked)
                {
                    if (caminhoAudioPergunta != null)
                        itemPergunta.criarAudio(caminhoAudioPergunta);
                }
                else
                {
                    // Apagou o audio
                    if (itemPergunta.ContemAudio != null && (bool)itemPergunta.ContemAudio)
                    {
                        itemPergunta.apagarAudio();
                    }
                }

                questaoAtual = questao;

                pnlItensResposta.Visible = true;
                lblItensResposta.Visible = true;
                btnExcluirQuestao.Enabled = true;

                carregarQuestoesDestino(questaoAtual.Questionario);

                carregarQuestoesTela();
            }
        }

        private bool validarSalvarQuestao()
        {

            if(txtTitulo.Text.Length < 3)
            {
                ((Master) MdiParent).MensagemAlerta("Digite um Titulo para identificar essa questão. (Ao menos 3 letras)");
                return false;
            }

            if(comboTentativas.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione a quantidade de tentativas permitidas pela questão");
                return false;
            }

            if(txtOrdem.Text.Length <=0)
            {
                ((Master) MdiParent).MensagemAlerta("Defina um número para essa questão dentro do questionário. (Ordem)");
                return false;
            }

            if(comboTipoQuestao.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione qual o Tipo de Questão");
                return false;
            }

            if(comboPosicaoPergunta.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione a posição na qual a pergunta irá aparecer (Posição da Pergunta)");
                return false;
            }

            if (comboposicaoRespostas.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione a posição na qual as respostas aparecerão (Posição da Pergunta)");
                return false;
            }


            if (comboDisciplina.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione a Disciplina.");
                return false;
            }

            if (comboArea.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione o Eixo.");
                return false;
            }

            if (String.IsNullOrEmpty(txtCompetencia.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Defina a competência da questão.");
                return false;
            }

            if (pnlCor.BackColor.Equals(Color.White))
            {
                ((Master)MdiParent).MensagemAlerta("Selecione a cor da questão.");
                return false;
            }

            if(ckContemTexto.Checked)
            {
                if(txtTexto.Text.Length == 0)
                {
                    ((Master) MdiParent).MensagemAlerta("Selecionou que a pergunta irá conter texto mas não cadastrou nenhum texto.");
                    return false;
                }
            }

            if (comboAno.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione o Ano.");
                return false;
            }

            if (comboSemestre.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione o Semestre.");
                return false;
            }

            if (questaoAtual == null)
            {
                if (ckContemImagem.Checked)
                {
                    if (String.IsNullOrEmpty(caminhoImagemPergunta))
                    {
                        ((Master) MdiParent).MensagemAlerta("Selecionou que a pergunta irá conter imagem mas não selecionou nenhuma imagem.");
                        return false;
                    }
                }

                if (ckContemAudio.Checked)
                {
                    if (String.IsNullOrEmpty(caminhoAudioPergunta))
                    {
                        ((Master) MdiParent).MensagemAlerta("Selecionou que a pergunta irá conter áudio mas não selecionou nenhum áudio.");
                        return false;
                    }
                }
            }

            if (!ckContemTexto.Checked && !ckContemImagem.Checked && !ckContemAudio.Checked)
            {
                ((Master) MdiParent).MensagemAlerta("A pergunta precisa conter ao menos uma das opções: Texto, Imagem, Áudio");
                return false;
            }

            if (comboTipoQuestao.SelectedIndex == 3)
            {
                if (String.IsNullOrEmpty(txtTexto.Text))
                {
                    ((Master)MdiParent).MensagemAlerta("Uma questão do tipo Psicogenese precisa que o texto da pergunta seja a Palavra, por favor digite a palavra no texto da pergunta.");
                    return false;   
                }

                if (!txtTexto.Text.Contains(";"))
                {
                    if (txtTexto.Text.Length > 4)
                    {
                        ((Master)MdiParent).MensagemAlerta("Uma questão do tipo Psicogenese precisa que o texto da pergunta seja a Palavra dividida em silabas, separadas por ponto e vírgula (;). A não ser que seja monossílaba, mas nesse caso o sistema exige que tenha no máximo 4 letras.");
                        return false;  
                    }
                }

                string alfabetoValido = ";ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                foreach (var letra in txtTexto.Text.ToCharArray())
                {
                    if (!alfabetoValido.Contains(letra))
                    {
                        ((Master)MdiParent).MensagemAlerta("A palavra da Psicogenese contém letra(s) que não pode(m) ser utilizadas. Substitua a letra: '" + letra + "'");
                        return false;
                    }
                }

                alfabetoValido = ";|ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                if (!String.IsNullOrEmpty(txtVariacoes.Text))
                {
                    foreach (var letra in txtVariacoes.Text.ToCharArray())
                    {
                        if (!alfabetoValido.Contains(letra))
                        {
                            ((Master)MdiParent).MensagemAlerta("Uma das variações contém letra(s) que não pode(m) ser utilizadas. Substitua a letra: '" + letra + "'");
                            return false;
                        }
                    }
                }
             
            }

            if (comboPosicaoPergunta.SelectedItem.ToString() == comboposicaoRespostas.SelectedItem.ToString())
            {
                ((Master) MdiParent).MensagemAlerta("A posição na tela da pergunta não pode ser a mesma da resposta.");
                return false;
            }

            if (!String.IsNullOrEmpty(txtpeso.Text))
            {
                double peso;

                if (!double.TryParse(txtpeso.Text, out peso))
                {
                    ((Master)MdiParent).MensagemAlerta("O peso deve ser um número decimal.");
                    return false;
                }
            }


            return true;

        }

        private void btnExcluirQuestao_Click(object sender, EventArgs e)
        {
             DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir essa questão?");

             if (di == DialogResult.OK)
             {
                 questaoAtual.deletar(questaoAtual);
                 questaoAtual = null;
                 limparTela();

                 pnlItensResposta.Visible = false;
                 lblItensResposta.Visible = false;
                 btnExcluirQuestao.Enabled = false;

                 pnlBotoesQuestoes.Controls.Clear();
                 carregarQuestoesTela();
             }
        }

        private void ckContemTexto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckContemTexto.Checked)
                txtTexto.Enabled = true;
            else
            {
                txtTexto.Text = "";
                txtTexto.Enabled = false;
            }
        }

        private void ckContemImagem_CheckedChanged(object sender, EventArgs e)
        {
            if (ckContemImagem.Checked)
                btnImagemPergunta.Enabled = true;
            else
                btnImagemPergunta.Enabled = false;
        }

        private void ckContemAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (ckContemAudio.Checked)
                btnAudioPergunta.Enabled = true;
            else
                btnAudioPergunta.Enabled = false;
        }

        private void btnImagemPergunta_Click(object sender, EventArgs e)
        {
            caminhoImagemPergunta = ((Master) MdiParent).envioImagem();
        }

        private void btnAudioPergunta_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                 var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioPergunta = val;
                    }
                }
            }
        }

        private void comboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboDisciplina.SelectedIndex >= 0)
            {
                comboArea.Items.Clear();

                foreach (var area in Area.obterTodos().FindAll(a => a.Disciplina == comboDisciplina.SelectedItem))
                {
                    comboArea.Items.Add(area);
                }

                comboArea.DisplayMember = "Nome";
            }
        }

        #endregion

        #region Métodos de Resposta

        private void btnImagemResposta_Click(object sender, EventArgs e)
        {
            caminhoImagemResposta = ((Master) MdiParent).envioImagem();
        }

        private void ckRespostaTexto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRespostaTexto.Checked)
            {
                txtTextoResposta.Enabled = true;
                ckRespostaImagem.Checked = false;
            }
            else
            {
                txtTextoResposta.Enabled = false;
            }
        }

        private void ckRespostaImagem_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRespostaImagem.Checked)
            {
                btnImagemResposta.Enabled = true;
                ckRespostaTexto.Checked = false;
                txtTextoResposta.Text = "";
            }
            else
                btnImagemResposta.Enabled = false;
        }

        private void ckOpcaoPorSalto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOpcaoPorSalto.Checked)
            {
                if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
                {
                    pnlSaltosOrdenacao.Enabled = true;
                }

                comboQuestaoDestino.Enabled = true;
            }
            else
            {
                if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
                {
                    pnlSaltosOrdenacao.Enabled = false;
                }

                comboQuestaoDestino.Enabled = false;
            }
        }

        private void btnSelecaoItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((MetroTile) sender).Name);
            ItemQuestao itemquestaoSelecionado = ItemQuestao.get(id);

            limparItemQuestao();
            caminhoImagemPergunta = null;
            caminhoAudioPergunta = null;
            caminhoImagemResposta = null;
            caminhoAudioSucessoResposta = null;
            caminhoAudioErroResposta = null;
            caminhoAudioLeitura = null;

            itemquestaoAtual = itemquestaoSelecionado;

            if (!string.IsNullOrEmpty(itemquestaoSelecionado.Titulo))
            {
                ckRespostaTexto.Checked = true;
                txtTextoResposta.Text = itemquestaoSelecionado.Titulo;
            }

            if (itemquestaoSelecionado.ContemImagem != null && (bool)itemquestaoSelecionado.ContemImagem)
                ckRespostaImagem.Checked = true;

            txtOrdemTela.Text = itemquestaoSelecionado.OrdemTela.ToString();
            txtOrdemResposta.Text = itemquestaoSelecionado.OrdemResposta.ToString();


            if (itemquestaoSelecionado.OpcaoCorreta != null)
                ckRespostaOpcaoCorreta.Checked = (bool)itemquestaoSelecionado.OpcaoCorreta;

            if (itemquestaoSelecionado.Salto != null && itemquestaoSelecionado.Salto.Count > 0)
            {
                // Verifica se é salto de ordenação ou forca
                if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
                {
                    Salto saltoAcerto = itemquestaoSelecionado.Salto.ToList().Find(s => s.SaltarAoErrar == false);
                    if (saltoAcerto != null)
                    {
                        if (saltoAcerto.VoltarDoSalto == null)
                            comboOrdenacaoSaltoAcerto.SelectedItem = saltoAcerto.Questao.Ordem.ToString();
                        else
                            comboOrdenacaoSaltoAcerto.SelectedItem = "FIM";
                    }

                    Salto saltoErro = itemquestaoSelecionado.Salto.ToList().Find(s => s.SaltarAoErrar == true);
                    if (saltoErro != null)
                    {
                        if (saltoErro.VoltarDoSalto == null)
                            comboOrdenacaoSaltoErro.SelectedItem = saltoErro.Questao.Ordem.ToString();
                        else
                            comboOrdenacaoSaltoErro.SelectedItem = "FIM";
                    }
                }
                else
                {
                    Salto salto = itemquestaoSelecionado.Salto.ToList()[0];

                    if (salto.VoltarDoSalto == null)
                    {
                        comboQuestaoDestino.SelectedItem = salto.Questao.Ordem.ToString();
                    }
                    else
                    {
                        comboQuestaoDestino.SelectedItem = "FIM";
                    }
                }

                ckOpcaoPorSalto.Checked = true;
            }
            else
            {
                ckOpcaoPorSalto.Checked = false;
                comboQuestaoDestino.SelectedIndex = -1;
                comboOrdenacaoSaltoAcerto.SelectedIndex = -1;
                comboOrdenacaoSaltoErro.SelectedIndex = -1;
            }


            ItemArquivo audioleitura = itemquestaoSelecionado.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioLeitura);
            if (audioleitura != null)
            {
                ckRespostaAudio.Checked = true;
                btnAudioLeituraOp.Enabled = true;
            }

            btnExcluirItem.Enabled = true;
            btnAudioSucessoOp.Enabled = true;
            btnAudioErroOp.Enabled = true;

        }


        private void btnSalvarItem_Click(object sender, EventArgs e)
        {
            if (validarSalvarItemQuestao())
            {
                bool teveSalto = false;
                bool deletaSalto = false;
                bool teveSaltoAcerto = false;
                bool teveSaltoErro = false;
                Salto salto = null;
                Salto saltoAcerto = null;
                Salto saltoErro = null;
                ItemQuestao itemQuestao = itemquestaoAtual;
                
                if(itemquestaoAtual == null)
                {
                    itemQuestao = new ItemQuestao();
                }
                
                itemQuestao.Eresposta = true;
                itemQuestao.Questao = questaoAtual;

                if (ckRespostaTexto.Checked)
                    itemQuestao.Titulo = txtTextoResposta.Text;
                itemQuestao.OrdemTela = Convert.ToInt32(txtOrdemTela.Text);

                if (txtOrdemResposta.Text.Length > 0)
                    itemQuestao.OrdemResposta = Convert.ToInt32(txtOrdemResposta.Text);

                itemQuestao.OpcaoCorreta = ckRespostaOpcaoCorreta.Checked;


                if(ckOpcaoPorSalto.Checked)
                {
                    // TRATA OS SALTOS DE FORMA DIFERENTE PARA QUESTOES DE ORDENACAO E FORCA
                    if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
                    {
                        if (itemquestaoAtual != null)
                        {
                            saltoAcerto = itemquestaoAtual.Salto.ToList().Find(s => s.SaltarAoErrar == false);
                            saltoErro = itemquestaoAtual.Salto.ToList().Find(s => s.SaltarAoErrar == true);
                        }

                        // Salto em caso de acerto
                        if (comboOrdenacaoSaltoAcerto.SelectedIndex >= 0)
                        {
                            if (saltoAcerto == null)
                            {
                                saltoAcerto = new Salto();
                                teveSaltoAcerto = true;
                            }

                            saltoAcerto.ItemQuestao = itemQuestao;

                            Questao questaoSalto;
                            if (comboOrdenacaoSaltoAcerto.SelectedItem.Equals("FIM"))
                            {
                                questaoSalto = itemQuestao.Questao;
                                saltoAcerto.VoltarDoSalto = false;
                            }
                            else
                            {
                                questaoSalto =
                                    questaoAtual.Questionario.Questao.ToList()
                                        .Find(q => q.Ordem.ToString().Equals(comboOrdenacaoSaltoAcerto.SelectedItem));
                                saltoAcerto.VoltarDoSalto = null;
                            }

                            saltoAcerto.Questao = questaoSalto;
                            saltoAcerto.SaltarAoErrar = false;

                            if (!teveSaltoAcerto)
                                saltoAcerto.atualizar(saltoAcerto);
                        }
                        else
                        {
                            if (saltoAcerto != null)
                                saltoAcerto.deletar(saltoAcerto);

                        }

                        // salto em caso de erro
                        if (comboOrdenacaoSaltoErro.SelectedIndex >= 0)
                        {
                            if (saltoErro == null)
                            {
                                saltoErro = new Salto();
                                teveSaltoErro = true;
                            }

                            saltoErro.ItemQuestao = itemQuestao;

                            Questao questaoSalto;
                            if (comboOrdenacaoSaltoErro.SelectedItem.Equals("FIM"))
                            {
                                questaoSalto = itemQuestao.Questao;
                                saltoErro.VoltarDoSalto = false;
                            }
                            else
                            {
                                questaoSalto =
                                    questaoAtual.Questionario.Questao.ToList()
                                        .Find(q => q.Ordem.ToString().Equals(comboOrdenacaoSaltoErro.SelectedItem));
                                saltoErro.VoltarDoSalto = null;
                            }

                            saltoErro.Questao = questaoSalto;
                            saltoErro.SaltarAoErrar = true;
                            if (!teveSaltoErro)
                                saltoErro.atualizar(saltoErro);
                        }
                        else
                        {
                            if (saltoErro != null)
                                saltoErro.deletar(saltoErro);
                        }
                    }
                    else
                    {
                        if (itemquestaoAtual == null)
                        {
                            salto = new Salto();
                            teveSalto = true;
                        }
                        else
                        {
                            if (itemquestaoAtual.Salto.Count > 0)
                            {
                                salto = itemquestaoAtual.Salto.ToList()[0];
                            }
                            else
                            {
                                salto = new Salto();
                                teveSalto = true;
                            }
                        }

                        salto.ItemQuestao = itemQuestao;

                        Questao questaoSalto;

                        if (comboQuestaoDestino.SelectedItem.Equals("FIM"))
                        {
                            questaoSalto = itemQuestao.Questao;
                            salto.VoltarDoSalto = false;
                        }
                        else
                        {
                            questaoSalto =
                                questaoAtual.Questionario.Questao.ToList()
                                    .Find(q => q.Ordem.ToString().Equals(comboQuestaoDestino.SelectedItem));
                            salto.VoltarDoSalto = null;
                        }

                        salto.Questao = questaoSalto;
                        salto.SaltarAoErrar = !itemQuestao.OpcaoCorreta;

                        if (!teveSalto)
                            salto.atualizar(salto);
                        
                    }
                }
                else
                {
                    if (itemquestaoAtual != null)
                    {
                        if (itemquestaoAtual.Salto.Count > 0)
                        {
                            deletaSalto = true;
                        }
                    }
                }

                // BANCO
                if (itemquestaoAtual != null)
                {
                    itemQuestao.atualizar(itemQuestao);

                    if (teveSalto) salto.adicionar(salto);
                    if (teveSaltoAcerto) saltoAcerto.adicionar(saltoAcerto);
                    if (teveSaltoErro) saltoErro.adicionar(saltoErro);
                   
                    if (deletaSalto)
                    {
                         itemquestaoAtual.Salto.ToList().ForEach(i => i.deletar(i));
                    }

                    ((Master) MdiParent).MensagemSucesso("Opção de Resposta Atualizada!");
                }
                else
                {
                    // Salva no banco
                    itemQuestao.adicionar(itemQuestao);
                    if (teveSalto) salto.adicionar(salto);
                    if (teveSaltoAcerto) saltoAcerto.adicionar(saltoAcerto);
                    if (teveSaltoErro) saltoErro.adicionar(saltoErro);


                    // Adiciona na interface
                    MetroTile botaoOpcao = new MetroTile();
                    botaoOpcao.Width = 103;
                    botaoOpcao.Height = 60;
                    botaoOpcao.TextAlign = ContentAlignment.MiddleLeft;
                    botaoOpcao.Margin = new Padding(4);
                    botaoOpcao.Text = itemQuestao.OrdemTela + @"- " + itemQuestao.Titulo;
                    botaoOpcao.Name = itemQuestao.idItemQuestao.ToString();
                    botaoOpcao.Click += new EventHandler(btnSelecaoItem_Click);

                    if (itemQuestao.OpcaoCorreta != null && (bool)itemQuestao.OpcaoCorreta)
                    {
                        botaoOpcao.BackColor = Color.LightGreen;
                        botaoOpcao.UseCustomBackColor = true;
                    }

                    ((Master) MdiParent).MensagemSucesso("Opção de Resposta Cadastrada!");
                }

                if (ckRespostaAudio.Checked)
                {
                    if (caminhoAudioLeitura != null)
                        itemQuestao.criarAudio(caminhoAudioLeitura, TipoArquivo.audioLeitura);
                }
                else
                {
                    // Apagou a audio de leitura
                    ItemArquivo audioleitura = itemQuestao.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioLeitura);
                    if (audioleitura != null)
                    {
                        itemQuestao.apagarAudioLeitura();
                    }
                }

                //if (caminhoAudioLeitura != null)
                //    itemQuestao.criarAudio(caminhoAudioLeitura, TipoArquivo.audioLeitura);

                if (caminhoAudioSucessoResposta != null)
                    itemQuestao.criarAudio(caminhoAudioSucessoResposta, TipoArquivo.audioSucessoOpcao);

                if (caminhoAudioErroResposta != null)
                    itemQuestao.criarAudio(caminhoAudioErroResposta, TipoArquivo.audioErroOpcao);

                // Trata os arquivos no diretorio
                if (ckRespostaImagem.Checked)
                {
                    if (caminhoImagemResposta != null)
                        itemQuestao.criarImagem(caminhoImagemResposta);
                }
                else
                {
                    // Apagou a imagem
                    if (itemQuestao.ContemImagem != null && (bool)itemQuestao.ContemImagem)
                    {
                        itemQuestao.apagarImagem();
                    }
                }

                limparItemQuestao();

                carregaItensQuestaoTela(itemQuestao.Questao);

            }
        }

        private bool validarSalvarItemQuestao()
        {

            if (!ckRespostaTexto.Checked && !ckRespostaImagem.Checked)
            {
                ((Master) MdiParent).MensagemAlerta("Uma opção de respota deve conter um texto ou uma imagem.");
                return false;
            }


            if (ckRespostaTexto.Checked)
            {
                if (txtTextoResposta.Text.Length <= 0)
                {
                    ((Master) MdiParent).MensagemAlerta("Selecionou que a resposta irá conter texto mas não cadastrou nenhum texto.");
                    return false;
                }
            }


            if (txtOrdemTela.Text.Length <= 0)
            {
                ((Master) MdiParent).MensagemAlerta("Defina um número de ordem para essa opção de respota. (Ordem na Tela)");
                return false;
            }

            if (itemquestaoAtual == null)
            {
                if (ckRespostaImagem.Checked)
                {
                    if (String.IsNullOrEmpty(caminhoImagemResposta))
                    {
                        ((Master) MdiParent).MensagemAlerta("Selecionou que a resposta irá conter imagem mas não selecionou nenhuma imagem.");
                        return false;
                    }
                }
            }

            if (ckOpcaoPorSalto.Checked)
            {
                if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
                {
                    if (comboOrdenacaoSaltoAcerto.SelectedIndex < 0 && comboOrdenacaoSaltoErro.SelectedIndex < 0)
                    {
                        ((Master)MdiParent).MensagemAlerta("Selecione a questão que destino do salto.");
                        return false;
                    }
                }
                else
                {
                    if (comboQuestaoDestino.SelectedIndex < 0)
                    {
                        ((Master)MdiParent).MensagemAlerta("Selecione a questão que destino do salto.");
                        return false;
                    }
                }

               
            }


            return true;

        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir essa opção?");

            if(di == DialogResult.OK)
            {
                itemquestaoAtual.deletar(itemquestaoAtual);
                itemquestaoAtual = null;

                carregaItensQuestaoTela(questaoAtual);

                limparItemQuestao();
            }
        }

        private void btnNovaOpcao_Click(object sender, EventArgs e)
        {
            caminhoImagemResposta = null;

            limparItemQuestao();
            itemquestaoAtual = null;
            btnExcluirItem.Enabled = false;
            btnAudioLeituraOp.Enabled = true;
            btnAudioSucessoOp.Enabled = true;
            btnAudioErroOp.Enabled = true;
        }

        private void limparItemQuestao()
        {
            itemquestaoAtual = null;
            ckRespostaTexto.Checked = false;
            ckRespostaImagem.Checked = false;
            ckRespostaAudio.Checked = false;
            txtTextoResposta.Text = "";
            txtOrdemTela.Text = "";
            txtOrdemResposta.Text = "";
            ckRespostaOpcaoCorreta.Checked = false;
            ckOpcaoPorSalto.Checked = false;
            comboQuestaoDestino.SelectedIndex = -1;
            comboOrdenacaoSaltoAcerto.SelectedIndex = -1;
            comboOrdenacaoSaltoErro.SelectedIndex = -1;
            btnExcluirItem.Enabled = false;
            btnAudioLeituraOp.Enabled = false;
            btnAudioSucessoOp.Enabled = false;
            btnAudioErroOp.Enabled = false;

            caminhoAudioLeitura = null;
            caminhoAudioSucessoResposta = null;
            caminhoAudioErroResposta = null;
        }

        private void btnAudioLeituraOp_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioLeitura = val;
                    }
                }
            }
        }

        private void btnAudioSucessoOp_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioSucessoResposta = val;
                    }
                }
            }
        }

        private void btnAudioErroOp_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioErroResposta = val;
                    }
                }
            }
        }

        #endregion


        #region Métodos Áudio Questão

        private void btnAudioSucesso_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioSucesso = val;
                    }
                }
            }
        }

        private void btnAudioErro_Click(object sender, EventArgs e)
        {
            using (var form = new FormAudio())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.caminhoAudioFinal;

                    if (!String.IsNullOrEmpty(val))
                    {
                        caminhoAudioErro = val;
                    }
                }
            }
        }

        private void btnSalvarAudios_Click(object sender, EventArgs e)
        {
            if((caminhoAudioSucesso == null) && (caminhoAudioErro == null))
            {
                ((Master) MdiParent).MensagemAlerta("Selecione algum Áudio para enviar.");
                return;
            }

            if(caminhoAudioSucesso != null)
            {
                ItemQuestao itemAudioSucesso = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == true));

                if(itemAudioSucesso == null)
                {
                    itemAudioSucesso = new ItemQuestao();
                    itemAudioSucesso.adicionar(itemAudioSucesso);
                }

                itemAudioSucesso.ETentativa = true;
                itemAudioSucesso.Questao = questaoAtual;
                itemAudioSucesso.OpcaoCorreta = true;
                itemAudioSucesso.ContemAudio = true;

                Arquivo arq = itemAudioSucesso.criarAudio(caminhoAudioSucesso);

                lblAudioSucessoCadastrado.Text = arq.Nome;
            }

            if (caminhoAudioErro != null)
            {
                ItemQuestao itemAudioErro = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == false));

                if (itemAudioErro == null)
                {
                    itemAudioErro = new ItemQuestao();
                    itemAudioErro.adicionar(itemAudioErro);
                }

                itemAudioErro.ETentativa = true;
                itemAudioErro.Questao = questaoAtual;
                itemAudioErro.OpcaoCorreta = false;
                itemAudioErro.ContemAudio = true;

                Arquivo arq = itemAudioErro.criarAudio(caminhoAudioErro);

                lblAudioErroCadastrado.Text = arq.Nome;
            }

            caminhoAudioSucesso = null;
            caminhoAudioErro = null;
            btnExcluirAudioSucesso.Enabled = true;
            btnExcluirAudioErro.Enabled = true;

            ((Master) MdiParent).MensagemSucesso("Áudio(s) Cadastrados!");
        }

        private void btnExcluirAudioSucesso_Click(object sender, EventArgs e)
        {
             DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir esse áudio?");

             if (di == DialogResult.OK)
             {
                 ItemQuestao itemAudioSucesso = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == true));

                 itemAudioSucesso.apagarAudio();
                 itemAudioSucesso.deletar(itemAudioSucesso);

                 btnExcluirAudioSucesso.Enabled = false;
                 lblAudioSucessoCadastrado.Text = "";
             }
        }

        private void btnExcluirAudioErro_Click(object sender, EventArgs e)
        {
            DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir esse áudio?");

            if (di == DialogResult.OK)
            {
                ItemQuestao itemAudioErro = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == false));

                itemAudioErro.apagarAudio();
                itemAudioErro.deletar(itemAudioErro);

                btnExcluirAudioErro.Enabled = false;
                lblAudioErroCadastrado.Text = "";
            }
        }

        private void carregarAudiosTela()
        {
            caminhoAudioSucesso = null;
            caminhoAudioErro = null;

            ItemQuestao itemAudioSucesso = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == true));
            if(itemAudioSucesso != null)
            {
                ItemArquivo itemArq = itemAudioSucesso.ItemArquivo.ToList()[0];
                lblAudioSucessoCadastrado.Text = itemArq.Arquivo.Nome;
                btnExcluirAudioSucesso.Enabled = true;
            }
            else
            {
                lblAudioSucessoCadastrado.Text = "";
                btnExcluirAudioSucesso.Enabled = false;
            }

            ItemQuestao itemAudioErro = questaoAtual.ItemQuestao.ToList().Find(i => (i.ETentativa == true) && (i.OpcaoCorreta == false));
            if (itemAudioErro != null)
            {
                ItemArquivo itemArq = itemAudioErro.ItemArquivo.ToList()[0];
                lblAudioErroCadastrado.Text = itemArq.Arquivo.Nome;
                btnExcluirAudioErro.Enabled = true;
            }
            else
            {
                lblAudioErroCadastrado.Text = "";
                btnExcluirAudioErro.Enabled = false;
            }
        }


        #endregion

        #region validacaoTela

        private void txtOrdem_TextChanged(object sender, EventArgs e)
        {
            validaTextBoxNumerica(txtOrdem);
        }

        private void txtOrdemTela_TextChanged(object sender, EventArgs e)
        {
            validaTextBoxNumerica(txtOrdemTela);
        }

        private void txtOrdemResposta_TextChanged(object sender, EventArgs e)
        {
            validaTextBoxNumerica(txtOrdemResposta);
        }

        private void validaTextBoxNumerica(MetroTextBox textBox)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    actualdata = actualdata.Replace(aChar, ' ');
                    actualdata = actualdata.Trim();
                }
            }
            textBox.Text = actualdata;
        }

        #endregion

        private void comboTipoQuestao_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlSaltosOrdenacao.Visible = false;

            if (comboTipoQuestao.SelectedIndex == 3)
            {
                lblVariacoes.Visible = true;
                txtVariacoes.Visible = true;
                lblTexto.Text = "Palavra";
            }
            else if (comboTipoQuestao.SelectedIndex == 2 || comboTipoQuestao.SelectedIndex == 1)
            {
                pnlSaltosOrdenacao.Visible = true;
            }
            else
            {
                lblVariacoes.Visible = false;
                txtVariacoes.Visible = false;
                lblTexto.Text = "Texto";
            }
        }

        private void pnlAddItem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImagemResposta_MouseHover(object sender, EventArgs e)
        {
            lblNameImagem.Visible = true;
            if (caminhoImagemResposta != null)
            {
                FileInfo info = new FileInfo(caminhoImagemResposta);
                lblNameImagem.Text = info.Name;
            }
            else
            {
                if (itemquestaoAtual != null)
                {
                    ItemArquivo imagem = itemquestaoAtual.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.imagem);
                    if(imagem!=null)
                        lblNameImagem.Text = imagem.Arquivo.Nome;
                }
            }
        }

        private void btnImagemResposta_MouseLeave(object sender, EventArgs e)
        {
            lblNameImagem.Visible = false;
            lblNameImagem.Text = "";
        }

        private void btnAudioLeituraOp_MouseHover(object sender, EventArgs e)
        {
            lblNameAudio.Visible = true;
            lblNameAudio.Text = "Sem Áudio de Leitura!";
            if (caminhoAudioLeitura != null)
            {
                FileInfo info = new FileInfo(caminhoAudioLeitura);
                lblNameAudio.Text = info.Name;
            }
            else
            {
                if(itemquestaoAtual != null)
                {
                    ItemArquivo audio = itemquestaoAtual.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioLeitura);
                    if(audio != null)
                        lblNameAudio.Text = audio.Arquivo.Nome;
                }
            }
        }

        private void btnAudioLeituraOp_MouseLeave(object sender, EventArgs e)
        {
            lblNameAudio.Visible = false;
            lblNameAudio.Text = "";
        }

        private void btnImagemPergunta_MouseHover(object sender, EventArgs e)
        {
            lblNameImagemPergunta.Visible = true;
            if(caminhoImagemPergunta != null)
            {
                FileInfo info = new FileInfo(caminhoImagemPergunta);
                lblNameImagemPergunta.Text = info.Name;
            }
            else
            {
                ItemQuestao itemPergunta;
                if (questaoAtual != null)
                {
                    itemPergunta = questaoAtual.ItemQuestao.ToList().Find(i => i.EPergunta == true);
                    if (itemPergunta != null)
                    {
                        ItemArquivo imagem = itemPergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.imagem);
                        if(imagem != null)
                            lblNameImagemPergunta.Text = imagem.Arquivo.Nome;
                    }
                }
            }
        }

        private void btnImagemPergunta_MouseLeave(object sender, EventArgs e)
        {
            lblNameImagemPergunta.Visible = false;
            lblNameImagemPergunta.Text = "";
        }

        private void btnAudioPergunta_MouseHover(object sender, EventArgs e)
        {
            lblNameAudioPergunta.Visible = true;
            if(caminhoAudioPergunta != null)
            {
                FileInfo info = new FileInfo(caminhoAudioPergunta);
                lblNameAudioPergunta.Text = info.Name;
            }
            else
            {
                ItemQuestao itemPergunta;
                if (questaoAtual != null)
                {
                    itemPergunta = questaoAtual.ItemQuestao.ToList().Find(i => i.EPergunta == true);
                    if (itemPergunta != null)
                    {
                        ItemArquivo audio = itemPergunta.ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audio);
                        if(audio != null)
                            lblNameAudioPergunta.Text = audio.Arquivo.Nome;
                    }
                }
            }
        }

        private void btnAudioPergunta_MouseLeave(object sender, EventArgs e)
        {
            lblNameAudioPergunta.Visible = false;
            lblNameAudioPergunta.Text = "";
        }

        private void ckRespostaAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRespostaAudio.Checked)
            {
                btnAudioLeituraOp.Enabled = true;
            }
            else
            {
                btnAudioLeituraOp.Enabled = false;
            }
        }

        // Inicio de código CSV ####
        private Questao novaQuestao(string[] dados)
        {
            Questao questao = new Questao();
            questao.Ordem = Convert.ToInt32(dados[0]);
            questao.TipoQuestao = TipoQuestao.obterTodos().Find(tq => tq.Nome == dados[4]);
            questao.Competencia =  dados[5];
            questao.Ano = Convert.ToInt64(dados[7]);
            questao.Semestre = Convert.ToInt64(dados[8]);
            questao.Titulo = dados[9];
            questao.Area = Area.obterTodos().Find(eixo => eixo.Nome == dados[10]);
            questao.Disciplina = Disciplina.obterTodos().Find(d => d.Nome == dados[11]);
            if (dados[12] == "") questao.Hint = false;
            else questao.Hint = Convert.ToBoolean(Convert.ToInt16(dados[12]));
            if (dados[13] == "") questao.Enfileirada = false;
            else questao.Enfileirada = Convert.ToBoolean(Convert.ToInt16(dados[13]));
            questao.Cor = dados[14];
            questao.PosicaoPergunta = 0;
            questao.PosicaoRespostas = 2;
            questao.Questionario = questionarioAtual;
            if (dados[19] == "") questao.Tentativas = 1;
            else questao.Tentativas = Convert.ToInt16(dados[19]);


            if (!String.IsNullOrEmpty(dados[20]))
            {
                questao.Peso = double.Parse(dados[20]);
            }

            if (!String.IsNullOrEmpty(dados[21]))
            {
                questao.TAG = dados[21];
            }

            ItemQuestao itemPergunta;
            // Cria uma Resposta
            itemPergunta = new ItemQuestao();
            itemPergunta.EPergunta = true;
            itemPergunta.Questao = questao;

            if (!String.IsNullOrEmpty(dados[15]))
            {
                if (dados[18] != "")
                {
                    itemPergunta.Titulo = dados[15].ToUpper() + "(" + dados[18].ToUpper() + ")";
                }
                else itemPergunta.Titulo = dados[15].ToUpper();
            }

            // Salva tudo no Banco
            questao.adicionar(questao);
            itemPergunta.adicionar(itemPergunta);

            // Estrutura de Arquivos
            string dirQuest = questao.Diretorio;

            if (!Directory.Exists(dirQuest))
            {
                Directory.CreateDirectory(dirQuest);
            }

            //((Master)MdiParent).MensagemSucesso("Questão Cadastrada!");


            // Trata os arquivos no diretorio
            if (!String.IsNullOrEmpty(dados[16])) itemPergunta.criarImagem(dados[16]);

            if (!String.IsNullOrEmpty(dados[17])) itemPergunta.criarAudio(dados[17]);

            return questao;
                 
        }

        private void novaAlternativa(string[] dados, Questao QuestaoAtual, string stringSaltoErro = null, string stringSaltoAcerto = null)
        {
            bool teveSalto = false;
            bool teveSaltoAcerto = false;
            bool teveSaltoErro = false;
            Salto salto = null;
            Salto saltoAcerto = null;
            Salto saltoErro = null;
            string stringSalto = null;

            ItemQuestao itemQuestao = new ItemQuestao();
            itemQuestao.Eresposta = true;
            itemQuestao.Questao = QuestaoAtual;

            if (dados[4] != "")
            {
                itemQuestao.Titulo = dados[4];
            }

            itemQuestao.OrdemTela = Convert.ToInt32(dados[2]);

            if (dados[1] == "1")
            {
                itemQuestao.OpcaoCorreta = true;
                if (itemQuestao.Titulo == null && itemQuestao.ContemImagem == null)
                {
                    itemQuestao.Titulo = "O";
                }
                stringSalto = stringSaltoAcerto;
            }
            else
            {
                itemQuestao.OpcaoCorreta = false;
                if (itemQuestao.Titulo == null && itemQuestao.ContemImagem == null)
                {
                    itemQuestao.Titulo = "X";
                }
                stringSalto = stringSaltoErro;
            }

            if (dados[3] != "")
            {
                itemQuestao.OrdemResposta = Convert.ToInt32(dados[3]);
                itemQuestao.OpcaoCorreta = true;
            }

            // TRATA OS SALTOS DE FORMA DIFERENTE PARA QUESTOES DE ORDENACAO
            // se ordem de resposta é nulo
            if (dados[3] != "")
            {
                // Salto em caso de acerto
                saltoAcerto = new Salto();
                teveSaltoAcerto = true;

                saltoAcerto.ItemQuestao = itemQuestao;

                Questao questaoSaltoAcerto;
                if (stringSaltoAcerto == "FIM" | stringSaltoAcerto == "Fim" | stringSaltoAcerto == "fim")
                {
                    questaoSaltoAcerto = itemQuestao.Questao;
                    saltoAcerto.VoltarDoSalto = false;
                }
                else
                {
                    questaoSaltoAcerto =
                        QuestaoAtual.Questionario.Questao.ToList()
                            .Find(q => q.Ordem.ToString().Equals(stringSaltoAcerto));
                    saltoAcerto.VoltarDoSalto = null;
                }

                saltoAcerto.Questao = questaoSaltoAcerto;
                saltoAcerto.SaltarAoErrar = false;

                if (!teveSaltoAcerto)
                {
                    saltoAcerto.atualizar(saltoAcerto);
                }

                // salto em caso de erro
                saltoErro = new Salto();
                teveSaltoErro = true;

                saltoErro.ItemQuestao = itemQuestao;

                Questao questaoSaltoErro;
                if (stringSaltoErro == "FIM" | stringSaltoErro == "Fim" | stringSaltoErro == "fim")
                {
                    questaoSaltoErro = itemQuestao.Questao;
                    saltoErro.VoltarDoSalto = false;
                }
                else
                {
                    questaoSaltoErro =
                        QuestaoAtual.Questionario.Questao.ToList()
                            .Find(q => q.Ordem.ToString().Equals(stringSaltoErro));
                    saltoErro.VoltarDoSalto = null;
                }

                saltoErro.Questao = questaoSaltoErro;
                saltoErro.SaltarAoErrar = true;

                if (!teveSaltoErro)
                {
                    saltoErro.atualizar(saltoErro);
                }

            }
            else
            {
                salto = new Salto();
                teveSalto = true;
                
                salto.ItemQuestao = itemQuestao;

                Questao questaoSalto;

                if (stringSalto == "FIM" | stringSalto == "Fim" | stringSalto == "fim")
                {
                    questaoSalto = itemQuestao.Questao;
                    salto.VoltarDoSalto = false;
                }
                else
                {
                    questaoSalto =
                        QuestaoAtual.Questionario.Questao.ToList()
                            .Find(q => q.Ordem.ToString().Equals(stringSalto));
                    salto.VoltarDoSalto = null;
                }

                salto.Questao = questaoSalto;
                salto.SaltarAoErrar = !itemQuestao.OpcaoCorreta;

                if (!teveSalto)
                    salto.atualizar(salto);
            }

            // Salva no banco
            itemQuestao.adicionar(itemQuestao);
            if (teveSalto) salto.adicionar(salto);
            if (teveSaltoAcerto) saltoAcerto.adicionar(saltoAcerto);
            if (teveSaltoErro) saltoErro.adicionar(saltoErro);            

            if (dados[6] != "")
            {
                itemQuestao.criarAudio(dados[6], TipoArquivo.audioLeitura);
            }

            if (dados[7] != "")
            {
                itemQuestao.criarAudio(dados[7], TipoArquivo.audioSucessoOpcao);
            }
            // Grava Feedback positivo padrão
            else
            {
                // Gambi pra extrair o path do arquivo no Resources/
                string audioResourceAcertou = @"C:\Users\Default\CorujaEdu\feedback\pos.wav";
                //cria audio feedback positivo para cada alternativa :(
                itemQuestao.criarAudio(audioResourceAcertou, TipoArquivo.audioSucessoOpcao);
            }

            if (dados[5] != "" && dados[4] == "")
            {
                itemQuestao.criarImagem(dados[5]);
            }

            if (dados[8] != "")
            {
                itemQuestao.criarAudio(dados[8], TipoArquivo.audioErroOpcao);
            }
            else
            {
                // Gambi pra extrair o path do arquivo no Resources/
                /*
                string audioResourceErrou = System.Reflection.Assembly.GetEntryAssembly().Location;
                audioResourceErrou = audioResourceErrou.Replace(@"bin\Debug\QuestionarioForms.exe", @"Resources\Audio5812.wav");
                */
                string audioResourceErrou = @"C:\Users\Default\CorujaEdu\feedback\neg.wav";
                //cria audio feedback negativo para cada alternativa :(
                itemQuestao.criarAudio(audioResourceErrou, TipoArquivo.audioErroOpcao);
            }
            

            limparItemQuestao();
            carregaItensQuestaoTela(itemQuestao.Questao);
        
        }

        private string trocaPontoVirgulaVariacao(string texto)
        {
            var temp = texto.Split('"');
            int i = 0;
            string s = null;
            foreach (string t in temp)
            {
                if (i % 2 != 0) s = s + t.Replace(';', '"');
                else s = s + t;
                i += 1;
            }
            return s;
        }

        private class Questoes
        {
            private Questao questoes;
            private string saltoAcerto;
            private string saltoErro;

 
            public Questao QuestoesAtuais
            {
                get { return questoes; }
                set { questoes = value; }
            }
            public string SaltoAcerto
            {
                get { return saltoAcerto; }
                set { saltoAcerto = value; }
            }
            public string SaltoErro
            {
                get { return saltoErro; }
                set { saltoErro = value; }
            }
        }

        private void btnImportarQestoesCsv_Click(object sender, EventArgs e)
        {
            string[] tempPath = txtPathCsv.Text.Split('\\');
            int lengthPath = tempPath.Length;
            string path = null;
            int i = 0;
            while (i < lengthPath - 1)
            {
                if (i == 0) path = tempPath[i];
                else path = path + "\\" + tempPath[i];
                i += 1;
            }

            string nomeFile = tempPath[lengthPath - 1].Split('.')[0];
            string pathQuestao = path + "\\" + nomeFile + ".qcsv";
            string pathAlternativa = path + "\\" + nomeFile + ".acsv";

            int nLinhaQuestoes = 0;
            int totalQuestoes = File.ReadLines(pathQuestao).Count() - 1;

            List<Questoes> todasQuestoes = new List<Questoes>();
            // the using ensures that the file is closed after all is read
            using (var readerQuestoes = new StreamReader(File.OpenRead(pathQuestao))) {
                while (!readerQuestoes.EndOfStream)
                {
                    var linhaQuestoes = readerQuestoes.ReadLine();
                    string[] dadosQuestoes;
                    if (linhaQuestoes.Contains('"'))
                    {
                        string temp = trocaPontoVirgulaVariacao(linhaQuestoes);
                        dadosQuestoes = temp.Split(';');
                        dadosQuestoes[15] = dadosQuestoes[15].Replace('"', ';');
                        dadosQuestoes[18] = dadosQuestoes[18].Replace('"', ';');
                    }
                    else dadosQuestoes = linhaQuestoes.Split(';');

                    if (nLinhaQuestoes != 0)
                    {
                        Questao questaoNova = new Questao();
                        questaoNova = novaQuestao(dadosQuestoes);
                        Questoes qNova = new Questoes();
                        qNova.QuestoesAtuais = questaoNova;
                        qNova.SaltoAcerto = dadosQuestoes[1];
                        qNova.SaltoErro = dadosQuestoes[2];
                        todasQuestoes.Add(qNova);
                    }
                    nLinhaQuestoes += 1;
                }
            }
            
            
            int nLinhaAlternativas = 0;
            string alternativaAnterior = null;
            int idQuestao = 0;
            //using has the same effect as above
            using (var readerAlternativas = new StreamReader(File.OpenRead(pathAlternativa))){
                while (!readerAlternativas.EndOfStream)
                {
                    var linhaAlternativas = readerAlternativas.ReadLine();
                    string[] dadosAlternativas = linhaAlternativas.Split(';');

                    if (nLinhaAlternativas != 0)
                    {
                        if (dadosAlternativas[0] != alternativaAnterior)
                        {
                            idQuestao = todasQuestoes.ToList().FindIndex(q => q.QuestoesAtuais.Ordem.ToString() == dadosAlternativas[0]);
                        }

                        novaAlternativa(dadosAlternativas, todasQuestoes[idQuestao].QuestoesAtuais, todasQuestoes[idQuestao].SaltoErro, todasQuestoes[idQuestao].SaltoAcerto);
                    }
                    nLinhaAlternativas += 1;
                }
            }
            pnlBotoesQuestoes.Controls.Clear();
            carregarQuestoesTela();
        }

        private void btnLocalizarCsv_Click(object sender, EventArgs e)
        {
            txtPathCsv.Text = ((Master)MdiParent).localizarCsv();
        }

        private void txtPathCsv_TextChanged(object sender, EventArgs e)
        {
            txtPathCsv.ForeColor = System.Drawing.Color.Black;
            
            if (File.Exists(txtPathCsv.Text))
            {
                string temp = txtPathCsv.Text.Substring(txtPathCsv.Text.Length - 5);
                if (temp ==  ".qcsv" | temp == ".acsv")
                {
                    btnImportarQestoesCsv.Enabled = true;
                }
            }
        }

        private void txtPathCsv_Click(object sender, EventArgs e)
        {
            txtPathCsv.SelectAll();
        }
    }
}
