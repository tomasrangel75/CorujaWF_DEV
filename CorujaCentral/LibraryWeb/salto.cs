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
    
    public partial class salto
    {
        public int idSalto { get; set; }
        public Nullable<bool> SaltarAoErrar { get; set; }
        public Nullable<bool> VoltarDoSalto { get; set; }
        public Nullable<int> ItemQuestao_id { get; set; }
        public Nullable<int> QuestaoDestino_id { get; set; }
    
        public virtual itemquestao itemquestao { get; set; }
        public virtual questao questao { get; set; }
    }
}