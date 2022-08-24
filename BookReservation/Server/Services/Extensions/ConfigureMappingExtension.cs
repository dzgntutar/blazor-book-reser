using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos.Book;
using BookReservation.Shared.Dtos.User;

namespace BookReservation.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                AllowNullDestinationValues = true;
                AllowNullCollections = true;

                CreateMap<Book, BookGetAllDto>();
                CreateMap<Book, BookGetByIdDto>();

                CreateMap<User, UserGetAllResponseDto>();
                CreateMap<User, UserGetByIdResponseDto>();
                CreateMap<User, UserSaveRequestDto>().ReverseMap();
                CreateMap<User, UserSaveResponseDto>().ReverseMap();

                CreateMap<UserUpdateRequestDto, User>()
                                                       .ForMember(s => s.FirstName,m => m.MapFrom(n => n.FirstName))
                                                       .ForMember(s => s.LastName, m => m.MapFrom(n => n.LastName))
                                                       .ForMember(s => s.UserName, m => m.MapFrom(n => n.UserName));

                CreateMap<User, UserUpdateResponseDto>().ReverseMap();
            }
        }
    }
}
