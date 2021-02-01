using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Path.TestCase.Api.Extensions.Host {
	public static class SeedDataExtension {
		public static IHost SeedData(this IHost host) {
			using (var scope = host.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				// var context = scope.ServiceProvider.GetService<CSContext>();
				// var cacheDatabase = scope.ServiceProvider.GetService<ICacheDatabase>();
			}

			return host;
		}
	}
}