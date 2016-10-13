<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Product:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox><br />
                    <asp:Button ID="ButtonOk" runat="server" Text="Ok" OnClick="ButtonOk_Click" />
                    <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" />
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate><table border="1"></HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Description") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate></table></FooterTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <br /><br />
                    <div style="font-size: x-small">
                        Соединение с сервером ...
                        <img src="ajax-loader.gif" alt="Загрузка" style="vertical-align:middle" />
                        <input id="Button1" onclick="AbortPostBack()" 
                            type="button" value="Отменить задачу" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
    </form>
</body>
</html>
