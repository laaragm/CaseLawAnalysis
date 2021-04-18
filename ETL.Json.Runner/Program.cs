using ETL.Json.Models;
using ETL.Json.Runner.Settings;
using ETL.Json.Services;
using Infra.CaseLaw;
using Infra.CaseLaw.Abstractions;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ETL.Json.Runner
{
	public class Program
	{
		private static IAppSettings AppSettings { get; set; }
		static void Main(string[] args)
		{
			Startup();
			var provider = GetServices().BuildServiceProvider();

			var dataSaver = new DataSaverService(provider.GetService<IJudmentDocuments>(), provider.GetService<IMinisters>(), provider.GetService<IParties>(), provider.GetService<IVotes>());
			var data = new DataLoaderService().Load(AppSettings.File);
			dataSaver.Save(data);
		}

		private static void Startup()
		{
			AppSettings = new AppSettingsReader().Read();
		}

		private static IServiceCollection GetServices()
			=> new ServiceCollection()
				.AddScoped<IInfraConfig>(x => new InfraConfig(AppSettings.ConnectionString))
				.AddScoped<IJudmentDocuments, JudmentDocuments>()
				.AddScoped<IMinisters, Ministers>()
				.AddScoped<IParties, Parties>()
				.AddScoped<IVotes, Votes>();
	}
}
