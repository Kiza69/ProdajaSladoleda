using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Employee
{
    public interface IDeleteEmployeeCommand : ICommand<int>
    {
    }
}
