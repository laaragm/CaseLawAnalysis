using Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Abstractions;
using Infra.Dapper;
using Slapper;

namespace Infra.CaseLaw.Repositories
{
	public class JudmentDocuments : DapperRepository, IJudmentDocuments
	{
		public JudmentDocuments(IInfraConfig infraConfig) : base(infraConfig, "JudmentDocument")
		{
		}

		public IEnumerable<JudmentDocument> All()
		{
			var query = $@"
							SELECT
								ID
								,ProcessNumber
								,JudmentText
								,DecisionText
								,ReportText
								,Minister Minister_ID
								,MinisterName Minister_Name
								,RawText
							FROM {Table}";
			using (var connection = Connection())
			{
				return AutoMapper.MapDynamic<JudmentDocument>(connection.Query<dynamic>(query));
				//return connection.Query<JudmentDocument>(query);
			}
		}

		public void Save(ref IDictionary<long, JudmentDocument> judmentDocuments)
		{
			foreach (var item in judmentDocuments)
			{
				var id = SaveAndGetID(item.Value);
				judmentDocuments[item.Key].ID = id;
				judmentDocuments[item.Key].Parties.Select(x => x.JudmentDocument.ID = id).ToList();
				judmentDocuments[item.Key].Votes.Select(x => x.JudmentDocument.ID = id).ToList();
			}
		}

		public void Save(ref IEnumerable<JudmentDocument> judmentDocuments)
		{
			judmentDocuments = judmentDocuments.AsList();
			foreach (var judmentDocument in judmentDocuments)
				judmentDocument.ID = SaveAndGetID(judmentDocument);
		}

		public void Save(JudmentDocument judmentDocument)
		{
			var query = $@"
							INSERT INTO {Table} (ProcessNumber, JudmentText, DecisionText, ReportText, Minister, MinisterName, RawText)
							VALUES ('{judmentDocument.ProcessNumber}', '{judmentDocument.JudmentText}', '{judmentDocument.DecisionText}', '{judmentDocument.ReportText}', @minister,'{judmentDocument.MinisterName}', '{judmentDocument.RawText}')";
			using (var connection = Connection())
			{
				connection.Execute(query, new { minister = judmentDocument.Minister.ID });
			}
		}

		public long SaveAndGetID(JudmentDocument judmentDocument)
		{
			var query = $@"
							INSERT INTO {Table} (ProcessNumber, JudmentText, DecisionText, ReportText, Minister, MinisterName, RawText)
							VALUES ('{judmentDocument.ProcessNumber}', '{judmentDocument.JudmentText}', '{judmentDocument.DecisionText}', '{judmentDocument.ReportText}', @minister,'{judmentDocument.MinisterName}', '{judmentDocument.RawText}')
							SELECT @@IDENTITY AS [@@IDENTITY];";
			using (var connection = Connection())
			{
				return connection.QueryFirstOrDefault<long>(query, new { minister = judmentDocument.Minister.ID });
			}
		}
	}
}
