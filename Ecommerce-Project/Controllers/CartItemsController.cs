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
    public class CartItemsController : ControllerBase
    {
        [HttpPost]
        [Route("InsertCartItems")]
        public object InsertCartItems(int Id, string Session_Id, string Product_Id, string Quantity)
        {
            CartItems m = new CartItems();
            m.Id = Id;
            m.Session_Id = Session_Id;
            m.Product_Id = Product_Id;
            m.Quantity = Quantity;
            var a = m.Insert();
            return (a);
        }


        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            CartItems cart = new CartItems();
            var a = ExtensionHelper.DataTableToJSON(cart.ReadAll());
            return a;
        }


        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            CartItems ca = new CartItems();
            ca.Id = Id;
            var b = ExtensionHelper.DataTableToJSON(ca.ReadById());
            return b;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            CartItems del = new CartItems();
            del.Id = Id;
            var d = del.Delete();
            return (d);
        }
    }
}
