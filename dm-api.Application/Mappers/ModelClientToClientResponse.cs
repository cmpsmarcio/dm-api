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
    public class ModelClientToClientResponse: Profile
    {
        public ModelClientToClientResponse()
        {
            MapClientResponse();
        }

        private void MapClientResponse()
        {
            CreateMap<Client, ClientResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(x => x.MobilePhone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt));
        }
    }
}
