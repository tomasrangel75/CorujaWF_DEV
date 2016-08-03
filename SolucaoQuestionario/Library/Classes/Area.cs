using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{
    public partial class Area : ClasseBase
    {
        public static List<Area> obterTodos()
        {
            return Gerenciador.getContexto().Area.ToList();
        }
    }
}
