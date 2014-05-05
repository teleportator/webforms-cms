using SharpCMS.UI.Mvc.Infrastructure.Abstract;

namespace SharpCMS.UI.Mvc.Infrastructure
{
	public class LogoConfiguration : ILogoConfiguration
	{
		public string UploadFolderPath
		{
			get { return "/content/companies/"; }
		}

		public string DefaultLogoFileName
		{
			get { return "no-image.jpg"; }
		}
	}
}