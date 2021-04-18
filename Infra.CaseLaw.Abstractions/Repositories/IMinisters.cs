using Domain;
using Infra.Dapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CaseLaw.Abstractions.Repositories
{
	public interface IMinisters : IDapperRepository
	{
		void Save(ref IDictionary<long, JudmentDocument> judmentDocuments);
		void Save(string name);
		long SaveAndGetID(string name);
		long? Exists(string name);
	}
}
