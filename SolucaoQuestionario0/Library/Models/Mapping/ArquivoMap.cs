using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class ArquivoMap : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoMap()
        {
            // Primary Key
            this.HasKey(t => t.idArquivo);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(200);

            this.Property(t => t.NomeFisico)
                .HasMaxLength(200);

            this.Property(t => t.CaminhoFisico)
                .HasMaxLength(200);

            this.Property(t => t.Extensao)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Arquivo");
            this.Property(t => t.idArquivo).HasColumnName("idArquivo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.NomeFisico).HasColumnName("NomeFisico");
            this.Property(t => t.CaminhoFisico).HasColumnName("CaminhoFisico");
            this.Property(t => t.Extensao).HasColumnName("Extensao");
            this.Property(t => t.TipoArquivo_id).HasColumnName("TipoArquivo_id");

            // Relationships
            this.HasOptional(t => t.TipoArquivo)
                .WithMany(t => t.Arquivoes)
                .HasForeignKey(d => d.TipoArquivo_id);

        }
    }
}
