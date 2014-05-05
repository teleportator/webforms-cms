using System;
using System.Linq;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Models.Common;

namespace SharpCMS.UI.Mvc.Controllers
{
	public class CommonController : ControllerBase
	{
		public ActionResult DisplayMainMenu()
		{
			var model = new MainMenuModel();
			var request = new FindMainMenuNodesRequest
			              	{
			              		Recursive = true,
			              		ShowInactive = AllowFullAccess
			              	};
			model.SiteNodes = ContentService.FindMainMenuNodes(request).NodesFound;
			return View("MenuPartial", model);
		}

		public ActionResult DisplaySideMenu(Guid id)
		{
			var model = new SideMenuModel();
			var request = new FindNodesRequest {ContentItemId = id.ToString()};
			SiteNodeView selectedNode = ContentService.FindNode(request).NodeFound;
			SiteNodeView rootSectionNode = GetRootSectionNode(selectedNode);
			model.RootSectionTitle = rootSectionNode.Title;
			model.RootSectionUrl = rootSectionNode.Url;
			model.Links = GetLinks(selectedNode.Id, selectedNode, null, new SideMenuCollectionModel(), AllowFullAccess);

			return View("SideMenuPartial", model);
		}

		public ActionResult Title(Guid? id)
		{
			var model = new PageTitleModel();
			SiteNodeView selectedNode = null;
			if (id.HasValue)
			{
				var request = new FindNodesRequest {ContentItemId = id.ToString()};
				selectedNode = ContentService.FindNode(request).NodeFound;
			}
			model.Title = selectedNode == null
			              	? "Я волонтер Ставрополя"
			              	: selectedNode.Title + " - " + "Я волонтер Ставрополя";
			return View("TitlePartial", model);
		}

		private static SideMenuCollectionModel GetLinks(string selectedNodeId, SiteNodeView node, string childRootId,
		                                                SideMenuCollectionModel childs, bool displayInactive)
		{
			if (node.Layer > 0)
			{
				var collection =
					new SideMenuCollectionModel(node.ChildNodes
					                            	.Where(n => n.DisplayOnSideMenu && (n.IsActive || displayInactive))
					                            	.Select(n => new SideMenuLinkModel
					                            	             	{
					                            	             		IsCurrent = n.Id == selectedNodeId,
					                            	             		Title = n.Title,
					                            	             		Url = n.Url,
					                            	             		Childs = n.Id == childRootId ? childs : new SideMenuCollectionModel()
					                            	             	}).ToList());
				collection.HasCurrent = node.ChildNodes.Any(n => n.Id == selectedNodeId) || childs.HasCurrent;
				return GetLinks(selectedNodeId, node.ParentNode, node.Id, collection, displayInactive);
			}

			return childs;
		}

		private static SiteNodeView GetRootSectionNode(SiteNodeView node)
		{
			return node.Layer == 1 ? node : GetRootSectionNode(node.ParentNode);
		}
	}
}