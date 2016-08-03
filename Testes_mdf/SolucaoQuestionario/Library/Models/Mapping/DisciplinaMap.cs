using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class DisciplinaMap : EntityTypeConfiguration<Disciplina>
    {
        public DisciplinaMap()
        {
            // Primary Key
            this.HasKey(t => t.idDisciplina);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Disciplina");
            this.Property(t => t.idDisciplina).HasColumnName("idDisciplina");
            this.Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            this.HasMany(t => t.Questionarios)
                .WithMany(t => t.Disciplinas)
                .Map(m =>
                    {
                        m.ToTable("QuestionarioDisciplina");
                        m.MapLeftKey("Disciplina_id");
                        m.MapRightKey("Questionario_id");
                    });


        }
    }
}
