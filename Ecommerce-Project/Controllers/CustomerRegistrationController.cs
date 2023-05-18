using Ecommerce_Project.Common;
using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        [HttpPost]
        [Route("InsertUser")]
        public async Task<object> InsertUser(CustomerRegistration data)
        {
            CustomerRegistration p = new CustomerRegistration();
            p.Id = data.Id;
            p.FirstName = data.FirstName;
            p.LastName = data.LastName;
            p.Gender = data.Gender;
            p.DOB = data.DOB;
            p.MobileNo = data.MobileNo;
            p.UserName = data.UserName;
            p.Password = data.Password;
            p.IsActive = data.IsActive;
            var result = p.Insert();
            if (result == 1)
            {
                return 1;
            }
            else if (result == 2) {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        [HttpGet]
        [Route("ReadAll")]
        public string ReadAll()
        {
            CustomerRegistration ra = new CustomerRegistration();
            var a = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            CustomerRegistration rbi = new CustomerRegistration();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(string Id)
        {
            CustomerRegistration d = new CustomerRegistration();
            d.Id = Id;
            var c = d.Delete();
            return (c);
        }
    }
}
