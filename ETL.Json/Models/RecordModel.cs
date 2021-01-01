using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class RecordModel
	{
		[JsonProperty("texto")]
		public string Text { get; set; }

		public RecordModel()
		{
		}

		public RecordModel(string text)
		{
			Text = text;
		}
	}
}
