using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Pontuacao
    {
        public long Aluno_id { get; set; }
        public long Questao_id { get; set; }
        public Nullable<bool> Acertou { get; set; }
        public Nullable<long> Tentativas { get; set; }
        public Nullable<double> Tempo { get; set; }
        public string Mouse { get; set; }
        public string Clicks { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Questao Questao { get; set; }
    }
}
