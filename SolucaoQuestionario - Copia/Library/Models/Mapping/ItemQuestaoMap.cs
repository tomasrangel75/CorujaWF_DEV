using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class ItemQuestaoMap : EntityTypeConfiguration<ItemQuestao>
    {
        public ItemQuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.idItemQuestao);

            // Properties
            this.Property(t => t.Titulo)
                .HasMaxLength(600);

            // Table & Column Mappings
            this.ToTable("ItemQuestao");
            this.Property(t => t.idItemQuestao).HasColumnName("idItemQuestao");
            this.Property(t => t.TipoItem_id).HasColumnName("TipoItem_id");
            this.Property(t => t.Questao_id).HasColumnName("Questao_id");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.OpcaoCorreta).HasColumnName("OpcaoCorreta");
            this.Property(t => t.TransformaImagem).HasColumnName("TransformaImagem");
            this.Property(t => t.EPergunta).HasColumnName("EPergunta");
            this.Property(t => t.Eresposta).HasColumnName("Eresposta");
            this.Property(t => t.ETentativa).HasColumnName("ETentativa");
            this.Property(t => t.OrdemTela).HasColumnName("OrdemTela");
            this.Property(t => t.OrdemResposta).HasColumnName("OrdemResposta");
            this.Property(t => t.ContemImagem).HasColumnName("ContemImagem");
            this.Property(t => t.ContemAudio).HasColumnName("ContemAudio");
            this.Property(t => t.idBase).HasColumnName("idBase");

            // Relationships
            this.HasRequired(t => t.TipoItem)
                .WithMany(t => t.ItemQuestaos)
                .HasForeignKey(d => d.TipoItem_id);
            this.HasOptional(t => t.Questao)
                .WithMany(t => t.ItemQuestaos)
                .HasForeignKey(d => d.Questao_id);

        }
    }
}
