using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Customer
{
    public class EFDeleteCustomerCommand : EFCommand, IDeleteCustomerCommand
    {
        public EFDeleteCustomerCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var customer = Context.Customers.Find(request);
            if (customer == null)
                throw new EntityNotFoundException("Customer");
            customer.Active = false;
            Context.SaveChanges();
        }
    }
}
