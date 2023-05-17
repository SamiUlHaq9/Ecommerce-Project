using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class PaymentDetails
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }

        public int Insert()
        {
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter("@Mode", "Update");
            par[1] = new SqlParameter("@Id", Id);
            par[2] = new SqlParameter("@Orderid", OrderId);
            par[3] = new SqlParameter("@Amount", Amount);
            par[4] = new SqlParameter("@Provider", Provider);
            par[5] = new SqlParameter("@Status", Status);
            DB.ExecuteDataset("Sp_PaymentDetails", par);
            return 1;
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_PaymentDetails", para);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReadById");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_PaymentDetails", param);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] parame = new SqlParameter[2];
            parame[0] = new SqlParameter("@Mode", "Delete");
            parame[1] = new SqlParameter("@Id", Id);
            DB.ExecuteDataset("Sp_PaymentDetails", parame);
            return 1;
        }
    }
}
