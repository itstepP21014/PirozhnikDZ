<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm.aspx.cs" Inherits="WebApplication4.MyWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<input runat="server" id="test" type="submit" value="GO!"/>
        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>--%>
        <div style="display: inline-block; margin-right: 20px">
            <asp:Label ID="LabelProducts" runat="server" Text="Label">Список продуктов:</asp:Label><br />   
            <asp:ListBox ID="ListBoxProducts" runat="server"  style="width: 200px"></asp:ListBox><br />
            <asp:Button ID="ButtonToBusket" runat="server" Text="Отправить в корзину"  OnClick="ButtonToBusket_Click"/>
        </div>
        <div style="display: inline-block">
            <asp:Label ID="LabelBusket" runat="server" Text="Label">Корзина:</asp:Label><br />
            <asp:ListBox ID="ListBoxBusket" runat="server" style="width: 200px"></asp:ListBox><br />
            <asp:Button ID="ButtonFromBusket" runat="server" Text="Убрать из корзины" OnClick="ButtonFromBusket_Click"/>
        </div>
     </div>
    </form>
</body>
</html>
