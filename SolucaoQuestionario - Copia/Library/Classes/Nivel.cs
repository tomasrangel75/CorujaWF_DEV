using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{

    public partial class Nivel : ClasseBase
    {

        public static List<Nivel> obterTodos()
        {
            return Gerenciador.getContexto().Nivel.ToList();
        }
        
    }
}
