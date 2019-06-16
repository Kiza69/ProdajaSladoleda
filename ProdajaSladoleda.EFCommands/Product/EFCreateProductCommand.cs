using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Product
{
    public class EFCreateProductCommand : EFCommand, ICreateProductCommand
    {
        public EFCreateProductCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateProductDto request)
        {
            if (Context.Products.Any(p => p.Name == request.Name && p.CategoryId == request.CategoryId))
                throw new EntityAlreadyExistException("Product");
            Context.Products.Add(new Domain.Product {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Filename = request.Filename
            });
            Context.SaveChanges();
        }
    }
}
