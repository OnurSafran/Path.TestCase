using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Path.TestCase.Api.Extensions.Application;
using Path.TestCase.Api.Extensions.Configuration;
using Path.TestCase.Api.Filters;
using Path.TestCase.Api.Middlewares;
using Path.TestCase.Api.Options;
using Path.TestCase.Application.CQRS.Command.Handler;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Core.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Path.TestCase.Api {
	public class Startup {
		public Startup(IConfiguration configuration, IWebHostEnvironment env) {
			Configuration = new ConfigurationBuilder()
				.AddConfiguration(configuration)
				.AddEnvironmentVariables()
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

			services.AddCors(options => {
				options
					.AddPolicy("ChatApp", builder => builder
						.WithOrigins("http://localhost:4200")
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials());
			});

			// Versioning
			services.VersioningSetup();

			// Add AutoMapper SORUN ÇIKARTTI
			//services.AddAutoMapper(typeof(CacheProfile));

			// Add MediatR
			services.AddMediatR(typeof(SendMessageHandler));

			// Redis
			services.CacheSetup(Configuration);

			// Postgres
			services.DbSetup(Configuration);

			// Add SignalR with Redis scale out	
			services.AddSignalR().AddStackExchangeRedis(Configuration.GetConnectionString("REDIS_URL"));

			// Add Controller Endpoints
			services.AddControllers(opts => { opts.Filters.Add(typeof(ModelStateFilter), int.MinValue); });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
			IApiVersionDescriptionProvider provider) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.CustomSwagger(provider);

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseStaticFiles();

			app.UseCors("ChatApp");

			app.UseAuthorization();

			app.UseMiddleware<ResponseMiddleware>();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
				endpoints.MapHub<ChatHub>("/chatHub");
			});
		}
	}
}