<%@ Page Title="Williams Specialty Company" Language="C#" MasterPageFile="~/WscMasterPageDefault.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ Register src="DisplayingControls/ProductListControlControl.ascx" tagname="ProductListControlControl" tagprefix="uc1" %>


<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  Runat="Server">
    <h1>
    <span class="storeTitle">Welcome to Williams Specialty Company!</span>
  </h1>
  
    
    <uc1:ProductListControlControl ID="ProductListControlControl1" runat="server" />
  
    
</asp:Content>
