<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true"
         CodeBehind="CompanyGroup.aspx.cs" Inherits="SharpCMS.UI.CompanyGroup" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Company"><span>Организации</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/AddCompanyItem.aspx?ParentId=<%= this.Id %>"><span>Новая организация</span></a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=Company"><span>Изменить раздел</span></a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteCompanyGroup"
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteCompanyGroup_Click"><span>Удалить раздел</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1><asp:Literal runat="server" ID="lblArticleTitle" /></h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
    <div class="organizations">
        <asp:Label runat="server" ID="lblEmptyCompanies" Text="Нет ни одной организации." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptCompanies">
            <HeaderTemplate><ul class="organization-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="organization-list-item">
                    <img class="organization-logo" src="<%# ((SharpCMS.Service.Views.CompanyView)Container.DataItem).Logo == "" ? _path : Eval("Logo") %>"
                        alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>" />
                    <h4 class="organization-title"><a href="/CompanyItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a></h4>
                    <p><%#Eval("Abstract") %></p>
                    <div style="clear:both;"/>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
