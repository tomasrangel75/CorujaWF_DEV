using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            this.Areas = new List<Area>();
            this.Questaos = new List<Questao>();
            this.Resultadoes = new List<Resultado>();
            this.Questionarios = new List<Questionario>();
        }

        public long idDisciplina { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Questao> Questaos { get; set; }
        public virtual ICollection<Resultado> Resultadoes { get; set; }
        public virtual ICollection<Questionario> Questionarios { get; set; }
    }
}
