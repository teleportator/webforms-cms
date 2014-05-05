<%@ Page Title="Я волонтер Ставрополя / Вход" Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="Login.aspx.cs" Inherits="SharpCMS.UI.Login" %>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="form-content">
    	<h1>Вход</h1>
    	<p>Пожалуйста, заполните следующие поля для входа.</p>
    	<table class="item-details">
    	    <tr>
    	        <td>
    	            <span class="item-details-label">E-mail:</span>
    	    		<asp:TextBox runat="server" ID="txtUserEmail" CssClass="item-details-property" Width="400px" />
                    <asp:RegularExpressionValidator runat="server" ID="valUserEmail" Display="Dynamic" ControlToValidate="txtUserEmail"
                        ErrorMessage="Не верный формат e-mail." SetFocusOnError="true"
                        ValidationExpression="^[\w\.=-]+@[\w\.-]+\.[\w-]{2,9}$" />
    	        </td>
    	    </tr>
    	    <tr>
    	        <td>
    	            <span class="item-details-label">Пароль:</span>
    	    		<asp:TextBox runat="server" ID="txtUserPassword" CssClass="item-details-property" Width="400px"
    	                TextMode="Password" />
    	        </td>
    	    </tr>
    	    <tr>
    	        <td>
    	            <asp:Button runat="server" ID="btnSubmit" Text="Войти" 
    	                onclick="btnSubmit_Click" />
    	        </td>
    	    </tr>
    	</table>
    	<p>Если вы по каким-то причинам не зарегистрированы, то можете <a href="/Register.aspx">сделать это прямо сейчас</a>.</p>
    </div>
</asp:Content>
