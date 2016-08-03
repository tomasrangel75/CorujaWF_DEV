using System;
using System.Collections.Generic;

namespace Library.Persistencia
{
    public partial class TipoArquivo
    {
        public TipoArquivo()
        {
            this.Arquivoes = new List<Arquivo>();
        }

        public long idTipoArquivo { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Arquivo> Arquivoes { get; set; }
    }
}
