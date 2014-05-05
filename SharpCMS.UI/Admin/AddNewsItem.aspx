<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="AddNewsItem.aspx.cs" Inherits="SharpCMS.UI.Admin.AddNewsItemPage" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCreateNewsItem" CssClass="editor-menu-item-link"
                    onclick="btnCreateNewsItem_Click"><span>Сохранить</span></asp:LinkButton>
            </li>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCancel" CssClass="editor-menu-item-link"
                    onclick="btnCancel_Click" CausesValidation="false"><span>Отмена</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <table class="item-details">
        <tr>
            <td>
                <span class="item-details-label">Родительский раздел:</span>
        		<asp:TextBox runat="server" ID="txtParentNewsGroupTitle" CssClass="item-details-property" ReadOnly="true"
                    Width="400px" />
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Заголовок:</span>
        		<asp:TextBox runat="server" ID="txtNewsItemTitle" CssClass="item-details-property" Text="Новый элемент"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valNewsItemTitleRequired" CssClass="input-error"
                    ControlToValidate="txtNewsItemTitle" Display="Dynamic" Text="Введите заголовок" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Основной текст:</span>
                <div class="item-details-property">
                    <fck:FCKeditor runat="server" ID="txtNewsItemText" Width="670px" Height="400px" />
                </div>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Краткое содержание:</span>
        		<asp:TextBox runat="server" ID="txtNewsItemAbstract" CssClass="item-details-property" TextMode="MultiLine"
                   Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valNewsItemAbstractRequired" CssClass="input-error"
                    ControlToValidate="txtNewsItemAbstract" Display="Dynamic" Text="Введите краткое содержание" />
                <asp:RegularExpressionValidator runat="server" ID="valNewsItemAbstractLimit" CssClass="input-error"
                    ControlToValidate="txtNewsItemAbstract" Display="Dynamic" Text="Вы ввели больше 200 символов"
                    ValidationExpression="^[\w\W]{1,200}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Дата публикации:</span>
        		<asp:TextBox runat="server" ID="txtNewsItemPublishedDate" CssClass="item-details-property"
                    Width="400px" />
                <span class="item-details-sublabel">Например, 01.01.2011</span>
                <asp:RequiredFieldValidator runat="server" ID="valNewsItemPublishedDateRequired" CssClass="input-error"
                    ControlToValidate="txtNewsItemPublishedDate" Display="Dynamic" Text="Введите дату публикации" />
                <asp:CompareValidator runat="server" ID="valNewsItemPublishedDateType" Type="Date" CssClass="input-error"
                    ControlToValidate="txtNewsItemPublishedDate" Display="Dynamic" Text="Не верный формат даты"
                    Operator="DataTypeCheck" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkNewsItemIsActive" CssClass="item-details-property"
                    Text="Показывать на сайте" Checked="true" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Keywords":</span>
        		<asp:TextBox runat="server" ID="txtNewsItemKeywords" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Description":</span>
        		<asp:TextBox runat="server" ID="txtNewsItemDescription" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Порядок сортировки:</span>
        		<asp:TextBox runat="server" ID="txtNewsItemSortOrder" CssClass="item-details-property" Text="500"
                    Width="400px" />
                <span class="item-details-sublabel">Целое число в диапазоне от 1 до 1000</span>
                <asp:RequiredFieldValidator runat="server" ID="valNewsItemSortOrderRequired" CssClass="input-error"
                    ControlToValidate="txtNewsItemSortOrder" Display="Dynamic" Text="Введите порядок сортировки" />
                <asp:RangeValidator runat="server" ID="valNewsItemSortOrder"
                    ControlToValidate="txtNewsItemSortOrder" Type="Integer" MinimumValue="1" MaximumValue="1000"
                    Display="Dynamic" CssClass="input-error" ErrorMessage="Введите целое число от 1 до 1000" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkNewsItemDisplayOnMainMenu" CssClass="item-details-property"
                    Text="Показывать в главном меню" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkNewsItemDisplayOnSideMenu" CssClass="item-details-property"
                    Text="Показывать в боковом меню" Checked="false" Enabled="false" />
        	</td>
        </tr>
    </table>
</asp:Content>
