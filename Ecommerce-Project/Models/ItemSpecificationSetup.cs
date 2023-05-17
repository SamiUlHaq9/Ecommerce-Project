using System.Data.SqlClient;
using System;
using System.Data;

namespace Ecommerce_Project.Models
{
    public class ItemSpecificationSetup
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string ItemSpecification { get; set; }
        public string ItemSpecificationId { get; set; }
        public string ItemField { get; set; }
        public string ItemPrice { get; set; }
        public string ItemQuantity { get; set; }
        public string IsActive { get; set; }
        public int InsertItemSpecification()
        {
                SqlParameter[] arryparam = new SqlParameter[5];
                arryparam[0] = new SqlParameter("@Mode", "Update");
                arryparam[1] = new SqlParameter("@Id", Id);
                arryparam[2] = new SqlParameter("@ItemId", ItemId);
                arryparam[3] = new SqlParameter("@ItemSpecification", ItemSpecification);
                arryparam[4] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_VariationName", arryparam);
                return 1;
        }
        public DataTable GetItemSpecification()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "GetItemSpecification");
            param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSpecification", param);
            return ds.Tables[0];
        }
        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadById");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSpecification", parm);
            return ds.Tables[0];
        }
        public int Delete()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Delete");
            param[1] = new SqlParameter("@Id", Id);
            DB.ExecuteNonQuery("Sp_ItemSpecification", param);
            return 1;
        }
        public int InsertItemField()
        {
            SqlParameter[] arryparam = new SqlParameter[7];
            arryparam[0] = new SqlParameter("@Mode", "Update");
            arryparam[1] = new SqlParameter("@Id", Id);
            arryparam[2] = new SqlParameter("@ItemSpecificationId", ItemSpecificationId);
            arryparam[3] = new SqlParameter("@ItemField", ItemField);
            arryparam[4] = new SqlParameter("@ItemPrice", ItemPrice);
            arryparam[5] = new SqlParameter("@ItemQuantity", ItemQuantity);
            arryparam[6] = new SqlParameter("@IsActive", IsActive);
            DB.ExecuteDataset("Sp_VariationValue", arryparam);
            return 1;
        }
        public DataTable ReadAllValue()
        {
            ds.Clear();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "ReadAll");
            ds = DB.ExecuteDataset("Sp_ItemField", param);
            return ds.Tables[0];
        }
        public DataTable ReadByIdValue()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadByIdValue");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSpecification", parm);
            return ds.Tables[0];
        }
        public DataTable ReadIdField()
        {
            ds.Clear();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Mode", "ReadById");
            parm[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemField", parm);
            return ds.Tables[0];
        }
        public int DeleteField()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Delete");
            param[1] = new SqlParameter("@Id", Id);
            DB.ExecuteNonQuery("Sp_ItemField", param);
            return 1;
        }
    }
}
