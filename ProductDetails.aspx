<%@ Page Title="" Language="C#" MasterPageFile="~/WscMasterPageAll.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table>   
    <tr>
        <td>
            <p>
            <asp:Image ID="productImage" runat="server" />
            </p>
         </td>
         <td>
             <p>
            <asp:Label CssClass="storeTitle" ID="titleLabel" runat="server"
        Text="Label"></asp:Label>
          </p>
          <p>
            <asp:Label CssClass="ProductDetail" ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
          </p>
           <h3 class="PriceDetail">
            <b>Price:</b>
            <asp:Label  ID="priceLabel" runat="server"
        Text="Label"></asp:Label>
          </h3>
          </td>
    </tr>
  </table>
</asp:Content>



