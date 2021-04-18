using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class PartyModel
	{
		public long ID { get; set; }
		[JsonProperty("nome")]
		public string Name { get; set; }
		[JsonProperty("tipo")]
		public string Type { get; set; }

		public PartyModel()
		{
		}
		
		public PartyModel(long id, string name, string type)
		{
			ID = id;
			Name = name;
			Type = type;
		}

		public Party ToParty() => new Party(ID, Name, Type);
	}
}
