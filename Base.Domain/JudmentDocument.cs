using System;
using System.Collections.Generic;

namespace Domain
{
	public class JudmentDocument
	{
		public long ID { get; set; }
		public long ProcessNumber { get; set; }
		public string JudmentText { get; set; }
		public string DecisionText { get; set; }
		public IEnumerable<Party> Parties { get; set; }
		public string ReportText { get; set; }
		public Minister Minister { get; set; }
		public string MinisterName { get; set; }
		public IEnumerable<Vote> Votes { get; set; }
		public string RawText { get; set; }

		public JudmentDocument()
		{
		}

		public JudmentDocument(long id, long processNumber, string judmentText, string decisionText, IEnumerable<Party> parties, string reportText, Minister minister, string ministerName, IEnumerable<Vote> votes, string rawText)
		{
			ID = id;
			ProcessNumber = processNumber;
			JudmentText = judmentText;
			DecisionText = decisionText;
			Parties = parties;
			ReportText = reportText;
			Minister = minister;
			MinisterName = ministerName;
			Votes = votes;
			RawText = rawText;
		}

		public JudmentDocument(JudmentDocument judmentDocument)
		{
			ID = judmentDocument.ID;
			ProcessNumber = judmentDocument.ProcessNumber;
			JudmentText = judmentDocument.JudmentText;
			DecisionText = judmentDocument.DecisionText;
			Parties = judmentDocument.Parties;
			ReportText = judmentDocument.ReportText;
			Minister = judmentDocument.Minister;
			MinisterName = judmentDocument.MinisterName;
			Votes = judmentDocument.Votes;
			RawText = judmentDocument.RawText;
		}
	}
}
