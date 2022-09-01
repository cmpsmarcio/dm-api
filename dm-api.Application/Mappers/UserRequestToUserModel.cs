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
    public class UserRequestToUserModel: Profile
    {
        public UserRequestToUserModel()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(dest => dest.Userpass, opt => opt.MapFrom(x => x.Password))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore());
        }
    }
}
