using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SharpCMS.Model.Navigation
{
    public class SiteNodeService
    {
        #region Fields
        private string _key = "SharpCMS_SiteNodeHierarchy";
        private ISiteNodeRepository _siteNodeRepository;
        private HttpContext _currentContext;
        #endregion

        #region .Ctor
        public SiteNodeService(ISiteNodeRepository siteNodeRepository, HttpContext currentContext)
        {
            _siteNodeRepository = siteNodeRepository;
            _currentContext = currentContext;
        }
        #endregion

        #region Methods
        public SiteHierarchyNode GetSiteMapHierarchy()
        {
            SiteHierarchyNode hierarchy = new SiteHierarchyNode();
            if (_currentContext.Cache[_key] != null)
            {
                hierarchy = (SiteHierarchyNode)_currentContext.Cache[_key];
            }
            else
            {
                hierarchy = _siteNodeRepository.GetAllNodes().ConvertToSiteHierarchyNodes();
                _currentContext.Cache.Insert(_key, hierarchy, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return hierarchy;
        }

        public SiteHierarchyNodeCollection FindMainMenuNodes()
        {
            return FindMainMenuNodesIn(GetSiteMapHierarchy());
        }

        public SiteHierarchyNodeCollection FindMainMenuNodesIn(SiteHierarchyNode layerRootNode)
        {
            SiteHierarchyNodeCollection result = new SiteHierarchyNodeCollection();
            if (layerRootNode.DisplayOnMainMenu == true)
            {
                result.Add(layerRootNode);
            }
            foreach (SiteHierarchyNode child in layerRootNode.ChildNodes)
            {
                FindMainMenuNodesIn(layerRootNode);
            }
            return result;
        }

        public SiteHierarchyNodeCollection FindSideMenuNodes()
        {
            return FindSideMenuNodesIn(GetSiteMapHierarchy());
        }

        public SiteHierarchyNodeCollection FindSideMenuNodesIn(SiteHierarchyNode layerRootNode)
        {
            SiteHierarchyNodeCollection result = new SiteHierarchyNodeCollection();
            if (layerRootNode.DisplayOnSideMenu == true)
            {
                result.Add(layerRootNode);
            }
            foreach (SiteHierarchyNode child in layerRootNode.ChildNodes)
            {
                FindSideMenuNodesIn(layerRootNode);
            }
            return result;
        }

        public SiteHierarchyNode FindNodeBy(ContentItem item)
        {
            return FindNodeByIdRecursively(GetSiteMapHierarchy(), item.Id);
        }

        private SiteHierarchyNode FindNodeByIdRecursively(SiteHierarchyNode layerRootNode, Guid itemId)
        {
            if (layerRootNode.ItemId == itemId)
            {
                return layerRootNode;
            }
            else
            {
                foreach (SiteHierarchyNode child in layerRootNode.ChildNodes)
                {
                    SiteHierarchyNode searchResult = FindNodeByIdRecursively(child, itemId);
                    if (searchResult != null)
                        return searchResult;
                }
                return null;
            }
        }

        public void InsertNode(ContentItem item, string url, int sortOrder, bool displayOnMainMenu, bool displayOnSideMenu)
        {
            SiteHierarchyNode node = FindNodeBy(item);
            if (node == null)
            {
                _siteNodeRepository.Add(new SiteNode()
                {
                    Id = new Guid(),
                    ContentItemId = item.Id,
                    ParentId = item.ParentId,
                    SortOrder = sortOrder,
                    Url = url,
                    Title = item.Title,
                    DisplayOnSideMenu = displayOnSideMenu,
                    DisplayOnMainMenu = displayOnMainMenu
                });
            }
            else
            {
                _siteNodeRepository.Save(new SiteNode()
                {
                    Id = node.Id,
                    ContentItemId = node.Id,
                    ParentId = item.ParentId,
                    SortOrder = sortOrder,
                    Url = url,
                    Title = item.Title,
                    DisplayOnSideMenu = displayOnSideMenu,
                    DisplayOnMainMenu = displayOnMainMenu
                });
            }
            _currentContext.Cache.Remove(_key);
        }

        public void DeleteNode(ContentItem item)
        {
            SiteHierarchyNode node = FindNodeBy(item);
            if (node != null)
            {
                _siteNodeRepository.Delete(node.ConvertToSiteNode());
            }
        }
        #endregion
    }
}
