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
    
    public partial class itemarquivo
    {
        public int ItemQuestao_idItemQuestao { get; set; }
        public int Arquivo_idArquivo { get; set; }
        public Nullable<int> Posicao { get; set; }
        public string Tamanho { get; set; }
        public Nullable<int> X { get; set; }
        public Nullable<int> Y { get; set; }
        public Nullable<int> TipoAcao { get; set; }
    
        public virtual arquivo arquivo { get; set; }
        public virtual itemquestao itemquestao { get; set; }
    }
}
