<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
    CodeBehind="IdeaGroup.aspx.cs" Inherits="SharpCMS.UI.IdeaGroupPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Idea">
                    <span>Идеи</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/AddIdeaItem.aspx?ParentId=<%= this.Id %>">
                    <span>Новая идея</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=Idea">
                    <span>Изменить раздел</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteIdeaGroup" 
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteIdeaGroup_Click"><span>Удалить раздел</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <div class="idea-add"><a href="/AddIdeaItemPublic.aspx?ParentId=<%= this.Id %>" class="idea-add-new">Добавить идею</a></div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1>
        	<asp:Literal runat="server" ID="lblArticleTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
    <div class="ideas">
        <asp:Label runat="server" ID="lblEmptyIdeas" Text="Нет ни одной новой идеи." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptIdeas">
            <HeaderTemplate><ul class="ideas-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="idea-list-item">
                    <h4 class="idea-header">
                        <a href="/IdeaItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a>
                        <asp:Label runat="server" ID="lblIdeaActivity" CssClass="item-activity" Text="откл."
                            Visible='<%# !((SharpCMS.Service.Views.IdeaView)Container.DataItem).IsActive %>' />
                    </h4>
                    <p><%#Eval("Abstract") %></p>
                    <div class="idea-info">
                        <span class="idea-created"><%# Eval("Created") %></span>
                        <span class="idea-author" title="автор идеи"><%# Eval("CreatedBy") %></span>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
