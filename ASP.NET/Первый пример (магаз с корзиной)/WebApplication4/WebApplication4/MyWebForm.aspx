<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm.aspx.cs" Inherits="WebApplication4.MyWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" dir="auto">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="display: inline-block; margin-right: 20px">
            <asp:Label ID="LabelProducts" runat="server" Text="Label">Список продуктов:</asp:Label><br />   
            <asp:ListBox ID="ListBoxProducts" runat="server"  style="width: 200px" SelectionMode="Multiple" OnSelectedIndexChanged="ListBoxProducts_SelectedIndexChanged"></asp:ListBox><br />
            <asp:Button ID="ButtonToBusket" runat="server" Text="Отправить в корзину"  OnClick="ButtonToBusket_Click"/>
        </div>
        <div style="display: inline-block">
            <asp:Label ID="LabelBusket" runat="server" Text="Label">Корзина:</asp:Label><br />
            <asp:ListBox ID="ListBoxBusket" runat="server" style="width: 200px" SelectionMode="Multiple" OnSelectedIndexChanged="ListBoxBusket_SelectedIndexChanged"></asp:ListBox><br />
            <asp:Button ID="ButtonFromBusket" runat="server" Text="Убрать из корзины" OnClick="ButtonFromBusket_Click"/>
        </div>
     </div>
    </form>
</body>
</html>
