using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class ReportModel
	{
		public long ID { get; set; }
		[JsonProperty("relator")]
		public string Reporter { get; set; }
		[JsonProperty("texto")]
		public string Text { get; set; }

		public ReportModel()
		{
		}

		public ReportModel(long id, string reporter, string text)
		{
			ID = id;
			Reporter = reporter;
			Text = text;
		}
	}
}
