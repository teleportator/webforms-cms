namespace SharpCMS.UI.Mvc.Infrastructure.Abstract
{
	public interface ILogoManager
	{
		string GetFileName(string path);
		string GetPath(string fileName);
	}
}