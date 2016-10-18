using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class ItemQuestao
    {
        public ItemQuestao()
        {
            this.ItemArquivoes = new List<ItemArquivo>();
            this.Saltoes = new List<Salto>();
        }

        public long idItemQuestao { get; set; }
        public long TipoItem_id { get; set; }
        public Nullable<long> Questao_id { get; set; }
        public string Titulo { get; set; }
        public Nullable<bool> OpcaoCorreta { get; set; }
        public Nullable<bool> TransformaImagem { get; set; }
        public Nullable<bool> EPergunta { get; set; }
        public Nullable<bool> Eresposta { get; set; }
        public Nullable<bool> ETentativa { get; set; }
        public Nullable<long> OrdemTela { get; set; }
        public Nullable<long> OrdemResposta { get; set; }
        public Nullable<bool> ContemImagem { get; set; }
        public Nullable<bool> ContemAudio { get; set; }
        public Nullable<long> idBase { get; set; }
        public virtual ICollection<ItemArquivo> ItemArquivoes { get; set; }
        public virtual TipoItem TipoItem { get; set; }
        public virtual Questao Questao { get; set; }
        public virtual ICollection<Salto> Saltoes { get; set; }
    }
}
