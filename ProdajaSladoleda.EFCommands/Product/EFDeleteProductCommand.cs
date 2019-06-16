using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Product
{
    public class EFDeleteProductCommand : EFCommand, IDeleteProductCommand
    {
        public EFDeleteProductCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);
            if (product == null)
                throw new EntityNotFoundException("Product");
            product.Active = false;
            Context.SaveChanges();
        }
    }
}
