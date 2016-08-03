using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Questao
    {
        public Questao()
        {
            this.ItemQuestaos = new List<ItemQuestao>();
            this.Pontuacaos = new List<Pontuacao>();
            this.Questao1 = new List<Questao>();
            this.Questao11 = new List<Questao>();
            this.Resultadoes = new List<Resultado>();
            this.Saltoes = new List<Salto>();
        }

        public long idQuestao { get; set; }
        public string Titulo { get; set; }
        public Nullable<long> Questionario_id { get; set; }
        public Nullable<long> TipoQuestao_id { get; set; }
        public Nullable<long> Proxima { get; set; }
        public Nullable<long> Disciplina_id { get; set; }
        public Nullable<long> QuestaoReplica { get; set; }
        public Nullable<long> Tentativas { get; set; }
        public string Cor { get; set; }
        public Nullable<long> Ordem { get; set; }
        public Nullable<long> PosicaoRespostas { get; set; }
        public Nullable<long> PosicaoPergunta { get; set; }
        public Nullable<long> Area_id { get; set; }
        public Nullable<long> idBase { get; set; }
        public Nullable<double> Peso { get; set; }
        public string TAG { get; set; }
        public Nullable<bool> Hint { get; set; }
        public virtual Area Area { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<ItemQuestao> ItemQuestaos { get; set; }
        public virtual ICollection<Pontuacao> Pontuacaos { get; set; }
        public virtual ICollection<Questao> Questao1 { get; set; }
        public virtual Questao Questao2 { get; set; }
        public virtual TipoQuestao TipoQuestao { get; set; }
        public virtual Questionario Questionario { get; set; }
        public virtual ICollection<Questao> Questao11 { get; set; }
        public virtual Questao Questao3 { get; set; }
        public virtual ICollection<Resultado> Resultadoes { get; set; }
        public virtual ICollection<Salto> Saltoes { get; set; }
    }
}
