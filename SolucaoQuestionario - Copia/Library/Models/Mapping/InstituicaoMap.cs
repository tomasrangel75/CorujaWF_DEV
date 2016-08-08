using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class InstituicaoMap : EntityTypeConfiguration<Instituicao>
    {
        public InstituicaoMap()
        {
            // Primary Key
            this.HasKey(t => t.idInstituicao);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Instituicao");
            this.Property(t => t.idInstituicao).HasColumnName("idInstituicao");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
