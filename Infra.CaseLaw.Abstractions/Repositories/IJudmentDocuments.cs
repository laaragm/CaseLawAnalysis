using Domain;
using Infra.Dapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CaseLaw.Abstractions.Repositories
{
	public interface IJudmentDocuments : IDapperRepository
	{
		IEnumerable<JudmentDocument> All();
		void Save(ref IDictionary<long, JudmentDocument> judmentDocuments);
		void Save(ref IEnumerable<JudmentDocument> judmentDocuments);
		void Save(JudmentDocument judmentDocument);
		long SaveAndGetID(JudmentDocument judmentDocument);
	}
}
