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
    public class UserPaymentController : ControllerBase
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
        [Route("InsertUserPayment")]
        public object InsertUserPayment(int Id, int UserId, string PaymentType, string Provider, int AccountNo, string Expiry)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            up.UserId = UserId;
            up.PaymentType = PaymentType;
            up.Provider = Provider;
            up.AccountNo = AccountNo;
            up.Expiry = Expiry;
            var a = up.Insert();
            return a;
        }

        [HttpPost]
        [Route("ReadAll")]
        public string ReadAll()
        {
            UserPayment up = new UserPayment();
            var b = DataTableToJSON(up.ReadAll());
            return b;
        }

        [HttpPost]
        [Route("ReadById")]
        public string ReadById(int Id)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            var c = DataTableToJSON(up.ReadById());
            return c;
        }

        [HttpPost]
        [Route("Delete")]
        public object Delete(int Id)
        {
            UserPayment up = new UserPayment();
            up.Id = Id;
            var c = up.Delete();
            return c;
        }
    }
}
