using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Category
{
    public interface IGetCategoryCommand : ICommand<int, CategoryDto >
    {
    }
}
