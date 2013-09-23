using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_ProductListControlControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    private void PopulateControls()
    {
        // Retrieve shopMenuID, MediaID and Page from the query string
        string shopmenuId = Request.QueryString["ShopMenuID"];
        
        string mediaId = Request.QueryString["MediaID"];
        
        string page = Request.QueryString["Page"];

        if (page == null) page = "1";
        // How many pages of products?
        int howManyPages = 1;
        // pager links format
        string firstPageUrl = "";
        string pagerFormat = "";

        // If browsing media
        if (mediaId != null)
        {
            // Retrieve list of products in media
            list.DataSource =
            StoreAccessClass.GetProductsInMedia(mediaId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = HyperlinkCreator.ToMedia(shopmenuId, mediaId, "1");
            pagerFormat = HyperlinkCreator.ToMedia(shopmenuId, mediaId, "{0}");
        }
        else if (shopmenuId != null)
        {
            // Retrieve list of best selling products to display when a menu is selected
            list.DataSource = StoreAccessClass.GetProductsOnBestSellMedia
            (shopmenuId, page, out howManyPages);
            list.DataBind();
            // get first page url and pager format
            firstPageUrl = HyperlinkCreator.ToShopMenu(shopmenuId, "1");
            pagerFormat = HyperlinkCreator.ToShopMenu(shopmenuId, "{0}");
        }
        else
        {
            // Retrieve list of best selling products to display in the storefront
            list.DataSource =
            StoreAccessClass.GetProductsOnBestSellShop(page, out howManyPages);
            list.DataBind();
            // have the current page as integer
            int currentPage = Int32.Parse(page);

        }

        // Display pager controls
        topPaginationControl.Display(int.Parse(page), howManyPages, firstPageUrl, pagerFormat,

     false);
        bottomPaginationControl.Display(int.Parse(page), howManyPages, firstPageUrl,pagerFormat,
    true);
    }
}