using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;

namespace Library.Persistencia_DbCentral
{

    public class clsDbOp : IclsDbOp, IDisposable
    {

        private SqlCeDataAdapter myAdapter;
        private SqlCeConnection conn;

        public void Dispose()
        {
            if (myAdapter != null)
            {
                myAdapter.Dispose();
                myAdapter = null;
            }
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
        // constructor
        public clsDbOp()
        {
            string connStr = @"Data Source = " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CorujaEdu\\DbCentral.sdf;Persist Security Info = False;";

            myAdapter = new SqlCeDataAdapter();
            conn = new SqlCeConnection(connStr);
        }

        // Method  - open - close database connection 
        private SqlCeConnection getConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }
        private void closeConnection()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        // Methods  - database ops
        /// <summary>
        /// Query against DB, return DataTable 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>DataTable</returns>
        public DataTable execSelectDt(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {
            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);
            DataTable dt = new DataTable();

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            try
            {
                sqlCmd.Connection = getConnection();
                SqlCeDataAdapter sqlDataAdapter = new SqlCeDataAdapter(sqlCmd);
                sqlDataAdapter.Fill(dt);
                return dt;

            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

            finally
            {
                closeConnection();
            }
        }

        /// <summary>
        /// Query against DB, return DataSet 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>DataSet</returns>
        public DataSet execSelectDs(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {
            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            try
            {
                sqlCmd.Connection = getConnection();
                SqlCeDataAdapter sqlDataAdapter = new SqlCeDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                ds = null;
                sqlDataAdapter.Fill(ds);
                return ds;

            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }
        }

        /// <summary>
        /// Insert, Update and Delete 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">The values which you have to insert, update, or delete</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>True for successful execution, otherwise False</returns>
        public int execNonQuery(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {

            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            // check command
            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            // Executing cmd against DB...
            try
            {
                sqlCmd.Connection = getConnection();
                return sqlCmd.ExecuteNonQuery();
            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }
        }

        /// <summary>
        /// Scalar Query against DB, return single value 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>single value (int)</returns>
        public int execScalar(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {
            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            try
            {
                sqlCmd.Connection = getConnection();
                return (int)sqlCmd.ExecuteScalar();
            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }
        }

        /// <summary>
        /// Scalar Query against DB, return single string value 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="parameters">Optional Parameters</param>
        /// <param name="isProcedure">If statement is a stored procedure </param>
        /// <returns>single value (int)</returns>
        public string execScalarStr(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {
            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            try
            {
                sqlCmd.Connection = getConnection();
                var res = sqlCmd.ExecuteScalar();
                return res.ToString();
            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }
        }
        
        /// <summary>
        /// Read data 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="isProcedure">If the first parameter "sql" is any name of the stored procedure then it must be true</param>
        /// <param name="parameters">The parameters WHERE clause in SELECT Query</param>
        /// <returns>The resultant dataSet aganist the select query or the stored procedure</returns>
        public void readData(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {
            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }
            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            try
            {
                sqlCmd.Connection = getConnection();
                SqlCeDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {

                }
                reader.Close();
            }
            catch (SqlCeException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }
        }

        /// <summary>
        /// Transaction 
        /// </summary>
        /// <param name="sqlSt">The SQL Query or the name of the Stored Procedure</param>
        /// <param name="isProcedure">If the first parameter "sql" is any name of the stored procedure then it must be true</param>
        /// <param name="parameters">The parameters</param>
        /// <returns>true = commit, false = rollback</returns>
        public bool execTrans(string sqlSt, bool isProcedure, SqlCeParameter[] parameters = null)
        {

            SqlCeCommand sqlCmd = new SqlCeCommand(sqlSt);

            if (isProcedure)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            // Adding parameters using SqlParameters...
            if (parameters != null)
            {
                foreach (SqlCeParameter parameter in parameters)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }

            SqlCeConnection transConn = new SqlCeConnection();
            transConn = getConnection();

            SqlCeTransaction trans = transConn.BeginTransaction();
            try
            {
                sqlCmd.Transaction = trans;
                trans.Commit();
                return true;
            }
            catch (SqlCeException e)
            {
                trans.Rollback();
                return false;
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message, e.InnerException);
            }
            finally
            {
                closeConnection();
            }

        }
     
    }
}
