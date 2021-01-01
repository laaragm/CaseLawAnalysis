using System;
using System.Collections.Generic;

namespace Base.Domain
{
	public class JudmentDocument
	{
		public long ID { get; set; }
		public long ProcessNumber { get; set; } //"numero"
		public string JudmentText { get; set; } //"acordao" -> "texto"
		public string DecisionText { get; set; } //"extratoata" -> "texto"
		public IEnumerable<Party> Parties { get; set; } //"partes" // 1->n criar tabela Party com FK pra JudmentDocument
		public Report Report { get; set; } //"relatorio"
		public Minister Minister { get; set; } //"relatorio" -> "relator"
		public string MinisterName { get; set; } //"relatorio" -> "relator"
		public IEnumerable<Vote> Votes { get; set; } //"votos" // 1->n criar tabela Vote com FK pra JudmentDocument
		public IEnumerable<string> RawText { get; set; } //"integratxt"

		public JudmentDocument()
		{
		}

		public JudmentDocument(long id, long processNumber, string judmentText, string decisionText, IEnumerable<Party> parties, Report report, Minister minister, string ministerName, IEnumerable<Vote> votes, IEnumerable<string> rawText)
		{
			ID = id;
			ProcessNumber = processNumber;
			JudmentText = judmentText;
			DecisionText = decisionText;
			Parties = parties;
			Report = report;
			Minister = minister;
			MinisterName = ministerName;
			Votes = votes;
			RawText = rawText;
		}
	}
}
