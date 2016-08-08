using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{

    public partial class TipoQuestao : ClasseBase
    {

        public enum TipoPsicogenese
        {
            NaoClassificado = 0,
            PreSilabico = 1,
            SilabicoSemValor = 2,
            SilabicoComValor = 3,
            Alfabetico = 4,
            Ortografico = 5
        }

        public static List<TipoQuestao> obterTodos()
        {
            return Gerenciador.getContexto().TipoQuestao.ToList();
        }


        public static TipoPsicogenese validarRepostaPsicogenese(string palavraPsicogenese, string palavraAluno, string variacoesPsicogenese, out int porcentagem)
        {
            porcentagem = 0;
            TipoPsicogenese resultadoGlobal = TipoPsicogenese.NaoClassificado;
            TipoPsicogenese resultadoLocal = TipoPsicogenese.NaoClassificado;

            string palavraFormatada = palavraPsicogenese.Replace(";", "");

            string palavraAlunoAux = palavraAluno;
             
            // Pega da resposta somente o tamanho correto da palavra para 
            //verificar se ele digitou corretamente mas colocou algum lixo ao final
            if (palavraAluno.Length > palavraFormatada.Length)
            {
                palavraAlunoAux = palavraAluno.Substring(0, palavraFormatada.Length);
            }

            // ORTOGRAFICO
            if (palavraAlunoAux.Equals(palavraFormatada))
            {
                resultadoGlobal = TipoPsicogenese.Ortografico;
                porcentagem = 100;
            }
            else
            {
                // calcula a porcentagem de acertos na palavra
                string palavraAlunoPorc = palavraAluno;
                int qtdAcertos = 0;
                foreach (var letra in palavraFormatada.ToCharArray())
                {
                    if (palavraAlunoPorc.Contains(letra))
                    {
                        qtdAcertos++;
                        int indice = palavraAlunoPorc.IndexOf(letra);
                        palavraAlunoPorc = palavraAlunoPorc.Remove(indice, 1);
                    }
                }
                porcentagem = (int)(((double)((double)qtdAcertos / (double)palavraFormatada.Length)) * 100);


                // ALFABETICO
                List<string> vetVariacoes = variacoesPsicogenese.Split("|".ToCharArray()).ToList();

                foreach (var varic in vetVariacoes)
                {
                    string auxVar = varic.Replace(";", "");

                    if (palavraAlunoAux.Equals(auxVar))
                    {
                        resultadoGlobal = TipoPsicogenese.Alfabetico;
                        break;
                    }
                }

                // Ainda não classificado
                if (resultadoGlobal == TipoPsicogenese.NaoClassificado)
                {
                    // Conta as  silabas para checar os outros tipos
                    List<string> vetSilabas = palavraPsicogenese.Split(";".ToCharArray()).ToList();
                    int qtdSilabas = vetSilabas.Count;

                    // Eliminacao de repeticoes
                    char letraanterior = char.MinValue;
                    string palavraAlunoSemRepeticao = "";

                    foreach (var letra in palavraAluno.ToCharArray())
                    {
                        if (!letra.Equals(letraanterior))
                        {
                            palavraAlunoSemRepeticao += letra;
                        }

                        letraanterior = letra;
                    }

                    // Depois de retiradas as repeticoes sobraram menos letras que a qtd de silabas
                    if (palavraAlunoSemRepeticao.Length < qtdSilabas)
                    {
                        // Verifica se as repeticoes formavam uma classificacao silabica
                        if (qtdSilabas == 1)
                        {
                            if (palavraAluno.Length != 1 && palavraAluno.Length != 2)
                                resultadoGlobal = TipoPsicogenese.PreSilabico;
                            else
                                resultadoGlobal = TipoPsicogenese.SilabicoSemValor;
                        }
                        else
                        {
                            if (palavraAluno.Length != qtdSilabas)
                                resultadoGlobal = TipoPsicogenese.PreSilabico;
                            else
                                resultadoGlobal = TipoPsicogenese.SilabicoSemValor;
                        }
                    }
                    else
                    {
                        // Percorre a palavra e suas variações para  veriricar o melhor resultado
                        List<string> opcoesCorretas = new List<string>();
                        opcoesCorretas.Add(palavraPsicogenese);

                        // Coloca separadores nas variacoes
                        foreach (var variacao in vetVariacoes)
                        {
                            if (!String.IsNullOrEmpty(variacao))
                            {
                                opcoesCorretas.Add(variacao);
                            }
                        }

                        // Percorre a palavra e as variacaoes
                        foreach (var opcao in opcoesCorretas)
                        {
                            resultadoLocal = TipoPsicogenese.NaoClassificado;

                            // Verifica se contem letras que nao pertencem a palavra
                            int qtdletrasNaoPertencem = 0;
                            string letrasErradas = "";
                            foreach (var letra in palavraAlunoSemRepeticao.ToCharArray())
                            {
                                if (!opcao.Contains(letra))
                                {
                                    letrasErradas += letra;
                                    qtdletrasNaoPertencem ++;
                                }
                            }

                            // Só aceita no máximo duas letras erradas ao final da palavra
                            if (qtdletrasNaoPertencem <= 2)
                            {
                                bool errosSomenteNoFinal = true;

                                // Veririfica erros de digitacao ao final da palavra
                                if (qtdletrasNaoPertencem > 0)
                                {
                                    foreach (var letraErrada in letrasErradas.ToCharArray())
                                    {
                                        int indice = palavraAlunoSemRepeticao.IndexOf(letraErrada);
                                        if (indice < palavraAlunoSemRepeticao.Length - 2)
                                        {
                                            errosSomenteNoFinal = false;
                                            break;
                                        }
                                    }
                                }

                                // Se só contem erros ao final ou nao contem erros 
                                //entao pode validar o silabico com valor
                                if (errosSomenteNoFinal)
                                {
                                    string palavraSemErros = palavraAlunoSemRepeticao;
                                    foreach (var letraErrada in letrasErradas.ToCharArray())
                                    {
                                        palavraSemErros = palavraSemErros.Replace(letraErrada.ToString(), "");
                                    }

                                    // SILABICO COM VALOR
                                    bool passouPelaValidacaoComValor = true;
                                    List<string> vetSilabasAux = opcao.Split(";".ToCharArray()).ToList();

                                    if (vetSilabasAux.Count == qtdSilabas)
                                    {

                                        // Verifica se tem letra a mais do que deveria e marca as silabas visitadas
                                        foreach (var letra in palavraSemErros.ToCharArray())
                                        {
                                            bool encontrou = false;
                                            for (int i = 0; i < qtdSilabas; i++)
                                            {
                                                string silaba = vetSilabasAux[i];

                                                if (silaba.Contains(letra))
                                                {
                                                    vetSilabasAux[i] = silaba.Remove(silaba.IndexOf(letra), 1);
                                                    encontrou = true;
                                                    break;
                                                }
                                            }

                                            if (!encontrou)
                                            {
                                                passouPelaValidacaoComValor = false;
                                                break;
                                            }
                                        }

                                        if (passouPelaValidacaoComValor)
                                        {
                                            // Verifica se visitou cada silaba pelo menos uma vez
                                            List<string> vetSilabasOpcao = opcao.Split(";".ToCharArray()).ToList();

                                            bool visitouTodasSilabas = true;
                                            for (int i = 0; i < qtdSilabas; i++)
                                            {
                                                // Se forem iguais significa que não visitou e não retirou 
                                                //nenhuma letra então não é silabico com valor
                                                if (vetSilabasOpcao[i].Equals(vetSilabasAux[i]))
                                                {
                                                    visitouTodasSilabas = false;
                                                    break;
                                                }
                                            }

                                            if (visitouTodasSilabas)
                                            {
                                                resultadoLocal = TipoPsicogenese.SilabicoComValor;
                                            }
                                        }
                                    }
                                }
                            }


                            // Ainda não classificado
                            if (resultadoLocal == TipoPsicogenese.NaoClassificado)
                            {
                                int qtdLetrasAluno = palavraAluno.Length;

                                if (qtdSilabas == 1)
                                {
                                    if ((qtdLetrasAluno == 1) || (qtdLetrasAluno == 2))
                                    {
                                        resultadoLocal = TipoPsicogenese.SilabicoSemValor;
                                    }
                                    else
                                    {
                                        resultadoLocal = TipoPsicogenese.PreSilabico;
                                    }
                                }
                                else
                                {
                                    if (qtdLetrasAluno == qtdSilabas)
                                    {
                                        resultadoLocal = TipoPsicogenese.SilabicoSemValor;
                                    }
                                    else
                                    {
                                        resultadoLocal = TipoPsicogenese.PreSilabico;
                                    }
                                }
                            }

                            if ((int)resultadoLocal > (int)resultadoGlobal)
                                resultadoGlobal = resultadoLocal;
                        }
                    }
                }
            }

            return resultadoGlobal;
        }
    }
}
