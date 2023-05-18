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

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        [HttpPost]
        [Route("InsertSubCategory")]
        public async Task<object> InsertSubCategory([FromBody] SubCategory data)
        {
            SubCategory m = new SubCategory();
            m.Id = data.Id;
            m.SubCategoryName = data.SubCategoryName;
            m.Description = data.Description;
            m.Type = data.Type;
            m.IsActive = data.IsActive;
            var a = m.SubCategoryInsert();
            return ("Insert Done");
        }

        [HttpPost]
        [Route("ReadAll")]
        public async Task<Object> ReadAll(SubCategory data)
        {
            SubCategory prov = new SubCategory();
            prov.Id = data.Id;
            var obj = ExtensionHelper.DataTableToJSON(prov.ReadAll());
            return obj;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            SubCategory prov = new SubCategory();
            prov.Id = Id;
            var obj = ExtensionHelper.DataTableToJSON(prov.ReadById());
            return obj;
        }

        [HttpPost]
        [Route("ReadForCategory")]
        public string ReadForCategory(string Id)
        {
            SubCategory prov = new SubCategory();
            prov.Id = Id;
            var obj = ExtensionHelper.DataTableToJSON(prov.ReadForCategory());
            return obj;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            SubCategory modal = new SubCategory();
            modal.Id = Id;
            var a = modal.Delete();
            return ("Successfully Deleted");
        }
    }

}
