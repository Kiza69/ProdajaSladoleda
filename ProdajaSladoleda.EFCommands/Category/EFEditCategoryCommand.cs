using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFEditCategoryCommand : EFCommand, IEditCategoryCommand
    {
        public EFEditCategoryCommand(ProdajaSladoledaContext context) : base(context)
        {
        }


        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.CategoryId);
            if (category == null)
                throw new EntityNotFoundException("Category");
            category.Name = request.Name;
            category.Price = request.Price;
            category.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
