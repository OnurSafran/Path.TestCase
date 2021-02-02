using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Path.TestCase.Application.Cache;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Infrastructure.Cache;
using Path.TestCase.Infrastructure.Cache.Base;
using Path.TestCase.Infrastructure.Data;
using Path.TestCase.Infrastructure.Interfaces;
using Path.TestCase.Infrastructure.Repository;

namespace Path.TestCase.Api.Extensions.Configuration {
	public static class SetupExtension {
		public static void DbSetup(this IServiceCollection services, IConfiguration configuration) {
			services.AddDbContext<ChatContext>(opt =>
				opt.UseNpgsql(
					configuration.GetConnectionString("PostgresConnection"),
					opt => opt.MigrationsAssembly("Path.TestCase.Infrastructure"))
			);

			services.AddScoped<DbContext, ChatContext>();

			services.AddScoped<IConnectionRepository, ConnectionRepository>();
			services.AddScoped<IRoomMessageRepository, RoomMessageRepository>();
			services.AddScoped<IRoomRepository, RoomRepository>();
		}

		public static void CacheSetup(this IServiceCollection services, IConfiguration configuration) {
			services.AddStackExchangeRedisCache(action => {
				action.Configuration = configuration.GetConnectionString("REDIS_URL");
			});

			services.AddScoped<ICacheDatabase, CacheDatabase>();
			services.AddScoped<IChatCacheModule, ChatCacheModule>();
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