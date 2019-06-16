using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using System.Collections.Generic;
using System.Linq;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFGetCategoriesCommand : EFCommand, IGetCategoriesCommand
    {
        public EFGetCategoriesCommand(ProdajaSladoledaContext context) : base(context)
        {

        }
        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = Context.Categories.Include(c => c.Products).AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(c => c.Name.ToLower()
                                .Contains(request.Keyword.ToLower()));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(c => c.Active == request.IsActive);
            }
            return query.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Price = c.Price,
                Active = c.Active,
                Products = c.Products.Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Description = p.Description,
                    Filename = p.Filename,
                    Active = p.Active
                })
            }) ;
        }
    }
}
