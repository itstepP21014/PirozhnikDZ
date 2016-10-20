<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChatApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Введите свой ник:"></asp:Label><br />
        <input type="text" id="message" />
        <input type="button" id="sendname" value="Готово" onclick="sendname_click" />
    </div>
    </form>
</body>
</html>
