using Elasticsearch.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.API.Config
{
	public class ElasticSearchConnection : IElasticSearchConnection
	{
		private IWebHostEnvironment Environment { get; set; }
		public ElasticSearchConnection(IWebHostEnvironment _environment)
		{
			Environment = _environment;
		}

		public IElasticClient EsClient()
		{
			var configuration = new ConfigurationBuilder()
							.SetBasePath(Environment.ContentRootPath)
							.AddJsonFile("appsettings.json")
							.Build();
			var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:uri"]));

			var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];

			if (!string.IsNullOrEmpty(defaultIndex))
				settings = settings.DefaultIndex(defaultIndex);

			var basicAuthUser = configuration["ElasticsearchSettings:username"];
			var basicAuthPassword = configuration["ElasticsearchSettings:password"];

			if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
				settings = settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

			var client = new ElasticClient(settings);

			return client;
		}
	}
}
