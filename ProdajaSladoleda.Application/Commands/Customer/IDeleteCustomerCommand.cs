using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Customer
{
    public interface IDeleteCustomerCommand : ICommand<int>
    {
    }
}
