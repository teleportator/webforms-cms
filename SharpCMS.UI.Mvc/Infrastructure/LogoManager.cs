using System;
using System.IO;
using SharpCMS.UI.Mvc.Infrastructure.Abstract;

namespace SharpCMS.UI.Mvc.Infrastructure
{
	public class LogoManager : ILogoManager
	{
		private readonly ILogoConfiguration _configuration;

		public LogoManager()
		{
			_configuration = new LogoConfiguration();
		}

		public string GetFileName(string path)
		{
			var fileName = Path.GetFileName(path);
			return (String.IsNullOrEmpty(fileName) ||
			        String.Equals(_configuration.DefaultLogoFileName, fileName, StringComparison.OrdinalIgnoreCase))
			       	? String.Empty
			       	: fileName;
		}

		public string GetPath(string fileName)
		{
			return _configuration.UploadFolderPath +
			       (String.IsNullOrEmpty(fileName) ? _configuration.DefaultLogoFileName : fileName);
		}
	}
}