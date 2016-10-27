<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="60000"/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:Repeater ID="Repeater1" runat="server" >
                    <HeaderTemplate>
                        <table>
                        <tr>
                            <th>id</th>
                            <th>data</th>
                            <th>rate</th>
                        </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                    <tr>
                        <td>
                        <asp:Label runat="server" ID="Label1" 
                            text='<%# Eval("Cur_ID") %>' />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="Label2" 
                                text='<%# Eval("Date") %>' />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="Label5" 
                                text='<%# Eval("Cur_OfficialRate") %>' />
                        </td>
                    </tr>
                    </ItemTemplate>

                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

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
  
    </div>
    </form>
</body>
</html>

