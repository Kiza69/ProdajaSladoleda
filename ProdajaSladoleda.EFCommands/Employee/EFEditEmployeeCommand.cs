using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Employee
{
    public class EFEditEmployeeCommand : EFCommand, IEditEmployeeCommand
    {
        public EFEditEmployeeCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateEmployeeDto request)
        {
            var employee = Context.Employees.Find(request.EmployeeId);
            if (employee == null)
                throw new EntityNotFoundException("Employee");
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Address = request.Address;
            employee.Phone = request.Phone;
            employee.Email = request.Email;
            employee.HireDate = request.HireDate;
            employee.UserId = request.UserId;
            employee.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
