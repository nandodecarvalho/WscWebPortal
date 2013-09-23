using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_MenuList : System.Web.UI.UserControl
{
    // Load menu details into the DataList
    protected void Page_Load(object sender, EventArgs e)
    {
        // Returns a DataTable object containing
        // menu data, which is read in the ItemTemplate of the DataList
        list.DataSource = StoreAccessClass.GetShopMenu();
        // Needed to bind the data bound controls to the data source
        list.DataBind();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}