using System;
using System.Web;

    /// <summary>
    /// This class generates different links to subpages
    /// </summary>

    public class HyperlinkCreator
    {
      // Builds an absolute URL
      private static string BuildAbsolute(string relativeUri)
      {
        // get current uri
        Uri uri = HttpContext.Current.Request.Url;
        // build absolute path
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/")) app += "/";
        relativeUri = relativeUri.TrimStart('/');
        // return the absolute path
        return HttpUtility.UrlPathEncode(
          String.Format("http://{0}:{1}{2}{3}",
          uri.Host, uri.Port, app, relativeUri));
      }

      // Generate a shopMenu URL
      public static string ToShopMenu(string shopMenuId, string page)
      {
        if (page == "1")
          return BuildAbsolute(String.Format("Store.aspx?ShopMenuID=  {0}", shopMenuId));
        else
            return BuildAbsolute(String.Format("Store.aspx?ShopMenuID=  {0}&Page={1}", shopMenuId, page));
        }

        // Generate a shopmenu URL for the default page
        public static string ToShopMenu(string shopmenuId)
        {
          return ToShopMenu(shopmenuId, "1");
        }


        public static string ToMedia(string shopmenuId, string mediaId, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format(
            "Store.aspx?ShopMenuID={0}&MediaID={1}",
            shopmenuId, mediaId));
            else
                return BuildAbsolute(String.Format(
            "Store.aspx?ShopMenuID={0}&MediaID={1}&Page={2}",
            shopmenuId, mediaId, page));
        }

        public static string ToMedia(string shopmenuId, string mediaId)
        {
            return ToMedia(shopmenuId, mediaId, "1");
        }


        public static string ToProduct(string productId)
        {
            return BuildAbsolute(String.Format("ProductDetails.aspx?ProductID={0}", productId));
        }

        public static string ToProductImage(string fileName)
        {
            // build product URL
            return BuildAbsolute("/Product_Images/" + fileName);
        }
      }