using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class ResultadoMap : EntityTypeConfiguration<Resultado>
    {
        public ResultadoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Aluno_id, t.Questionario_id });

            // Properties
            this.Property(t => t.Aluno_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Questionario_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Resultado");
            this.Property(t => t.Aluno_id).HasColumnName("Aluno_id");
            this.Property(t => t.Questionario_id).HasColumnName("Questionario_id");
            this.Property(t => t.TotalAcertos).HasColumnName("TotalAcertos");
            this.Property(t => t.TotalErros).HasColumnName("TotalErros");
            this.Property(t => t.Disciplina_id).HasColumnName("Disciplina_id");
            this.Property(t => t.EstadoQuestionario_id).HasColumnName("EstadoQuestionario_id");
            this.Property(t => t.UltimaQuestao_id).HasColumnName("UltimaQuestao_id");

            // Relationships
            this.HasRequired(t => t.Aluno)
                .WithMany(t => t.Resultadoes)
                .HasForeignKey(d => d.Aluno_id);
            this.HasOptional(t => t.Disciplina)
                .WithMany(t => t.Resultadoes)
                .HasForeignKey(d => d.Disciplina_id);
            this.HasOptional(t => t.EstadoQuestionario)
                .WithMany(t => t.Resultadoes)
                .HasForeignKey(d => d.EstadoQuestionario_id);
            this.HasOptional(t => t.Questao)
                .WithMany(t => t.Resultadoes)
                .HasForeignKey(d => d.UltimaQuestao_id);
            this.HasRequired(t => t.Questionario)
                .WithMany(t => t.Resultadoes)
                .HasForeignKey(d => d.Questionario_id);

        }
    }
}
