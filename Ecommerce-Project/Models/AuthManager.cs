using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class AuthManager
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();

        public DataTable UserLoginManager()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@Mode", "Authunticate");
            para[1] = new SqlParameter("@UserName", UserName);
            para[2] = new SqlParameter("@Password", Password);
            var ds = DB.ExecuteDataset("Sp_User", para);
            return ds.Tables[0];
        }
    }
}
