using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
    public class Questionario
    {


        IclsDbOp newOp = new clsDbOp();
        string sqlQuery;
        SqlCeParameter[] parameters = null;


        public int id { get; set; }
        public string Prova { get; set; }
        public string Descricao { get; set; }

        public void GetQ()
        {
            sqlQuery = "Select Prova from Questionarios where id = @id";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.id);

            var res = newOp.execScalarStr(sqlQuery, false, parameters);
            this.Prova = res;
        }

        public void GetId()
        {
            sqlQuery = "Select id from Questionarios where Prova = @Prova";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@Prova", this.Prova);

            int res = newOp.execScalar(sqlQuery, false, parameters);
            this.id = res;
        }


    }
}
