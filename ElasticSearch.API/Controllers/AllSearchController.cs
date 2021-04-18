using ElasticSearch.API.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.API.Controllers
{
	public class AllSearchController : Controller
	{
		private readonly IElasticSearchConnection ElasticSearchConnection;
		public AllSearchController(IElasticSearchConnection elasticSearchConnection)
		{
			ElasticSearchConnection = elasticSearchConnection;
		}

		[HttpGet]
		public ActionResult Search()
		{
			return View("Search");
		}
	}
}
