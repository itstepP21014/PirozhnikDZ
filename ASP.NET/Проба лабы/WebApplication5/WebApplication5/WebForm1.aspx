<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>
<%@ Register Src="~/MyControl.ascx" TagName="mycontrol" TagPrefix="Tmycontrol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <table>
                        <tr>
                            <td bgcolor="#CCFFCC">
                            <asp:Label runat="server" ID="Label1" text='<%# Eval("CategoryName") %>' />
                            </td>
                            <td bgcolor="#CCFFCC">
                                <asp:Label runat="server" ID="Label2" text='<%# Eval("Description") %>' />
                            </td>
                            <td>
                                <Tmycontrol:mycontrol ID="control1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>

          </asp:Repeater>

        </div>
    </form>
</body>
</html>
