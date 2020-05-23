using AutoMapper;
using BackEnd.DAL.Models;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region Secrity
            // CreateMap<ApplicationUser, IdentityUser>().ReverseMap();
            //CreateMap<ApplicationUser, UserDetailsDto>().ReverseMap();
            #endregion

            CreateMap<AdminUsersVM, AdminUsers>().ReverseMap();
            CreateMap<CarVM, Car>().ReverseMap();
            CreateMap<CityVM, City>().ReverseMap();
            CreateMap<CountryVM, Country>().ReverseMap();
            CreateMap<CustomerVM, Customer>().ReverseMap();
            CreateMap<CustomerNotificationsVM, CustomerNotifications>().ReverseMap();
            CreateMap<MalfunctionVM, Malfunction>().ReverseMap();
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<WorkshopVM, Workshop>().ReverseMap();
            CreateMap<WorkshopSVM, Workshop>().ReverseMap();
            CreateMap<WorkshopCarVM, WorkshopCar>().ReverseMap();
            CreateMap<WorkshopFeaturesVM, WorkshopFeatures>().ReverseMap();
            CreateMap<WorkshopMalfunctionVM, WorkshopMalfunction>().ReverseMap();
            CreateMap<WorkshopNotificationsVM, WorkshopNotifications>().ReverseMap();
            CreateMap<WorkshopRateVM, WorkshopRate>().ReverseMap();
            CreateMap<WorkshopNotificationsVM, WorkshopNotifications>().ReverseMap();
            CreateMap<WorkshopTechnicianVM, WorkshopTechnician>().ReverseMap();
            CreateMap<WorkshopWorkTimeVM, WorkshopWorkTime>().ReverseMap();
            CreateMap<FeaturesVM, Features>().ReverseMap();
            //CreateMap<ReportSetting, ReportSettingModel>();
            //CreateMap<ReportSettingModel, ReportSetting>()
            //     .ForMember(t => t.CurrentDate, opt => opt.MapFrom(s => DateTime.ParseExact(s.CurrentDate, "d/M/yyyy", CultureInfo.InvariantCulture)));
            //#endregion

        }
    }
}
