using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class ItemBrand
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string IsActive { get; set; }

        public int InsertItemBrand()
        {
                SqlParameter[] arryparam = new SqlParameter[4];
                arryparam[0] = new SqlParameter("@Mode", "Update");
                arryparam[1] = new SqlParameter("@Id", Id);
                arryparam[2] = new SqlParameter("@BrandName", BrandName);
                arryparam[3] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_ItemBrand", arryparam);
                return 1;
            }
        public DataTable ReadAll()
        {
            try
            {
                ds.Clear();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter("@Mode", "ReadAll");
                ds = DB.ExecuteDataset("Sp_ItemBrand", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "ReadById");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemBrand", Param);
            return ds.Tables[0];
        }
        public int Delete()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Mode", "Delete");
                param[1] = new SqlParameter("@Id", Id);
                DB.ExecuteNonQuery("Sp_ItemBrand", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
