<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShareDocument.aspx.cs" Inherits="sem4_Project.ShareDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Share Document</h2>

<br />

User:
<br />
<asp:DropDownList ID="ddlUsers" runat="server" Width="200px"></asp:DropDownList>

<br /><br />

Permission:
<br />
<asp:DropDownList ID="ddlPermission" runat="server">
    <asp:ListItem>View</asp:ListItem>
    <asp:ListItem>Edit</asp:ListItem>
</asp:DropDownList>

<br /><br />

<asp:Button ID="btnShare" runat="server" Text="Share" OnClick="btnShare_Click" />

<br /><br />

<asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
