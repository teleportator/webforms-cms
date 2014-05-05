using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;

namespace SharpCMS.Repository.Stub
{
    public static class DataContext
    {
        private static List<SiteNode> _nodes;
        private static List<Article> _articles;

        public static List<SiteNode> Nodes
        {
            get
            {
                if (_nodes == null)
                    Init();
                return _nodes;
            }
        }

        public static List<Article> Articles
        {
            get
            {
                if (_articles == null)
                    Init();
                return _articles;
            }
        }

        public static void Init()
        {
            Guid id = Guid.NewGuid();

            _nodes = new List<SiteNode>();
            _articles = new List<Article>();

            Article homeArticle = new Article()
            {
                Abstract = "Home Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "Home Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "Home Page Keywords",
                ParentId = Guid.Empty,
                Text = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce " +
                       "posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros " +
                       "quis urna. Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus." +
                       "</p>" +
                       "<p>" +
                       "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. " +
                       "Proin pharetra nonummy pede. Mauris et orci. Aenean nec lorem. In porttitor. Donec laoreet " +
                       "nonummy augue." +
                       "</p>" +
                       "<p>" +
                       "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque " +
                       "at sem venenatis eleifend. Ut nonummy. Fusce aliquet pede non pede. Suspendisse dapibus lorem " +
                       "pellentesque magna. Integer nulla." +
                       "</p>",
                Title = "Волонтерство",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article newsArticle = new Article()
            {
                Abstract = "News Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "News Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "News Page Keywords",
                ParentId = homeArticle.Id,
                Text = "<p>News Page Text</p>",
                Title = "Новости",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article actionsArticle = new Article()
            {
                Abstract = "Actions Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "Actions Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "Actions Page Keywords",
                ParentId = homeArticle.Id,
                Text = "<p>Actions Page Text</p>",
                Title = "Акции",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article companyArticle = new Article()
            {
                Abstract = "Company Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "Company Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "Company Page Keywords",
                ParentId = homeArticle.Id,
                Text = "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce " +
                       "posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros " +
                       "quis urna. Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus." +
                       "</p>" +
                       "<p>" +
                       "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. " +
                       "Proin pharetra nonummy pede. Mauris et orci. Aenean nec lorem. In porttitor. Donec laoreet " +
                       "nonummy augue." +
                       "</p>" +
                       "<p>" +
                       "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque " +
                       "at sem venenatis eleifend. Ut nonummy. Fusce aliquet pede non pede. Suspendisse dapibus lorem " +
                       "pellentesque magna. Integer nulla." +
                       "</p>",
                Title = "О Центре",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article contactsArticle = new Article()
            {
                Abstract = "Contact Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "Contact Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "Contact Page Keywords",
                ParentId = companyArticle.Id,
                Text = "<p>Contact Page Text</p>",
                Title = "Контакты",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article historyArticle = new Article()
            {
                Abstract = "History Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "History Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "History Page Keywords",
                ParentId = companyArticle.Id,
                Text = "<p>History Page Text</p>",
                Title = "История",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            Article otherArticle = new Article()
            {
                Abstract = "Other Page Abstract",
                Created = DateTime.Now,
                CreatedBy = "Admin",
                Description = "Other Page Description",
                Id = Guid.NewGuid(),
                IsActive = true,
                Keywords = "Other Page Keywords",
                ParentId = historyArticle.Id,
                Text = "<p>Other Page Text</p>",
                Title = "Они",
                Updated = DateTime.Now,
                UpdatedBy = "Admin"
            };

            _articles.Add(homeArticle);
            _articles.Add(newsArticle);
            _articles.Add(actionsArticle);
            _articles.Add(companyArticle);
            _articles.Add(contactsArticle);
            _articles.Add(historyArticle);
            _articles.Add(otherArticle);

            SiteNode homeNode = new SiteNode()
            {
                ItemId = homeArticle.Id,
                DisplayOnMainMenu = false,
                DisplayOnSideMenu = false,
                Id = id,
                ParentId = Guid.Empty,
                SortOrder = 500,
                Title = homeArticle.Title,
                Url = "/Default.aspx"
            };

            id = Guid.NewGuid();
            SiteNode newsNode = new SiteNode()
            {
                ItemId = newsArticle.Id,
                DisplayOnMainMenu = true,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = homeNode.Id,
                SortOrder = 500,
                Title = newsArticle.Title,
                Url = "/Article.aspx?Id=" + newsArticle.Id.ToString()
            };

            id = Guid.NewGuid();
            SiteNode actionsNode = new SiteNode()
            {
                ItemId = actionsArticle.Id,
                DisplayOnMainMenu = true,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = homeNode.Id,
                SortOrder = 500,
                Title = actionsArticle.Title,
                Url = "/Article.aspx?Id=" + actionsArticle.Id.ToString()
            };

            id = Guid.NewGuid();
            SiteNode companyNode = new SiteNode()
            {
                ItemId = companyArticle.Id,
                DisplayOnMainMenu = true,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = homeNode.Id,
                SortOrder = 500,
                Title = companyArticle.Title,
                Url = "/Article.aspx?Id=" + companyArticle.Id.ToString()
            };

            id = Guid.NewGuid();
            SiteNode contactNode = new SiteNode()
            {
                ItemId = contactsArticle.Id,
                DisplayOnMainMenu = false,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = companyNode.Id,
                SortOrder = 500,
                Title = contactsArticle.Title,
                Url = "/Article.aspx?Id=" + contactsArticle.Id.ToString()
            };

            id = Guid.NewGuid();
            SiteNode historyNode = new SiteNode()
            {
                ItemId = historyArticle.Id,
                DisplayOnMainMenu = false,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = companyNode.Id,
                SortOrder = 500,
                Title = historyArticle.Title,
                Url = "/Article.aspx?Id=" + historyArticle.Id.ToString()
            };

            id = Guid.NewGuid();
            SiteNode otherNode = new SiteNode()
            {
                ItemId = otherArticle.Id,
                DisplayOnMainMenu = false,
                DisplayOnSideMenu = true,
                Id = id,
                ParentId = historyNode.Id,
                SortOrder = 500,
                Title = otherArticle.Title,
                Url = "/Article.aspx?Id=" + otherArticle.Id.ToString()
            };

            _nodes.Add(homeNode);
            _nodes.Add(newsNode);
            _nodes.Add(actionsNode);
            _nodes.Add(companyNode);
            _nodes.Add(contactNode);
            _nodes.Add(historyNode);
            _nodes.Add(otherNode);
        }
    }
}
