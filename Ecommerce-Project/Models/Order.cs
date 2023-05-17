using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class Order
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string CustomrId { get; set; }
        public string OrderNo { get; set; }
        public string Total { get; set; }
        public string Product { get; set; }
        public string PaymentId { get; set; }
        public string IsActive { get; set; }


        public int Insert()
        {
            try
            {
                SqlParameter[] par = new SqlParameter[8];
                par[0] = new SqlParameter("@Mode", "Update");
                par[1] = new SqlParameter("@OId", Id);
                par[2] = new SqlParameter("@OrderNo", OrderNo);
                par[3] = new SqlParameter("@Customer", CustomrId);
                par[4] = new SqlParameter("@Total", Total);
                par[5] = new SqlParameter("@Paymentid", Product);
                par[6] = new SqlParameter("@Productid", PaymentId);
                par[7] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_Order", par);
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_Order", para);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReadById");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_OrderDetails", param);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] parame = new SqlParameter[2];
            parame[0] = new SqlParameter("@Mode", "Delete");
            parame[1] = new SqlParameter("@Id", Id);
            DB.ExecuteDataset("Sp_OrderDetails", parame);
            return 1;
        }

        public int GetOrderNo()
        {
            SqlParameter[] parame = new SqlParameter[1];
            parame[0] = new SqlParameter("@Mode", "GetOrderNo");
            var dataSet = DB.ExecuteDataset("Sp_Order", parame);
            int orderNo = 0;
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                orderNo = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            }
            return orderNo;
        }
    }
}
