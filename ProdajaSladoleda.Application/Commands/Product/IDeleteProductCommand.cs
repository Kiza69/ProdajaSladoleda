using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Product
{
    public interface IDeleteProductCommand : ICommand<int>
    {
    }
}
