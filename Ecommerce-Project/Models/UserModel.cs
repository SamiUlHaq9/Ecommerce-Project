using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class UserModel
    {
        DataSet ds = new DataSet();
        DBBridge db = new DBBridge();
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }


        public DataTable UsersAuthenticate()
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@Mode", "Authenticate");
                parm[1] = new SqlParameter("@Id", Id);
                parm[2] = new SqlParameter("@EmailAddress", EmailAddress);
                parm[3] = new SqlParameter("@Password", Password);
                ds = db.ExecuteDataset("SP_UserLogin", parm);
                return ds.Tables[0];
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public int InsertUser()
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@Mode", "Update");
            parm[1] = new SqlParameter("@Id", Id);
            parm[2] = new SqlParameter("@UserName", UserName);
            parm[3] = new SqlParameter("@Password", Password);
            parm[4] = new SqlParameter("@EmailAddress", EmailAddress);
            parm[5] = new SqlParameter("@Role", Role);
            parm[6] = new SqlParameter("@SurName", SurName);
            parm[7] = new SqlParameter("@GivenName", GivenName);
            db.ExecuteDataset("SP_UserLogin", parm);
            return 1;
        }
    }
}
