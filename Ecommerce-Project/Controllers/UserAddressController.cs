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
    public class UserAddressController : ControllerBase
    {
        [HttpPost]
        [Route("InsertUserAddress")]
        public object InsertUserAddress(int Id, int UserId, string Addressline1, string Addressline2, string City, string PostalCode,
           string Country, string Telephone, string Mobile)
        {
            UserAddress ua = new UserAddress();
            ua.Id = Id;
            ua.UserId = UserId;
            ua.Addressline1 = Addressline1;
            ua.Addressline2 = Addressline2;
            ua.City = City;
            ua.PostalCode = PostalCode;
            ua.Country = Country;
            ua.Telephone = Telephone;
            ua.Mobile = Mobile;
            var a = ua.Insert();
            return (a);
        }

        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            UserAddress ra = new UserAddress();
            var a = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            UserAddress rbi = new UserAddress();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            UserAddress d = new UserAddress();
            d.Id = Id;
            var c = d.Delete();
            return (c);
        }
    }
}
