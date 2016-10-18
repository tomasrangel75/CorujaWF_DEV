using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{


    public partial class Turma : ClasseBase
    {

        public static List<Turma> obterTodos()
        {
            return Gerenciador.getContexto().Turma.ToList();
        }

        public override bool deletar(object objeto)
        {
            if (Aluno.Count > 0)
            {
                Aluno.ToList().ForEach(i => i.deletar(i));
            }

            return base.deletar(objeto);
        }
    }
}
