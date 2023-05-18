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
    public class UserPaymentController : ControllerBase
    {
        [HttpPost]
        [Route("InsertUserPayment")]
        public object InsertUserPayment(int Id, int UserId, string PaymentType, string Provider, int AccountNo, string Expiry)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            up.UserId = UserId;
            up.PaymentType = PaymentType;
            up.Provider = Provider;
            up.AccountNo = AccountNo;
            up.Expiry = Expiry;
            var a = up.Insert();
            return a;
        }

        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            UserPayment up = new UserPayment();
            var b = ExtensionHelper.DataTableToJSON(up.ReadAll());
            return b;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            var c = ExtensionHelper.DataTableToJSON(up.ReadById());
            return c;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            var c = up.Delete();
            return c;
        }
    }
}
