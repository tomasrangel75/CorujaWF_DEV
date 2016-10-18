using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class EstadoQuestionarioMap : EntityTypeConfiguration<EstadoQuestionario>
    {
        public EstadoQuestionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.idEstadoQuestionario);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("EstadoQuestionario");
            this.Property(t => t.idEstadoQuestionario).HasColumnName("idEstadoQuestionario");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
