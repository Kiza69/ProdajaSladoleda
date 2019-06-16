using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Employee
{
    public class EFGetEmployeeCommand : EFCommand, IGetEmployeeCommand
    {
        public EFGetEmployeeCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public EmployeeDto Execute(int request)
        {
            var employee = Context.Employees.Where(e => e.EmployeeId == request)
                                            .Include(e => e.User)
                                            .FirstOrDefault();
            if (employee == null)
                throw new EntityNotFoundException("Employee");
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                HireDate = employee.HireDate,
                UserId = employee.UserId,
                Active = employee.Active,
                User = new UserDto
                {
                    UserId = employee.User.UserId,
                    Username = employee.User.Username
                }
            };
        }
    }
}
