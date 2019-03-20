<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Bdbay.WebForm1" %>

<!DOCTYPE HTML>
<html>
<head>
        <style type="text/css">         
            .mid_div {
                background-color:rgba(0,0,0,0.5);
              display:block;
              height:auto;
              width:100%;
            }

    </style>
</head>
<body>
    <form runat="server" id="fp">

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />

        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="2">A</asp:ListItem>
            <asp:ListItem Value="3">B</asp:ListItem>
            <asp:ListItem Value="4">C</asp:ListItem>
        </asp:DropDownList>

    </form>

</body>
</html>
