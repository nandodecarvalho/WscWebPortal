<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResultsAdvandecControl.ascx.cs" Inherits="DisplayingControls_SearchResultsAdvandecControl" %>
<asp:Panel ID="searchDisplayAdvanced" runat="server" DefaultButton="searchButton">
  <table class="SearchContainerResult">
    <tr>
      <td class="SearchContainerHead">Couldn't find what you were looking for? Try Our advanced search.</td>
    </tr>
    <tr>
      <td class="SearchContainerContent">
        <asp:TextBox ID="searchTextContainer" Runat="server" Width="128px"
          MaxLength="100" />
        <asp:Button ID="searchButton" Runat="server"
          Text="Search" Width="60px" onclick="searchButton_Click" /><br />
        <asp:CheckBox ID="allQueriesCheckBox" Runat="server"
          Text="Advanced Search" />
      </td>
    </tr>
  </table>
</asp:Panel>