<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="EditVacancyItem.aspx.cs" Inherits="SharpCMS.UI.Admin.EditVacancyItemPage" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnSaveVacancyItem" CssClass="editor-menu-item-link"
                    onclick="btnSaveVacancyItem_Click" ><span>Сохранить</span></asp:LinkButton>
            </li>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCancel" CssClass="editor-menu-item-link" 
                    onclick="btnCancel_Click" CausesValidation="false" ><span>Отмена</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <table class="item-details">
        <tr>
            <td>
                <span class="item-details-label">Родительский раздел:</span>
        		<asp:TextBox runat="server" ID="txtParentVacancyGroupTitle" CssClass="item-details-property" ReadOnly="true"
                    Width="400px" />
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Заголовок:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemTitle" CssClass="item-details-property" Width="400px"
                     MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemTitleRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemTitle" Display="Dynamic" Text="Введите заголовок" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Основной текст:</span>
                <div class="item-details-property">
                    <fck:FCKeditor runat="server" ID="txtVacancyItemText" Width="670px" Height="400px" />
                </div>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Краткое содержание:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemAbstract" CssClass="item-details-property" TextMode="MultiLine"
                    Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemAbstractRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemAbstract" Display="Dynamic" Text="Введите краткое содержание" />
                <asp:RegularExpressionValidator runat="server" ID="valVacancyItemAbstractLimit" CssClass="input-error"
                    ControlToValidate="txtVacancyItemAbstract" Display="Dynamic" Text="Вы ввели больше 200 символов"
                    ValidationExpression="^[\w\W]{1,200}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Работадатель:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemEmployer" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemEmployerRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemEmployer" Display="Dynamic" Text="Введите работадателя" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Обязанности:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemResponsibilities" CssClass="item-details-property"
                    TextMode="MultiLine" Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 1000 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemResponsibilitiesRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemResponsibilities" Display="Dynamic" Text="Введите обязанности" />
                <asp:RegularExpressionValidator runat="server" ID="valVacancyItemResponsibilitiesLimit" CssClass="input-error"
                    ControlToValidate="txtVacancyItemResponsibilities" Display="Dynamic" Text="Вы ввели больше 1000 символов"
                    ValidationExpression="^[\w\W]{1,1000}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Требования:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemDemands" CssClass="item-details-property" TextMode="MultiLine"
                   Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 1000 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemDemandsRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemDemands" Display="Dynamic" Text="Введите требования" />
                <asp:RegularExpressionValidator runat="server" ID="valVacancyItemDemandsLimit" CssClass="input-error"
                    ControlToValidate="txtVacancyItemDemands" Display="Dynamic" Text="Вы ввели больше 1000 символов"
                    ValidationExpression="^[\w\W]{1,1000}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Условия:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemConditions" CssClass="item-details-property" TextMode="MultiLine"
                   Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 1000 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemConditionsRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemConditions" Display="Dynamic" Text="Введите условия" />
                <asp:RegularExpressionValidator runat="server" ID="valVacancyItemConditionsLimit" CssClass="input-error"
                    ControlToValidate="txtVacancyItemConditions" Display="Dynamic" Text="Вы ввели больше 1000 символов"
                    ValidationExpression="^[\w\W]{1,1000}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Контактная информация:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemContact" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemContactRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemContact" Display="Dynamic" Text="Введите контактную информацию." />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkVacancyItemIsActive" CssClass="item-details-property"
                    Text="Показывать на сайте" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Keywords":</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemKeywords" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Description":</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemDescription" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Порядок сортировки:</span>
        		<asp:TextBox runat="server" ID="txtVacancyItemSortOrder" CssClass="item-details-property" Width="400px" />
                <span class="item-details-sublabel">Целое число в диапазоне от 1 до 1000</span>
                <asp:RequiredFieldValidator runat="server" ID="valVacancyItemSortOrderRequired" CssClass="input-error"
                    ControlToValidate="txtVacancyItemSortOrder" Display="Dynamic" Text="Введите порядок сортировки" />
                <asp:RangeValidator runat="server" ID="valVacancyItemSortOrder"
                    ControlToValidate="txtVacancyItemSortOrder" Type="Integer" MinimumValue="1" MaximumValue="1000"
                    Display="Dynamic" CssClass="input-error" ErrorMessage="Введите целое число от 1 до 1000" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkVacancyItemDisplayOnMainMenu" CssClass="item-details-property"
                    Text="Показывать в главном меню" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkVacancyItemDisplayOnSideMenu" CssClass="item-details-property"
                    Text="Показывать в боковом меню" Enabled="false" />
        	</td>
        </tr>
    </table>
</asp:Content>
