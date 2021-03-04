using AutoMapper;
using moreDevelopment.Data;
using moreDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moreDevelopment.Web.App_Start
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<products, productsViewModel>().ReverseMap();
            CreateMap<invoices, createInvoiceViewModel>().ReverseMap();
            CreateMap<invoices, invoiceViewModel>().ReverseMap();
            CreateMap<invoiceProducts, productsViewModel>().ReverseMap();
        }
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperProfile>();
            });
        }
    }
}