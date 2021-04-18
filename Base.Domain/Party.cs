using System;
using System.Collections.Generic;

namespace Domain
{
	public class Party
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public JudmentDocument JudmentDocument { get; set; }

		public Party()
		{
		}
		
		public Party(long id, string name, string type)
		{
			ID = id;
			Name = name;
			Type = type;
		}

		public Party(long id, string name, string type, JudmentDocument judmentDocument) : this(id, name, type)
		{
			JudmentDocument = judmentDocument;
		}
	}
}
