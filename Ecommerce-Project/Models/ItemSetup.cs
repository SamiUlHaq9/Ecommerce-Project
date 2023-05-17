using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Models
{
    public class ItemSetup
    {
        DBBridge DB = new DBBridge();
        DataSet ds = new DataSet();
        public string Id { get; set; }
        public string ImageFilePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public string Status { get; set; }
        public string Brand { get; set; }
        public string Quantity { get; set; }
        public string Weight { get; set; }
        public string MaxOrderQuantity { get; set; }
        public string Price { get; set; }
        public string CompareAtPrice { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string IsActive { get; set; }

        public int InsertItemSetup()
        {
            try
            {
                SqlParameter[] arryparam = new SqlParameter[17];
                arryparam[0] = new SqlParameter("@Mode", "Update");
                arryparam[1] = new SqlParameter("@Id", Id);
                arryparam[2] = new SqlParameter("@Title", Title);
                arryparam[3] = new SqlParameter("@Description", Description);
                arryparam[4] = new SqlParameter("@BrandName", Brand);
                arryparam[5] = new SqlParameter("@ProductType", ProductType);
                arryparam[6] = new SqlParameter("@Status", Status);
                arryparam[7] = new SqlParameter("@Quantity", Quantity);
                arryparam[8] = new SqlParameter("@Weight", Weight);
                arryparam[9] = new SqlParameter("@MaxOrderQuantity", MaxOrderQuantity);
                arryparam[10] = new SqlParameter("@Price", Price);
                arryparam[11] = new SqlParameter("@CompareAtPrice", CompareAtPrice);
                arryparam[12] = new SqlParameter("@Category", Category);
                arryparam[13] = new SqlParameter("@SubCategory", SubCategory);
                arryparam[14] = new SqlParameter("@SKU", SKU);
                arryparam[15] = new SqlParameter("@Barcode", Barcode);
                arryparam[16] = new SqlParameter("@IsActive", IsActive);
                DB.ExecuteDataset("Sp_ItemSetup", arryparam);
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        public DataTable ReadAll()
        {
            try
            {
                ds.Clear();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter("@Mode", "ReadAll");
                ds = DB.ExecuteDataset("Sp_ItemSetup", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable GetSubCategory()
        {
            try
            {
                ds.Clear();
                SqlParameter[] Param = new SqlParameter[2];
                Param[0] = new SqlParameter("@Mode", "GetSubCategory");
                Param[1] = new SqlParameter("@Id", Id);
                ds = DB.ExecuteDataset("Sp_ItemSetup", Param);
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public DataTable ReadById()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "ReadById");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSetup", Param);
            return ds.Tables[0];
        }
        public DataTable GetdataforDw()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "GetdataforDw");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSetup", Param);
            return ds.Tables[0];
        }
        public DataTable ReadItem()
        {
            ds.Clear();
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@Mode", "ReadItem");
            Param[1] = new SqlParameter("@Id", Id);
            ds = DB.ExecuteDataset("Sp_ItemSetup", Param);
            return ds.Tables[0];
        }
        public int Delete()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Mode", "Delete");
                param[1] = new SqlParameter("@Id", Id);
                DB.ExecuteNonQuery("Sp_ItemSetup", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
