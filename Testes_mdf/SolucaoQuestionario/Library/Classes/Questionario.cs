using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Library.Persistencia
{

    public partial class Questionario : ClasseBase
    {

        public string Diretorio
        {
            get
            {
                return ConfigurationManager.AppSettings["avalFullPath"] + "\\" + idQuestionario + "\\";
            }
        }

        public string DiretorioProva
        {
            get
            {
                return ConfigurationManager.AppSettings["avalFullPath"] + "\\";
            }
        }

        public static List<Questionario> obterTodos()
        {
            return Gerenciador.getContexto().Questionario.ToList();
        }

        public static Questionario get(int id)
        {
            return Gerenciador.getContexto().Questionario.Find(id);
        }

        public override bool deletar(object objeto)
        {
            if (Questao.Count > 0)
            {
                Questao.ToList().ForEach(i => i.deletar(i));
            }

            if(Resultado.Count > 0)
            {
                Resultado.ToList().ForEach(i => i.deletar(i));
            }

            if (Aplicacao.Count > 0)
            {
                Aplicacao.ToList().ForEach(i => i.deletar(i));
            }

            if(Arquivo != null)
            {
                Arquivo arqTemp = Arquivo;
               
                string caminhoAnterior = Diretorio + Arquivo.NomeFisico;

                Arquivo = null;
                Arquivo_id = null;

                atualizar(this);

                arqTemp.deletar(arqTemp);

                File.Delete(caminhoAnterior);
            }

            string caminhoQues = Diretorio;

            bool retorno =  base.deletar(objeto);

            Directory.Delete(caminhoQues, true);

            return retorno;
        }
   
    }
}
