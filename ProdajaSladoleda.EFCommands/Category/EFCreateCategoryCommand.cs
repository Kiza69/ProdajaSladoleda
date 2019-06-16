using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFCreateCategoryCommand : EFCommand, ICreateCategoryCommand
    {
        public EFCreateCategoryCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateCategoryDto request)
        {
            if (Context.Categories.Any(c => c.Name == request.Name))
                throw new EntityAlreadyExistException("Student");
            Context.Categories.Add(new Domain.Category
            {
                Name = request.Name,
                Price = request.Price
            });
            Context.SaveChanges();
        }
    }
}
