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
            var dtoj = DataTableToJSON(ra.ReadAll());
            return dtoj;
        }


        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            Discount rbi = new Discount();
            rbi.Id = Id;
            var b = DataTableToJSON(rbi.ReadById());
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
