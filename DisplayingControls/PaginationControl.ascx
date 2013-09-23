<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginationControl.ascx.cs" Inherits="DisplayingControls_PaginationControl" %>

<p>
Page
<asp:Label ID="currentPageLabel" runat="server" />
of
<asp:Label ID="howManyPagesLabel" runat="server" />
|

<asp:HyperLink ID="previousLink" Runat="server">Previous</asp:HyperLink>

<asp:Repeater ID="pagesRepeater" runat="server">
  <ItemTemplate>
    <asp:HyperLink ID="hyperlink" runat="server" Text='<%# Eval("Page") %>'

NavigateUrl='<%# Eval("Url") %>' />
  </ItemTemplate>
</asp:Repeater>

<asp:HyperLink ID="nextLink" Runat="server">Next</asp:HyperLink>
</p>
