using AutoMapper;
using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //start registering object mapping
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Address, src => src.MapFrom(m => m.UserProfile.Address))
                .ForMember(x => x.FirstName, src => src.MapFrom(m => m.UserProfile.FirstName))
                .ForMember(x => x.LastName, src => src.MapFrom(m => m.UserProfile.LastName))
                .ReverseMap();
        }
    }
}
