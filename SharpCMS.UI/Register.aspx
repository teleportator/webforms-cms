<%@ Page Title="Я волонтер Ставрополя / Регистрация" Language="C#" MasterPageFile="~/Shared/Master/admin.Master"
         AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SharpCMS.UI.RegisterPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="form-content">
    	<h1>Регистрация</h1>
        <p>Все поля обязательны для заполнения.</p>
        <asp:Repeater runat="server" ID="rptErrors" EnableViewState="false">
            <HeaderTemplate><ul class="form-error-list"></HeaderTemplate>
            <ItemTemplate>
                <li class="form-error-list-item"><%# Container.DataItem %></li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        <table class="item-details">
            <tr>
    	        <td>
    	            <span class="item-details-label">E-mail, на который будет зарегистрирован аккаунт:</span>
    	    	    <asp:TextBox runat="server" ID="txtUserEmail" CssClass="item-details-property" Width="400px" />
                    <asp:RequiredFieldValidator ID="valEmailRequired" runat="server" ControlToValidate="txtUserEmail"
                        ErrorMessage="Укажите e-mail." Display="Dynamic" />
                    <asp:RegularExpressionValidator runat="server" ID="valUserEmail" Display="Dynamic"
                        ControlToValidate="txtUserEmail" ErrorMessage="Указан не верный e-mail."
                        ValidationExpression="^[\w\.=-]+@[\w\.-]+\.[\w-]{2,9}$" />
    	        </td>
    	    </tr>
            <tr>
    	        <td>
    	            <span class="item-details-label">Ваше имя:</span>
    	    	    <asp:TextBox runat="server" ID="txtUserName" CssClass="item-details-property" Width="400px" />
                    <asp:RequiredFieldValidator ID="valUserNameRequired" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="Укажите ваше имя." Display="Dynamic" />
                    <asp:RegularExpressionValidator runat="server" ID="valUserName" Display="Dynamic"
                        ControlToValidate="txtUserName" ErrorMessage="Имя должно содержать от 5 до 15 символов. Можно использовать латинские буквы, цифры."
                        ValidationExpression="^[a-zA-Z0-9\.-]{5,15}$" />
    	        </td>
    	    </tr>
            <tr>
                <td>
                    <span class="item-details-label">Пароль:</span>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="item-details-property" Width="400px" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="valPasswordRequired" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Укажите пароль." Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="item-details-label">Подтверждение пароля:</span>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="item-details-property"
                        Width="400px" />
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" Display="Dynamic"
                        ControlToValidate="txtConfirmPassword" ErrorMessage="Подтвердите пароль." />
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword" Display="Dynamic"
                        ErrorMessage='Поля "Пароль" и "Подтверждение пароля" должны совпадать.' />
                </td>
            </tr>
            <tr>
            	<td>
            		<asp:Button runat="server" ID="btnCreateUser" Text="Создать пользователя" onclick="btnCreateUser_Click" />
            	</td>
            </tr>
        </table>
    </div>
</asp:Content>
