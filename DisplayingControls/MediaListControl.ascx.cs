using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_MediaListControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Obtain the ID of the selected Menu
        string shopmenuId = Request.QueryString["ShopMenuID"];
        // Continue only if ShopMenuID exists in the query string

        if (shopmenuId != null)
        {
            // Returns a DataTable
            // object containing media data, which is displayed by the DataList
            list.DataSource = StoreAccessClass.GetMediaInShopMenu(shopmenuId);
            // Binds the data bound controls to the data source
            list.DataBind();
        }
    }
}