using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class TipoQuestaoMap : EntityTypeConfiguration<TipoQuestao>
    {
        public TipoQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.idTipoQuestao);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TipoQuestao");
            this.Property(t => t.idTipoQuestao).HasColumnName("idTipoQuestao");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
