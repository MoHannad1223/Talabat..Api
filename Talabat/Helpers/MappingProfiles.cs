using AutoMapper;
using Talabat.Core.Entities;
using Talabat.DTO;

namespace Talabat.Helpers
{
	public class MappingProfiles:Profile
	{
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                     .ForMember(d=>d.ProductType,O=>O.MapFrom(s=>s.ProductType.Name))
                     .ForMember(d => d.ProductBrand, O => O.MapFrom(s => s.ProductBrand.Name))
                     .ForMember(d=>d.PictureUrl,O=>O.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
