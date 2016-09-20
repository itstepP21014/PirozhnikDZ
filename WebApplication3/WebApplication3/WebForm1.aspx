<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<%@ Import Namespace="WebApplication3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Приглашения</h2>

        <h3>Люди которые были приглашены: </h3>
        <table>
            <thead>
                <tr>
                    <th>Имя</th>
                    <th>Email</th>
                    <th>Телефон</th>
                </tr>
            </thead>
        </table>

        <% var yesData = GuestRepository.getInstance().GetAllGuest()
               .Where(r => r.WillAttend.Value);
               foreach(var rsvp in yesData)
               {
                   string htmlString = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                   rsvp.Name, rsvp.Email, rsvp.Phone);
                   Response.Write(htmlString);
               }
            %>


    </div>
    </form>
</body>
</html>
