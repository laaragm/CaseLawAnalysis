using ETL.Json.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ETL.Json.Services
{
	public class DataLoaderService
	{
		public IEnumerable<JudmentDocumentModel> Load(string fileName)
		{
			var data = new List<JudmentDocumentModel>();
			using (WebClient client = new WebClient())
			using (Stream stream = client.OpenRead(fileName))
			using (StreamReader streamReader = new StreamReader(stream))
			using (JsonTextReader reader = new JsonTextReader(streamReader))
			{
				reader.SupportMultipleContent = true;

				var serializer = new JsonSerializer();
				while (reader.Read())
				{
					if (reader.TokenType == JsonToken.StartObject)
					{
						JudmentDocumentModel judmentDocument = serializer.Deserialize<JudmentDocumentModel>(reader);
						data.Add(judmentDocument);
					}
				}
				return data;
			}
		}
	}
}
