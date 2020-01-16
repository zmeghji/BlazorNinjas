using ApiModels;
using AutoMapper;
using NinjasApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjasApi.Mappers
{
    public class NinjaProfile : Profile
    {
        public NinjaProfile()
        {
            CreateMap<Ninja, NinjaApiModel>();
            CreateMap<NinjaApiModel, Ninja>();
        }
    }
}
