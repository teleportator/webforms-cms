<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthManager.ascx.cs"
            Inherits="SharpCMS.UI.Shared.Controls.AuthManager" %>

<asp:LoginView runat="server" ID="LoginView">
    <AnonymousTemplate>
        <a class="register-item" href="/Login.aspx?ReturnUrl=<%= this.Request.RawUrl %>">Войти</a>
        <a class="register-item" href="/Register.aspx">Зарегистрироваться</a>
    </AnonymousTemplate>
    <LoggedInTemplate>
        <asp:LoginName ID="LoginName" runat="server" />
        <asp:LoginStatus ID="LoginStatus" Runat="server" CssClass="register-item" LogoutText="Выйти"/>
    </LoggedInTemplate>
</asp:LoginView>
