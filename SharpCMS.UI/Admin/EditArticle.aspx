<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="SharpCMS.UI.Admin.EditArticlePage"
         MasterPageFile="~/Shared/Master/admin.Master" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>

<asp:Content runat="server" ContentPlaceHolderID="EditorPlaceHolder" ID="EditorContent">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnSaveArticle" CssClass="editor-menu-item-link" 
                    onclick="btnSaveArticle_Click"><span>Сохранить</span></asp:LinkButton>
            </li>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCancel" CssClass="editor-menu-item-link" 
                    onclick="btnCancel_Click" CausesValidation="false"><span>Отмена</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="RightPlaceHolder" ID="RightContent">
    <table class="item-details">
        <tr>
            <td>
                <span class="item-details-label">Родительский раздел:</span>
        		<asp:TextBox runat="server" ID="txtParentArticleTitle" CssClass="item-details-property" ReadOnly="true"
                    Width="400px" />
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Заголовок:</span>
        		<asp:TextBox runat="server" ID="txtArticleTitle" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valArticleTitleRequired" ControlToValidate="txtArticleTitle"
                    Display="Dynamic" Text="Введите заголовок" CssClass="input-error" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Основной текст:</span>
                <div class="item-details-property">
                    <fck:FCKeditor runat="server" ID="txtArticleText" Width="670px" Height="400px" />
                </div>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Краткое содержание:</span>
        		<asp:TextBox runat="server" ID="txtArticleAbstract" CssClass="item-details-property" TextMode="MultiLine"
                    Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valArticleAbstractRequired" CssClass="input-error"
                    ControlToValidate="txtArticleAbstract" Display="Dynamic" Text="Введите краткое содержание" />
                <asp:RegularExpressionValidator runat="server" ID="valArticleAbstractLimit" CssClass="input-error"
                    ControlToValidate="txtArticleAbstract" Display="Dynamic" Text="Вы ввели больше 200 символов"
                    ValidationExpression="^[\w\W]{1,200}$" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkArticleIsActive" CssClass="item-details-property"
                    Text="Показывать на сайте" Checked="true" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Keywords":</span>
        		<asp:TextBox runat="server" ID="txtArticleKeywords" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Description":</span>
        		<asp:TextBox runat="server" ID="txtArticleDescription" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Порядок сортировки:</span>
        		<asp:TextBox runat="server" ID="txtArticleSortOrder" CssClass="item-details-property" Text="500"
                    Width="400px" />
                <span class="item-details-sublabel">Целое число в диапазоне от 1 до 1000</span>
                <asp:RequiredFieldValidator runat="server" ID="valArticleSortOrderRequired" CssClass="input-error"
                    ControlToValidate="txtArticleSortOrder" Display="Dynamic" Text="Введите порядок сортировки" />
                <asp:RangeValidator runat="server" ID="valArticleSortOrder"
                    ControlToValidate="txtArticleSortOrder" Type="Integer" MinimumValue="1" MaximumValue="1000"
                    Display="Dynamic" CssClass="input-error" ErrorMessage="Введите целое число от 1 до 1000" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkArticleDisplayOnMainMenu" CssClass="item-details-property"
                    Text="Показывать в главном меню" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkArticleDisplayOnSideMenu" CssClass="item-details-property"
                    Text="Показывать в боковом меню" Enabled="false" />
        	</td>
        </tr>
    </table>
</asp:Content>