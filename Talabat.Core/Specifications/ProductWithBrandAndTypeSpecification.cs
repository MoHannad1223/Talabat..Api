using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
	public class ProductWithBrandAndTypeSpecification:BaseSpecifiction<Product>
	{
        //ctor for Get All products
        public ProductWithBrandAndTypeSpecification():base()
        {
            Includes.Add(p => p.ProductType);
			Includes.Add(p => p.ProductBrand);
		//	Includes.Add(p => p.Id);
		}
        public ProductWithBrandAndTypeSpecification(int id):base(p=>p.Id==id)
        {
			Includes.Add(p => p.ProductType);
			Includes.Add(p => p.ProductBrand);
			//Includes.Add(p => p.Id);
		}
    }
}
