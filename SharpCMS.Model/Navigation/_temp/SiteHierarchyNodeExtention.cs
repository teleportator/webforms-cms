using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model.Navigation
{
    public static class SiteHierarchyNodeExtention
    {
        public static SiteNode ConvertToSiteNode(this SiteHierarchyNode node)
        {
            return new SiteNode()
                {
                    Id = node.Id,
                    ContentItemId = node.Id,
                    ParentId = node.ParentNode.Id,
                    SortOrder = node.SortOrder,
                    Url = node.Url,
                    Title = node.Title,
                    DisplayOnSideMenu = node.DisplayOnSideMenu,
                    DisplayOnMainMenu = node.DisplayOnMainMenu
                };
        }
    }
}
