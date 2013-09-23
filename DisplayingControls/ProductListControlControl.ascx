<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductListControlControl.ascx.cs" Inherits="DisplayingControls_ProductListControlControl" %>
<%@ Register src="PaginationControl.ascx" tagname="PaginationControl" tagprefix="uc1" %>

<uc1:PaginationControl ID="topPaginationControl" runat="server" 
    Visible="False" />
<asp:DataList ID="list" runat="server" RepeatColumns="3" CssClass="ProductList">   

     <ItemTemplate>
       <h3 class="ProductTitle">
         <a href="<%# HyperlinkCreator.ToProduct(Eval("ProductID").ToString()) %>">
           <%# HttpUtility.HtmlEncode(Eval("ProductName").ToString()) %>
         </a>
       </h3>
       <a href="<%# HyperlinkCreator.ToProduct(Eval("ProductID").ToString()) %>">
         <img width="100" border="0"
    src="<%# HyperlinkCreator.ToProductImage(Eval("ProductThumb").ToString()) %>"
    alt='<%# HttpUtility.HtmlEncode(Eval("ProductName").ToString())%>' />
        </a>
        <h3 class="ProductDetail">
        <%# HttpUtility.HtmlEncode(Eval("ProductDescription").ToString()) %>
        </h3>
        <p>
        <h3 class="PriceDetail">
          Price:
          <%# Eval("ProductPrice", "{0:c}") %>
        </h3>
        </p>
      </ItemTemplate>
 </asp:DataList>
<uc1:PaginationControl ID="bottomPaginationControl" runat="server" 
    Visible="False" />

