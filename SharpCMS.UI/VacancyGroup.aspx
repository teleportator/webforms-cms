<%@ Page Language="C#" MasterPageFile="~/Shared/Master/page.Master" AutoEventWireup="true" CodeBehind="VacancyGroup.aspx.cs"
         Inherits="SharpCMS.UI.VacancyGroupPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link"
                    href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Vacancy"><span>Вакансии</span>
                </a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/AddVacancyItem.aspx?ParentId=<%= this.Id %>">
                    <span>Новая вакансия</span>
                </a>
            </li>
            <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
            <li class="editor-menu-item">
                <a class="editor-menu-item-link" href="/Admin/EditArticle.aspx?Id=<%= this.Id %>&PageType=Vacancy">
                    <span>Изменить раздел</span>
                </a>
            </li>
            <li class="editor-menu-item">
                <asp:LinkButton runat="server" CssClass="editor-menu-item-link" ID="btnDeleteVacancyGroup" 
                    OnClientClick="if (confirm('Вы действительно хотите безвозвратно удалить этот элемент?') == false) return false;"
                    onclick="btnDeleteVacancyGroup_Click"><span>Удалить раздел</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1>
        	<asp:Literal runat="server" ID="lblArticleTitle" />
        </h1>
        <asp:Literal runat="server" ID="lblArticleText" />
    </div>
    <div class="vacancies">
        <asp:Label runat="server" ID="lblEmptyVacancies" Text="Нет ни одной открытой вакансии." CssClass="empty-list" />
        <asp:Repeater runat="server" ID="rptVacancies">
            <HeaderTemplate><ul class="vacancies-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="vacancy-list-item">
                    <h4 class="vacancy-header">
                        <a href="/VacancyItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a>
                        <asp:Label runat="server" ID="lblItemActivity" CssClass="item-activity" Text="откл."
                            Visible='<%# !((SharpCMS.Service.Views.VacancyView)Container.DataItem).IsActive %>' />
                    </h4>
                    <p><%# Eval("Employer") %>, <span class="vacancy-date"><%# Eval("Created") %></span></p>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
