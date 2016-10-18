<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlRadio.ascx.cs" Inherits="WebApplicationTest.ControlRadio" %>

<div>
    <asp:Label ID="Label1" runat="server" Text="<%# Eval("QuestionText") %>"></asp:Label>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList> 
</div>