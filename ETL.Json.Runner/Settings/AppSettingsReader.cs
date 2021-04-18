using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ETL.Json.Runner.Settings
{
	public class AppSettingsReader
	{
		private string FileName = "appsettings.json";
		public IAppSettings Read() => JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(FileName));
	}
}
