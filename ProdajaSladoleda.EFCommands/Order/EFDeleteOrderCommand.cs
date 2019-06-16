using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Order
{
    public class EFDeleteOrderCommand : EFCommand, IDeleteOrderCommand
    {
        public EFDeleteOrderCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var order = Context.Orders.Find(request);
            if (order == null)
                throw new EntityNotFoundException("Order");
            order.Active = false;
            Context.SaveChanges();
        }
    }
}
