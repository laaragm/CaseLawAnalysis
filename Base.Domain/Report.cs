using System;
using System.Collections.Generic;

namespace Base.Domain
{
	public class Report
	{
		public long ID { get; set; }
		public string Reporter { get; set; } //"relator"
		public string Text { get; set; } //"texto"

		public Report()
		{
		}

		public Report(long id, string reporter, string text)
		{
			ID = id;
			Reporter = reporter;
			Text = text;
		}
	}
}
