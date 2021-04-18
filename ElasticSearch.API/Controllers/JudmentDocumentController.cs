using Domain;
using ElasticSearch.API.Config;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Repositories;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.API.Controllers
{
	[ApiVersion("1.0")]
	[Route("v{version:apiVersion}/[controller]")]
	[ApiController]
	public class JudmentDocumentController : Controller
	{
		private readonly IElasticSearchConnection ElasticSearchConnection;
		private IElasticClient ElasticClient { get; set; }
		IJudmentDocuments JudmentDocuments { get; set; }

		public JudmentDocumentController(IElasticSearchConnection elasticSearchConnection, IJudmentDocuments judmentDocuments)
		{
			ElasticSearchConnection = elasticSearchConnection;
			ElasticClient = ElasticSearchConnection.EsClient();
			JudmentDocuments = judmentDocuments;
		}

		[HttpPost]
		public void PostJudmentDocument()
		{
			var all = JudmentDocuments.All();
			var descriptor = new BulkDescriptor();

			if (!ElasticClient.Indices.Exists(nameof(JudmentDocument).ToLower()).Exists)
				ElasticClient.Indices.Create(nameof(JudmentDocument).ToLower());

			ElasticClient.IndexMany<JudmentDocument>(all);
			var insert = ElasticClient.Bulk(descriptor);
			if (!insert.IsValid)
				throw new Exception(insert.OriginalException.ToString());
		}

		[HttpGet("All")]
		public ICollection<JudmentDocument> GetAll()
		{
			var result = ElasticClient.Search<JudmentDocument>(s => s
				.Index(nameof(JudmentDocument).ToLower())
				.MatchAll()).Documents.ToList();

			return result;
		}
	}
}
