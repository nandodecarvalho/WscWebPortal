using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_MenuList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       list.DataSource = StoreAccessClass.GetShopMenu();
       list.DataBind();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}