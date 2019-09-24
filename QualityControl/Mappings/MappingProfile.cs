using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quality.DAL.Entities;
using QualityControl.ViewModels;

namespace QualityControl.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.Employee, source => source.MapFrom(src => src.Employee.Surname + " " + src.Employee.Name))
                .ForMember(dest => dest.Organization, source => source.MapFrom(src => src.Organization.Name));
        }
    }
}
