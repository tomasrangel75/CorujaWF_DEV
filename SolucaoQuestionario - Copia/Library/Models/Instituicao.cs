using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            this.Eventoes = new List<Evento>();
            this.Turmas = new List<Turma>();
        }

        public long idInstituicao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Evento> Eventoes { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
