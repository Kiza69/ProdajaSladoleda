using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Employee
{
    public interface ICreateEmployeeCommand : ICommand<CreateEmployeeDto>
    {
    }
}
