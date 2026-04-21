<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="sem4_Project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Welcome to CloudDocs</h2>

<br />

<asp:Button Text="Create New Document" PostBackUrl="~/NewDocument.aspx" runat="server" />
<br /><br />
<asp:Button Text="View All Documents" PostBackUrl="~/DocumentList.aspx" runat="server" />

</asp:Content>
