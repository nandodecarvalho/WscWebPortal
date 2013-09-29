<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuList.ascx.cs" Inherits="DisplayingControls_MenuList" %>
<asp:DataList ID="list" runat="server" CssClass="MenuList" Width="180px">
      <HeaderStyle CssClass="MenuListHead" />
      <HeaderTemplate>
        Shop
      </HeaderTemplate>
      <ItemTemplate>
        <asp:HyperLink
            ID="HyperLink1"
            Runat="server"
            NavigateUrl= '<%#HyperlinkCreator.ToShopMenu(Eval("ShopMenuID").ToString())%>'
            Text='<%# HttpUtility.HtmlEncode(Eval("ShopMenuName").ToString()) %>'
            CssClass='<%# Eval("ShopMenuID").ToString() ==
            Request.QueryString["ShopMenuID"] ? "MenuSelected" :
            "MenuUnselected" %>'>
        </asp:HyperLink>
      </ItemTemplate>
    </asp:DataList>
