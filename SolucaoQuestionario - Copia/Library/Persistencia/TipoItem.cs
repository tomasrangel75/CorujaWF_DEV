//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.Persistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoItem
    {
        public TipoItem()
        {
            this.ItemQuestao = new HashSet<ItemQuestao>();
        }
    
        public long idTipoItem { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<ItemQuestao> ItemQuestao { get; set; }
    }
}
