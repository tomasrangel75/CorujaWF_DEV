using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Questionario
    {
        public Questionario()
        {
            this.Aplicacaos = new List<Aplicacao>();
            this.Questaos = new List<Questao>();
            this.Resultadoes = new List<Resultado>();
            this.Disciplinas = new List<Disciplina>();
        }

        public long idQuestionario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<long> Nivel_id { get; set; }
        public Nullable<long> Arquivo_id { get; set; }
        public string Cor { get; set; }
        public Nullable<bool> RepetePergunta { get; set; }
        public Nullable<long> idBase { get; set; }
        public virtual ICollection<Aplicacao> Aplicacaos { get; set; }
        public virtual Arquivo Arquivo { get; set; }
        public virtual Nivel Nivel { get; set; }
        public virtual ICollection<Questao> Questaos { get; set; }
        public virtual ICollection<Resultado> Resultadoes { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}
