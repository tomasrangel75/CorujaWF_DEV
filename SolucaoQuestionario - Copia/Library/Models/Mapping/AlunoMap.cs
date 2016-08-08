using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            // Primary Key
            this.HasKey(t => t.idAluno);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Aluno");
            this.Property(t => t.idAluno).HasColumnName("idAluno");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Turma_id).HasColumnName("Turma_id");

            // Relationships
            this.HasOptional(t => t.Turma)
                .WithMany(t => t.Alunoes)
                .HasForeignKey(d => d.Turma_id);

        }
    }
}
