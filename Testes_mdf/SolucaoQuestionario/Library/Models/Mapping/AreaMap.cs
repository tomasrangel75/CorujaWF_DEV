using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
            // Primary Key
            this.HasKey(t => t.idArea);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Area");
            this.Property(t => t.idArea).HasColumnName("idArea");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Disciplina_id).HasColumnName("Disciplina_id");

            // Relationships
            this.HasOptional(t => t.Disciplina)
                .WithMany(t => t.Areas)
                .HasForeignKey(d => d.Disciplina_id);

        }
    }
}
