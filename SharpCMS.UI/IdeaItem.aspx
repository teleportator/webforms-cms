<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true" CodeBehind="IdeaItem.aspx.cs"
         Inherits="SharpCMS.UI.IdeaItemPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"href="/Admin/EditIdeaItem.aspx?Id=<%= this.Id %>"><span>Изменить элемент</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteIdeaItem"
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteIdeaItem_Click"><span>Удалить элемент</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="idea-content">
        <h1><asp:Literal runat="server" ID="lblIdeaTitle" /></h1>
        <asp:Literal runat="server" ID="lblIdeaText" />
        <div class="idea-info">
            <asp:Label runat="server" ID="lblIdeaCreated" CssClass="idea-created" />
            <asp:Label runat="server" ID="lblIdeaAuthor" CssClass="idea-author" ToolTip="автор идеи" />
        </div>
    </div>
    <div class="comments">
        <h2>комментарии</h2>
        <asp:Label runat="server" ID="lblEmptyComments" Text="Нет ни одного комментария." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptComments" Visible="true" onitemcommand="rptComments_ItemCommand" >
            <HeaderTemplate><ul class="comments-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="comments-list-item">
                    <div class="comment-info">
                        <span class="comment-author" title="автор комментария"><%# Eval("CreatedBy") %>,</span>
                        <span class="comment-created"><%# Eval("Created") %></span>
                        <asp:LinkButton runat="server" ID="btnDeleteComment" Text="Удалить" Visible="<%# AllowFullAccess %>"
                            OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                            CommandArgument='<%# Eval("Id") %>' />
                    </div>
                    <div class="comment-text"><%# Eval("Text") %></div>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <asp:Panel runat="server" ID="pnlAuthRequired" CssClass="info-text">
            <span>Только зарегистрированные пользователи могут оставлять комментарии. 
                <a href="/Login.aspx?ReturnUrl=<%= this.Request.RawUrl %>">Войдите</a>, пожалуйста.</span>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlCommentForm">
            <asp:TextBox runat="server" ID="txtCommentText" CssClass="item-details-property" TextMode="MultiLine"
                Width="400px" Rows="7" />
            <div class="item-details-property">
                <asp:Button runat="server" ID="btnAddComment" Text="Добавить" onclick="btnAddComment_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
