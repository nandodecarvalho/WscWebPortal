using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResults : System.Web.UI.Page
{
  
  protected void Page_Load(object sender, EventArgs e)
  {
    
    string searchQuery = Request.QueryString["Search"];
    titleLabel.Text = "Search";
    descriptionLabel.Text = "We found these results for \"" + searchQuery + "\"";
    
    this.Title = WscWebPortalStaticData.SiteName +
               " : Product Search : " + searchQuery;
    }
}