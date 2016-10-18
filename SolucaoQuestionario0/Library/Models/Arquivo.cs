using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class Arquivo
    {
        public Arquivo()
        {
            this.ItemArquivoes = new List<ItemArquivo>();
            this.Questionarios = new List<Questionario>();
        }

        public long idArquivo { get; set; }
        public string Nome { get; set; }
        public string NomeFisico { get; set; }
        public string CaminhoFisico { get; set; }
        public string Extensao { get; set; }
        public Nullable<long> TipoArquivo_id { get; set; }
        public virtual TipoArquivo TipoArquivo { get; set; }
        public virtual ICollection<ItemArquivo> ItemArquivoes { get; set; }
        public virtual ICollection<Questionario> Questionarios { get; set; }
    }
}
