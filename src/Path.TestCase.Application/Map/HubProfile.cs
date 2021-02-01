using AutoMapper;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.ReceiveMessageNotification;
using Path.TestCase.Application.Notifications.UserEnteredNotification;
using Path.TestCase.Application.Notifications.UserLeftNotification;

namespace Path.TestCase.Application.Map {
	public class HubProfile : Profile {
		public HubProfile() {
			CreateMap<ReceiveMessageNotification, MessageResponse>()
				.ForMember(dto => dto.Nickname,
					opt => opt.MapFrom(src => src.User.Nickname));
			CreateMap<UserEnteredNotification, UserResponse>()
				.ForMember(dto => dto.Nickname,
					opt => opt.MapFrom(src => src.User.Nickname));
			CreateMap<UserLeftNotification, UserResponse>()
				.ForMember(dto => dto.Nickname,
					opt => opt.MapFrom(src => src.User.Nickname));
		}
	}
}