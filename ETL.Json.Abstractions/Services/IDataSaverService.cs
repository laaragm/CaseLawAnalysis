using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.Json.Abstractions.Services
{
	public interface IDataSaverService
	{
		void Save(IEnumerable<JudmentDocumentModel> data);
	}
}
