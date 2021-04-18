using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.Json.Runner.Settings
{
	public class AppSettings : IAppSettings
	{
		public string ConnectionString { get; set; }
		public string File { get; set; }
	}
}
