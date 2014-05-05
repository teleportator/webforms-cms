using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using SharpCMS.Model;

namespace SharpCMS.Repository.EF
{
    public class SharpCMSDataContext : ObjectContext
    {
        #region Fields
        private ObjectSet<Article> _articles;
        private ObjectSet<SiteNode> _siteNodes;
        private ObjectSet<News> _news;
        private ObjectSet<Company> _companies;
        private ObjectSet<Idea> _ideas;
        private ObjectSet<Comment> _comments;
        private ObjectSet<Vacancy> _vacancies;
        private ObjectSet<Announcement> _announcements;
        #endregion

        #region .Ctor
        public SharpCMSDataContext()
            : base("name=Entities", "Entities")
        {
            _articles = CreateObjectSet<Article>();
            _siteNodes = CreateObjectSet<SiteNode>();
            _news = CreateObjectSet<News>();
            _companies = CreateObjectSet<Company>();
            _ideas = CreateObjectSet<Idea>();
            _comments = CreateObjectSet<Comment>();
            _vacancies = CreateObjectSet<Vacancy>();
            _announcements = CreateObjectSet<Announcement>();
        }
        #endregion

        #region Members
        public ObjectSet<Article> Articles
        {
            get { return _articles; }
        }

        public ObjectSet<SiteNode> SiteNodes
        {
            get { return _siteNodes; }
        }

        public ObjectSet<News> NewsCollection
        {
            get { return _news; }
        }

        public ObjectSet<Company> Companies
        {
            get { return _companies; }
        }

        public ObjectSet<Idea> Ideas
        {
            get { return _ideas; }
        }

        public ObjectSet<Comment> Comments
        {
            get { return _comments; }
        }

        public ObjectSet<Vacancy> Vacancies
        {
            get { return _vacancies; }
        }

        public ObjectSet<Announcement> Announcements
        {
            get { return _announcements; }
        }
        #endregion
    }
}
