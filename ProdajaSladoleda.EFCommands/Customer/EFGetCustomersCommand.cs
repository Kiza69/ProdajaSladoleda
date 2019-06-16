using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Customer
{
    public class EFGetCustomersCommand : EFCommand, IGetCustomersCommand
    {
        public EFGetCustomersCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public PagedResponse<CustomerDto> Execute(CustomerSearch request)
        {
            var customers = Context.Customers.Include(c => c.User).AsQueryable();

            if (request.Keyword != null)
                customers = customers.Where(c => c.FirstName.ToLower().Contains(request.Keyword.ToLower())
                || c.LastName.ToLower().Contains(request.Keyword.ToLower()) || c.Address.ToLower().Contains(request.Keyword.ToLower())
                || c.Email.ToLower().Contains(request.Keyword.ToLower()) || c.Phone.ToLower().Contains(request.Keyword.ToLower()));
            if (request.IsActive.HasValue)
                customers = customers.Where(c => c.Active == request.IsActive);

            var totalCounts = customers.Count();
            var pagesCounts = (int)Math.Ceiling((double)totalCounts / request.PerPage);

            customers = customers.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var response = new PagedResponse<CustomerDto> {
                TotalCount = totalCounts,
                PagesCount = pagesCounts,
                CurrentPage = request.PageNumber,
                Data = customers.Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Phone = c.Phone,
                    Email = c.Email,
                    UserId = c.UserId,
                    Active = c.Active,
                    User = new UserDto
                    {
                        UserId = c.User.UserId,
                        Username = c.User.Username
                    }
                })
        };
            return response;
        }
    }
}
