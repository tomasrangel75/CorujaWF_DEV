using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Evento
    {
        public Evento()
        {
            this.Aplicacaos = new List<Aplicacao>();
        }

        public long idEvento { get; set; }
        public Nullable<long> Instituicao_id { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public virtual ICollection<Aplicacao> Aplicacaos { get; set; }
        public virtual Instituicao Instituicao { get; set; }
    }
}
