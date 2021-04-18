using Domain;
using Infra.Dapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CaseLaw.Abstractions.Repositories
{
	public interface IVotes : IDapperRepository
	{
		void Save(ref IDictionary<long, JudmentDocument> judmentDocuments);
		void Save(IEnumerable<Vote> votes);
		void Save(Vote vote);
	}
}
