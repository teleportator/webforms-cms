<%@ Page Title="Я волонтер Ставрополя / Заявка на получение личной книжки волонтера" Language="C#"
         MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true" CodeBehind="GetVolunteerBook.aspx.cs"
         Inherits="SharpCMS.UI.GetVolunteerBookPage" %>

<asp:Content ID="EditorContent" ContentPlaceHolderID="EditorPlaceHolder" runat="server" />

<asp:Content ID="LeftContent" ContentPlaceHolderID="LeftPlaceHolder" runat="server" />

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="form-content">
        <h1>Заявка на получение личной книжки волонтёра</h1>
        <asp:MultiView runat="server" ID="mvwVolunteerBookRequest" ActiveViewIndex="0">
            <asp:View runat="server" ID="viewRequestForm">
                <p>Все поля обязательны для заполнения.</p>
                <table class="item-details">
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Фамилия:</span>
    	    	            <asp:TextBox runat="server" ID="txtLastName" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valLastNameRequired" runat="server" ControlToValidate="txtLastName"
                                ErrorMessage="Укажите свою фамилию" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Имя:</span>
    	    	            <asp:TextBox runat="server" ID="txtFirstName" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valFirstNameRequired" runat="server"
                                ControlToValidate="txtFirstName" ErrorMessage="Укажите своё имя" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Отчество:</span>
    	    	            <asp:TextBox runat="server" ID="txtPatronymic" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valPatronymicRequired" runat="server"
                                ControlToValidate="txtPatronymic" ErrorMessage="Укажите своё отчество" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Дата рождения:</span>
    	    	            <asp:TextBox runat="server" ID="txtDateOfBirth" CssClass="item-details-property" Width="400px" />
                            <span class="item-details-sublabel">Например, 01.01.2011</span>
                            <asp:RequiredFieldValidator ID="valDateOfBirthRequired" runat="server"
                                ControlToValidate="txtDateOfBirth" ErrorMessage="Укажите дату своего рождения"
                                Display="Dynamic" />
                            <asp:CompareValidator runat="server" ID="valDateOfBirthType" Type="Date" Display="Dynamic"
                                ErrorMessage="Не верный формат даты" ControlToValidate="txtDateOfBirth" Operator="DataTypeCheck" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Учебное заведение:</span>
    	    	            <asp:TextBox runat="server" ID="txtSchool" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valSchoolRequired" runat="server" ControlToValidate="txtSchool"
                                ErrorMessage="Укажите свое учебное заведение" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Специальность:</span>
    	    	            <asp:TextBox runat="server" ID="txtProfession" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valProfessionRequired" runat="server" ControlToValidate="txtProfession"
                                ErrorMessage="Укажите свою специальность" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Контактный телефон:</span>
    	    	            <asp:TextBox runat="server" ID="txtPhone" CssClass="item-details-property" Width="400px" />
                            <asp:RequiredFieldValidator ID="valPhoneRequired" runat="server" ControlToValidate="txtPhone"
                                ErrorMessage="Укажите свой контактный телефон" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
    	                <td>
    	                    <span class="item-details-label">Чем хочу помогать:</span>
    	    	            <asp:TextBox runat="server" ID="txtHelp" CssClass="item-details-property" Width="400px"
                                TextMode="MultiLine" Rows="7" />
                            <asp:RequiredFieldValidator ID="valHelpRequired" runat="server" ControlToValidate="txtHelp"
                                ErrorMessage="Укажите то, чем хотите помогать" Display="Dynamic" />
    	                </td>
    	            </tr>
                    <tr>
            	        <td>
            		        <asp:Button runat="server" ID="btnSendRequest" Text="Отправить заявку"
                                OnClick="btnSendRequest_Click" />
            	        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View runat="server" ID="viewSuccess">
                <p>Ваша заявка отправлена. Специалисты ЦВПВМ свяжутся с Вами в ближайшее время.</p>
                <p>Вернуться на главную страницу сайта "<a href='/'>Я волонтер Ставрополя</a>"</p>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
