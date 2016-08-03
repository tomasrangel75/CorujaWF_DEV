using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Resultado
    {
        public long Aluno_id { get; set; }
        public long Questionario_id { get; set; }
        public Nullable<long> TotalAcertos { get; set; }
        public Nullable<long> TotalErros { get; set; }
        public Nullable<long> Disciplina_id { get; set; }
        public Nullable<long> EstadoQuestionario_id { get; set; }
        public Nullable<long> UltimaQuestao_id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual EstadoQuestionario EstadoQuestionario { get; set; }
        public virtual Questao Questao { get; set; }
        public virtual Questionario Questionario { get; set; }
    }
}
