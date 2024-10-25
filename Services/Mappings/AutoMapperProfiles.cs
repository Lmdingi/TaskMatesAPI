using AutoMapper;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEntity = DataAccess.Entity;

namespace Services.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DEntity.DemoEmailList, DemoEmailList>().ReverseMap();
        }
    }
}
