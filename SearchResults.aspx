<%@ Page Title="" Language="C#" MasterPageFile="~/WscMasterPageAll.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

<%@ Register src="DisplayingControls/ProductListControlControl.ascx" tagname="ProductListControlControl" tagprefix="uc1" %>

<%@ Register src="DisplayingControls/SearchResultsAdvandecControl.ascx" tagname="SearchResultsAdvandecControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
     <br/>
     <asp:Label CssClass="StoreTitle" ID="titleLabel" runat="server"> </asp:Label>
      <br />
      <asp:Label CssClass="StoreDescription" ID="descriptionLabel" runat="server"></asp:Label>
      <br /> <br />       
     <uc1:ProductListControlControl ID="ProductListControlControl1" runat="server" />
     <uc2:SearchResultsAdvandecControl ID="SearchResultsAdvandecControl1" 
         runat="server" />

</asp:Content>

