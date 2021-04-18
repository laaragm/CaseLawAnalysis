using Nest;

namespace ElasticSearch.API.Config
{
	public interface IElasticSearchConnection
	{
		IElasticClient EsClient();
	}
}
