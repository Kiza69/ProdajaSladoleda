using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Order
{
    public interface IDeleteOrderCommand : ICommand<int>
    {
    }
}
