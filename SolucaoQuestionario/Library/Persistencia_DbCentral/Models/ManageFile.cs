using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistencia_DbCentral.Models
{
	public class ManageFile
	{
		IclsDbOp newOp = new clsDbOp();
		string sqlQuery;
		SqlCeParameter[] parameters = null;

		#region Props

		public int id { get; set; }
		public int openF { get; set; }	
		public int closeF { get; set; }
		public int isFinished { get; set; }
		public int idAluno { get; set; }
		public int idProva { get; set; }
		public string filePath { get; set; }
		public string NomeAluno { get; set; }


		#endregion

		#region Methods

		public DataTable ListaAval()
		{
			sqlQuery = "Select filepath, IdAluno, NomeAluno, IdProva from OpenCloseFile where closeF = 0  and isFinished = 0";
			return newOp.execSelectDt(sqlQuery, false, parameters);
		}

		public int UpdClose()
		{
			sqlQuery = "Update OpenCloseFile set closeF = @close where IdAluno = @IdAluno and " +
				" IdProva = @IdProva and NomeAluno = @NomeAluno";

			int result = 0;

			parameters = new SqlCeParameter[4];
			parameters[0] = new SqlCeParameter("@IdAluno", this.idAluno);
			parameters[1] = new SqlCeParameter("@IdProva", this.idProva);
			parameters[2] = new SqlCeParameter("@NomeAluno", this.NomeAluno);
			parameters[3] = new SqlCeParameter("@close", this.closeF);

			result = newOp.execNonQuery(sqlQuery, false, parameters);
			return result;

		}

		public int AddAval()
		{
			sqlQuery = "INSERT INTO OpenCloseFile (IdAluno, IdProva, NomeAluno, filePath) VALUES (@IdAluno, @IdProva, @NomeAluno, @filePath)";
			int result = 0;

			parameters = new SqlCeParameter[4];
			parameters[0] = new SqlCeParameter("@IdAluno", this.idAluno);
			parameters[1] = new SqlCeParameter("@IdProva", this.idProva);
			parameters[2] = new SqlCeParameter("@NomeAluno", this.NomeAluno);
			parameters[3] = new SqlCeParameter("@filePath", this.filePath);

			result = newOp.execNonQuery(sqlQuery, false, parameters);
			return result;
		}

		public int DelAval()
		{
			int result = 0;
			sqlQuery = "delete from  OpenCloseFile WHERE IdAluno = @IdAluno and " +
				" IdProva = @IdProva and NomeAluno = @NomeAluno";
			parameters = new SqlCeParameter[3];
			parameters[0] = new SqlCeParameter("@IdAluno", this.idAluno);
			parameters[1] = new SqlCeParameter("@IdProva", this.idProva);
			parameters[2] = new SqlCeParameter("@NomeAluno", this.NomeAluno);
	
			result = newOp.execNonQuery(sqlQuery, false, parameters);
			return result;
		}
			
		
		#endregion

	}
}
