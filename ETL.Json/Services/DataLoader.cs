using ETL.Json.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ETL.Json.Services
{
	public class DataLoader
	{
		public JudmentDocumentModel Load(string fileName)
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				string json = reader.ReadToEnd();
				JudmentDocumentModel data = JsonConvert.DeserializeObject<JudmentDocumentModel>(json);
				return data;
			}
		}
	}
}
