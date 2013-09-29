using System.Data;
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
         string shopmenuId = Request.QueryString["ShopMenuID"];
        
        string mediaId = Request.QueryString["MediaID"];
        
        string page = Request.QueryString["Page"];

        if (page == null) page = "1";
        string searchQuery = Request.QueryString["Search"];
        int howManyPages = 1;
        string firstPageUrl = "";
        string pagerFormat = "";

        // If performing a product search
        if (searchQuery != null)
        {
            // Retrieve AllWords from query string
            string allQueries = Request.QueryString["AllQueries"];
            // Perform search
            list.DataSource = StoreSearchClass.SearchStore(searchQuery, allQueries, page, out howManyPages);
            list.DataBind();
            // Display pager
            firstPageUrl = HyperlinkCreator.ToSearch(searchQuery, allQueries.ToUpper() == "TRUE", "1");
            pagerFormat = HyperlinkCreator.ToSearch(searchQuery, allQueries.ToUpper() == "TRUE", "{0}");
        }

        else if (mediaId != null)
            {
                list.DataSource =
                StoreAccessClass.GetProductsInMedia(mediaId, page, out howManyPages);
                list.DataBind();
                firstPageUrl = HyperlinkCreator.ToMedia(shopmenuId, mediaId, "1");
                pagerFormat = HyperlinkCreator.ToMedia(shopmenuId, mediaId, "{0}");
            }
            else if (shopmenuId != null)
            {
                 list.DataSource = StoreAccessClass.GetProductsOnBestSellMedia
                (shopmenuId, page, out howManyPages);
                list.DataBind();
                 firstPageUrl = HyperlinkCreator.ToShopMenu(shopmenuId, "1");
                pagerFormat = HyperlinkCreator.ToShopMenu(shopmenuId, "{0}");
            }
            else
            {
                list.DataSource =
                StoreAccessClass.GetProductsOnBestSellShop(page, out howManyPages);
                list.DataBind();
                int currentPage = Int32.Parse(page);

            }

            topPaginationControl.Display(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
            bottomPaginationControl.Display(int.Parse(page), howManyPages, firstPageUrl,pagerFormat, true);
    }

    
}