using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Product
{
    public class EFGetProductsCommand : EFCommand, IGetProductsCommand
    {
        public EFGetProductsCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public IEnumerable<ProductDto> Execute(ProductSearch request)
        {
            var products = Context.Products.Include(p => p.OrderDetails).Include(p => p.Category).AsQueryable();

            if (request.Keyword != null)
                products = products.Where(p => p.Name.ToLower().Contains(request.Keyword.ToLower())
                || p.Description.ToLower().Contains(request.Keyword.ToLower()));
            if (request.CategoryId != 0)
                products = products.Where(p => p.Category.CategoryId == request.CategoryId);
            if (request.IsActive.HasValue)
                products = products.Where(p => p.Active == request.IsActive);

            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Filename = p.Filename,
                Active = p.Active,
                Category = new CategoryDto {
                    CategoryId = p.Category.CategoryId,
                    Name = p.Category.Name,
                    Price = p.Category.Price,
                    Active = p.Category.Active
                },
                OrderDetails = p.OrderDetails.Select(od => new OrderDetailDto {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    Active = od.Active
                })
            });
        }
    }
}
