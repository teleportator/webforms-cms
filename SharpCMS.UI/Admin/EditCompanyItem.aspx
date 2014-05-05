<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="EditCompanyItem.aspx.cs" Inherits="SharpCMS.UI.Admin.EditCompanyItem" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fck" %>
<%@ Register src="~/Shared/Controls/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="sharp" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server">
    <div class="editor-menu-underlayer"></div>
    <div class="editor-menu">
    	<ul>
            <li class="editor-menu-item">
            	<asp:LinkButton runat="server" ID="btnSaveCompanyItem" CssClass="editor-menu-item-link"
                    onclick="btnSaveCompanyItem_Click" ><span>Сохранить</span></asp:LinkButton>
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
        		<asp:TextBox runat="server" ID="txtParentCompanyGroupTitle" CssClass="item-details-property"
                    ReadOnly="true" Width="400px" />
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Заголовок:</span>
        		<asp:TextBox runat="server" ID="txtСompanyItemTitle" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valСompanyItemTitleRequired" CssClass="input-error"
                    ControlToValidate="txtСompanyItemTitle" Display="Dynamic" Text="Введите заголовок" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Основной текст:</span>
                <div class="item-details-property">
                    <fck:FCKeditor runat="server" ID="txtCompanyItemText" Width="670px" Height="400px" />
                </div>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Краткое содержание:</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemAbstract" CssClass="item-details-property"
                    TextMode="MultiLine" Width="400px" Rows="7" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
                <asp:RequiredFieldValidator runat="server" ID="valCompanytItemAbstractRequired" CssClass="input-error"
                    ControlToValidate="txtCompanyItemAbstract" Display="Dynamic" Text="Введите краткое содержание" />
                <asp:RegularExpressionValidator runat="server" ID="valCompanyItemAbstractLimit" CssClass="input-error"
                    ControlToValidate="txtCompanyItemAbstract" Display="Dynamic" Text="Вы ввели больше 200 символов"
                    ValidationExpression="^[\w\W]{1,200}$" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Адрес:</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemAddress" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">E-mail:</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemEmail" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Например, manager@example.com. Максимум 200 символов</span>
                <asp:RegularExpressionValidator runat="server" ID="valCompanyItemEmailType" CssClass="input-error"
                    ControlToValidate="txtCompanyItemEmail" Display="Dynamic" Text="Не верный формат e-mail"
                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Веб-сайт (например, http://www.example.com):</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemHyperlink" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Например, www.example.com. Максимум 200 символов</span>
                <asp:RegularExpressionValidator runat="server" ID="valCompanyItemHyperlinkType" CssClass="input-error"
                    ControlToValidate="txtCompanyItemHyperlink" Display="Dynamic" Text="Не верный формат URL"
                    ValidationExpression="^[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,4}(/\S*)?$" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Логотип:</span>
        		<sharp:ImageUploader runat="server" ID="iupCompanyLogo" ImageWidth="150"
                    DefaultImagePath="/Shared/Images/no-image.jpg" UploadFolderPath="/Shared/Content/companies" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Номер телефона:</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemPhoneNumber" CssClass="item-details-property" Width="400px"
                    MaxLength="200" />
                <span class="item-details-sublabel">Например, +7 8652 12 34 56</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkCompanyItemIsActive" CssClass="item-details-property"
                    Text="Показывать на сайте" Checked="true" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Keywords":</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemKeywords" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
            </td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Тег "Description":</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemDescription" CssClass="item-details-property"
                    Width="400px" MaxLength="200" />
                <span class="item-details-sublabel">Максимум 200 символов</span>
        	</td>
        </tr>
        <tr>
        	<td>
        		<span class="item-details-label">Порядок сортировки:</span>
        		<asp:TextBox runat="server" ID="txtCompanyItemSortOrder" CssClass="item-details-property"
                    Width="400px" />
                <span class="item-details-sublabel">Целое число в диапазоне от 1 до 1000</span>
                <asp:RequiredFieldValidator runat="server" ID="valCompanyItemSortOrderRequired" CssClass="input-error"
                    ControlToValidate="txtCompanyItemSortOrder" Display="Dynamic" Text="Введите порядок сортировки" />
                <asp:RangeValidator runat="server" ID="valCompanyItemSortOrder"
                    ControlToValidate="txtCompanyItemSortOrder" Type="Integer" MinimumValue="1" MaximumValue="1000"
                    Display="Dynamic" CssClass="input-error" ErrorMessage="Введите целое число от 1 до 1000" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkCompanyItemDisplayOnMainMenu" CssClass="item-details-property"
                    Text="Показывать в главном меню" />
        	</td>
        </tr>
        <tr>
        	<td>
        		<asp:CheckBox runat="server" ID="chkCompanyItemDisplayOnSideMenu" CssClass="item-details-property"
                    Text="Показывать в боковом меню" Enabled="false" />
        	</td>
        </tr>
    </table>
</asp:Content>
