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
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("InsertOrder")]
        public object InsertOrder(Order data)
        {
            Order od = new Order();
            od.Id = data.Id;
            od.CustomrId = data.CustomrId;
            od.OrderNo = data.OrderNo;
            od.Total = data.Total;
            od.Product = data.Product;
            od.PaymentId = data.PaymentId;
            od.IsActive = data.IsActive;
            var a = od.Insert();
            return (a);
        }

        private string GenerateOrderNumber()
        {
            string prefix = "OR#";
            string sequentialNumber = GetNextSequentialNumber().ToString("D6"); // Pad with zeros to 6 digits
            return prefix + sequentialNumber;
        }

        private int GetNextSequentialNumber()
        {
            try
            {

                Order od = new Order();
                var a = od.GetOrderNo();
                return a + 1;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw;
            }
        }

        [HttpGet]
        [Route("ReadAll")]
        public string ReadAll()
        {
            Order ra = new Order();
            var a = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            Order rbi = new Order();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(string Id)
        {
            Order d = new Order();
            d.Id = Id;
            var c = d.Delete();
            return (c);
        }
    }
}
