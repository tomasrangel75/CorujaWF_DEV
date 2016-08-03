using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class TipoQuestao
    {
        public TipoQuestao()
        {
            this.Questaos = new List<Questao>();
        }

        public long idTipoQuestao { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Questao> Questaos { get; set; }
    }
}
