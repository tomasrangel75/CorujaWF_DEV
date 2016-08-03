using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class AplicacaoMap : EntityTypeConfiguration<Aplicacao>
    {
        public AplicacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.idAplicacao);

            // Properties
            this.Property(t => t.idAplicacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Aplicacao");
            this.Property(t => t.idAplicacao).HasColumnName("idAplicacao");
            this.Property(t => t.Questionario_id).HasColumnName("Questionario_id");
            this.Property(t => t.Turma_id).HasColumnName("Turma_id");
            this.Property(t => t.Evento_id).HasColumnName("Evento_id");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasOptional(t => t.Evento)
                .WithMany(t => t.Aplicacaos)
                .HasForeignKey(d => d.Evento_id);
            this.HasRequired(t => t.Turma)
                .WithMany(t => t.Aplicacaos)
                .HasForeignKey(d => d.Turma_id);
            this.HasRequired(t => t.Questionario)
                .WithMany(t => t.Aplicacaos)
                .HasForeignKey(d => d.Questionario_id);

        }
    }
}
