using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAI.API.Models.InputModels.Products;
using TNAI.API.Models.OutputModel.Products;
using TNAI.Model.Entitites;

namespace TNAI.API.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductInputModel, Product>().ForMember(x => x.Id, d=>d.Ignore()).ForMember(x=>x.Category,d=>d.Ignore());
            CreateMap<Product, ProductOutputModel>().ForMember(x => x.CategoryName,
                d => d.MapFrom(s => s.Category.Name));
        }
        
    }
}