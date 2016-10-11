<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPhotos.aspx.cs" Inherits="WebApplication3.ViewPhotos" %>

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
                    <div>
                        <asp:Image ID="ImageResult" runat="server" ImageUrl='<%# Eval("Url") %>'/>
                    </div>
                </ItemTemplate>
           
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
