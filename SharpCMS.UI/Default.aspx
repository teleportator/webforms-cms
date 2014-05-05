<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SharpCMS.UI.HomePage"
         MasterPageFile="~/Shared/Master/core.Master" Title="Я волонтер Ставрополя"%>

<asp:Content runat="server" ContentPlaceHolderID="EditorPlaceHolder" ID="EditorContent">
    <asp:Panel runat="server" ID="pnlEditorMenu">
        <div class="editor-menu-underlayer"></div>
        <div class="editor-menu">
            <ul>
                <li class="editor-menu-delimiter"><span>добавление<br />разделов</span></li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Article"><span>Статьи</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Announcement"><span>Акции</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Vacancy"><span>Вакансии</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Idea"><span>Идеи</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=News"><span>Новости</span></a>
                </li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link"
                        href="/Admin/AddArticle.aspx?ParentId=<%= this.Id %>&PageType=Company"><span>Организации</span></a>
                </li>
                <li class="editor-menu-delimiter"><img src="/Shared/Images/editor-menu-separator.png" /></li>
                <li class="editor-menu-item">
                    <a class="editor-menu-item-link" href="/Admin/EditHomePage.aspx"><span>Изменить раздел</span></a>
                </li>
            </ul>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainPlaceHolder" ID="MainContent" runat="server">
    <div class="main">
        <div class="main-content">
        	<div class="left-home-content">
        		<div class="latest-news">
        			<h2>
        				Новости
        			</h2>
                    <ul>
                        <asp:Repeater runat="server" ID="rptLatestNews">
                            <ItemTemplate>
                                <li class="news-item">
                    	            <span class="news-date"><%# Eval("PublishedDate")%></span>
                    	            <a href="/NewsItem.aspx?Id=<%# Eval("Id") %>"><%#Eval("Title") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
        			<a href="/NewsGroup.aspx?Id=13a2cfb5-dc64-49a5-8ab9-2f494bb0f85b" class="details">
        				все новости
        			</a>
        		</div>
                <div class="info-block">
                    <h2>
                    	<asp:Literal runat="server" ID="lblHomePageArticleHeader" />
                    </h2>
                    <asp:Literal runat="server" ID="lblHomePageArticleText" />
                </div>
                <div class="main-video">
                    <iframe width="640" height="510" src="http://www.youtube.com/embed/G7AtAQyA9Hc?rel=0" frameborder="0" allowfullscreen></iframe>
                </div>
                <div class="actions">
                    <h2>
                    	Акции
                    </h2>
                    <ul>
                        <asp:Repeater runat="server" ID="rptAnnouncementGroups">
                            <ItemTemplate>
                                <li class="actions-item">
                    	            <a href="/AnnouncementGroup.aspx?Id=<%# Eval("Id") %>" class="actions-item-link">
                                        <%#Eval("Title") %>
                                    </a>
                    	            <p><%# Eval("Abstract") %></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="activities">
                    <div class="book">
                    	<a href="/Article.aspx?Id=29933ec5-d984-49a5-993d-cd36081b6a9f">
                    		<img class="book-image" src="/shared/images/book.jpg" alt="Книжка волонтера"/>
                    	</a>
                        <h4>
                            <a href="/Article.aspx?Id=29933ec5-d984-49a5-993d-cd36081b6a9f">
                            	Получи личную книжку волонтера
                            </a>
                        </h4>
                        <p>У каждого гражданина есть паспорт, у истинного волонтера - его личная книжка. Заходи и получи её!</p>
                    </div>
                    <div class="idea">
                    	<a href="/AddIdeaItemPublic.aspx?ParentId=f65dbcd2-8ca4-48ca-b320-8b72d9307bd5">
                    		<img class="idea-image" src="/shared/images/idea.jpg" alt="Есть идея?"/>
                    	</a>
                        <h4>
                            <a href="/AddIdeaItemPublic.aspx?ParentId=f65dbcd2-8ca4-48ca-b320-8b72d9307bd5">
                            	Предложи свою идею
                            </a>
                        </h4>
                        <p>Если ты знаешь, какие добрые акции нужны нашему городу, набирай  инициативную команду здесь и воплощай мечты в реальность!</p>
                    </div>
                    <div class="vacancy">
                    	<a href="/VacancyGroup.aspx?Id=ae3a9acf-e290-4381-821a-9c74b35f2317">
                    		<img class="vacancy-image" src="/shared/images/vacancy.jpg" alt="Вакансии"/>
                    	</a>
                        <h4>
                            <a href="/VacancyGroup.aspx?Id=ae3a9acf-e290-4381-821a-9c74b35f2317">
                            	Вакансии для тебя
                            </a>
                        </h4>
                        <p>Ищешь работу? В этом разделе ты можешь узнать, кому требуется твоя помощь прямо сейчас.</p>
                    </div>
                </div>
        	</div>
        	<div class="right-home-content">
        		<div class="organizations">
        			<h2>
        				Организации
        			</h2>
                    <ul>
                        <asp:Repeater runat="server" ID="rptCompanies">
                            <ItemTemplate>
                                <li class="organizations-item">
                    	            <a href="/CompanyItem.aspx?Id=<%# Eval("Id") %>" class="organizations-item-link">
                                        <img src="<%# ((SharpCMS.Service.Views.CompanyView)Container.DataItem).Logo == "" ? _path : Eval("Logo") %>"
                                            alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>"/>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <a href="/CompanyGroup.aspx?Id=cf3e7ba9-df4f-4ab3-9fe4-1a1a9ed974ed" class="details">
        				все организации
        			</a>
        		</div>
        	</div>
        </div>
    </div>
</asp:Content>