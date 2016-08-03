using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{

    public partial class Resultado : ClasseBase
    {
        public static List<Resultado> obterTodos()
        {
            return Gerenciador.getContexto().Resultado.ToList();
        }
    }
}
