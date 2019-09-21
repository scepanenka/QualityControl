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
//                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
//                .ForMember(dest => dest.Number, source => source.MapFrom(src => src.Number))
//                .ForMember(dest => dest.DateReceipt, source => source.MapFrom(src => src.DateReceipt))
//                .ForMember(dest => dest.DateExecution, source => source.MapFrom(src => src.DateExecution));
        }
    }
}
