using AutoMapper;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.ReceiveMessageNotification;
using Path.TestCase.Application.Notifications.UserConnectedNotification;
using Path.TestCase.Application.Notifications.UserLeftNotification;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.Map {
	public class ResponseProfile : Profile {
		public ResponseProfile() {
			CreateMap<UserLeftNotification, UserResponse>();
			CreateMap<UserConnectedNotification, UserResponse>();
			CreateMap<CacheMessage, MessageResponse>();
		}
	}
}