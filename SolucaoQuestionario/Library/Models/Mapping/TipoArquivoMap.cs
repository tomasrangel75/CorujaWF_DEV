using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class TipoArquivoMap : EntityTypeConfiguration<TipoArquivo>
    {
        public TipoArquivoMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoArquivo);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TipoArquivo");
            this.Property(t => t.idTipoArquivo).HasColumnName("idTipoArquivo");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
