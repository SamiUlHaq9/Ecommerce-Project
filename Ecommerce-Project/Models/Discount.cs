using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class Discount
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discounts { get; set; }
        public string IsActive { get; set; }

        public int Insert()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[6];
                para[0] = new SqlParameter("@Mode", "Update");
                para[1] = new SqlParameter("@Id", Id);
                para[2] = new SqlParameter("@Name", Name);
                para[3] = new SqlParameter("@Description", Description);
                para[4] = new SqlParameter("@DiscountPer", Discounts);
                para[5] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_Discount", para);
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
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_Discount", param);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] parama = new SqlParameter[2];
            parama[0] = new SqlParameter("@Mode", "ReadById");
            parama[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_Discount", parama);
            return ds.Tables[0];
        }

        public int Delete()
        {
            try
            {
                ds.Clear();
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@Mode", "Delete");
                par[1] = new SqlParameter("@Id", Id);
                DB.ExecuteDataset("Sp_Discount", par);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
