using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class NivelMap : EntityTypeConfiguration<Nivel>
    {
        public NivelMap()
        {
            // Primary Key
            this.HasKey(t => t.idNivel);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Nivel");
            this.Property(t => t.idNivel).HasColumnName("idNivel");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
