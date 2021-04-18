using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class VoteModel
	{
		public long ID { get; set; }
		[JsonProperty("texto")]
		public string Text { get; set; }

		public VoteModel()
		{
		}

		public VoteModel(long id, string text)
		{
			ID = id;
			Text = text;
		}

		public Vote ToVote() => new Vote(ID, Text);
	}
}
