using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class SaltoMap : EntityTypeConfiguration<Salto>
    {
        public SaltoMap()
        {
            // Primary Key
            this.HasKey(t => t.idSalto);

            // Properties
            // Table & Column Mappings
            this.ToTable("Salto");
            this.Property(t => t.idSalto).HasColumnName("idSalto");
            this.Property(t => t.ItemQuestao_id).HasColumnName("ItemQuestao_id");
            this.Property(t => t.QuestaoDestino_id).HasColumnName("QuestaoDestino_id");
            this.Property(t => t.SaltarAoErrar).HasColumnName("SaltarAoErrar");
            this.Property(t => t.VoltarDoSalto).HasColumnName("VoltarDoSalto");

            // Relationships
            this.HasRequired(t => t.ItemQuestao)
                .WithMany(t => t.Saltoes)
                .HasForeignKey(d => d.ItemQuestao_id);
            this.HasRequired(t => t.Questao)
                .WithMany(t => t.Saltoes)
                .HasForeignKey(d => d.QuestaoDestino_id);

        }
    }
}
