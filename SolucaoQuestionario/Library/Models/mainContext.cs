using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Library.Persistencia.Mapping;

namespace Library.Persistencia
{
    public partial class mainContext : DbContext
    {
        static mainContext()
        {
            Database.SetInitializer<mainContext>(null);
        }

        public mainContext()
            : base("Name=mainContext")
        {
        }

        public mainContext(string conexao)
            : base(conexao)
        {
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new AplicacaoMap());
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new ArquivoMap());
            modelBuilder.Configurations.Add(new DisciplinaMap());
            modelBuilder.Configurations.Add(new EstadoQuestionarioMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new InstituicaoMap());
            modelBuilder.Configurations.Add(new ItemArquivoMap());
            modelBuilder.Configurations.Add(new ItemQuestaoMap());
            modelBuilder.Configurations.Add(new NivelMap());
            modelBuilder.Configurations.Add(new PontuacaoMap());
            modelBuilder.Configurations.Add(new QuestaoMap());
            modelBuilder.Configurations.Add(new QuestionarioMap());
            modelBuilder.Configurations.Add(new ResultadoMap());
            modelBuilder.Configurations.Add(new SaltoMap());
            modelBuilder.Configurations.Add(new TipoArquivoMap());
            modelBuilder.Configurations.Add(new TipoItemMap());
            modelBuilder.Configurations.Add(new TipoQuestaoMap());
            modelBuilder.Configurations.Add(new TurmaMap());
        }
    }
}
