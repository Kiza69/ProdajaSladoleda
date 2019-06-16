using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Category
{
    public interface IGetCategoryDLLCommand : ICommand<DDL, IEnumerable<DDLCatedoryDto>>
    {
    }
}
