using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_SearchAdvancedDisplayControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {
           

            string searchQuery = Request.QueryString["Search"];

            if (searchQuery != null)
                searchTextContainer.Text = searchQuery;
        }

    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        ExecuteSearch();
    }



    private void ExecuteSearch()
    {
        string searchText = searchTextContainer.Text;
        bool allQueries = false;
        if (searchTextContainer.Text.Trim() != "")
            Response.Redirect(HyperlinkCreator.ToSearch(searchText, allQueries, "1"));
    }
}