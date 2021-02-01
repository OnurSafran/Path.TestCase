using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Path.TestCase.Api.Extensions.Configuration {
	public static class SetupExtension {
		public static void DbSetup(this IServiceCollection services, IConfiguration configuration) {
			// services.AddEntityFrameworkNpgsql().AddDbContext<CSContext>(opt =>
			// 	opt.UseNpgsql(
			// 		configuration.GetConnectionString("PostgresConnection"),
			// 		opt => opt.MigrationsAssembly("Infrastructure"))
			// );
			//
			// services.AddScoped<DbContext, CSContext>();
			//
			// services.AddScoped<IUserRepository, UserRepository>();
			// services.AddScoped<IProductRepository, ProductRepository>();
			// services.AddScoped<ICartRepository, CartRepository>();
			// services.AddScoped<ICartItemRepository, CartItemRepository>();
		}

		public static void CacheSetup(this IServiceCollection services, IConfiguration configuration) {
			// services.AddStackExchangeRedisCache(action => {
			// 	action.Configuration = configuration.GetConnectionString("REDIS_URL");
			// });
			//
			// services.AddScoped<ICacheDatabase, CacheDatabase>();
		}

		public static void VersioningSetup(this IServiceCollection services) {
			services.CustomAddVersionedApiExplorer();
			services.AddApiVersioning(cfg => {
				cfg.DefaultApiVersion = new ApiVersion(1, 0);
				cfg.AssumeDefaultVersionWhenUnspecified = true;
				//cfg.ErrorResponses
			});
			services.AddApiVersioning(options => options.ReportApiVersions = true);
		}
	}
}