using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            // Primary Key
            this.HasKey(t => t.idTurma);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Turma");
            this.Property(t => t.idTurma).HasColumnName("idTurma");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Instituicao_id).HasColumnName("Instituicao_id");
            this.Property(t => t.Nivel_id).HasColumnName("Nivel_id");

            // Relationships
            this.HasOptional(t => t.Instituicao)
                .WithMany(t => t.Turmas)
                .HasForeignKey(d => d.Instituicao_id);
            this.HasOptional(t => t.Nivel)
                .WithMany(t => t.Turmas)
                .HasForeignKey(d => d.Nivel_id);

        }
    }
}
