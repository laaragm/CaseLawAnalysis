using Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Abstractions;
using Infra.Dapper;

namespace Infra.CaseLaw.Repositories
{
	public class Parties : DapperRepository, IParties
	{
		public Parties(IInfraConfig infraConfig) : base(infraConfig, "Party")
		{
		}

		public void Save(ref IDictionary<long, JudmentDocument> judmentDocuments)
		{
			foreach (var item in judmentDocuments)
				Save(item.Value.Parties);
		}

		public void Save(IEnumerable<Party> parties)
		{
			foreach (var party in parties)
				Save(party);
		}

		public void Save(Party party)
		{
			var query = $@"
							INSERT INTO {Table} (Name, Type, JudmentDocument)
							VALUES ('{party.Name}', '{party.Type}', @judmentDocument)";
			using (var connection = Connection())
			{
				connection.Execute(query, new { judmentDocument = party.JudmentDocument.ID });
			}
		}
	}
}
