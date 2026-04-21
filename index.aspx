<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sem4_Project.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body style="background:#f0f0f0; font-family:Arial, sans-serif;">

    <form id="form1" runat="server">
        <div style="width:400px; margin:60px auto; background:white; padding:30px; border:1px solid #ccc; border-radius:6px;">

            <h2 style="text-align:center; margin-bottom:20px;">Login</h2>

            <asp:Label runat="server" Text="Username" Font-Bold="true"></asp:Label>
             
            <br />
            <asp:TextBox ID="txtUsername" runat="server" Width="100%" Height="32px" 
                style="margin-top:5px; padding:5px;"></asp:TextBox>

            <br /><br />

            <asp:Label runat="server" Text="Password" Font-Bold="true"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%" Height="32px"
                style="margin-top:5px; padding:5px;"></asp:TextBox>

            <br /><br />

            <asp:Button ID="btnLogin" runat="server" Text="Login"
                Width="100%" Height="38px"
                BackColor="#2563EB" ForeColor="White"
                Font-Bold="true"
                OnClick="btnLogin_Click" />

            <br /><br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <br /><br />

            <div style="text-align:center;">
                Don't have an account? 
                <asp:HyperLink 
                    runat="server" 
                    NavigateUrl="~/Register.aspx" 
                    style="color:#2563EB; font-weight:bold;">
                    Register here
                </asp:HyperLink>
            </div>

        </div>
    </form>

</body>
</html>
