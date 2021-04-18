using Infra.CaseLaw.Abstractions;
using Infra.Dapper.Abstractions;
using System;
using System.Data.SqlClient;

namespace Infra.Dapper
{
	public class DapperRepository : IDapperRepository
	{
		protected string Table;
		IInfraConfig InfraConfig { get; }

		public DapperRepository(IInfraConfig infraConfig, string table)
		{
			InfraConfig = infraConfig;
			Table = table;
		}

		protected SqlConnection Connection()
		{
			var connection = new SqlConnection(InfraConfig.ConnectionString);
			connection.Open();
			return connection;
		}
	}
}
