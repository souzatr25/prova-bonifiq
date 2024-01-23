using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class ProductService : IServices<ProductList>
	{
		TestDbContext _ctx;


		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

        public ProductList ListEntity(int page)
        {
			int totalCount = 10;
            int skipCount = (page - 1) * totalCount;
            var products = _ctx.Products.Skip(skipCount).Take(totalCount).ToList();
            bool hasNext = _ctx.Products.Count() > skipCount + totalCount;

            return new ProductList() { HasNext = hasNext, TotalCount = _ctx.Products.Count(), Products = products };
        }
       

	}
}
