using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            // Primary Key
            this.HasKey(t => t.idEvento);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Evento");
            this.Property(t => t.idEvento).HasColumnName("idEvento");
            this.Property(t => t.Instituicao_id).HasColumnName("Instituicao_id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasOptional(t => t.Instituicao)
                .WithMany(t => t.Eventoes)
                .HasForeignKey(d => d.Instituicao_id);

        }
    }
}
