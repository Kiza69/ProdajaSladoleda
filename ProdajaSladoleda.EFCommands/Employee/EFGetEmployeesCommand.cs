using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Employee
{
    public class EFGetEmployeesCommand : EFCommand, IGetEmployeesCommand
    {
        public EFGetEmployeesCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public PagedResponse<EmployeeDto> Execute(EmployeeSearch request)
        {
            var employees = Context.Employees.Include(c => c.User).AsQueryable();

            if (request.Keyword != null)
                employees = employees.Where(e => e.FirstName.ToLower().Contains(request.Keyword.ToLower())
                || e.LastName.ToLower().Contains(request.Keyword.ToLower()) || e.Address.ToLower().Contains(request.Keyword.ToLower())
                || e.Email.ToLower().Contains(request.Keyword.ToLower()) || e.Phone.ToLower().Contains(request.Keyword.ToLower()));
            if (request.IsActive.HasValue)
                employees = employees.Where(e => e.Active == request.IsActive);

            var totalCounts = employees.Count();
            var pagesCount = (int)Math.Ceiling((double)totalCounts / request.PerPage);


            employees = employees.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var response = new PagedResponse<EmployeeDto>
            {
                TotalCount = totalCounts,
                PagesCount = pagesCount,
                CurrentPage = request.PageNumber,
                Data = employees.Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Email = e.Email,
                    HireDate = e.HireDate,
                    UserId = e.UserId,
                    Active = e.Active,
                    User = new UserDto
                    {
                        UserId = e.User.UserId,
                        Username = e.User.Username
                    }
                })
            };
            return response;
        }
    }
}
