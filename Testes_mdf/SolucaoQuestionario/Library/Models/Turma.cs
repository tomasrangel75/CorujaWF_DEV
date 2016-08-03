using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Turma
    {
        public Turma()
        {
            this.Alunoes = new List<Aluno>();
            this.Aplicacaos = new List<Aplicacao>();
        }

        public long idTurma { get; set; }
        public string Nome { get; set; }
        public Nullable<long> Instituicao_id { get; set; }
        public Nullable<long> Nivel_id { get; set; }
        public virtual ICollection<Aluno> Alunoes { get; set; }
        public virtual ICollection<Aplicacao> Aplicacaos { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public virtual Nivel Nivel { get; set; }
    }
}
