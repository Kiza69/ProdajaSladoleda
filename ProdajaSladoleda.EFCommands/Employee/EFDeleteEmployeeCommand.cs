using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Employee
{
    public class EFDeleteEmployeeCommand : EFCommand, IDeleteEmployeeCommand
    {
        public EFDeleteEmployeeCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var employee = Context.Employees.Find(request);
            if (employee == null)
                throw new EntityNotFoundException("Employee");
            employee.Active = false;
            Context.SaveChanges();
        }
    }
}
