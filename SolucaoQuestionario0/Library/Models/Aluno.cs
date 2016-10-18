using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Aluno
    {
        public Aluno()
        {
            this.Pontuacaos = new List<Pontuacao>();
            this.Resultadoes = new List<Resultado>();
        }

        public long idAluno { get; set; }
        public string Nome { get; set; }
        public Nullable<long> Turma_id { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<Pontuacao> Pontuacaos { get; set; }
        public virtual ICollection<Resultado> Resultadoes { get; set; }
    }
}
