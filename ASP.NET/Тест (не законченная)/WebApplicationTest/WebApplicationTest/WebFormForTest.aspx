<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormForTest.aspx.cs" Inherits="WebApplicationTest.WebFormForTest" %>
<%@ Register Src="~/ControlCheck.ascx" TagName="controlcheck" TagPrefix="Tcontrolcheck" %>
<%@ Register Src="~/ControlRadio.ascx" TagName="controlradio" TagPrefix="Tcontrolradio" %>

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
                <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                <asp:Button ID="ButtonBack" runat="server" Text="Back" OnClick="ButtonBack_Click"/>
                <asp:Button ID="ButtonNext" runat="server" Text="Next" OnClick="ButtonNext_Click" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
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



ladcontrol(question)
{
switch()questiontype
case check : this.loadControl("control1")
case radio : this.loadControl("control2")
}



updatepanel
{
panel (куда будет загружаться control)
{

}
buttons
}