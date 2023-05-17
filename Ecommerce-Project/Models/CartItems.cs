using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class CartItems
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public int Id { get; set; }
        public string Session_Id { get; set; }
        public string Product_Id { get; set; }
        public string Quantity { get; set; }

        public int Insert()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = new SqlParameter("@Mode", "Update");
                para[1] = new SqlParameter("@Id", Id);
                para[2] = new SqlParameter("@Sessionid", Session_Id);
                para[3] = new SqlParameter("@Productid", Product_Id);
                para[4] = new SqlParameter("@Quantity", Quantity);
                DB.ExecuteDataset("Sp_CartItems", para);
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
            ds = DB.ExecuteDataset("Sp_CartItems", param);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@Mode", "ReadById");
            par[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_CartItems", par);
            return ds.Tables[0];
        }

        public int Delete()
        {
            try
            {
                ds.Clear();
                SqlParameter[] parama = new SqlParameter[2];
                parama[0] = new SqlParameter("@Mode", "Delete");
                parama[1] = new SqlParameter("@Id", Id);
                DB.ExecuteDataset("Sp_CartItems", parama);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
