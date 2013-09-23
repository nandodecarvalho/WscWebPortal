using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    // Fill the page with data
    private void PopulateControls()
    {
        // Retrieve ShopMenuID from the query 
        string shopmenuId = Request.QueryString["MediaID"];
        // Retrieve MediaID from the query string
        string mediaId = Request.QueryString["MediaID"];
        // If browsing media...
        if (mediaId != null)
        {
            // Retrieve media and shopmenu details and display them
            MediaInfo cd = StoreAccessClass.GetMediaInfo(mediaId);
            storeTitleLabel.Text = HttpUtility.HtmlEncode(cd.MediaName) + ":: ";
            ShopMenuInfo dd = StoreAccessClass.GetShopMenuInfo(shopmenuId);
            storeDescriptionLabel.Text = HttpUtility.HtmlEncode(cd.MediaDescription);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(WscWebPortalConfiguration.SiteName +
                         ": " + dd.ShopMenuName + ": " + cd.MediaName);
        }
        // If browsing a menu...
        else if (shopmenuId != null)
        {
            // Retrieve menu details and display them
            ShopMenuInfo dd = StoreAccessClass.GetShopMenuInfo(shopmenuId);
            storeTitleLabel.Text = HttpUtility.HtmlEncode(dd.ShopMenuName) + ":: ";
            storeDescriptionLabel.Text = HttpUtility.HtmlEncode(dd.ShopMenuDescription);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(WscWebPortalConfiguration.SiteName +
      ": " + dd.ShopMenuName);
        }
    }
}