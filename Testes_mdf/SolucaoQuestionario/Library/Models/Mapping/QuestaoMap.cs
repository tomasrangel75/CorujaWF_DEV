using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistencia.Mapping
{
    public class QuestaoMap : EntityTypeConfiguration<Questao>
    {
        public QuestaoMap()
        {
            // Primary Key
            this.HasKey(t => t.idQuestao);

            // Properties
            this.Property(t => t.Titulo)
                .HasMaxLength(250);

            this.Property(t => t.Cor)
                .HasMaxLength(45);

            this.Property(t => t.TAG)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Questao");
            this.Property(t => t.idQuestao).HasColumnName("idQuestao");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.Questionario_id).HasColumnName("Questionario_id");
            this.Property(t => t.TipoQuestao_id).HasColumnName("TipoQuestao_id");
            this.Property(t => t.Proxima).HasColumnName("Proxima");
            this.Property(t => t.Disciplina_id).HasColumnName("Disciplina_id");
            this.Property(t => t.QuestaoReplica).HasColumnName("QuestaoReplica");
            this.Property(t => t.Tentativas).HasColumnName("Tentativas");
            this.Property(t => t.Cor).HasColumnName("Cor");
            this.Property(t => t.Ordem).HasColumnName("Ordem");
            this.Property(t => t.PosicaoRespostas).HasColumnName("PosicaoRespostas");
            this.Property(t => t.PosicaoPergunta).HasColumnName("PosicaoPergunta");
            this.Property(t => t.Area_id).HasColumnName("Area_id");
            this.Property(t => t.idBase).HasColumnName("idBase");
            this.Property(t => t.Peso).HasColumnName("Peso");
            this.Property(t => t.TAG).HasColumnName("TAG");
            this.Property(t => t.Hint).HasColumnName("Hint");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.Questaos)
                .HasForeignKey(d => d.Area_id);
            this.HasOptional(t => t.Disciplina)
                .WithMany(t => t.Questaos)
                .HasForeignKey(d => d.Disciplina_id);
            this.HasOptional(t => t.Questao2)
                .WithMany(t => t.Questao1)
                .HasForeignKey(d => d.QuestaoReplica);
            this.HasOptional(t => t.TipoQuestao)
                .WithMany(t => t.Questaos)
                .HasForeignKey(d => d.TipoQuestao_id);
            this.HasOptional(t => t.Questionario)
                .WithMany(t => t.Questaos)
                .HasForeignKey(d => d.Questionario_id);
            this.HasOptional(t => t.Questao3)
                .WithMany(t => t.Questao11)
                .HasForeignKey(d => d.Proxima);

        }
    }
}
