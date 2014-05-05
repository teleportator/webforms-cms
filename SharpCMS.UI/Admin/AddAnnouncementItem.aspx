﻿<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="AddAnnouncementItem.aspx.cs" Inherits="SharpCMS.UI.Admin.AddAnnouncementItemPage" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCreateAnnouncementItem" CssClass="editor-menu-item-link"
                    onclick="btnCreateAnnouncementItem_Click"><span>Сохранить</span></asp:LinkButton>
            </li>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnCancel" CssClass="editor-menu-item-link" 
                    onclick="btnCancel_Click" CausesValidation="false"><span>Отмена</span></asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server" />

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <table class="item-details">
        <tr>
            <td>
                <span class="item-details-label">Родительский раздел:</span>
        		<asp:TextBox runat="server" ID="txtParentAnnouncementGroupTitle" CssClass="item-details-property"
                    ReadOnly="true" Width="400px" />
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Заголовок:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemTitle" CssClass="item-details-property" Text="Новый элемент"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemTitleRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemTitle" Display="Dynamic" Text="Введите заголовок" />
                
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Основной текст:</span>
                <div class="item-details-property">
                    <fck:FCKeditor runat="server" ID="txtAnnouncementItemText" Width="670px" Height="400px" />
                </div>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Краткое содержание:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemAbstract" CssClass="item-details-property"
                    TextMode="MultiLine" Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemAbstractRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemAbstract" Display="Dynamic" Text="Введите краткое содержание" />
                <asp:RegularExpressionValidator runat="server" ID="valAnnouncementItemAbstractLimit" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemAbstract" Display="Dynamic" Text="Вы ввели больше 200 символов"
                    ValidationExpression="^[\w\W]{1,200}$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Дата начала:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemStartingDate" CssClass="item-details-property"
                    Width="400px" />
                <span class="item-details-sublabel">Например, 01.01.2011</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemStartingDateRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemStartingDate" Display="Dynamic" Text="Введите дату начала" />
                <asp:CompareValidator runat="server" ID="valAnnouncementItemStartingDateType" Type="Date"
                    ControlToValidate="txtAnnouncementItemStartingDate" Display="Dynamic" Text="Не верный формат даты"
                    Operator="DataTypeCheck" CssClass="input-error" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Дата окончания:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemExpiryDate" CssClass="item-details-property"
                    Width="400px" />
                <span class="item-details-sublabel">Дата окончание не должна быть меньше даты начала. Например, 02.01.2011</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemExpiryDateRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemExpiryDate" Display="Dynamic" Text="Введите дату окончания" />
                <asp:CompareValidator runat="server" ID="valAnnouncementItemExpiryDateComparer" Type="Date"
                    ControlToValidate="txtAnnouncementItemExpiryDate" Display="Dynamic" CssClass="input-error"
                    Text="Не верный формат даты" Operator="GreaterThanEqual"
                    ControlToCompare="txtAnnouncementItemStartingDate" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Место проведения:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemVenue" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemVenueRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemVenue" Display="Dynamic" Text="Введите место проведения" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Время проведения:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemStartingTime" CssClass="item-details-property"
                    Width="400px" />
                <span class="item-details-sublabel">Например, 09:00</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemStartingTimeRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemStartingTime" Display="Dynamic" Text="Введите время проведения" />
                <asp:RegularExpressionValidator runat="server" ID="valAnnouncementItemStartingTimeType" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemStartingTime" Display="Dynamic"
                    Text="Не верный формат времени" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9])$" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Организатор:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemOrganizer" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemOrganizerRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemStartingTime" Display="Dynamic" Text="Введите организатора" />
        	</td>
        </tr>
        <tr>
        	<td>
                <span class="item-details-label">Контакты:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemContact" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemContact" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemStartingTime" Display="Dynamic" Text="Введите контакты" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkAnnouncementItemIsActive" CssClass="item-details-property"
                    Text="Показывать на сайте" Checked="true" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Keywords":</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemKeywords" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Description":</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemDescription" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Порядок сортировки:</span>
        		<asp:TextBox runat="server" ID="txtAnnouncementItemSortOrder" CssClass="item-details-property" Text="500"
                    Width="400px" />
                <span class="item-details-sublabel">Целое число в диапазоне от 1 до 1000</span>
                <asp:RequiredFieldValidator runat="server" ID="valAnnouncementItemSortOrderRequired" CssClass="input-error"
                    ControlToValidate="txtAnnouncementItemSortOrder" Display="Dynamic" Text="Введите порядок сортировки" />
                <asp:RangeValidator runat="server" ID="valAnnouncementItemSortOrder"
                    ControlToValidate="txtAnnouncementItemSortOrder" Type="Integer" MinimumValue="1" MaximumValue="1000"
                    Display="Dynamic" CssClass="input-error" ErrorMessage="Введите целое число от 1 до 1000" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkAnnouncementItemDisplayOnMainMenu" CssClass="item-details-property"
                    Text="Показывать в главном меню" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkAnnouncementItemDisplayOnSideMenu" CssClass="item-details-property"
                    Text="Показывать в боковом меню" Checked="false" Enabled="false" />
        	</td>
        </tr>
    </table>
</asp:Content>
