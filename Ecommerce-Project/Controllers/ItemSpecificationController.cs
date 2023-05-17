using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemSpecificationController : ControllerBase
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
        [Route("InsertItemSpecification")]
        public async Task<object> InsertItemSpecification(ItemSpecificationSetup data)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = data.Id;
            cs.ItemId = data.ItemId;
            cs.ItemSpecification = data.ItemSpecification;
            cs.IsActive = data.IsActive;
            var a = cs.InsertItemSpecification();
            return a;
        }

        [HttpPost]
        [Route("GetItemSpecification")]
        public async Task<object> GetItemSpecification(string Id)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = Id;
            var ra = DataTableToJSON(cs.GetItemSpecification());
            return ra;
        }
        [HttpPost]
        [Route("ReadById")]
        public string ReadById(string Id)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = Id;
            var a = DataTableToJSON(cs.ReadById());
            return a;
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<object> Delete(string Id)
        {
            ItemSpecificationSetup modal = new ItemSpecificationSetup();
            modal.Id = Id;
            var a = modal.Delete();
            return ("Successfully Deleted");
        }
        [HttpPost]
        [Route("InsertItemField")]
        public async Task<object> InsertItemField(ItemSpecificationSetup data)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = data.Id;
            cs.ItemSpecificationId = data.ItemSpecificationId;
            cs.ItemField = data.ItemField;
            cs.ItemPrice = data.ItemPrice;
            cs.ItemQuantity = data.ItemQuantity;
            cs.IsActive = data.IsActive;
            var a = cs.InsertItemField();
            return a;
        }
        [HttpPost]
        [Route("ReadAllValue")]
        public async Task<object> ReadAllValue()
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            var ra = DataTableToJSON(cs.ReadAllValue());
            return ra;
        }
        [HttpPost]
        [Route("ReadByIdValue")]
        public string ReadByIdValue(string Id)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = Id;
            var a = DataTableToJSON(cs.ReadByIdValue());
            return a;
        }
        [HttpPost]
        [Route("ReadIdField")]
        public string ReadIdField(string Id)
        {
            ItemSpecificationSetup cs = new ItemSpecificationSetup();
            cs.Id = Id;
            var a = DataTableToJSON(cs.ReadIdField());
            return a;
        }
        [HttpPost]
        [Route("DeleteField")]
        public async Task<object> DeleteField(string Id)
        {
            ItemSpecificationSetup modal = new ItemSpecificationSetup();
            modal.Id = Id;
            var a = modal.DeleteField();
            return ("Successfully Deleted");
        }
    }
}
