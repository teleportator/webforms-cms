namespace SharpCMS.UI.Mvc.Infrastructure.Abstract
{
	public interface IUrlPatternFactory
	{
		string GetUrlPatternFor(string type);
	}
}