﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuestEntities : DbContext
    {
        public QuestEntities()
            : base("name=QuestEntities")
        {
        }

        public QuestEntities(string conexao)
            : base(conexao)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Aplicacao> Aplicacao { get; set; }
        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<EstadoQuestionario> EstadoQuestionario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<ItemArquivo> ItemArquivo { get; set; }
        public DbSet<ItemQuestao> ItemQuestao { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Questionario> Questionario { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<TipoArquivo> TipoArquivo { get; set; }
        public DbSet<TipoItem> TipoItem { get; set; }
        public DbSet<TipoQuestao> TipoQuestao { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Salto> Salto { get; set; }
        public DbSet<Area> Area { get; set; }
    }
}
