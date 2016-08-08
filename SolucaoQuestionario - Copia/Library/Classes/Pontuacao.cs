using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{

    public partial class Pontuacao : ClasseBase
    {

        public string OrdemQuestao
        {
            get { return this.Questao.Ordem.ToString(); }
        }

        public string DataHoraQuestaoString
        {
            get
            {
                return ((DateTime)DataHora).ToShortDateString() + "-" + ((DateTime)DataHora).ToShortTimeString();

            }
        }

        public string AcertouString
        {
            get
            {
                if (this.Questao.TipoQuestao_id.ToString().Equals("4"))
                {
                    return "";
                }


                if (Acertou != null)
                {
                    if ((bool) this.Acertou)
                        return "Sim";

                    return "Não";
                }
                else
                {
                    return "";
                }
            }

        }

        public string TentativaString
        {
            get
            {
                if (this.Questao.TipoQuestao_id.ToString().Equals("4"))
                {
                    if (Tentativas == 1)
                    {
                        return "PreSilabico";
                    }
                    else if (Tentativas == 2)
                    {
                        return "SilabicoSemValor";
                    }
                    else if (Tentativas == 3)
                    {
                        return "SilabicoComValor";
                    }
                    else if (Tentativas == 4)
                    {
                        return "Alfabetico";
                    }
                    else if (Tentativas == 5)
                    {
                        return "Ortografico";
                    }
                    else
                    {
                        return "NaoClassificado";
                    }
                }
                else
                {
                    return Tentativas.ToString();
                }
            }

        }

        public string CliquesFormatado
        {
            get
            {
                if (this.Questao.TipoQuestao_id.ToString().Equals("4"))
                {
                    return "";
                }

                if (!String.IsNullOrEmpty(this.Clicks))
                {
                    return this.Clicks.Remove(Clicks.Length - 1);
                }
                return "";
                
            }
        }

        public static List<Pontuacao> obterTodos()
        {
            return Gerenciador.getContexto().Pontuacao.ToList();
        }
    }
}
