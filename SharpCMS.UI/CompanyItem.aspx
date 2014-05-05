<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
         CodeBehind="CompanyItem.aspx.cs" Inherits="SharpCMS.UI.CompanyItem" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/EditCompanyItem.aspx?Id=<%= this.Id %>"><span>Изменить элемент</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteNewsItem"
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteCompanyItem_Click" ><span>Удалить элемент</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <div class="organization-properties">
    	<asp:Image runat="server" ID="imgCompanyLogo" CssClass="organization-logo" />
        <span class="item-details-label">Адрес:</span>
        <span class="item-details-property">
            <asp:Literal runat="server" ID="lblCompanyAddress"/>
        </span>
        <span class="item-details-label">Телефон:</span>
        <span class="item-details-property">
        	<asp:Literal runat="server" ID="lblCompanyPhoneNumber" />
        </span>
        <span class="item-details-label">E-mail:</span>
        <span class="item-details-property">
        	<asp:HyperLink runat="server" ID="lnkCompanyEmail" />
        </span>
        <span class="item-details-label">Веб-сайт:</span>
        <span class="item-details-property">
        	<asp:HyperLink runat="server" ID="lnkCompanyHyperlink" Target="_blank" />
        </span>
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="organization-content">
        <h1>
        	<asp:Literal runat="server" ID="lblCompanyTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblCompanyText" />
    </div>
</asp:Content>
