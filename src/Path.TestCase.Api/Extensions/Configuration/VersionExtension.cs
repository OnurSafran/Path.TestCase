using Microsoft.Extensions.DependencyInjection;
using Path.TestCase.Api.Filters;

namespace Path.TestCase.Api.Extensions.Configuration {
	public static class VersionExtension {
		public static void CustomAddVersionedApiExplorer(this IServiceCollection services) {
			services.AddVersionedApiExplorer(
				options => {
					//The format of the version added to the route URL  
					options.GroupNameFormat = "'v'VVV";
					//Tells swagger to replace the version in the controller route  
					options.SubstituteApiVersionInUrl = true;
				});
			
			services.AddSwaggerGen(options => { options.OperationFilter<SwaggerDefaultValues>(); });
		}
	}
}