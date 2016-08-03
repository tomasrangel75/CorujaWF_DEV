using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Aplicacao
    {
        public long idAplicacao { get; set; }
        public long Questionario_id { get; set; }
        public long Turma_id { get; set; }
        public Nullable<long> Evento_id { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Questionario Questionario { get; set; }
    }
}
