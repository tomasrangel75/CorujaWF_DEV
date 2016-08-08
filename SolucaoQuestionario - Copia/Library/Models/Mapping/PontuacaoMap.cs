using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class PontuacaoMap : EntityTypeConfiguration<Pontuacao>
    {
        public PontuacaoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Aluno_id, t.Questao_id });

            // Properties
            this.Property(t => t.Aluno_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Questao_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Mouse)
                .HasMaxLength(500);

            this.Property(t => t.Clicks)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Pontuacao");
            this.Property(t => t.Aluno_id).HasColumnName("Aluno_id");
            this.Property(t => t.Questao_id).HasColumnName("Questao_id");
            this.Property(t => t.Acertou).HasColumnName("Acertou");
            this.Property(t => t.Tentativas).HasColumnName("Tentativas");
            this.Property(t => t.Tempo).HasColumnName("Tempo");
            this.Property(t => t.Mouse).HasColumnName("Mouse");
            this.Property(t => t.Clicks).HasColumnName("Clicks");

            // Relationships
            this.HasRequired(t => t.Aluno)
                .WithMany(t => t.Pontuacaos)
                .HasForeignKey(d => d.Aluno_id);
            this.HasRequired(t => t.Questao)
                .WithMany(t => t.Pontuacaos)
                .HasForeignKey(d => d.Questao_id);

        }
    }
}
