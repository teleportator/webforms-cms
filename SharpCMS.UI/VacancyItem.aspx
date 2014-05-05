<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true" CodeBehind="VacancyItem.aspx.cs"
         Inherits="SharpCMS.UI.VacancyItem" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/EditVacancyItem.aspx?Id=<%= this.Id %>"><span>Изменить элемент</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteVacancyItem"
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteVacancyItem_Click"><span>Удалить элемент</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <div class="vacancy-properties">
    	<span class="item-details-label">Организация:</span>
        <asp:Label runat="server" ID="lblVacancyEmployer" CssClass="item-details-property" />
        <span class="item-details-label">Контактная информация:</span>
        <asp:Label runat="server" ID="lblVacancyContact" CssClass="item-details-property" />
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="vacancy-content">
        <h1><asp:Literal runat="server" ID="lblVacancyTitle" /></h1>
        <asp:Literal runat="server" ID="lblVacancyText" />
        <h2>Обязанности</h2>
        <asp:Repeater runat="server" ID="rptResponsibilities">
            <HeaderTemplate><ul class="list-field"></HeaderTemplate>
            <ItemTemplate><li><p><%# Eval("Value") %></p></li></ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <h2>Требования</h2>
        <asp:Repeater runat="server" ID="rptDemands">
            <HeaderTemplate><ul class="list-field"></HeaderTemplate>
            <ItemTemplate><li><p><%# Eval("Value") %></p></li></ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <h2>Условия</h2>
        <asp:Repeater runat="server" ID="rptConditions">
            <HeaderTemplate><ul class="list-field"></HeaderTemplate>
            <ItemTemplate><li><p><%# Eval("Value") %></p></li></ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
