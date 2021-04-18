using Domain;
using ETL.Json.Models;
using Infra.CaseLaw.Abstractions;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETL.Json.Services
{
	public class DataSaverService
	{
		IJudmentDocuments JudmentDocuments { get; set; }
		IMinisters Ministers { get; set; }
		IParties Parties { get; set; }
		IVotes Votes { get; set; }

		public DataSaverService(IJudmentDocuments judmentDocuments, IMinisters ministers, IParties parties, IVotes votes)
		{
			JudmentDocuments = judmentDocuments;
			Ministers = ministers;
			Parties = parties;
			Votes = votes;
		}

		public void Save(IEnumerable<JudmentDocumentModel> data)
		{
			IDictionary<long, JudmentDocument> judmentDocsDict = new Dictionary<long, JudmentDocument>();
			var judmentDocs = data.Select(x => x.ToJudmentDocument());
			foreach (var document in judmentDocs)
				judmentDocsDict.Add(document.ProcessNumber, document);

			Ministers.Save(ref judmentDocsDict);
			JudmentDocuments.Save(ref judmentDocsDict);
			Parties.Save(ref judmentDocsDict);
			Votes.Save(ref judmentDocsDict);
		}
	}
}
