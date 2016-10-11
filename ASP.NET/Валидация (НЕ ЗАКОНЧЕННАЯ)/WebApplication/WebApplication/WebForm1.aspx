<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="DividerTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="LabelDiv" runat="server" Text="______"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="DenominatorTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="LabelDon" runat="server" Text="_____"></asp:Label>
            </div>
            <div>
                <asp:Button ID="ResultButton" runat="server" Text="Разделить" />
                <asp:Label ID="ResultLable" runat="server" Text="_______"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
