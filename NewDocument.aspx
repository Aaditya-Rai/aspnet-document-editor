<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewDocument.aspx.cs" Inherits="sem4_Project.NewDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:850px; margin:auto; background:white; padding:30px; border:1px solid #ccc;">

    <h2 style="margin-top:0;">New Document</h2>

    <br />

    <!-- Document Title -->
    <asp:TextBox 
        ID="txtTitle" 
        runat="server" 
        Width="100%" 
        Font-Size="22px"
        BorderStyle="None"
        placeholder="Untitled Document">
    </asp:TextBox>

    <hr />

    <!-- Document Editor -->
    <asp:TextBox 
        ID="txtContent" 
        runat="server"
        TextMode="MultiLine"
        Rows="22"
        Width="100%"
        style="border:none; font-size:16px; line-height:1.6;">
    </asp:TextBox>

    <br /><br />

    <!-- Save Button -->
    <asp:Button 
        ID="btnSave" 
        runat="server" 
        Text="Save Document"
        Width="150px"
        Height="35px"
        BackColor="#2563EB"
        ForeColor="White"
        Font-Bold="true"
        OnClick="btnSave_Click" />

    <br /><br />

    <asp:Label 
        ID="lblMsg" 
        runat="server" 
        ForeColor="Green">
    </asp:Label>

</div>

</asp:Content>
