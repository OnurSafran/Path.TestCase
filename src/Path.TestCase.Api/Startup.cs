using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Path.TestCase.Api.Extensions.Application;
using Path.TestCase.Api.Extensions.Configuration;
using Path.TestCase.Api.Filters;
using Path.TestCase.Api.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Path.TestCase.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			// Filter
			services.AddControllers(opts => { opts.Filters.Add(typeof(ModelStateFilter), int.MinValue); });
			
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
			// Versioning
			services.VersioningSetup();
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

			// global cors policy
			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials
			
			// app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}