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
            var a = DataTableToJSON(ra.ReadAll());
            return a;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            Order rbi = new Order();
            rbi.Id = Id;
            var b = DataTableToJSON(rbi.ReadById());
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
