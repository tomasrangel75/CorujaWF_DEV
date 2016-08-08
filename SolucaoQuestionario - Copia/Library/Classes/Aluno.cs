using System.Collections.Generic;
using System.Linq;

namespace Library.Persistencia
{
    public partial class Aluno : ClasseBase
    {
        public static List<Aluno> obterTodos()
        {
            return Gerenciador.getContexto().Aluno.ToList();
        }

        public override bool deletar(object objeto)
        {
            if (Pontuacao.Count > 0)
            {
                Pontuacao.ToList().ForEach(i => i.deletar(i));
            }

            if (Resultado.Count > 0)
            {
                Resultado.ToList().ForEach(i => i.deletar(i));
            }


            return base.deletar(objeto);
        }
    }
}
