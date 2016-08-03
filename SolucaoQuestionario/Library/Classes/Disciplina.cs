using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{


    public partial class Disciplina : ClasseBase
    {

        public static List<Disciplina> obterTodos()
        {
            return Gerenciador.getContexto().Disciplina.ToList();
        }
       
    }
}
