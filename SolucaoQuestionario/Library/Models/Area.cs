using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Area
    {
        public Area()
        {
            this.Questaos = new List<Questao>();
        }

        public long idArea { get; set; }
        public string Nome { get; set; }
        public Nullable<long> Disciplina_id { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<Questao> Questaos { get; set; }
    }
}
