using Domain;
using ETL.Json.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

		public JudmentDocument ToJudmentDocument()
		{
			var judmentDocument = new JudmentDocument
				(
					ID,
					ProcessNumber,
					JudmentText.Text.Clean(),
					DecisionText == null ? null : DecisionText.Text.Clean(),
					new List<Party>(Parties.Select(x => new PartyModel(x.ID, x.Name, x.Type).ToParty())),
					new ReportModel(Report.ID, Report.Reporter, Report.Text.Clean()).ToReportText(),
					new Minister(0, Report.Reporter),
					Report.Reporter,
					new List<Vote>(Votes.Select(x => new VoteModel(x.ID, x.Text.Clean()).ToVote())),
					string.Join(" ", RawText.Select(x => x.Clean()).ToArray())
				);
			judmentDocument.Parties.Select(x => x.JudmentDocument = new JudmentDocument(judmentDocument)).ToList();
			judmentDocument.Votes.Select(x => x.JudmentDocument = new JudmentDocument(judmentDocument)).ToList();

			return judmentDocument;
		}
	}
}
