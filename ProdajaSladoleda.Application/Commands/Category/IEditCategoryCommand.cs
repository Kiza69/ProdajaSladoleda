using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProdajaSladoleda.Application.Commands.Category
{
    public interface IEditCategoryCommand : ICommand<CategoryDto>
    {
    }
}
