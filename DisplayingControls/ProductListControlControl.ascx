<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductListControlControl.ascx.cs" Inherits="DisplayingControls_ProductListControlControl" %>
<%@ Register src="PaginationControl.ascx" tagname="PaginationControl" tagprefix="uc1" %>

<uc1:PaginationControl ID="topPaginationControl" runat="server" 
    Visible="False" />
<asp:DataList ID="list" runat="server" RepeatColumns="3" CssClass="ProductList" 
    BorderColor="#CCCCCC" >   

     <ItemStyle BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="1px" />

     <ItemTemplate>
      
       <a href="<%# HyperlinkCreator.ToProduct(Eval("ProductID").ToString()) %>">
         <img width="243" border="0"
    src="<%# HyperlinkCreator.ToProductImage(Eval("ProductThumb").ToString()) %>"
    alt='<%# HttpUtility.HtmlEncode(Eval("ProductName").ToString())%>' />
        </a>
        <h3 class="ProductTitle">
         <a href="<%# HyperlinkCreator.ToProduct(Eval("ProductID").ToString()) %>">
           <%# HttpUtility.HtmlEncode(Eval("ProductName").ToString()) %>
         </a>
       </h3>
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
     <SeparatorStyle BorderWidth="0px" />
 </asp:DataList>
<uc1:PaginationControl ID="bottomPaginationControl" runat="server" 
    Visible="False" />

