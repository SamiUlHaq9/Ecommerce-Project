using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;


namespace Ecommerce_Project.Models
{
    /// <summary>
    /// Summary description for DBBridge.
    /// </summary>
    [Serializable]
    public class DBBridge
    {
        // private SQLHelper SqlHelper = new SQLHelper();
        public DBBridge()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// [METHOD] connect to the db
        /// </summary>
        /// <returns>TRUE, if it is saved</returns>
        public static string DBConnection()
        {
            try
            {

                return "Data Source=.;Initial Catalog=IMSDB; Integrated Security=True";
                //return  System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                //return "Data Source=.;Initial Catalog=SMART_ERP; User id =noor; Password=perfect;Persist Security Info=true";  //System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
   // return "Data Source=192.168.1.50;Initial Catalog=SMART_ERP; User id =noor; Password=perfect;Persist Security Info=true";  //System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
    //  return "Data Source=202.141.254.194;Initial Catalog=SMART_ERP; User id =noor; Password=perfect;Persist Security Info=true";  //System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            }
             catch (Exception ce)
            {
  
                throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }
        //for crystal report
        //public ConnectionInfo RptDBConnection()
        //{
        //    try
        //    {
        //        ConnectionInfo myConnectionInfo = new ConnectionInfo();
        //        myConnectionInfo.ServerName = "ZAHIDA-PC";
        //        myConnectionInfo.DatabaseName = "HIMS";
        //        myConnectionInfo.UserID = "sa";
        //        myConnectionInfo.Password = "123456";
        //        return myConnectionInfo;
        //    }
        //    catch (Exception ce)
        //    {
        //        throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
        //    }
        //}
        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public int ExecuteNonQuerywithTrans(string storedProcedure, SqlParameter[] param)
        {
            SqlConnection conTrans = new SqlConnection(DBConnection());
            SqlTransaction sqlTrans;
            conTrans.Open();
            int returnResult = 0;
            using (sqlTrans = conTrans.BeginTransaction())
            {
                try
                {
                    returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                    sqlTrans.Commit();
                    return returnResult;
                }
                catch (Exception sq)
                {
                    sqlTrans.Rollback();
                    throw sq;
                }
                finally
                {
                    conTrans.Close();
                }
            }
        }
        public int ExecuteNonQuery(string storedProcedure)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public int ExecuteNonQuerySQL(string sqlquery)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(DBConnection(), CommandType.Text, sqlquery);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public int ExecuteNonQuerywithTrans(string storedProcedure)
        {
            SqlConnection conTrans = new SqlConnection(DBConnection());
            SqlTransaction sqlTrans;
            conTrans.Open();
            int returnResult = 0;
            using (sqlTrans = conTrans.BeginTransaction())
            {
                try
                {
                    returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure);
                    sqlTrans.Commit();
                    return returnResult;
                }
                catch (Exception sq)
                {
                    sqlTrans.Rollback();
                    throw sq;
                }
                finally
                {
                    conTrans.Close();
                }
            }
        }
        public int ExecuteNonQuerywithTransfromFrontEnd(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            try
            {
                int returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                return returnResult;
            }
            catch (SqlException sq)
            {
                sqlTrans.Rollback();
                throw sq;
            }
        }
        public DataSet ExecuteDataset(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public DataSet ExecuteDatasetSQL(string storedProcedure)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.Text, storedProcedure);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public DataSet ExecuteDataset(string storedProcedure, SqlParameter param)
        {
            try
            {
                return SqlHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public object ExecuteScalar(string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteScalar(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public object ExecuteScalar(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            try
            {
                return SqlHelper.ExecuteScalar(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public SqlDataReader ExecuteReader(string storedProcedure, SqlParameter[] param)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure, param);
                return reader;
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public SqlDataReader ExecuteReader(string storedProcedure)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure);
                return reader;
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public SqlDataReader ExecuteReaderSQL(string sqlquery)
        {
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(DBConnection(), CommandType.Text, sqlquery);
                return reader;
            }
            catch (SqlException sq)
            {
                throw sq;
            }
        }
        public int ExecuteNonQuerywithMultipleTrans(SqlTransaction sqlTrans, string storedProcedure)
        {
            int returnResult = 0;
            try
            {
                returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure);
                return returnResult;
            }
            catch (Exception sq)
            {
                throw sq;
            }
        }
        public int ExecuteNonQuerywithMultipleTrans(SqlTransaction sqlTrans, string storedProcedure, SqlParameter[] param)
        {
            int returnResult = 0;
            try
            {
                returnResult = SqlHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param);
                return returnResult;
            }
            catch (Exception sq)
            {
                throw sq;
            }
        }
    }
}
