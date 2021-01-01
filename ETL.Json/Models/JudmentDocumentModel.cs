using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ETL.Json.Models
{
	public class JudmentDocumentModel
	{
		public long ID { get; set; }
		[JsonProperty("numero")]
		public long ProcessNumber { get; set; }
		[JsonProperty("acordao")]
		public JudmentModel JudmentText { get; set; }
		[JsonProperty("extratoata")]
		public RecordModel DecisionText { get; set; }
		[JsonProperty("partes")]
		public IEnumerable<PartyModel> Parties { get; set; }
		[JsonProperty("relatorio")]
		public ReportModel Report { get; set; }
		[JsonProperty("votos")]
		public IEnumerable<VoteModel> Votes { get; set; }
		[JsonProperty("integratxt")]
		public IEnumerable<string> RawText { get; set; }

		public JudmentDocumentModel()
		{
		}

		public JudmentDocumentModel(long id, long processNumber, JudmentModel judmentText, RecordModel decisionText, IEnumerable<PartyModel> parties, ReportModel report, IEnumerable<VoteModel> votes, IEnumerable<string> rawText)
		{
			ID = id;
			ProcessNumber = processNumber;
			JudmentText = judmentText;
			DecisionText = decisionText;
			Parties = parties;
			Report = report;
			Votes = votes;
			RawText = rawText;
		}
	}
}
