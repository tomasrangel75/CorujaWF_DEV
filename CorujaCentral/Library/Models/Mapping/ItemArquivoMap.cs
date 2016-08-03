using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class ItemArquivoMap : EntityTypeConfiguration<ItemArquivo>
    {
        public ItemArquivoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ItemQuestao_id, t.Arquivo_id });

            // Properties
            this.Property(t => t.ItemQuestao_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Arquivo_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tamanho)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ItemArquivo");
            this.Property(t => t.ItemQuestao_id).HasColumnName("ItemQuestao_id");
            this.Property(t => t.Arquivo_id).HasColumnName("Arquivo_id");
            this.Property(t => t.Posicao).HasColumnName("Posicao");
            this.Property(t => t.Tamanho).HasColumnName("Tamanho");
            this.Property(t => t.X).HasColumnName("X");
            this.Property(t => t.Y).HasColumnName("Y");
            this.Property(t => t.TipoAcao).HasColumnName("TipoAcao");

            // Relationships
            this.HasRequired(t => t.Arquivo)
                .WithMany(t => t.ItemArquivoes)
                .HasForeignKey(d => d.Arquivo_id);
            this.HasRequired(t => t.ItemQuestao)
                .WithMany(t => t.ItemArquivoes)
                .HasForeignKey(d => d.ItemQuestao_id);

        }
    }
}
