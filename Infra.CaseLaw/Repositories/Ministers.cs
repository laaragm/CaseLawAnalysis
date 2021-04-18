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

namespace Infra.CaseLaw.Repositories
{
	public class Ministers : DapperRepository, IMinisters
	{
		public Ministers(IInfraConfig infraConfig) : base(infraConfig, "Minister")
		{
		}

		public void Save(ref IDictionary<long, JudmentDocument> judmentDocuments)
		{
			foreach (var item in judmentDocuments)
				judmentDocuments[item.Key].Minister.ID = SaveAndGetID(item.Value.Minister.Name);
		}

		public void Save(string name)
		{
			var id = Exists(name);
			if (!id.HasValue || id == 0)
			{
				var query = $@"
								INSERT INTO {Table} (Name)
								VALUES ('{name}')";
				using (var connection = Connection())
				{
					connection.Execute(query);
				}
			}
		}

		public long SaveAndGetID(string name)
		{
			var id = Exists(name);
			if (!id.HasValue || id == 0)
			{
				var query = $@"
								INSERT INTO {Table} (Name)
								VALUES ('{name}')
								SELECT @@IDENTITY AS [@@IDENTITY];";
				using (var connection = Connection())
				{
					return connection.QueryFirstOrDefault<long>(query);
				}
			}
			return (long)id;
		}

		public long? Exists(string name)
		{
			var query = $@"SELECT ID FROM {Table}
							WHERE Name LIKE '%{name}%'";
			using (var connection = Connection())
			{
				return connection.QueryFirstOrDefault<long>(query);
			}
		}
	}
}
