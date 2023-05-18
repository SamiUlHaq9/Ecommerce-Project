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
    public class ShoppingSessionController : ControllerBase
    {
        [HttpPost]
        [Route("InsertShoppingSession")]
        public object InsertShoppingSession(int Id, int UserId, string Total)
        {
            ShoppingSession ss = new ShoppingSession();
            ss.Id = Id;
            ss.UserId = UserId;
            ss.Total = Total;
            var a = ss.Insert();
            return (a);
        }

        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            ShoppingSession ra = new ShoppingSession();
            var a = ExtensionHelper.DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            ShoppingSession rbi = new ShoppingSession();
            rbi.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(rbi.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            ShoppingSession d = new ShoppingSession();
            d.Id = Id;
            var c = d.Delete();
            return (c);
        }
    }
}
