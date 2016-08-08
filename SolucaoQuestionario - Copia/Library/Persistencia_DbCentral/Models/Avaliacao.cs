using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
    public class Avaliacao
    {
        IclsDbOp newOp = new clsDbOp();
        string sqlQuery;
        SqlCeParameter[] parameters = null;

        #region Props

        public int id { get; set; }
        public int Aluno_id { get; set; }
        public int Prova_id { get; set; }
        public DateTime? DtIni { get; set; }
        public DateTime? DtFim { get; set; }
        public string Status { get; set; }


        #endregion

        #region Methods

        public DataTable ListaAval()
        {
            sqlQuery = "Select A.id, A.Prova_id, Q.Prova, A.DtIni, A.DtFim, A.Status from Avaliacaos A inner join Questionarios Q on A.Prova_id = Q.id where A.Aluno_id = @id";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.Aluno_id);

            return newOp.execSelectDt(sqlQuery, false, parameters);

        }
        
        public void CheckStatus()
        {
            sqlQuery = "Select Count(Status) from Avaliacaos where aluno_id = @Aluno_id and  prova_id = @Prova_id and Status = 'Iniciada'";
            parameters = new SqlCeParameter[2];
            parameters[0] = new SqlCeParameter("@Aluno_id", this.Aluno_id);
            parameters[1] = new SqlCeParameter("@Prova_id", this.Prova_id);
       
            int result = newOp.execScalar(sqlQuery, false, parameters);
            if (result == 1) this.Status = "Iniciada";
        }

        public void GetId()
        {
        
        sqlQuery = "Select id from Avaliacaos where Aluno_id = @Aluno_id and Prova_id = @Prova_id and DtIni = @DtIni";
            parameters = new SqlCeParameter[3];
            parameters[0] = new SqlCeParameter("@Aluno_id", this.Aluno_id);
            parameters[1] = new SqlCeParameter("@Prova_id", this.Prova_id);
            parameters[2] = new SqlCeParameter("@DtIni", this.DtIni);

            var result = newOp.execScalar(sqlQuery, false, parameters);
            this.id = result;
        }

        public void DelAval()
        {
            sqlQuery = "delete from  Avaliacaos WHERE id = @id";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.id);

            newOp.execNonQuery(sqlQuery, false, parameters);
        }

        public string AddAval()
        {
            sqlQuery = "INSERT INTO Avaliacaos (Aluno_id, Prova_id, DtIni, Status) VALUES (@Aluno_id, @Prova_id, @DtIni, @Status)";
            int result = 0;

            parameters = new SqlCeParameter[4];
            parameters[0] = new SqlCeParameter("@Aluno_id", this.Aluno_id);
            parameters[1] = new SqlCeParameter("@Prova_id", this.Prova_id);
            parameters[2] = new SqlCeParameter("@DtIni", this.DtIni);
            parameters[3] = new SqlCeParameter("@Status", this.Status);

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

        public string UpdStatus()
        {
            sqlQuery = "Update Avaliacaos set Status = @Status, DtFim = @DtFim where id = @id";
            int result = 0;

            parameters = new SqlCeParameter[3];
            parameters[0] = new SqlCeParameter("@id", this.id);
            parameters[1] = new SqlCeParameter("@Status", this.Status);
            parameters[2] = new SqlCeParameter("@DtFim", this.DtFim);

            result = newOp.execNonQuery(sqlQuery, false, parameters);
            if (result > 0)
            {
                return "Registro atualizado com sucesso";
            }
            else
            {
                return "Operação não concluída";
            }

        }

        public int GetIdProva(string prova)
        {
            sqlQuery = "Select id from questionarios where Prova = @Prova";
            int result = 0;

            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@Prova", prova);
      
            result = newOp.execScalar(sqlQuery, false, parameters);
    
            return result;
        }

        #endregion

    }
}
