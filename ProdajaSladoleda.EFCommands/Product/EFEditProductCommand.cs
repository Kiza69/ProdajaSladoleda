using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.EFCommands.Product
{
    public class EFEditProductCommand : EFCommand, IEditProductCommand
    {
        public EFEditProductCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateProductDto request)
        {
            var product = Context.Products.Find(request.ProductId);
            if (product == null)
                throw new EntityNotFoundException("Product");
            product.Name = request.Name;
            product.CategoryId = request.CategoryId;
            product.Description = request.Description;
            product.Filename = request.Filename;
            product.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
