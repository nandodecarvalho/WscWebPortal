using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Class used to acces the database. Business tier per se. 
/// 
/// </summary>
public static class StoreAccessClass
{
    static StoreAccessClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // This method is used to retrieve the list of Menu
    public static DataTable GetShopMenu()
    {
        // get a configured DbCommand object. it uses the DataAccess class so we don't have to type it all the time.
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure 
        comm.CommandText = "GetShopMenu";
        // execute the stored procedure and return the results
        return DataAccessClass.ExecuteSelectCommand(comm);
    }

    // get the ShopMenu information
    public static ShopMenuInfo GetShopMenuInfo(string ShopMenutId)
    {
        // get a configured DbCommand object. again the Data AccessClass
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetShopMenuDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = ShopMenutId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // wrap retrieved data into a ShopMenuInfo object
        ShopMenuInfo info = new ShopMenuInfo();
        if (table.Rows.Count > 0)
        {
            info.ShopMenuName = table.Rows[0]["ShopMenuName"].ToString();
            info.ShopMenuDescription = table.Rows[0]["ShopMenuDescription"].ToString();
        }
        // return ShopMenuInfo details
        return info;
    }

    // Get Media Info
    public static MediaInfo GetMediaInfo(string mediaId)
    {
      // get a configured DbCommand object
      DbCommand comm = DataAccessClass.CreateCommand();
      // set the stored procedure name
      comm.CommandText = "StoreGetMediaDetails";
      // create a new parameter
      DbParameter param = comm.CreateParameter();
      param.ParameterName = "@MediaID";
      param.Value = mediaId;
      param.DbType = DbType.Int32;
      comm.Parameters.Add(param);

      
      DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
      // wrap retrieved data into MediaInfo object
      MediaInfo info = new MediaInfo();
      if (table.Rows.Count > 0)
      {
        info.ShopMenuId = Int32.Parse(table.Rows[0]["ShopMenuID"].ToString());
        info.MediaName = table.Rows[0]["MediaName"].ToString();
        info.MediaDescription = table.Rows[0]["MediaDescription"].ToString();
      }
      // return Media Information
      return info;
     }

    // Get product info
    public static ProductInfo GetProductInfo(string productId)
    {
        // get a configured DbCommand object
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetProductDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // wrap retrieved data into a ProductInfo object
        ProductInfo info = new ProductInfo();
        if (table.Rows.Count > 0)
        {
            // get the first table row
            DataRow dr = table.Rows[0];
            // get product info
            info.ProductID = int.Parse(productId);
            info.ProductName = dr["ProductName"].ToString();
            info.ProductDescription = dr["ProductDescription"].ToString();
            info.ProductPrice = Decimal.Parse(dr["ProductPrice"].ToString());
            info.ProductThumb = dr["ProductThumb"].ToString();
            info.ProductImage = dr["ProductImage"].ToString();
            info.BestSellShop = bool.Parse(dr["BestSellShop"].ToString());
            info.BestSellCategory = bool.Parse(dr["BestSellCategory"].ToString());
        }
        // return Product info
        return info;
     }


    // retrieve the list of Media in Menu
    public static DataTable GetMediaInShopMenu(string shopmenuId)
    {
        // get a configured DbCommand object
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetMediaInShopMenu";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = shopmenuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        return DataAccessClass.ExecuteSelectCommand(comm);
    }

    //
    //
    // retrieve the list of products in a Media category
    public static DataTable GetProductsInMedia
    (string mediaId, string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetProductsInMedia";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@MediaID";
        param.Value = mediaId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;

        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse
      (comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)WscWebPortalConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    // Retrieve the list of products the ebst sell list so they can be displayed in the store front.
    public static DataTable GetProductsOnBestSellShop(string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetProductsOnBestSellShop";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure and save the results in a DataTable
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters
      ["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)WscWebPortalConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }

    // retrieve the list of best sell products to be displayed in a given menu.
    public static DataTable GetProductsOnBestSellMedia
    (string shopmenuId, string pageNumber, out int howManyPages)
    {
        // get a configured DbCommand object
        DbCommand comm = DataAccessClass.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "StoreGetProductsOnBestSellMedia";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ShopMenuID";
        param.Value = shopmenuId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductDescriptionLength";
        param.Value = WscWebPortalConfiguration.ProductDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = WscWebPortalConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure and save the results in a DataTable
        DataTable table = DataAccessClass.ExecuteSelectCommand(comm);
        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                       (double)WscWebPortalConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }



    /* // Retrieve the list of product characteristic
     public static DataTable GetProductCharacteristic(string productId)
     {
         // get a configured DbCommand object
         DbCommand comm = DataAccessData.CreateCommand();

         // set the stored procedure name
         comm.CommandText = "StoreGetProductCharacteristic";
         // create a new parameter
         DbParameter param = comm.CreateParameter();
         param.ParameterName = "@ProductID";
         param.Value = productId;
         param.DbType = DbType.Int32;
         comm.Parameters.Add(param);
         // execute the stored procedure and return the results
         return DataAccessClass.ExecuteSelectCommand(comm);
     }*/

}
