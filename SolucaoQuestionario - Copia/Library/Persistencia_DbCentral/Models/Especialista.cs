using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;
using System.Data;

namespace Library.Persistencia_DbCentral.Models
{
    public class Especialista
    {      

        IclsDbOp newOp = new clsDbOp();
        string sqlQuery;
        SqlCeParameter[] parameters = null;

        #region Props

        public int id { get; set; }
        public string Nome { get; set; }
        public Collection<Paciente> Pacientes { get; set; }

        #endregion

        #region Methods

        public DataTable listaEspecialistas()
        {
            sqlQuery = "Select id, Nome from Especialistas";
            return newOp.execSelectDt(sqlQuery, false);

        }

        public string AddEsp()
        {
            sqlQuery = "INSERT INTO Especialistas (Nome) VALUES (@Nome)";
            int result = 0;

            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@Nome", this.Nome);
            
            result = newOp.execNonQuery(sqlQuery, false, parameters);
            if (result > 0)
            {
                return "Operação relaizada com sucesso";
            }
            else
            {
                return "Operação não concluída";
            }

        }

        public string UpdtEsp()
        {
            sqlQuery = "UPDATE Especialistas SET Nome = @Nome WHERE id = @id";
            int result = 0;

            parameters = new SqlCeParameter[2];
            parameters[0] = new SqlCeParameter("@Nome", this.Nome);
            parameters[1] = new SqlCeParameter("@id", this.id);
          
            result = newOp.execNonQuery(sqlQuery, false, parameters);
            if (result > 0)
            {
                return "Atualização realizada com sucesso";
            }
            else
            {
                return "Atualização não concluída";
            }
        }

        public string DelEsp()
        {
            sqlQuery = "delete from  Especialistas WHERE id = @id";
            int result = 0;

            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.id);

            result = newOp.execNonQuery(sqlQuery, false, parameters);
            if (result > 0)
            {
                return "Registro removido com sucesso";
            }
            else
            {
                return "Operação não concluída";
            }
        }

        #endregion


    }
}
