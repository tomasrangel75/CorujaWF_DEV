//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipoquestao
    {
        public tipoquestao()
        {
            this.questao = new HashSet<questao>();
        }
    
        public int idTipoQuestao { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<questao> questao { get; set; }
    }
}
