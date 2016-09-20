<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Биг движ:)</h1>
    </div>
        <div>
        <label>Ваше имя:</label><input type="text" id="name" runat="server"/></div>

        <div>
        <label>Ваш email:</label><input type="text" id="email" runat="server"/></div>

        <div>
        <label>Ваш телефон:</label><input type="text" id="phone" runat="server"/></div>

        <div>
        <label>Вы придете?</label>
            <select id="willattend" runat="server">
                <option value="">Выберете один из вариантов</option>
                <option value="true">Да</option>
                <option value="false">Нет</option>
            </select>

        </div>
        <div>
            <button type="submit">Отправить приглашение</button>
        </div>


  
    </form>
</body>
</html>
