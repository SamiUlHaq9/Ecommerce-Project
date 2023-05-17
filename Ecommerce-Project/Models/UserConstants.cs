using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {

            new UserModel() { UserName = "jason_admin", EmailAddress = "jason.admin@email.com", Password = "MyPass_w0rd", GivenName = "Jason", SurName = "Bryant", Role = "Administrator" },
            new UserModel() { UserName = "elyse_seller", EmailAddress = "elyse.seller@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", SurName = "Lambert", Role = "Seller" },
        };
    }
}
