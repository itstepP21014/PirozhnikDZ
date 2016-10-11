<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication.WebUserControl1" %>

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div>
            <span runat="server" ID="Span1" text='<%# Eval("Name") %>' ><%# Eval("Name") %></span>
        </div>
    </ItemTemplate>
</asp:Repeater>