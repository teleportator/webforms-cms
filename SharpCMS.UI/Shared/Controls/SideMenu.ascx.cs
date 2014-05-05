using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Service.Views;
using System.Text;

namespace SharpCMS.UI.Shared.Controls
{
    public partial class SideMenuControl : System.Web.UI.UserControl
    {
        private readonly string _item = "<li class='sidemenu-item'>" +
                                        "<a class='{0}' href='{1}'>{2}</a>";
        private readonly string _activeClass = " active";
        private readonly string _menuItemLinkClass = "sidemenu-item-link";
        private Dictionary<string, SiteNodeView> _layerParents = new Dictionary<string, SiteNodeView>();
        private SiteNodeView _currentNode;
        private bool _showAllNodes;

        public bool ShowAllNodes
        {
            set { _showAllNodes = value; }
        }

        public SiteNodeView CurrentNode
        {
            set { _currentNode = value; }
        }

        public void SetCurrentNodeToDisplay(SiteNodeView currentNode)
        {
            _currentNode = currentNode;

            string resultList = FindChildNodeList(_currentNode, null, null);
            PopulateParentList(_currentNode);
            List<string> kies = _layerParents.Keys.ToList();
            foreach (string key in kies)
            {
                if (_layerParents[key].Layer == 0)
                {
                    SiteNodeView currentFirstLayer = _layerParents[key].ChildNodes.Where(n => n.Id == key).FirstOrDefault();
                    lnkFirstLayer.Text = currentFirstLayer.Title;
                    lnkFirstLayer.NavigateUrl = currentFirstLayer.Url;
                }
                else
                {
                    resultList = FindChildNodeList(_layerParents[key], resultList, key);
                }
                _layerParents.Remove(key);
                
            }
            lblSideMenu.Text = resultList;
        }

        private void PopulateParentList(SiteNodeView currentNode)
        {
            if (currentNode.Layer > 0)
            {
                _layerParents.Add(currentNode.Id, currentNode.ParentNode);
                PopulateParentList(currentNode.ParentNode);
            }
        }

        private string FindChildNodeList(SiteNodeView currentNode, string childList, string key)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<ul>");
            foreach (SiteNodeView childNode in currentNode.ChildNodes)
            {
                if ((childNode.DisplayOnSideMenu == true) && (_showAllNodes || childNode.IsActive))
                {
                    if (childNode.Id == key)
                    {
                        if (childNode.Id == _currentNode.Id)
                        {
                            result.AppendFormat("<li class='sidemenu-item'><span class='{0}'>{1}</span>",
                                _menuItemLinkClass + _activeClass, childNode.Title);
                        }
                        else
                        {
                            result.AppendFormat(_item, _menuItemLinkClass + _activeClass, childNode.Url, childNode.Title);
                        }
                        result.Append(childList);
                    }
                    else
                        result.AppendFormat(_item, _menuItemLinkClass, childNode.Url, childNode.Title);
                    result.Append("</li>");
                }
            }
            result.Append("</ul>");
            return result.ToString();
        }
    }
}