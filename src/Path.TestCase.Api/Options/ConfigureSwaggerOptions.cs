using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Path.TestCase.Api.Options {
	public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions> {
		private readonly IApiVersionDescriptionProvider _provider;

		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

		public void Configure(SwaggerGenOptions options) {
			// add a swagger document for each discovered API version
			// note: you might choose to skip or document deprecated API versions differently
			foreach (var description in _provider.ApiVersionDescriptions) {
				options.SwaggerDoc(description.GroupName,
					new OpenApiInfo() {
						Title =
							$"{this.GetType().Assembly.GetCustomAttribute<System.Reflection.AssemblyProductAttribute>()?.Product} {description.ApiVersion}",
						Version = description.ApiVersion.ToString(),
						Description = description.IsDeprecated
							? $"{this.GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description} - DEPRECATED"
							: this.GetType().Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()
								?.Description,
					});
			}
		}

		private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description) {
			var info = new OpenApiInfo() {Title = "Sample API", Version = description.ApiVersion.ToString(),};

			if (description.IsDeprecated) {
				info.Description += " This API version has been deprecated.";
			}

			return info;
		}
	}
}