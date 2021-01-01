using System;
using System.Collections.Generic;

namespace Base.Domain
{
	public class Party
	{
		public long ID { get; set; }
		public string Name { get; set; } //"nome"
		public string Type { get; set; } //"tipo"

		public Party()
		{
		}
		
		public Party(long id, string name, string type)
		{
			ID = id;
			Name = name;
			Type = type;
		}
	}
}
