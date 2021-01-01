using ETL.Json.Services;
using System;

namespace ETL.Json.Runner
{
	public class Program
	{
		static void Main(string[] args)
		{
			DataLoader dataLoader = new DataLoader();
			var data = dataLoader.Load(@"C:\Users\larag\OneDrive\Área de Trabalho\IC\DocumentosAcordaos.json");
		}
	}
}
