<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchAdvancedDisplayControl.ascx.cs" Inherits="DisplayingControls_SearchAdvancedDisplayControl" %>
<asp:Panel ID="searchDisplay" runat="server" DefaultButton="searchButton">
  <table class="SearchContainer">
    
    <tr>
      <td class="SearchContainerContent">
        <asp:TextBox ID="searchTextContainer" Runat="server" Width="100px"
          MaxLength="100" />
        <asp:Button ID="searchButton" Runat="server"
          Text="Search" Width="60px" onclick="searchButton_Click" /><br />
        
      </td>
    </tr>
  </table>
</asp:Panel>