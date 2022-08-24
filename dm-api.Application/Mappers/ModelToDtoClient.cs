using AutoMapper;
using dm_api.Application.Dtos;
using dm_api.Domain.Entities;

namespace dm_api.Application.Mappers
{
    public class ModelToDtoClient : Profile
    {
        public ModelToDtoClient()
        {
            ClientDtoMap();
        }

        private void ClientDtoMap()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(x => x.MobilePhone))
                .ForMember(dest => dest.email, opt => opt.MapFrom(x => x.email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt));
        }
    }
}
