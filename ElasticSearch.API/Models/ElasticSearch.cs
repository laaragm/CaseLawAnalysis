using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.API.Models
{
	public class ElasticSearch
	{
		public Uri Uri { get; set; }
		public string Index { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
