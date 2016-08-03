using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Salto
    {
        public long idSalto { get; set; }
        public long ItemQuestao_id { get; set; }
        public long QuestaoDestino_id { get; set; }
        public Nullable<bool> SaltarAoErrar { get; set; }
        public Nullable<bool> VoltarDoSalto { get; set; }
        public virtual ItemQuestao ItemQuestao { get; set; }
        public virtual Questao Questao { get; set; }
    }
}
