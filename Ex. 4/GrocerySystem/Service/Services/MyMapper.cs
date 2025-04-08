using AutoMapper;
using Repository.Entities;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MyMapper: Profile
    {
        public MyMapper()
        {
            CreateMap<Merchandise, MerchandiseDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<SupplierMerchandise, SupplierMerchandiseDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
