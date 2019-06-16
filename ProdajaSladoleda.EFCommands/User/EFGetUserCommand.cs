using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.User
{
    public class EFGetUserCommand : EFCommand, IGetUserCommand
    {
        public EFGetUserCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Where(u => u.UserId == request)
                                    .Include(u => u.Customer)
                                    .Include(u => u.Employee)
                                    .Include(u => u.Role)
                                    .FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("User");
            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                RoleId = user.RoleId,
                Active = user.Active,
                Role = new RoleDto
                {
                    RoleId = user.Role.RoleId,
                    Name = user.Role.Name,
                    Active = user.Role.Active
                }//,
                //Customer = new CustomerDto
                //{
                //    CustomerId = user.Customer.CustomerId,
                //    FirstName = user.Customer.FirstName,
                //    LastName = user.Customer.LastName,
                //    Active = user.Customer.Active
                //},
                //Employee = new EmployeeDto
                //{
                //    EmployeeId = user.Employee.EmployeeId,
                //    FirstName = user.Employee.FirstName,
                //    LastName = user.Employee.LastName,
                //    Active = user.Employee.Active
                //}
            };
        }
    }
}
