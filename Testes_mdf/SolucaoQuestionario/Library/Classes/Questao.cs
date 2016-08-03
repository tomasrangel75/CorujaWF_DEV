using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Library.Persistencia
{



    public partial class Questao : ClasseBase
    {
        public enum Posicao
        {
            Acima = 0,
            Meio = 1,
            Abaixo = 2,
            Direita = 3,
            Esquerda = 4
        }

        public string Diretorio
        {
            get
            {
                return ConfigurationManager.AppSettings["avalFullPath"] + "\\" + Questionario.idQuestionario + "\\" + idQuestao + "\\";
            }
        }

        public string DiretorioProva
        {
            get
            {
                return ConfigurationManager.AppSettings["avalFullPath"] + "\\" + idBase + "\\";
            }
        }

        public string NomeTela
        {
            get { return this.Ordem + " - " + this.Titulo; }
        }

        public static Questao get(int id)
        {
            return Gerenciador.getContexto().Questao.Find(id);
        }


        public static List<Questao> obterTodos()
        {
            return Gerenciador.getContexto().Questao.ToList();
        }

        public override bool deletar(object objeto)
        {
            if (ItemQuestao.Count > 0)
            {
                ItemQuestao.ToList().ForEach(i => i.deletar(i));
            }

            if (Salto.Count > 0)
            {
                Salto.ToList().ForEach(i => i.deletar(i));
            }

            if (Pontuacao.Count > 0)
            {
                Pontuacao.ToList().ForEach(i => i.deletar(i));
            }

            // Apaga as referencias dos resultados
            if (Resultado.Count > 0)
            {
                var alterar = Resultado;
                foreach (var res in alterar)
                {

                    res.UltimaQuestao_id = null;
                    res.atualizar(res);
                }
            }

            string caminhoQues = Diretorio;

            bool retorno = base.deletar(objeto);

            if (Directory.Exists(caminhoQues))
            {
                Directory.Delete(caminhoQues, true);
            }

            return retorno;
        }
    }
}
