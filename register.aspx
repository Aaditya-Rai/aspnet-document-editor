<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="sem4_Project.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
<div style="width:400px; margin:auto; background:white; padding:25px; border:1px solid #ccc;">

    <h2 style="text-align:center;">Register</h2>

    <br />

    Username:
    <br />
    <asp:TextBox ID="txtUsername" runat="server" Width="100%" Height="30px"></asp:TextBox>

    <br /><br />

    Password:
    <br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%" Height="30px"></asp:TextBox>

    <br /><br />

    Confirm Password:
    <br />
    <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="100%" Height="30px"></asp:TextBox>

    <br /><br />

    <asp:Button 
        ID="btnRegister" 
        runat="server" 
        Text="Register" 
        Width="100%" Height="35px"
        BackColor="#2563EB"
        ForeColor="White"
        OnClick="btnRegister_Click" />

    <br /><br />

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

</div>
        </div>
    </form>
</body>
</html>
