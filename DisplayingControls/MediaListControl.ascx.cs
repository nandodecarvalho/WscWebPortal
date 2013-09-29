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
       string shopmenuId = Request.QueryString["ShopMenuID"];
       if (shopmenuId != null)
        {
            list.DataSource = StoreAccessClass.GetMediaInShopMenu(shopmenuId);
            list.DataBind();
        }
    }
}