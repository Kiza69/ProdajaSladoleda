using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdajaSladoleda.EFCommands.Category
{
    public class EFGetCategoryDLLCommand : EFCommand, IGetCategoryDLLCommand
    {
        public EFGetCategoryDLLCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public IEnumerable<DDLCatedoryDto> Execute(DDL request)
        {
            var categories = Context.Categories.Where(c => c.Active == true).AsQueryable();
            return categories.Select(c => new DDLCatedoryDto
            {
                Id = c.CategoryId,
                Name = c.Name
            });
        }
    }
}
