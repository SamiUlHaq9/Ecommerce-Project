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
    public class ItemSetupController : ControllerBase
    {
        [HttpPost]
        [Route("InsertItemSetup")]
        public async Task<object> InsertItemSetup(ItemSetup data)
        {
            ItemSetup cs = new ItemSetup();
            cs.Id = data.Id;
            cs.Title = data.Title;
            cs.Description = data.Description;
            cs.Brand = data.Brand;
            cs.ProductType = data.ProductType;
            cs.Status = data.Status;
            cs.Quantity = data.Quantity;
            cs.Weight = data.Weight;
            cs.MaxOrderQuantity = data.MaxOrderQuantity;
            cs.Price = data.Price;
            cs.CompareAtPrice = data.CompareAtPrice;
            cs.Category = data.Category;
            cs.SubCategory = data.SubCategory;
            cs.SKU = data.SKU;
            cs.Barcode = data.Barcode;
            cs.IsActive = data.IsActive;
            var result = cs.InsertItemSetup();
            
            if (result == 1)
            {
                return 1;
            }
            else if (result == 2)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        [HttpGet]
        [Route("ReadAll")]
        public async Task<object> ReadAll()
        {
            ItemSetup cs = new ItemSetup();
            var ra = ExtensionHelper.DataTableToJSON(cs.ReadAll());
            return ra;
        }
        [HttpGet]
        [Route("GetSubCategory")]
        public string GetSubCategory(string Id)
         {
            ItemSetup cs = new ItemSetup();
            cs.Id = Id;
            var a = ExtensionHelper.DataTableToJSON(cs.GetSubCategory());
            return a;
        }
        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            ItemSetup cs = new ItemSetup();
            cs.Id = Id;
            var a = ExtensionHelper.DataTableToJSON(cs.ReadById());
            return a;
        }
        [HttpPost]
        [Route("ReadItem")]
        public string ReadItem(ItemSetup data)
        {
            ItemSetup cs = new ItemSetup();
            cs.Id = data.Id;
            var a = ExtensionHelper.DataTableToJSON(cs.ReadItem());
            return a;
        }
        [HttpPost]
        [Route("GetdataforDw")]
        public string GetdataforDw(string Id)
        {
            ItemSetup cs = new ItemSetup();
            cs.Id = Id;
            var a = ExtensionHelper.DataTableToJSON(cs.GetdataforDw());
            return a;
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            ItemSetup modal = new ItemSetup();
            modal.Id = Id;
            var a = modal.Delete();
            return ("Successfully Deleted");
        }
    }
}
