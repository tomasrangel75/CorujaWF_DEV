using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class ItemArquivo
    {
        public long ItemQuestao_id { get; set; }
        public long Arquivo_id { get; set; }
        public Nullable<long> Posicao { get; set; }
        public string Tamanho { get; set; }
        public Nullable<long> X { get; set; }
        public Nullable<long> Y { get; set; }
        public Nullable<long> TipoAcao { get; set; }
        public virtual Arquivo Arquivo { get; set; }
        public virtual ItemQuestao ItemQuestao { get; set; }
    }
}
