using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Path.TestCase.Api.Extensions.Application {
	public static class SwaggerExtension {
		public static void CustomSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider) {
			app.UseSwagger();
			app.UseSwaggerUI(
				options => {
					//Build a swagger endpoint for each discovered API version  
					foreach (var description in provider.ApiVersionDescriptions) {
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
							description.GroupName.ToUpperInvariant());
					}
				});
		}

	}
}