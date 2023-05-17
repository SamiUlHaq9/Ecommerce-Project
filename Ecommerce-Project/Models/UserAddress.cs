using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class UserAddress
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public int Insert()
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@Mode", "Update");
            par[1] = new SqlParameter("@Id", Id);
            par[2] = new SqlParameter("@UserId", UserId);
            par[3] = new SqlParameter("@Addressline1", Addressline1);
            par[1] = new SqlParameter("@Addressline2", Addressline2);
            par[2] = new SqlParameter("@City", City);
            par[3] = new SqlParameter("@PostalCode", PostalCode);
            par[1] = new SqlParameter("@Country", Country);
            par[2] = new SqlParameter("@Telephone", Telephone);
            par[3] = new SqlParameter("@Mobile", Mobile);
            DB.ExecuteDataset("SP_UserAddress", par);
            return 1;
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("SP_UserAddress", para);
            return ds.Tables[0];
        }


        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReadById");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("SP_UserAddress", param);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] parame = new SqlParameter[2];
            parame[0] = new SqlParameter("@Mode", "Delete");
            parame[1] = new SqlParameter("@Id", Id);
            DB.ExecuteDataset("SP_UserAddress", parame);
            return 1;
        }
    }
}
