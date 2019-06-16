using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Employee
{
    public class EFCreateEmployeeCommand : EFCommand, ICreateEmployeeCommand
    {
        public EFCreateEmployeeCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateEmployeeDto request)
        {
            if (Context.Employees.Any(c => c.Email == request.Email))
                throw new EntityAlreadyExistException("Employee");
            Context.Employees.Add(new Domain.Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                HireDate = DateTime.Now,
                UserId = request.UserId
            });
            Context.SaveChanges();
        }
    }
}
