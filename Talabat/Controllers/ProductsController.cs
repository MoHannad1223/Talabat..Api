using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositoiries;
using Talabat.Core.Specifications;
using Talabat.DTO;

namespace Talabat.Controllers
{
	
	public class ProductsController : APIBaaseController
	{
		private readonly IGenaricRepository<Product> _productRepo;
		private readonly IMapper _mapper;

		public ProductsController(IGenaricRepository<Product> productRepo,IMapper mapper)
		{
			_productRepo = productRepo;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>>GetProducts()
		{
			var Spec=new ProductWithBrandAndTypeSpecification();
			var products = await _productRepo.GetAllWithSpecAsync(Spec);
			var MappedProduct=_mapper.Map<IEnumerable< Product>,IEnumerable< ProductToReturnDto>>(products);
			//OkObjectResult result=new OkObjectResult(products);
			//return (result);
			return Ok(MappedProduct);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var Spec=new ProductWithBrandAndTypeSpecification(id);
			var product = await _productRepo.GetByIdWithSpecAsync(Spec);
			var MappedProducts = _mapper.Map<Product, ProductToReturnDto>(product);
			return Ok(MappedProducts);
		
		}
	}
}
