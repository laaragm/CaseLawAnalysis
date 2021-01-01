using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class JudmentModel
	{
		[JsonProperty("texto")]
		public string Text { get; set; }

		public JudmentModel()
		{
		}
		
		public JudmentModel(string text)
		{
			Text = text;
		}
	}
}
