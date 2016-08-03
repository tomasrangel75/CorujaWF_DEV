using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Nivel
    {
        public Nivel()
        {
            this.Questionarios = new List<Questionario>();
            this.Turmas = new List<Turma>();
        }

        public long idNivel { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Questionario> Questionarios { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
