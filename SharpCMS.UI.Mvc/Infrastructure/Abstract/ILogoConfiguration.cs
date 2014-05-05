namespace SharpCMS.UI.Mvc.Infrastructure.Abstract
{
	public interface ILogoConfiguration
	{
		string UploadFolderPath { get; }
		string DefaultLogoFileName { get; }
	}
}