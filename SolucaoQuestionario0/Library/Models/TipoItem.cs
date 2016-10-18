using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class TipoItem
    {
        public TipoItem()
        {
            this.ItemQuestaos = new List<ItemQuestao>();
        }

        public long idTipoItem { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ItemQuestao> ItemQuestaos { get; set; }
    }
}
