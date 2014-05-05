<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
         CodeBehind="AnnouncementGroup.aspx.cs" Inherits="SharpCMS.UI.AnnouncementGroupPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Announcement">
                    <span>Акции</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/AddAnnouncementItem.aspx?ParentId=<%= this.Id %>">
                    <span>Новая акция</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=Announcement">
                    <span>Изменить раздел</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteAnnouncementGroup" 
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteAnnouncementGroup_Click"><span>Удалить раздел</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server" />

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1>
        	<asp:Literal runat="server" ID="lblArticleTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
    <div class="announcements">
        <asp:Label runat="server" ID="lblEmptyAnnouncements" Text="Нет ни одной новой акции." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptAnnouncements">
            <HeaderTemplate><ul class="announcement-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="announcement-list-item">
                    <span class="announcement-date">
                        <%#Eval("StartingDate") %>
                        <%# ((string)Eval("ExpiryDate") == (string)Eval("StartingDate")) ? "" : " - " + Eval("ExpiryDate")%>
                    </span>
                    <h4 class="announcement-header">
                        <a href="/AnnouncementItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a>
                        <asp:Label runat="server" ID="lblAnnouncementActivity" CssClass="item-activity" Text="откл."
                            Visible='<%# !((SharpCMS.Service.Views.AnnouncementView)Container.DataItem).IsActive %>' />
                    </h4>
                    <p><%#Eval("Abstract") %></p>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
