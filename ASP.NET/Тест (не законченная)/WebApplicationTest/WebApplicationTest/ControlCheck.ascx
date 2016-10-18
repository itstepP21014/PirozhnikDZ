<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlCheck.ascx.cs" Inherits="WebApplicationTest.ControlCheck" %>

<div>
    <asp:Label ID="Label1" runat="server" Text="<%# Eval("QuestionText") %>"></asp:Label>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
</div>