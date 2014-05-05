using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Service;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class StaticPagePresenter : IStaticPagePresenter
    {
        protected ContentService _contentService;
        protected IPageBaseView _view;

        public StaticPagePresenter(ContentService contentService, IPageBaseView view)
        {
            _contentService = contentService;
            _view = view;
        }

        public SiteNodeViewCollection GetMainMenuNodes()
        {
            FindMainMenuNodesRequest request = new FindMainMenuNodesRequest()
            {
                Recursive = true,
                ShowInactive = _view.AllowFullAccess
            };
            return _contentService.FindMainMenuNodes(request).NodesFound;
        }
    }
}
