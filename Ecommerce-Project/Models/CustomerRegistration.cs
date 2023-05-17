using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class CustomerRegistration
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string IsActive { get; set; }

        public int Insert()
        {
            try
            {
                SqlParameter[] par = new SqlParameter[11];
                par[0] = new SqlParameter("@Mode", "Update");
                par[1] = new SqlParameter("@Id", Id);
                par[2] = new SqlParameter("@FisrtName", FirstName);
                par[3] = new SqlParameter("@LastName", LastName);
                par[4] = new SqlParameter("@MobileNo", MobileNo);
                par[5] = new SqlParameter("@UserName", UserName);
                par[6] = new SqlParameter("@Password", Password);
                par[7] = new SqlParameter("@Gender", Gender);
                par[8] = new SqlParameter("@DOB", DOB);
                par[9] = new SqlParameter("@IsActive", IsActive);
                ds = DB.ExecuteDataset("Sp_CustomerRegistration", par);
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_CustomerRegistration", para);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Mode", "ReadById");
            para[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_CustomerRegistration", para);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Mode", "Delete");
            para[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_CustomerRegistration", para);
            return 1;
        }
    }
}
