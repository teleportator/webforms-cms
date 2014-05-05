<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs"
    Inherits="SharpCMS.UI.Shared.Controls.MainMenuControl" %>

<asp:Repeater runat="server" ID="rptMainMenu">
    <HeaderTemplate>
        <ul class="menu">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="menu-item">
            <a class="menu-item-link" href="<%# Eval("Url") %>"><%# Eval("Title") %></a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>