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
    
    public partial class questao
    {
        public questao()
        {
            this.itemquestao = new HashSet<itemquestao>();
            this.pontuacao = new HashSet<pontuacao>();
            this.questao1 = new HashSet<questao>();
            this.questao11 = new HashSet<questao>();
            this.resultado = new HashSet<resultado>();
            this.salto = new HashSet<salto>();
        }
    
        public int idQuestao { get; set; }
        public string Titulo { get; set; }
        public Nullable<int> Tentativas { get; set; }
        public string Cor { get; set; }
        public Nullable<int> Ordem { get; set; }
        public Nullable<int> PosicaoRespostas { get; set; }
        public Nullable<int> PosicaoPergunta { get; set; }
        public Nullable<int> idBase { get; set; }
        public Nullable<double> Peso { get; set; }
        public string TAG { get; set; }
        public Nullable<bool> Hint { get; set; }
        public Nullable<bool> Enfileirada { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<int> Semestre { get; set; }
        public string Competencia { get; set; }
        public Nullable<int> Questionario_id { get; set; }
        public Nullable<int> TipoQuestao_id { get; set; }
        public Nullable<int> Proxima { get; set; }
        public Nullable<int> Disciplina_id { get; set; }
        public Nullable<int> QuestaoReplica { get; set; }
        public Nullable<int> Area_id { get; set; }
    
        public virtual area area { get; set; }
        public virtual disciplina disciplina { get; set; }
        public virtual ICollection<itemquestao> itemquestao { get; set; }
        public virtual ICollection<pontuacao> pontuacao { get; set; }
        public virtual ICollection<questao> questao1 { get; set; }
        public virtual questao questao2 { get; set; }
        public virtual ICollection<questao> questao11 { get; set; }
        public virtual questao questao3 { get; set; }
        public virtual questionario questionario { get; set; }
        public virtual tipoquestao tipoquestao { get; set; }
        public virtual ICollection<resultado> resultado { get; set; }
        public virtual ICollection<salto> salto { get; set; }
    }
}
