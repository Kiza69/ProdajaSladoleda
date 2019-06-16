using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFGetCategoryCommand : EFCommand, IGetCategoryCommand
    {
        public EFGetCategoryCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.
                Where(c => c.CategoryId == request).
                Include(c => c.Products).
                FirstOrDefault();
            if (category == null)
                throw new EntityNotFoundException("Category");
            return new CategoryDto {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Price = category.Price,
                Active = category.Active,
                Products = category.Products.Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Description = p.Description,
                    Filename = p.Filename,
                    Active = p.Active
                })
            };
        }
    }
}

