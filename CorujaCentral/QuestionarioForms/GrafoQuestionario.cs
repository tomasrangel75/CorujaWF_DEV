using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Library.Persistencia;
using System.Drawing;

namespace QuestionarioForms
{
    public class GrafoQuestionario
    {
        private List<no> nosTerminais;
        private List<aresta> listArestas; 
        private List<no> grafo;

        public void getMinMaxCor(int cor, out int min, out int max)
        {
            no noAtual = nosTerminais.Find(n => n.cor.Equals(cor));

            if (noAtual != null)
            {
                min = noAtual.menorValor;
                max = noAtual.maiorValor;
            }
            else
            {

                min = -1;
                max = -1;
            }
        }

        public int gerarGrafo(List<Questao> listaQuestoesEixo, int ultimaQuestaoDoQuestionario)
        {
            int resultado = criarGrafo(listaQuestoesEixo, ultimaQuestaoDoQuestionario);

            if (resultado == -1)
                return -1;

            List<no> nosRaizes = grafo.FindAll(n => n.raiz);

            foreach (var noRaiz in nosRaizes)
            {
                caminhamentoProfundidade(noRaiz, 0, 0, 0);
            }

            return 1;
        }

        private void caminhamentoProfundidade(no noAtual, int peso, int maiorValor, int menorValor)
        {
            bool alterouValores = false;

            if(maiorValor > 1000)
                throw new Exception("Erro de loop");

            // Atualiza o peso
            if (noAtual.maiorValor == 0)
                noAtual.maiorValor = maiorValor + peso;
            else
            {
                if (noAtual.maiorValor < maiorValor + peso)
                {
                    noAtual.maiorValor = maiorValor + peso;
                    alterouValores = true;
                }
            }

            if (noAtual.menorValor == 0)
                noAtual.menorValor = menorValor + peso;
            else
            {
                if (noAtual.menorValor > menorValor + peso)
                {
                    noAtual.menorValor = menorValor + peso;
                    alterouValores = true;
                }
            }

            noAtual.visitado = true;

            // Caso base
            if (noAtual.folha)
            {
                return;
            }

            if (noAtual.arestaAcerto != null)
            {
                if (noAtual.arestaAcerto.visitada == false || alterouValores)
                {
                    noAtual.arestaAcerto.visitada = true;
                    caminhamentoProfundidade(noAtual.arestaAcerto.noDestino, noAtual.arestaAcerto.peso, noAtual.maiorValor, noAtual.menorValor);
                }
            }


            if (noAtual.arestaErro != null)
            {
                if (noAtual.arestaErro.visitada == false || alterouValores)
                {
                    noAtual.arestaErro.visitada = true;
                    caminhamentoProfundidade(noAtual.arestaErro.noDestino, noAtual.arestaErro.peso, noAtual.maiorValor, noAtual.menorValor);
                }
            }
        }

