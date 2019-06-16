using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Product
{
    public interface IEditProductCommand : ICommand<CreateProductDto>
    {
    }
}
