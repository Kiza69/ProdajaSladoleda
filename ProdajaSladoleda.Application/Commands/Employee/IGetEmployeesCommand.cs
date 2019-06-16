using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Employee
{
    public interface IGetEmployeesCommand : ICommand<EmployeeSearch, PagedResponse<EmployeeDto>>
    {
    }
}
