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
    public class DiscountController : ControllerBase
    {
        [HttpPost]
        [Route("InsertDiscount")]
        public async Task<object> InsertDiscount(Discount data)
        {
            Discount dis = new Discount();
            dis.Id = data.Id;
            dis.Name = data.Name;
            dis.Description = data.Description;
            dis.Discounts = data.Discounts;
            dis.IsActive = data.IsActive;
            var a = dis.Insert();
            return (a);
        }


        [HttpGet]
        [Route("ReadAll")]
        public string ReadAll()
        {
            Discount ra = new Discount();
            var dtoj = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return dtoj;
        }


        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            Discount rbi = new Discount();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            Discount del = new Discount();
            del.Id = Id;
            var c = del.Delete();
            return (c);
        }
    }
}
