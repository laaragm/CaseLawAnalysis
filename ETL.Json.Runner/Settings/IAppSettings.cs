using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.Json.Runner.Settings
{
	public interface IAppSettings
	{
		string ConnectionString { get; }
		string File { get; }
	}
}
