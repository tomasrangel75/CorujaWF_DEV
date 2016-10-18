using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
    public class Paciente
    {
        
        IclsDbOp newOp = new clsDbOp();
        string sqlQuery;
        SqlCeParameter[] parameters = null;


        #region Props

        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Sexo { get; set; }
        public DateTime DtCadastro { get; set; }

        public int Especialista_id { get; set; }

        #endregion

        #region Methods

        public DataTable ListaPacientes()
        {
            sqlQuery = "Select id, nome from Pacientes where  Especialista_id = @id";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.Especialista_id);

            return newOp.execSelectDt(sqlQuery, false, parameters);

        }

        public DataTable ListaDadosPacientes()
        {
            sqlQuery = "Select id, nome, sexo, DtNasc from Pacientes";
            return newOp.execSelectDt(sqlQuery, false, parameters);
        }

        public void GetPac()
        {
            sqlQuery = "Select Nome, DtNasc, Sexo, DtCadastro from Pacientes where   id = @id";
            parameters = new SqlCeParameter[1];
            parameters[0] = new SqlCeParameter("@id", this.id);
            var pac = newOp.execSelectDt(sqlQuery, false, parameters);
            this.Nome = pac.Rows[0][0].ToString();
            this.DtNasc = Convert.ToDateTime(pac.Rows[0][1]);
            this.Sexo = pac.Rows[0][2].ToString();
            this.DtCadastro = Convert.ToDateTime(pac.Rows[0][3]);
        }

        public int GetIdPac(string espNome)
        {
            sqlQuery = "Select id from Pacientes where nome = @nome and Especialista_id = @Esp_Id ";
            parameters = new SqlCeParameter[2];
            parameters[0] = new SqlCeParameter("@nome", this.Nome);
            parameters[1] = new SqlCeParameter("@Esp_Id", this.Especialista_id);

            sqlQuery = "Select id from Pacientes where nome = '" + this.Nome + "' and Especialista_id in (select id From Especialistas where nome = '" + espNome + "')";


            var pacId = newOp.execScalar(sqlQuery, false,null);
            return pacId;
         }


        public string AddPaciente()
        {
            sqlQuery = "INSERT INTO Pacientes (Nome, DtNasc, Sexo, DtCadastro, Especialista_id ) VALUES (@Nome, @DtNasc, @Sexo, @DtCadastro, @Esp_Id)";
            int result = 0;

            parameters = new SqlCeParameter[5];
            parameters[0] = new SqlCeParameter("@Nome", this.Nome);
            parameters[1] = new SqlCeParameter("@DtNasc", this.DtNasc);
            parameters[2] = new SqlCeParameter("@Sexo", this.Sexo);
            parameters[3] = new SqlCeParameter("@DtCadastro", this.DtCadastro);
            parameters[4] = new SqlCeParameter("@Esp_Id", this.Especialista_id);

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

        public string UpdtPac()
        {
            sqlQuery = "UPDATE Pacientes SET Nome = @Nome, DtNasc = @DtNasc, Sexo = @Sexo, DtCadastro = @DtCadastro WHERE id = @id";
            int result = 0;

            parameters = new SqlCeParameter[5];
            parameters[0] = new SqlCeParameter("@Nome", this.Nome);
            parameters[1] = new SqlCeParameter("@DtNasc", Convert.ToDateTime(this.DtNasc));
            parameters[2] = new SqlCeParameter("@DtCadastro", Convert.ToDateTime(this.DtCadastro));
            parameters[3] = new SqlCeParameter("@Sexo", this.Sexo);
            parameters[4] = new SqlCeParameter("@id", this.id);

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

        public string DelPac()
        {
            sqlQuery = "delete from  Pacientes WHERE id = @id";
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
