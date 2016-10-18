using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class EstadoQuestionario
    {
        public EstadoQuestionario()
        {
            this.Resultadoes = new List<Resultado>();
        }

        public long idEstadoQuestionario { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Resultado> Resultadoes { get; set; }
    }
}
