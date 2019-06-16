using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFDeleteCategoryCommand : EFCommand, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if (category == null)
                throw new EntityNotFoundException("Category");
            category.Active = false;
            Context.SaveChanges();
        }
    }
}
