<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="SharpCMS.UI.ArticlePage"
         MasterPageFile="~/Shared/Master/page.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="EditorPlaceHolder" ID="EditorContent">
    <asp:Panel runat="server" ID="pnlEditorMenu">
        <div class="editor-menu-underlayer"></div>
        <div class="editor-menu">
    	    <ul>
                <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Article"><span>Статьи</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Announcement"><span>Акции</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Vacancy"><span>Вакансии</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Idea"><span>Идеи</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=News"><span>Новости</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Company"><span>Организации</span></a>
                </li>
                <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=Article"><span>Изменить раздел</span></a>
                </li>
                <li class="editor-menu-item">
                    <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteArticle"
                        OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                        onclick="btnDeleteArticle_Click"><span>Удалить раздел</span></asp:LinkButton>
                </li>
            </ul>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="RightPlaceHolder" ID="RightContent">
    <div class="article-content">
        <h1>
        	<asp:Literal runat="server" ID="lblArticleTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
</asp:Content>