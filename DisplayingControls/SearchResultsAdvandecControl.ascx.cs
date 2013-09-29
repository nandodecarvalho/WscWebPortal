using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayingControls_SearchResultsAdvandecControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
        if (!IsPostBack)
        {
        
        string allQueries = Request.QueryString["AllQueries"];
        string searchQuery = Request.QueryString["Search"];
        if (allQueries != null)
          allQueriesCheckBox.Checked = (allQueries.ToUpper() == "TRUE");
        if (searchQuery != null)
          searchTextContainer.Text = searchQuery;

        }
    }
   protected void searchButton_Click(object sender, EventArgs e)
    {
       
        {
          ExecuteSearch();
        }
   }
    
        private void ExecuteSearch()
        {
          string searchQuery = searchTextContainer.Text;
          bool allQueries = allQueriesCheckBox.Checked;
          if (searchTextContainer.Text.Trim() != "")
            Response.Redirect( HyperlinkCreator.ToSearch(searchQuery, allQueries, "1"));
        }
    
       
}