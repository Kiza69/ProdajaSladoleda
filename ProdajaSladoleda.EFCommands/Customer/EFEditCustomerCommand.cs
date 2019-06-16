using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Customer
{
    public class EFEditCustomerCommand : EFCommand, IEditCustomerCommand
    {
        public EFEditCustomerCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateCustomerDto request)
        {
            var customer = Context.Customers.Find(request.CustomerId);
            if (customer == null)
                throw new EntityNotFoundException("Customer");
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Address = request.Address;
            customer.Phone = request.Phone;
            customer.Email = request.Email;
            customer.UserId = request.UserId;
            customer.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
