using ETL.Json.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ETL.Json.Abstractions.Services
{
	public interface IDataLoaderService
	{
		IEnumerable<JudmentDocumentModel> Load(string fileName);
	}
}
