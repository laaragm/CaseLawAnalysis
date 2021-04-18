using Elasticsearch.Net;
using Nest;
using System;
using System.Configuration;

namespace ElasticSearch.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			var nodes = new Uri[] { new Uri("http://localhost:9200/") };
			var connectionPool = new StaticConnectionPool(nodes);
			var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
			var elasticClient = new ElasticClient(connectionSettings);
		}
	}
}
