using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class QuestionarioMap : EntityTypeConfiguration<Questionario>
    {
        public QuestionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.idQuestionario);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(300);

            this.Property(t => t.Descricao)
                .HasMaxLength(500);

            this.Property(t => t.Cor)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("Questionario");
            this.Property(t => t.idQuestionario).HasColumnName("idQuestionario");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Nivel_id).HasColumnName("Nivel_id");
            this.Property(t => t.Arquivo_id).HasColumnName("Arquivo_id");
            this.Property(t => t.Cor).HasColumnName("Cor");
            this.Property(t => t.RepetePergunta).HasColumnName("RepetePergunta");
            this.Property(t => t.idBase).HasColumnName("idBase");

            // Relationships
            this.HasOptional(t => t.Arquivo)
                .WithMany(t => t.Questionarios)
                .HasForeignKey(d => d.Arquivo_id);
            this.HasOptional(t => t.Nivel)
                .WithMany(t => t.Questionarios)
                .HasForeignKey(d => d.Nivel_id);

        }
    }
}
