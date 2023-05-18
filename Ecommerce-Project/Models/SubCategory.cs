using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class SubCategory
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();

        public string Id { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string IsActive { get; set; }

        public int SubCategoryInsert()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[6];
                para[0] = new SqlParameter("@Mode", "Update");
                para[1] = new SqlParameter("@Id", Id);
                para[2] = new SqlParameter("@SubCategory", SubCategoryName);
                para[3] = new SqlParameter("@Description", Description);
                para[4] = new SqlParameter("@Type", Type);
                para[5] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_SubCategory", para);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetSubCategory()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReadAll");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_SubCategory", param);
            return ds.Tables[0];
        }
        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadById");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_SubCategory", parm);
            return ds.Tables[0];
        }

        public DataTable ReadForCategory()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadForCategory");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_SubCategory", parm);
            return ds.Tables[0];
        }

        public int Delete()
        {
                SqlParameter[] parame = new SqlParameter[2];
                parame[0] = new SqlParameter("@Mode", "Delete");
                parame[1] = new SqlParameter("@Id", Id);
                DB.ExecuteNonQuery("Sp_SubCategory", parame);
                return 1;
        }
    }
   
}

