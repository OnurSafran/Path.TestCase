using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Api.Extensions.Host {
	public static class SeedDataExtension {
		public static IHost SeedData(this IHost host) {
			using (var scope = host.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				var chatCacheModule = scope.ServiceProvider.GetService<IChatCacheModule>();

				if (chatCacheModule.GetActiveRooms() == default(List<CacheRoom>)) {
					List<CacheRoom> cacheRooms = new List<CacheRoom> {
						new CacheRoom() {
							RoomId = Guid.NewGuid().ToString(), Messages = new List<CacheMessage>(), Title = "Room1"
						},
						new CacheRoom() {
							RoomId = Guid.NewGuid().ToString(), Messages = new List<CacheMessage>(), Title = "Room2"
						},
						new CacheRoom() {
							RoomId = Guid.NewGuid().ToString(),
							Messages = new List<CacheMessage>(),
							Title = "Onurun Özel Odası :)"
						}
					};

					// Set Each Room
					cacheRooms.ForEach(r => chatCacheModule.SetRoom(r));

					// Set Room List
					chatCacheModule.SetActiveRooms(cacheRooms);
				}
			}

			return host;
		}
	}
}