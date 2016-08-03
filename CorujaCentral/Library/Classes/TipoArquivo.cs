using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{

    public partial class TipoArquivo : ClasseBase
    {
        public static TipoArquivo imagem
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("Imagem"));
            }
        }

        public static TipoArquivo audio
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("Audio"));
            }
        }

        public static TipoArquivo audioLeitura
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("AudioItemLeitura"));
            }
        }

        public static TipoArquivo audioErroOpcao
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("AudioItemErro"));
            }
        }

        public static TipoArquivo audioSucessoOpcao
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("AudioItemSucesso"));
            }
        }

        public static TipoArquivo video
        {
            get
            {
                return obterTodos().ToList().Find(t => t.Nome.Equals("Vídeo"));
            }
        }

        public static List<TipoArquivo> obterTodos()
        {
            return Gerenciador.getContexto().TipoArquivo.ToList();
        }


    }
}
