using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model.Navigation
{
    public static class SiteNodeExtention
    {
        public static SiteHierarchyNode ConvertToSiteHierarchyNodes(this IEnumerable<SiteNode> nodes)
        {
            SiteHierarchyNode root;
            root = nodes.GetRootNode().ConvertToSiteHierarchyNode(null);
            root.ChildNodes = GetChildNodesRecursive(nodes, root, nodes.GetRootNode().Id);
            return root;
        }

        private static SiteHierarchyNodeCollection GetChildNodesRecursive(IEnumerable<SiteNode> nodes,
            SiteHierarchyNode parentHierarchyNode, Guid parentId)
        {
            SiteHierarchyNodeCollection layerRoot = new SiteHierarchyNodeCollection();
            IEnumerable<SiteNode> childNodes = nodes.Where(n => n.ParentId == parentId).OrderBy(p => p.SortOrder);
            foreach (SiteNode childNode in childNodes)
            {
                SiteHierarchyNode childHierarchyNode = childNode.ConvertToSiteHierarchyNode(parentHierarchyNode);
                childHierarchyNode.ChildNodes = GetChildNodesRecursive(nodes, childHierarchyNode, childNode.Id);
                layerRoot.Add(childHierarchyNode);
            }
            return layerRoot;
        }

        public static SiteHierarchyNode ConvertToSiteHierarchyNode(this SiteNode node, SiteHierarchyNode parent)
        {
            SiteHierarchyNode hierarchyNode = new SiteHierarchyNode();
            hierarchyNode.DisplayOnMainMenu = node.DisplayOnMainMenu;
            hierarchyNode.DisplayOnSideMenu = node.DisplayOnSideMenu;
            hierarchyNode.Id = node.Id;
            hierarchyNode.ItemId = node.ContentItemId;
            hierarchyNode.ParentNode = parent;
            hierarchyNode.SortOrder = node.SortOrder;
            hierarchyNode.Title = node.Title;
            hierarchyNode.Url = node.Url;
            return hierarchyNode;
        }

        private static SiteNode GetRootNode(this IEnumerable<SiteNode> nodes)
        {
            return nodes.Where(n => n.ParentId == Guid.Empty).First();
        }
    }
}
