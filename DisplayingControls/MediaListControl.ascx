<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MediaListControl.ascx.cs" Inherits="DisplayingControls_MediaListControl" %>
<asp:DataList ID="list" runat="server" CssClass="MediaList" Width="180px">
    <HeaderStyle CssClass="MediaListHead" />
    <HeaderTemplate>
        Media
    </HeaderTemplate>
    <ItemTemplate>
        
  <asp:HyperLink ID="HyperLink1" Runat="server"
    NavigateUrl='<%# HyperlinkCreator.ToMedia(Request.QueryString["ShopMenuID"],
    Eval("MediaID").ToString()) %>'
    Text='<%# HttpUtility.HtmlEncode(Eval("MediaName").ToString()) %>'
    CssClass='<%# Eval("MediaID").ToString() ==Request.QueryString["MediaID"] ?"MediaSelected" : "MediaUnselected" %>'>>
  </asp:HyperLink>

    </ItemTemplate>
</asp:DataList>

