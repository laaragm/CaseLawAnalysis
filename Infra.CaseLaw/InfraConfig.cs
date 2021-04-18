using Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Infra.CaseLaw.Abstractions;

namespace Infra.CaseLaw
{
	public class InfraConfig : IInfraConfig
	{
		public string ConnectionString { get; set; }

		public InfraConfig(string connectionString)
		{
			ConnectionString = connectionString;
		}

		protected SqlConnection Connection()
		{
			var connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection;
		}
	}
}
