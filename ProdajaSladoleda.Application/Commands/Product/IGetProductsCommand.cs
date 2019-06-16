using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Product
{
    public interface IGetProductsCommand : ICommand<ProductSearch, IEnumerable<ProductDto>>
    {
    }
}
