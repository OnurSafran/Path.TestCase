using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;
using Path.TestCase.Core.Models.Entities;
using Path.TestCase.Infrastructure.Data;

namespace Path.TestCase.Api.Extensions.Host {
	public static class SeedDataExtension {
		public static IHost SeedData(this IHost host) {
			using (var scope = host.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				var chatContext = scope.ServiceProvider.GetService<ChatContext>();
				var chatCacheModule = scope.ServiceProvider.GetService<IChatCacheModule>();


				List<CacheRoom> cacheRooms = chatCacheModule.GetActiveRooms();

				// If rooms exist
				if (cacheRooms == default(List<CacheRoom>)) {
					cacheRooms = new List<CacheRoom> {
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


				// Migration
				chatContext.Database.Migrate();

				// Add Rooms If doesnt exist
				var anyRoom = chatContext.Rooms.AnyAsync(p => !p.Deleted).Result;
				if (!anyRoom) {
					cacheRooms.ForEach(r => chatContext.Rooms.Add(new Room() {
						Id = Guid.NewGuid(), Messages = new List<RoomMessage>(), RoomId = r.RoomId, Title = r.Title
					}));
				}

				chatContext.SaveChanges();
			}

			return host;
		}
	}
}