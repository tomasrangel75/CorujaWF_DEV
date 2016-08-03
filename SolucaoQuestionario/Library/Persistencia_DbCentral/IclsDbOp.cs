using System.Data;
using System.Data.SqlServerCe;

namespace Library.Persistencia_DbCentral
{

    public interface IclsDbOp
    {
        /// <summary>
        /// Query against DB, return DataTable 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>DataTable</returns>
        DataTable execSelectDt(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        /// <summary>
        /// Query against DB, return DataSet 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>DataSet</returns>
        DataSet execSelectDs(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        /// <summary>
        /// Insert, Update and Delete 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">The values which you have to insert, update, or delete</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>True for successful execution, otherwise False</returns>
        int execNonQuery(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        /// <summary>
        /// Scalar Query against DB, return single value 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>single value (int)</returns>
        int execScalar(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        string execScalarStr(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        /// <summary>
        /// Read data 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="isProcedure">If the first parameter "sql" is any name of the stored procedure then it must be true</param>
        /// <param name="parameters">The parameters WHERE clause in SELECT Query</param>
        /// <returns>The resultant dataSet aganist the select query or the stored procedure</returns>
        void readData(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
        /// <summary>
        /// Transaction 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="isProcedure">If the first parameter "sql" is any name of the stored procedure then it must be true</param>
        /// <param name="parameters">The parameters</param>
        /// <returns>true = commit, false = rollback</returns>
        bool execTrans(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null);
    }
}
