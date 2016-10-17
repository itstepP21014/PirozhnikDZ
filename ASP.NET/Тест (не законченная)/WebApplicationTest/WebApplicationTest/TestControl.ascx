<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestControl.ascx.cs" Inherits="WebApplicationTest.TestControl" %>

<div>
    <asp:Label ID="Label1" runat="server" Text="<%# Eval("QuestionText") %>"></asp:Label>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>


    <asp:Button ID="ButtonBack" runat="server" Text="Back" OnClick="ButtonBack_Click"/>
    <asp:Button ID="ButtonNext" runat="server" Text="Next" OnClick="ButtonNext_Click" />
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
</div>
