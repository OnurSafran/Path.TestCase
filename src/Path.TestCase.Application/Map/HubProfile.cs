using AutoMapper;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.ReceiveMessageNotification;
using Path.TestCase.Application.Notifications.UserEnteredNotification;
using Path.TestCase.Application.Notifications.UserLeftNotification;

namespace Path.TestCase.Application.Map {
	public class HubProfile : Profile {
		public HubProfile() {
			CreateMap<ReceiveMessageNotification, MessageResponse>();
			CreateMap<UserEnteredNotification, UserResponse>();
			CreateMap<UserLeftNotification, UserResponse>();
		}
	}
}