using System;
using System.Collections.Generic;

namespace Base.Domain
{
	public class Vote
	{
		public long ID { get; set; }
		public string Text { get; set; } //"texto"

		public Vote()
		{
		}

		public Vote(long id, string text)
		{
			ID = id;
			Text = text;
		}
	}
}
