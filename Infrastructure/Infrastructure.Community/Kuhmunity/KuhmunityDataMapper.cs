using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Globalization;
using Web.Service.Models;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;

namespace Web.Service.Kuhmunity
{

    public class KuhmunityDataMapper : Profile
    {
        public KuhmunityDataMapper()
        {
            CreateMap<ParticipationViewModel, UserRegisterInput>()
                        .ForMember(dest => dest.DateOfBirth, m => m.MapFrom(
                    src => DateTime.ParseExact(src.DOB.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.MilkaEmail, m => m.MapFrom(src => src.OptinNewsletter ? "1" : "0"))
                //.ForMember(dest => dest.Mobile, m => m.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Newsletter, m => m.MapFrom(src => src.OptinNewsletter.ToString()))
                .ForMember(dest => dest.PostalCode, m => m.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Street1, m => m.MapFrom(src => src.StreetName))
                .ForMember(dest => dest.Street2, m => m.MapFrom(src => src.AddressAdditionalInfo))
                .ForMember(dest => dest.Town, m => m.MapFrom(src => src.City));
        }
    }


    //public class KuhmunityDataMapper : IDisposable
    //{
    //    public KuhmunityDataMapper()
    //    {
    //        Mapper.Reset();
    //        Mapper.Initialize(cfg =>
    //        {
    //            cfg.CreateMap<ParticipationViewModel, UserRegisterInput>()
    //                    .ForMember(dest => dest.DateOfBirth, m => m.MapFrom(
    //                src => DateTime.ParseExact(src.DOB.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")))
    //            .ForMember(dest => dest.MilkaEmail, m => m.MapFrom(src => src.OptinNewsletter ? "1" : "0"))
    //            //.ForMember(dest => dest.Mobile, m => m.MapFrom(src => src.PhoneNumber))
    //            .ForMember(dest => dest.Newsletter, m => m.MapFrom(src => src.OptinNewsletter.ToString()))
    //            .ForMember(dest => dest.PostalCode, m => m.MapFrom(src => src.PostalCode))
    //            .ForMember(dest => dest.Street1, m => m.MapFrom(src => src.StreetName))
    //            .ForMember(dest => dest.Street2, m => m.MapFrom(src => src.AddressAdditionalInfo))
    //            .ForMember(dest => dest.Town, m => m.MapFrom(src => src.City));


    //            cfg.CreateMap<ParticipationViewModel, UserRegisterInput>();
    //        });
    //    }

    //    public void Dispose()
    //    {
    //        Mapper.Reset();
    //    }

    //    //public override void ConfigureMappings(IConfiguration config, ApplicationContext applicationContext)
    //    //{
    //    //    config.CreateMap<ParticipationViewModel, UserRegisterInput>()
    //    //        .ForMember(dest => dest.DateOfBirth, m => m.MapFrom(
    //    //            src => DateTime.ParseExact(src.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")))
    //    //        .ForMember(dest => dest.MilkaEmail, m => m.MapFrom(src => src.Newletter ? "1" : "0"))
    //    //        .ForMember(dest => dest.Mobile, m => m.MapFrom(src => src.PhoneNumber))
    //    //        .ForMember(dest => dest.Newsletter, m => m.MapFrom(src => src.Newletter.ToString()))
    //    //        .ForMember(dest => dest.PostalCode, m => m.MapFrom(src => src.PostCode))
    //    //        .ForMember(dest => dest.Street1, m => m.MapFrom(src => src.Street))
    //    //        .ForMember(dest => dest.Street2, m => m.MapFrom(src => src.AdditionalAddress))
    //    //        .ForMember(dest => dest.Town, m => m.MapFrom(src => src.City));
    //    //}
    //}


    //public class KuhmunityDataMapper : MapperConfiguration
    //{
    //    public override void ConfigureMappings(IConfiguration config, ApplicationContext applicationContext)
    //    {
    //        config.CreateMap<ParticipationViewModel, UserRegisterInput>()
    //            .ForMember(dest => dest.DateOfBirth, m => m.MapFrom(
    //                src => DateTime.ParseExact(src.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")))
    //            .ForMember(dest => dest.MilkaEmail, m => m.MapFrom(src => src.Newletter ? "1" : "0"))
    //            .ForMember(dest => dest.Mobile, m => m.MapFrom(src => src.PhoneNumber))
    //            .ForMember(dest => dest.Newsletter, m => m.MapFrom(src => src.Newletter.ToString()))
    //            .ForMember(dest => dest.PostalCode, m => m.MapFrom(src => src.PostCode))
    //            .ForMember(dest => dest.Street1, m => m.MapFrom(src => src.Street))
    //            .ForMember(dest => dest.Street2, m => m.MapFrom(src => src.AdditionalAddress))
    //            .ForMember(dest => dest.Town, m => m.MapFrom(src => src.City));
    //    }
    //}
}