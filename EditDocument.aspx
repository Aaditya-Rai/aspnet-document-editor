<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditDocument.aspx.cs" Inherits="sem4_Project.EditDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Edit Document</h2>

<br />

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <asp:TextBox 
            ID="txtTitle" 
            runat="server" 
            Width="100%" 
            Font-Size="22px"
            BorderStyle="None">
        </asp:TextBox>

        <hr />

        <asp:TextBox 
            ID="txtContent" 
            runat="server"
            TextMode="MultiLine"
            Rows="22"
            Width="100%"
            style="border:none; font-size:16px;">
        </asp:TextBox>

        <br /><br />

        <asp:Button 
            ID="btnUpdate" 
            runat="server" 
            Text="Update Document"
            Width="170px"
            Height="35px"
            BackColor="#2563EB"
            ForeColor="White"
            OnClick="btnUpdate_Click" />

        <br /><br />

        <asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label ID="lblAuto" runat="server" ForeColor="Blue"></asp:Label>

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>

</asp:Content>