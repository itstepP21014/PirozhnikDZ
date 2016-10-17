<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormForTest.aspx.cs" Inherits="WebApplicationTest.WebFormForTest" %>
<%@ Register Src="~/TestControl.ascx" TagName="testcontrol" TagPrefix="Ttestcontrol" %>

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
                <Ttestcontrol:testcontrol ID="control1" runat="server" />
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
