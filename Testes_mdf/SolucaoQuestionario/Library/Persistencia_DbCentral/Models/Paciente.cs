using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
    public class Paciente
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Sexo { get; set; }
        public DateTime DtCadastro { get; set; }

        public int Especialista_id { get; set; }
       

    }
}
