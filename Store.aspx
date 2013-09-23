<%@ Page Title="" Language="C#" MasterPageFile="~/WscMasterPageAll.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="Store" %>

<%@ Register src="DisplayingControls/ProductListControlControl.ascx" tagname="ProductListControlControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
        <asp:Label ID="storeTitleLabel" CssClass="storeTitle" runat="server" /> 
        <asp:Label ID="storeDescriptionLabel" CssClass="storeDescription"  runat="server" />
     </h1>
    
     <uc1:ProductListControlControl ID="ProductListControlControl1" 
        runat="server" />
   
</asp:Content>

