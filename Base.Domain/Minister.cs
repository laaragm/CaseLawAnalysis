using System;
using System.Collections.Generic;

namespace Domain
{
	public class Minister
	{
		public long ID { get; set; }
		public string Name { get; set; } 

		public Minister()
		{
		}

		public Minister(long id, string name)
		{
			ID = id;
			Name = name;
		}
	}
}
