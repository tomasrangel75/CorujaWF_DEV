using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{


    public partial class Instituicao : ClasseBase
    {

        public static List<Instituicao> obterTodos()
        {
            return Gerenciador.getContexto().Instituicao.ToList();
        }

        public override bool deletar(object objeto)
        {
            if (Evento.Count > 0)
            {
                Evento.ToList().ForEach(i => i.deletar(i));
            }

            if (Turma.Count > 0)
            {
                Turma.ToList().ForEach(i => i.deletar(i));
            }

            return base.deletar(objeto);
        }
    }
}
