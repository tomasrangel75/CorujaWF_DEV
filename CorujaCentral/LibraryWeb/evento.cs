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
    
    public partial class evento
    {
        public evento()
        {
            this.aplicacao = new HashSet<aplicacao>();
        }
    
        public int idEvento { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> Instituicao_id { get; set; }
    
        public virtual ICollection<aplicacao> aplicacao { get; set; }
        public virtual instituicao instituicao { get; set; }
    }
}
