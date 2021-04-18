using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ElasticSearch.API.Config;
using Infra.CaseLaw;
using Infra.CaseLaw.Abstractions;
using Infra.CaseLaw.Abstractions.Repositories;
using Infra.CaseLaw.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nest;
using ElasticSearch.API.Models;

namespace ElasticSearch.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IInfraConfig InfraConfig { get; }
		public static string ConnectionString { get; private set; }
		public IConfigurationRoot ConfigurationRoot { get; set; }

		public Startup(IConfiguration configuration, IWebHostEnvironment _environment)
		{
			Configuration = configuration;
			ConfigurationRoot = new ConfigurationBuilder()
							.SetBasePath(_environment.ContentRootPath)
							.AddJsonFile("appsettings.json")
							.Build();
			InfraConfig = new InfraConfig(ConfigurationRoot["ConnectionString"]);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				//.AddScoped<IElasticClient, ElasticClient>()
				.AddScoped<IElasticSearchConnection, ElasticSearchConnection>()
				.AddScoped<IJudmentDocuments, JudmentDocuments>()
				.AddScoped<IMinisters, Ministers>()
				.AddScoped<IParties, Parties>()
				.AddScoped<IVotes, Votes>()
				.AddSingleton(InfraConfig)
				.AddSingleton(ConfigurationRoot);

			services.AddControllersWithViews();
			services.AddControllers();
			services.AddSwaggerGen(c => c.SwaggerDoc(name: "v1", new OpenApiInfo() { Title = "CaseLawAnalysis", Version = "v1" }));
			services.AddApiVersioning(x =>
			{
				x.DefaultApiVersion = new ApiVersion(1, 0);
				x.AssumeDefaultVersionWhenUnspecified = true;
				x.ReportApiVersions = true;
			});
			services.AddMvc((options) =>
			{
				//options.Conventions.Add(new FromBodyApplicationModelConvention());
			})
			.AddJsonOptions(c =>
			{
				c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				//c.JsonSerializerOptions.Converters.Add(new EntityConverter());
				c.JsonSerializerOptions.IgnoreNullValues = true;
				c.JsonSerializerOptions.MaxDepth = 1000;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();

			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "CaseLawAnalysis");
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
