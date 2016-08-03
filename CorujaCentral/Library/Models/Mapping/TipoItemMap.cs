using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class TipoItemMap : EntityTypeConfiguration<TipoItem>
    {
        public TipoItemMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoItem);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TipoItem");
            this.Property(t => t.idTipoItem).HasColumnName("idTipoItem");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
