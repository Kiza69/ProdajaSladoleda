using ProdajaSladoleda.Application.DataTransfer;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProdajaSladoleda.Application.Commands.Product
{
    public interface ICreateProductCommand : ICommand<CreateProductDto>
    {
    }
}
