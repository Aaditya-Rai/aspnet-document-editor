<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DocumentList.aspx.cs" Inherits="sem4_Project.DocumentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Documents</h2>

<br />

<asp:GridView 
    ID="GridView1" 
    runat="server" 
    AutoGenerateColumns="False" 
    Width="100%" 
    OnRowCommand="GridView1_RowCommand">

    <Columns>

        <asp:BoundField DataField="DocumentID" HeaderText="ID" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />

         
        <asp:ButtonField Text="Open" CommandName="OpenDoc" />

        
        <asp:ButtonField Text="Delete" CommandName="DeleteDoc" />

        
        <asp:ButtonField Text="Share" CommandName="ShareDoc" />

    </Columns>

</asp:GridView>

</asp:Content>
