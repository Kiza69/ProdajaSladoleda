using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Customer
{
    public class EFCreateCustomerCommand : EFCommand, ICreateCustomerCommand
    {
        public EFCreateCustomerCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateCustomerDto request)
        {
            if (Context.Customers.Any(c => c.Email == request.Email))
                throw new EntityAlreadyExistException("Customer");
            Context.Customers.Add(new Domain.Customer{
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                UserId = request.UserId
            } );
            Context.SaveChanges();
        }
    }
}
