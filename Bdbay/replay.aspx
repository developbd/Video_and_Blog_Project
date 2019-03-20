<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="replay.aspx.cs" Inherits="Bdbay.replay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Replay</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Reply Command</h3>
        <asp:TextBox ID="txtCommand" TextMode="MultiLine" Width="100%" Rows="5" runat="server"></asp:TextBox>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        <asp:Button ID="btnReplay" runat="server" OnClick="btnReplay_Click" Width="100" Height="30" Text="Replay" />
        <asp:Button ID="btnEdit" OnClick="btnEdit_Click" runat="server" Width="100" Height="30" Text="Edit" />
        <asp:Button ID="btnEditx"  OnClick="btnEditx_Click" runat="server" Width="100" Height="30" Text="Edit" />
        <asp:Button ID="btnEditB" OnClick="btnEditB_Click"  runat="server" Width="100" Height="30" Text="Edit" />
    </div>
    </form>
</body>
</html>
