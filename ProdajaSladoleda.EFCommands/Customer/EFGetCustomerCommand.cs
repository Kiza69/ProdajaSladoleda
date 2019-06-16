using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Customer
{
    public class EFGetCustomerCommand : EFCommand, IGetCustomerCommand
    {
        public EFGetCustomerCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public CustomerDto Execute(int request)
        {
            var customer = Context.Customers.Where(c => c.CustomerId == request)
                                            .Include(c => c.User)
                                            .FirstOrDefault();
            if (customer == null)
                throw new EntityNotFoundException("Customer");
            return new CustomerDto {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                UserId = customer.UserId,
                Active = customer.Active,
                User = new UserDto
                {
                    UserId = customer.User.UserId,
                    Username = customer.User.Username
                }
            };
        }
    }
}
