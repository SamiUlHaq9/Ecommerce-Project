using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class User
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }


        public int Insert()
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@Mode", "Update");
            par[1] = new SqlParameter("@Id", Id);
            par[2] = new SqlParameter("@Username", Username);
            par[3] = new SqlParameter("@Password", Password);
            par[1] = new SqlParameter("@FirstName", FirstName);
            par[2] = new SqlParameter("@LastName", LastName);
            par[3] = new SqlParameter("@Telephone", Telephone);
            DB.ExecuteDataset("Sp_User", par);
            return 1;
        }

        public DataTable ReadAll()
        {
            ds.Clear();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_User", para);
            return ds.Tables[0];
        }

        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ReadById");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_User", param);
            return ds.Tables[0];
        }

        public int Delete()
        {
            SqlParameter[] parame = new SqlParameter[2];
            parame[0] = new SqlParameter("@Mode", "Delete");
            parame[1] = new SqlParameter("@Id", Id);
            DB.ExecuteDataset("Sp_User", parame);
            return 1;
        }
    }
}
