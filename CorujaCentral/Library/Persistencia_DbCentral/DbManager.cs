using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral
{
    public class DbManager
    {
        public int? IdAluno { get; set; }

        public int? IdAval { get; set; }

        public string GetDbRootPath()
        {
            return "";
        }

        public bool RenameDb(byte type)
        {
            return true;
        }

    }
}
