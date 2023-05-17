using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class CustomSetup
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }

        public int InsertCustomSetup()
        {
            try
            {
                SqlParameter[] arryparam = new SqlParameter[5];
                arryparam[0] = new SqlParameter("@Mode", "Update");
                arryparam[1] = new SqlParameter("@Id", Id);
                arryparam[2] = new SqlParameter("@Type", Type);
                arryparam[3] = new SqlParameter("@Description", Description);
                arryparam[4] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("SP_CustomSetup", arryparam);
                return 1;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadAll");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("SP_CustomSetup", parm);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "ReadById");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("SP_CustomSetup", Param);
            return ds.Tables[0];
        }

        public DataTable GetdataforDw()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "GetdataforDw");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("SP_CustomSetup", Param);
            return ds.Tables[0];
        }


        public int Delete()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Mode", "Delete");
                param[1] = new SqlParameter("@Id", Id);
                DB.ExecuteNonQuery("SP_CustomSetup", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
