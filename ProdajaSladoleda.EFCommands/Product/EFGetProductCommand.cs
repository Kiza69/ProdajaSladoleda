using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Product
{
    public class EFGetProductCommand : EFCommand, IGetProductCommand
    {
        public EFGetProductCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.Products.Where(p => p.ProductId == request).
                                            Include(p => p.Category).
                                            Include(p => p.OrderDetails).
                                            FirstOrDefault();
            if (product == null)
                throw new EntityNotFoundException("Product");
            return new ProductDto {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Filename = product.Filename,
                Active = product.Active,
                Category = new CategoryDto
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name,
                    Price = product.Category.Price,
                    Active = product.Category.Active
                },
                OrderDetails = product.OrderDetails.Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    Active = od.Active
                })
            };
        }   
    }
}
