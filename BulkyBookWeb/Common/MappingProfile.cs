using AutoMapper;
using BulkyBookWeb.Models;
using BulkyBookWeb.ViewModels;

namespace BulkyBookWeb.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
           
        }
    }
}
