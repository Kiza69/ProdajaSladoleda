using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.User
{
    public class EFGetUsersCommand : EFCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public PagedResponse<UserDto> Execute(UserSearch request)
        {
            var users = Context.Users.Include(u => u.Customer)
                                        .Include(u => u.Employee)
                                        .Include(u => u.Role)
                                        .AsQueryable();

            if (request.Keyword != null)
                users = users.Where(u => u.Username.ToLower() == request.Keyword.ToLower());
            if (request.IsActive.HasValue)
                users = users.Where(u => u.Active == request.IsActive);

            var totalCounts = users.Count();
            var pagesCount = (int)Math.Ceiling((double)totalCounts / request.PerPage);


            users = users.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var response = new PagedResponse<UserDto>
            {
                TotalCount = totalCounts,
                PagesCount = pagesCount,
                CurrentPage = request.PageNumber,
                Data = users.Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    RoleId = u.RoleId,
                    Active = u.Active,
                    Role = new RoleDto
                    {
                        RoleId = u.Role.RoleId,
                        Name = u.Role.Name,
                        Active = u.Role.Active
                    },
                    Customer = u.Customer.Select(c => new CustomerDto
                    {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Active = c.Active,
                        UserId = c.UserId
                    }),
                    Employee = u.Employee.Select(e => new EmployeeDto
                    {
                        EmployeeId = e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Active = e.Active,
                        UserId = e.UserId
                    })
                })
            };
            return  response;
        }
    }
}
