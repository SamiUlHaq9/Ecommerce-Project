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
    public class CustomSetupController : ControllerBase
    {
        [HttpPost]
        [Route("InsertCustomSetup")]
        public async Task<object> InsertCustomSetup(CustomSetup data)
        {
            CustomSetup cs = new CustomSetup();
            cs.Id = data.Id;
            cs.Type = data.Type;
            cs.Description = data.Description;
            cs.IsActive = data.IsActive;
            var a = cs.InsertCustomSetup();
            return "Insert Done";
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<object> GetCategory(string Id)
        {
            CustomSetup cs = new CustomSetup();
            cs.Id = Id;
            var ra = ExtensionHelper.DataTableToJSON(cs.ReadAll());
            return ra;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            CustomSetup cs = new CustomSetup();
            cs.Id = Id;
            var a = ExtensionHelper.DataTableToJSON(cs.ReadById());
            return a;
        }

        [HttpPost]
        [Route("GetdataforDw")]
        public string GetdataforDw(string Id)
        {
            CustomSetup cs = new CustomSetup();
            cs.Id = Id;
            var a = ExtensionHelper.DataTableToJSON(cs.GetdataforDw());
            return a;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            CustomSetup modal = new CustomSetup();
            modal.Id = Id;
            var a = modal.Delete();
            return ("Successfully Deleted");
        }
    }
}
