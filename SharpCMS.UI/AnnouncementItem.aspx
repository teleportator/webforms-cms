<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
         CodeBehind="AnnouncementItem.aspx.cs" Inherits="SharpCMS.UI.AnnouncementItemPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"href="/Admin/EditAnnouncementItem.aspx?Id=<%= this.Id %>">
                    <span>Изменить элемент</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteAnnouncementItem"
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteAnnouncementItem_Click"><span>Удалить элемент</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server" >
    <div class="announcement-properties">
    	<span class="item-details-label">Место проведения:</span>
        <asp:Label runat="server" ID="lblAnnouncementVenue" CssClass="item-details-property" />
        <span class="item-details-label">Время начала:</span>
        <asp:Label runat="server" ID="lblAnnouncementStartingTime" CssClass="item-details-property" />
        <span class="item-details-label">Организатор:</span>
        <asp:Label runat="server" ID="lblAnnouncementOrganizer" CssClass="item-details-property" />
        <span class="item-details-label">Контактная информация:</span>
        <asp:Label runat="server" ID="lblAnnouncementContact" CssClass="item-details-property" />
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="announcement-content">
        <h1><asp:Literal runat="server" ID="lblAnnouncementTitle" /></h1>
        <asp:Label runat="server" ID="lblAnnouncementDate" CssClass="announcement-date" />
        <asp:Literal runat="server" ID="lblAnnouncementText" />
    </div>
</asp:Content>