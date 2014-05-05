<%@ Page Language="C#" MasterPageFile="~/Shared/Master/admin.Master" AutoEventWireup="true"
         CodeBehind="AddIdeaItemPublic.aspx.cs" Inherits="SharpCMS.UI.AddIdeaItemPublicPage" %>

<asp:Content ID="RightContent" ContentPlaceHolderID="RightPlaceHolder" runat="server">
    <div class="form-content">
    	<h1>Добавление идеи</h1>
        <asp:MultiView runat="server" ID="mvwAddIdeaItem" ActiveViewIndex="0">
            <asp:View runat="server" ID="viewAuthRequired">
                <div class="info-text">
                    <span>Только зарегистрированные пользователи могут предлагать идеи. <a href="/Login.aspx?ReturnUrl=<%= this.Request.RawUrl %>">Войдите</a>, пожалуйста.</span>
                </div>
            </asp:View>
            <asp:View runat="server" ID="viewSuccess">
                <span>Идея добавлена. После прохождения модерации она будет доступна на сайте. Вернуться к <asp:HyperLink runat="server" ID="lnkParentSiteNode">списку идей</asp:HyperLink>.</span>
            </asp:View>
            <asp:View runat="server" ID="viewIdeaItemForm">
                <p><strong>Внимательно</strong> всё проверьте перед публикацией. После публикации вы не сможете отредактировать идею.</p>
    	        <p>Грамотная речь и четко выраженные мысли повысят ваши шансы пройти модерацию.</p>
    	        <table class="item-details">
    	            <tr>
    	    	        <td>
    	                    <span class="item-details-label">Категория:</span>
                            <asp:DropDownList runat="server" ID="ddlIdeaItemCategory" CssClass="item-details-property"
                                Width="400px" />
    	    	        </td>
    	            </tr>
    	            <tr>
    	    	        <td>
    	    		        <span class="item-details-label">Заголовок:</span>
    	    		        <asp:TextBox runat="server" ID="txtIdeaItemTitle" CssClass="item-details-property" Width="400px"
                                MaxLength="200" />
                            <span class="item-details-sublabel">Заголовок должен быть наполнен смыслом, чтобы можно было понять, о чем будет идея. Максимум 200 символов.</span>
    	                    <asp:RequiredFieldValidator runat="server" ID="valIdeaItemTitleRequired" CssClass="input-error"
                                ControlToValidate="txtIdeaItemTitle" Display="Dynamic" Text="Введите заголовок" />
    	    	        </td>
    	            </tr>
    	            <tr>
    	    	        <td>
    	    		        <span class="item-details-label">Краткое содержание:</span>
    	    		        <asp:TextBox runat="server" ID="txtIdeaItemAbstract" CssClass="item-details-property" TextMode="MultiLine"
    	                       Width="400px" Rows="7" />
                            <span class="item-details-sublabel">Постарайтесь коротко изложить основной смысл идеи. Максимум 200 символов.</span>
    	                    <asp:RequiredFieldValidator runat="server" ID="valIdeaItemAbstractRequired" CssClass="input-error"
                                ControlToValidate="txtIdeaItemAbstract" Display="Dynamic" Text="Введите краткое содержание." />
                            <asp:RegularExpressionValidator ID="valIdeaItemAbstractLimit" runat="server" CssClass="input-error"
                                ControlToValidate="txtIdeaItemAbstract" ValidationExpression="^[\w\W]{1,200}$" Display="Dynamic"
                                ErrorMessage="Максимум 200 символов." />
    	    	        </td>
    	            </tr>
    	            <tr>
    	    	        <td>
    	    		        <span class="item-details-label">Основной текст:</span>
    	                    <asp:TextBox runat="server" ID="txtIdeaItemText" CssClass="item-details-property" TextMode="MultiLine"
    	                       Width="400px" Rows="7" />
                            <span class="item-details-sublabel">Постарайтесь коротко изложить основной смысл идеи. Максимум 4000 символов.</span>
    	                    <asp:RequiredFieldValidator runat="server" ID="valIdeaItemTextRequired" CssClass="input-error"
                                ControlToValidate="txtIdeaItemText" Display="Dynamic" Text="Введите основной текст." />
                            <asp:RegularExpressionValidator ID="valIdeaItemTextLimit" runat="server" Display="Dynamic"
                                ControlToValidate="txtIdeaItemText" ValidationExpression="^[\w\W]{1,4000}$"
                                ErrorMessage="Максимум 4000 символов." />
    	    	        </td>
    	            </tr>
    	            <tr>
    	    	        <td>
    	    		        <asp:Button runat="server" ID="btnCreateIdeaItem" Text="Добавить идею"
                                OnClick="btnCreateIdeaItem_Click" />
    	    	        </td>
    	            </tr>
    	        </table>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
