<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideMenu.ascx.cs" Inherits="SharpCMS.UI.Shared.Controls.SideMenuControl" %>

<div class="sidemenu">
    <span class="first-layer">
        <asp:HyperLink runat="server" ID="lnkFirstLayer" CssClass="first-layer-link" />
    </span>
    <asp:Literal runat="server" ID="lblSideMenu" />
</div>