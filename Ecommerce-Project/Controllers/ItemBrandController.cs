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
    public class ItemBrandController : ControllerBase
    {
        [NonAction]
        public static string DataTableToJSON(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }


        [HttpPost]
        [Route("InsertItemBrand")]
        public async Task<object> InsertItemBrand(ItemBrand data)
        {
            ItemBrand ItmBrnd = new ItemBrand();
            ItmBrnd.Id = data.Id;
            ItmBrnd.BrandName = data.BrandName;
            ItmBrnd.IsActive = data.IsActive;
            var a = ItmBrnd.InsertItemBrand();
            return a;
        }
        [HttpGet]
        [Route("ReadAll")]
        public async Task<object> ReadAll()
        {
            ItemBrand cs = new ItemBrand();
            var ra = DataTableToJSON(cs.ReadAll());
            return ra;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            ItemBrand cs = new ItemBrand();
            cs.Id = Id;
            var a = DataTableToJSON(cs.ReadById());
            return a;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            ItemBrand modal = new ItemBrand();
            modal.Id = Id;
            var a = modal.Delete();
            return ("Successfully Deleted");
        }
    }
}
