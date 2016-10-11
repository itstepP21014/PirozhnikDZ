<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhoto.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1"  runat="server" />
            <asp:Button ID="ButtonUpload" OnClick="ButtonUpload_Click" runat="server" Text="Upload" />
        </div>
        <br />
        <asp:Button ID="ButtonSeeResult" OnClick="ButtonSeeResult_Click" runat="server" Text="See uploaded files" />
    </form>
</body>
</html>
