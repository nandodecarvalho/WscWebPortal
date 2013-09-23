using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];
    // Retrieves product details
    ProductInfo pi = StoreAccessClass.GetProductInfo(productId);

    // if there is a product
    if (pi.ProductName != null)
    {
      PopulateControls(pi);
    }
  }

  // Fill the control with data
  private void PopulateControls(ProductInfo pi)
  {
    // Display product details
    titleLabel.Text = pi.ProductName;
    descriptionLabel.Text = pi.ProductDescription;
    priceLabel.Text = String.Format("{0:c}", pi.ProductPrice);
    productImage.ImageUrl = "Product_Images/" + pi.ProductImage;
    // Set the title of the page
    this.Title = WscWebPortalConfiguration.SiteName + pi.ProductName;
  }

    
}