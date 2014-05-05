<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs"
         Inherits="SharpCMS.UI.ErrorPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server" />

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server" />

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="article-content">
        <h1>Страница не найдена</h1>
        <p>К сожалению, запрошенной вами страницы не существует или она была удалена.</p>
        <p>Если вы видите ошибку 404, проверьте, правильно ли вы ввели адрес (URL) страницы.</p>
    </div>
</asp:Content>
