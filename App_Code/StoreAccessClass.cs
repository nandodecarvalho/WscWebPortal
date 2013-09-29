using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Class used to acces the database.
/// Set up the stored procedure parameters, execute the command, and return the results.
/// Business tier per se. 
/// </summary>
public static class StoreAccessClass
{
    static StoreAccessClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Load webportal menu
    public static DataTable GetShopMenu()
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "GetShopMenu";
        return DataAccessClass.ExecuteSelectCommand(comm);
    }

    public static ShopMenuInfo GetShopMenuInfo(string ShopMenutId)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetShopMenuDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = ShopMenutId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // wrap retrieved data into a ShopMenuInfo object
        ShopMenuInfo info = new ShopMenuInfo();
        if (table.Rows.Count > 0)
        {
            info.ShopMenuName = table.Rows[0]["ShopMenuName"].ToString();
            info.ShopMenuDescription = table.Rows[0]["ShopMenuDescription"].ToString();
        }
        return info;
    }

    // Load Media Info
    public static MediaInfo GetMediaInfo(string mediaId)
    {
      
      DbCommand comm = DataAccessClass.CreateCommand();
      comm.CommandText = "StoreGetMediaDetails";
      DbParameter param = comm.CreateParameter();
      param.ParameterName = "@MediaID";
      param.Value = mediaId;
      param.DbType = DbType.Int32;
      comm.Parameters.Add(param);

      
      DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
      MediaInfo info = new MediaInfo();
      if (table.Rows.Count > 0)
      {
        info.ShopMenuId = Int32.Parse(table.Rows[0]["ShopMenuID"].ToString());
        info.MediaName = table.Rows[0]["MediaName"].ToString();
        info.MediaDescription = table.Rows[0]["MediaDescription"].ToString();
      }
     return info;
     }

    // Load product info
    public static ProductInfo GetProductInfo(string productId)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetProductDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
       ProductInfo info = new ProductInfo();
        if (table.Rows.Count > 0)
        {
           DataRow dr = table.Rows[0];
           info.ProductID = int.Parse(productId);
            info.ProductName = dr["ProductName"].ToString();
            info.ProductDescription = dr["ProductDescription"].ToString();
            info.ProductPrice = Decimal.Parse(dr["ProductPrice"].ToString());
            info.ProductThumb = dr["ProductThumb"].ToString();
            info.ProductImage = dr["ProductImage"].ToString();
            info.BestSellShop = bool.Parse(dr["BestSellShop"].ToString());
            info.BestSellCategory = bool.Parse(dr["BestSellCategory"].ToString());
        }
       return info;
     }


    // Once a menu is pressed, load media belonging to that menu
    public static DataTable GetMediaInShopMenu(string shopmenuId)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetMediaInShopMenu";
       DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = shopmenuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
       return DataAccessClass.ExecuteSelectCommand(comm);
    }

    
    // Load products in  selected media
    public static DataTable GetProductsInMedia
    (string mediaId, string pageNumber, out int howManyPages)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetProductsInMedia";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@MediaID";
        param.Value = mediaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalStaticData.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalStaticData.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
       param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;

        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
      int howManyProducts = Int32.Parse
      (comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)WscWebPortalStaticData.ProductsPerPage);
      return table;
    }

    // Display products marked as bestseller on the store front.
    public static DataTable GetProductsOnBestSellShop(string pageNumber, out int howManyPages)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetProductsOnBestSellShop";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalStaticData.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
      param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalStaticData.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        int howManyProducts = Int32.Parse(comm.Parameters
       ["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)WscWebPortalStaticData.ProductsPerPage);
      return table;
    }

    //  Display products marked as bestseller on a subpage.
    public static DataTable GetProductsOnBestSellMedia
    (string shopmenuId, string pageNumber, out int howManyPages)
    {
        DbCommand comm = DataAccessClass.CreateCommand();
        comm.CommandText = "StoreGetProductsOnBestSellMedia";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = shopmenuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalStaticData.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
       param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalStaticData.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)WscWebPortalStaticData.ProductsPerPage);
       return table;
    }


    // Retrieve product size
    public static DataTable GetProductAttribute(string productId)
    {
         DbCommand comm = DataAccessClass.CreateCommand();

        comm.CommandText = "StoreGetProductAttributeData";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        return DataAccessClass.ExecuteSelectCommand(comm);
    }

    

}
