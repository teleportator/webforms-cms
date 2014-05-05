using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Model;
using SharpCMS.Service.Views;

namespace SharpCMS.Service.Mappers
{
    public static class SiteNodeExtensions
    {
        public static SiteNodeView ConvertToSiteNodeViews(this IEnumerable<SiteNode> nodes)
        {
            SiteNodeView root;
            root = nodes.GetRootNode().ConvertToSiteNodeView(null);
            root.ChildNodes = GetChildNodesRecursive(nodes, root);
            return root;
        }

        private static SiteNodeViewCollection GetChildNodesRecursive(IEnumerable<SiteNode> nodes, SiteNodeView parentNode)
        {
            SiteNodeViewCollection layerRoot = new SiteNodeViewCollection();
            IEnumerable<SiteNode> childNodes = nodes.Where(n => n.ParentId == new Guid(parentNode.Id)).OrderBy(p => p.Title).OrderBy(p => p.SortOrder);
            foreach (SiteNode childNode in childNodes)
            {
                SiteNodeView childNodeView = childNode.ConvertToSiteNodeView(parentNode);
                childNodeView.ChildNodes = GetChildNodesRecursive(nodes, childNodeView);
                layerRoot.Add(childNodeView);
            }
            return layerRoot;
        }

        public static SiteNodeView ConvertToSiteNodeView(this SiteNode node, SiteNodeView parent)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            SiteNodeView hierarchyNode = new SiteNodeView()
            {
                DisplayOnMainMenu = node.DisplayOnMainMenu,
                DisplayOnSideMenu = node.DisplayOnSideMenu,
                Id = node.Id.ToString(),
                ContentItemId = node.ContentItemId.ToString(),
                ParentNode = parent,
                SortOrder = node.SortOrder.ToString(),
                Title = node.Title,
                Url = node.Url,
                IsActive = node.IsActive
            };
            return hierarchyNode;
        }

        private static SiteNode GetRootNode(this IEnumerable<SiteNode> nodes)
        {
            return nodes.Where(n => n.ParentId == Guid.Empty).First();
        }
    }
}
