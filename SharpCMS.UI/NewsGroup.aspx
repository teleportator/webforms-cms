<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
         CodeBehind="NewsGroup.aspx.cs" Inherits="SharpCMS.UI.NewsGroupPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=News"><span>Новости</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/AddNewsItem.aspx?ParentId=<%= this.Id %>"><span>Новая новость</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=News"><span>Изменить раздел</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteArticle" 
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteArticle_Click"><span>Удалить раздел</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1>
        	<asp:Literal runat="server" ID="lblArticleTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
    <div class="news">
        <asp:Label runat="server" ID="lblEmptyNews" Text="Нет ни одного нового события." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptNewsList">
            <HeaderTemplate><ul class="news-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="news-list-item">
                    <span class="news-date"><%# Eval("PublishedDate")%></span>
                    <h4 class="news-header"><a href="/NewsItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a></h4>
                    <p><%#Eval("Abstract") %></p>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