        private int criarGrafo(List<Questao> listaQuestoesEixo, int ultimaQuestaoDoQuestionario)
        {
            nosTerminais = new List<no>();
            listArestas = new List<aresta>();
            grafo = new List<no>();
            listaQuestoesEixo.OrderBy(q => q.Ordem);

            // Cria todos os nós, arestas e nós terminais artificiais
            foreach (var questao in listaQuestoesEixo)
            {
                no noAtual = grafo.Find(n => n.num == (int) questao.Ordem);

                if (noAtual == null)
                {
                    noAtual = new no();
                    grafo.Add(noAtual);
                }

                // Seta os dados básicos do nó
                Color corQuestao =  ColorTranslator.FromHtml(questao.Cor);
                ItemRelatorioAluno.corRelatorio ultimaCorParse =
                    ItemRelatorioAluno.convertCorRelatorioFromColor(corQuestao);

                noAtual.cor = (int)ultimaCorParse;
                noAtual.num = (int)questao.Ordem;
                noAtual.maiorValor = 0;
                noAtual.menorValor = 0;

                // Verifica se á a ultima questao do questionario para criar as arestas logo nesse caso
                if (questao.Ordem == ultimaQuestaoDoQuestionario)
                {
                    aresta arestaacerto = new aresta();
                    arestaacerto.noOrigem = noAtual;
                    arestaacerto.noDestino = criaNoTerminal(noAtual.cor);
                    if (questao.Hint == true)
                    {
                        arestaacerto.peso = 1;
                    }
                    else
                    {
                        arestaacerto.peso = 2;
                    }

                    aresta arestaErro = new aresta();
                    arestaErro.noOrigem = noAtual;
                    arestaErro.noDestino = criaNoTerminal(getCorAnterior(noAtual.cor));
                    arestaErro.peso = 0;

                    noAtual.arestaAcerto = arestaacerto;
                    noAtual.arestaErro = arestaErro;

                    listArestas.Add(arestaacerto);
                    listArestas.Add(arestaErro);
                }
                else
                {
                    // Carrega as arestas baseado nos saltos
                    Salto saltoAcerto = null;
                    Salto saltoErro = null;

                    // Verifica se é multipla escolha
                    if (questao.TipoQuestao_id == 1)
                    {
                        foreach (var itemQuestao in questao.ItemQuestao)
                        {
                            if (saltoAcerto != null && saltoErro != null)
                                break;

                            if (itemQuestao.Salto.Count > 0)
                            {
                                if (itemQuestao.OpcaoCorreta != null && itemQuestao.OpcaoCorreta == true)
                                {
                                    saltoAcerto = itemQuestao.Salto.ToList()[0];
                                }
                                else
                                {
                                    saltoErro = itemQuestao.Salto.ToList()[0];
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var itemQuestao in questao.ItemQuestao)
                        {
                            if (saltoAcerto != null && saltoErro != null)
                                break;

                            if (itemQuestao.Salto.Count > 0)
                            {
                                foreach (var salto in itemQuestao.Salto)
                                {
                                    if (salto.SaltarAoErrar == true)
                                    {
                                        saltoErro = salto;
                                    }
                                    else
                                    {
                                        saltoAcerto = salto;
                                    }
                                }
                            }
                        }
                    }

                    // verifica se o salto não foi cadastrado para a questao apontar para a proxima na ordem
                    if (saltoAcerto == null)
                    {
                        int proximaOrdem = (int) questao.Ordem + 1;

                        // Checa se a proxima questao está dentro do eixo
                        Questao proxima = listaQuestoesEixo.Find(q => Convert.ToInt32(q.Ordem).Equals(proximaOrdem));

                        // Se a proxima questao está no eixo então é um salto implicito
                        if (proxima != null)
                        {
                            saltoAcerto = new Salto();
                            saltoAcerto.Questao = proxima;
                        }
                        else
                        {
                            // Nesse caso a proxima questao nao está no eixo logo ela é terminal
                            // Cria um salto para o fim
                            saltoAcerto = new Salto();
                            saltoAcerto.Questao = null;
                            saltoAcerto.VoltarDoSalto = false;
                        }
                    }

                    if (saltoErro == null)
                    {
                        int proximaOrdem = (int) questao.Ordem + 1;

                        // Checa se a proxima questao está dentro do eixo
                        Questao proxima = listaQuestoesEixo.Find(q => Convert.ToInt32(q.Ordem).Equals(proximaOrdem));

                        // Se a proxima questao está no eixo então é um salto implicito
                        if (proxima != null)
                        {
                            saltoErro = new Salto();
                            saltoErro.Questao = proxima;
                        }
                        else
                        {
                            // Nesse caso a proxima questao nao está no eixo logo ela é terminal
                            // Cria um salto para o fim
                            saltoErro = new Salto();
                            saltoErro.Questao = null;
                            saltoErro.VoltarDoSalto = false;
                        }
                    }


                    // Cria a aresta de acerto
                    no noProxima = null;

                    // É um salto para o fim
                    if (saltoAcerto.VoltarDoSalto != null)
                    {
                        noProxima = criaNoTerminal(noAtual.cor);
                    }
                    else if (saltoAcerto.Questao != null)
                    {
                        // Verifica se a próxima está no eixo
                        Questao proxima = listaQuestoesEixo.Find(q => q.Ordem.Equals(saltoAcerto.Questao.Ordem));
                        if (proxima != null)
                        {
                            // Está no eixo
                            // Verifica se o nó dela já foi criado
                            noProxima = grafo.Find(n => n.num == (int) proxima.Ordem);
                            if (noProxima == null)
                            {
                                noProxima = new no();
                                noProxima.num = (int) proxima.Ordem;
                                grafo.Add(noProxima);
                            }
                        }
                        else
                        {
                            // A proxima questao não está no eixo, logo esse é um nó terminal
                            noProxima = criaNoTerminal(noAtual.cor);
                        }
                    }

                    aresta arestaAcerto = new aresta();
                    arestaAcerto.noOrigem = noAtual;
                    arestaAcerto.noDestino = noProxima;
                    if (questao.Hint == true)
                    {
                        arestaAcerto.peso = 1;
                    }
                    else
                    {
                        arestaAcerto.peso = 2;
                    }



                    // Cria a aresta de erro

                    no noProximaErro = null;
                    // É um salto para o fim
                    if (saltoErro.VoltarDoSalto != null)
                    {
                        noProximaErro = criaNoTerminal(getCorAnterior(noAtual.cor));
                    }
                    else if (saltoErro.Questao != null)
                    {
                        // Verifica se a próxima está no eixo
                        Questao proxima = listaQuestoesEixo.Find(q => q.Ordem.Equals(saltoErro.Questao.Ordem));
                        if (proxima != null)
                        {
                            // Está no eixo
                            // Verifica se o nó dela já foi criado
                            noProximaErro = grafo.Find(n => n.num == (int) proxima.Ordem);
                            if (noProximaErro == null)
                            {
                                noProximaErro = new no();
                                noProximaErro.num = (int) proxima.Ordem;
                                grafo.Add(noProximaErro);
                            }
                        }
                        else
                        {
                            // A proxima questao não está no eixo, logo esse é um nó terminal e o aluno perdeu uma cor
                            noProximaErro = criaNoTerminal(getCorAnterior(noAtual.cor));
                        }
                    }

                    aresta arestaErro = new aresta();
                    arestaErro.noOrigem = noAtual;
                    arestaErro.noDestino = noProximaErro;
                    arestaErro.peso = 0;

                    noAtual.arestaAcerto = arestaAcerto;
                    noAtual.arestaErro = arestaErro;

                    listArestas.Add(arestaAcerto);
                    listArestas.Add(arestaErro);
                }
            }

            // Procura o nó raiz 
            List<no> nosVerdes = grafo.FindAll(n => n.cor == 2);
            if (nosVerdes != null && nosVerdes.Count > 0)
            {
                foreach (var noVerde in nosVerdes)
                {
                    // Verifica se alguem aponta para ele
                    aresta ar = listArestas.Find(a => a.noDestino.Equals(noVerde));
                    if (ar == null)
                    {
                        noVerde.raiz = true;
                    }
                }
            }
            else
            {
                grafo = null;
                return -1;
            }


            return 1;
        }

        private int getCorAnterior(int cor)
        {
            if (cor > 0)
            {
                return cor - 1;
            }

            return 0;
        }

        private no criaNoTerminal(int cor)
        {
            no noexistente = nosTerminais.Find(n => n.cor == cor);

            if (noexistente == null)
            {
                noexistente = new no();
                noexistente.cor = cor;
                noexistente.folha = true;
                noexistente.maiorValor = 0;
                noexistente.menorValor = 0;
                nosTerminais.Add(noexistente);
                grafo.Add(noexistente);
            }

            return noexistente;
        }
    }

    public class no
    {
        public int num { get; set; }
        public aresta arestaAcerto { get; set; }
        public aresta arestaErro { get; set; }

        public int cor { get; set; }

        public int maiorValor { get; set; }
        public int menorValor { get; set; }

        public bool raiz { get; set; }
        public bool folha { get; set; }

        public bool visitado { get; set; }
    }

    public class aresta
    {
        public int peso { get; set; }
        public no noOrigem { get; set; }
        public no noDestino { get; set; }
        public bool visitada { get; set; }

    }
}
