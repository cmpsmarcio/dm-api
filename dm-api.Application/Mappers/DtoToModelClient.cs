using AutoMapper;
using dm_api.Application.Dtos;
using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Mappers
{
    public class DtoToModelClient: Profile
    {
        public DtoToModelClient()
        {
            ClientMap();
        }

        private void ClientMap()
        {
            CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(x => x.MobilePhone))
                .ForMember(dest => dest.email, opt => opt.MapFrom(x => x.email))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
