using System;

namespace Infra.CaseLaw.Abstractions
{
	public interface IInfraConfig
	{
		string ConnectionString { get; }
	}
}
