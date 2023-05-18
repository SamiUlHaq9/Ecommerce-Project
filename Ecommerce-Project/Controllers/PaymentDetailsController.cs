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
    public class PaymentDetailsController : ControllerBase
    {
        [HttpPost]
        [Route("InsertPaymentDetails")]
        public object InsertPaymentDetails(int Id, int OrderId, string Amount, string Provider, string Status)
        {
            PaymentDetails pd = new PaymentDetails();
            pd.Id = Id;
            pd.OrderId = OrderId;
            pd.Amount = Amount;
            pd.Provider = Provider;
            pd.Status = Status;
            var a = pd.Insert();
            return (a);
        }

        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            PaymentDetails ra = new PaymentDetails();
            var a = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            PaymentDetails rbi = new PaymentDetails();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            PaymentDetails d = new PaymentDetails();
            d.Id = Id;
            var c = d.Delete();
            return (c);
        }
    }
}
