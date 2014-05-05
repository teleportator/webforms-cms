using SharpCMS.UI.Mvc.Infrastructure.Abstract;

namespace SharpCMS.UI.Mvc.Infrastructure
{
	public class UrlPatternFactory : IUrlPatternFactory
	{
		public string GetUrlPatternFor(string type)
		{
			switch (type)
			{
				case "page":
					return "/" + type + "/display/{0}";
				default:
					return "/" + type + "/list/{0}";
			}
		}
	}
}