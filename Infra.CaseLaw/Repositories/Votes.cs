using Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Infra.CaseLaw.Abstractions;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.Dapper;

namespace Infra.CaseLaw.Repositories
{
	public class Votes : DapperRepository, IVotes
	{
		public Votes(IInfraConfig infraConfig) : base(infraConfig, "Vote")
		{
		}

		public void Save(ref IDictionary<long, JudmentDocument> judmentDocuments)
		{
			foreach (var item in judmentDocuments)
				Save(item.Value.Votes);
		}

		public void Save(IEnumerable<Vote> votes)
		{
			foreach (var vote in votes)
				Save(vote);
		}

		public void Save(Vote vote)
		{
			var query = $@"
							INSERT INTO {Table} (Text, JudmentDocument)
							VALUES ('{vote.Text}', @judmentDocument)";
			using (var connection = Connection())
			{
				connection.Execute(query, new { judmentDocument = vote.JudmentDocument.ID });
			}
		}
	}
}
