using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class UserPayment
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }
        public int AccountNo { get; set; }
        public string Expiry { get; set; }

        public int Insert()
        {
            try
            {
                SqlParameter[] par = new SqlParameter[7];
                par[0] = new SqlParameter("@Mode", "Update");
                par[1] = new SqlParameter("@Id", Id);
                par[2] = new SqlParameter("@UserId", UserId);
                par[3] = new SqlParameter("@PaymentType", PaymentType);
                par[4] = new SqlParameter("@Provider", Provider);
                par[5] = new SqlParameter("@AccountNo", AccountNo);
                par[6] = new SqlParameter("@Expiry", Expiry);
                ds = DB.ExecuteDataset("Sp_UserPayment", par);
                return 1;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_UserPayment", para);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Mode", "ReadById");
            para[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_UserPayment", para);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Mode", "Delete");
            para[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_UserPayment", para);
            return 1;
        }
    }
}
