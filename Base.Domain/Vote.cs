using System;
using System.Collections.Generic;

namespace Domain
{
	public class Vote
	{
		public long ID { get; set; }
		public string Text { get; set; }
		public JudmentDocument JudmentDocument { get; set; }

		public Vote()
		{
		}

		public Vote(long id, string text)
		{
			ID = id;
			Text = text;
		}

		public Vote(long id, string text, JudmentDocument judmentDocument) : this(id, text)
		{
			JudmentDocument = judmentDocument;
		}
	}
}
