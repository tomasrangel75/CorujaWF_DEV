using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
    public class Avaliacao
    {
        public int id { get; set; }
        public int Aluno_id { get; set; }
        public int Prova_id{ get; set; }
        public DateTime? DtIni { get; set; }
        public DateTime? DtFim { get; set; }
        public string Status { get; set; }
    }
}
