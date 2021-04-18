using Domain;
using Infra.Dapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CaseLaw.Abstractions.Repositories
{
	public interface IParties : IDapperRepository
	{
		void Save(ref IDictionary<long, JudmentDocument> judmentDocuments);
		void Save(IEnumerable<Party> parties);
		void Save(Party party);
	}
}
