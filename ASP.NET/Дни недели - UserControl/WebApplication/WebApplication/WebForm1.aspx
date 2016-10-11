<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>
<%@ Register Src="~/WebUserControl1.ascx" TagName="control" TagPrefix="Tcontrol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        span[text="<%= DateTime.Now.DayOfWeek %>"]{
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <Tcontrol:control ID="control1" runat="server" />
        </div>
    </form>
</body>
</html>
