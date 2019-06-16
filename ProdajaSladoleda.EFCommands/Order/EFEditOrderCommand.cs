using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Order
{
    public class EFEditOrderCommand : EFCommand, IEditOrderCommand
    {
        public EFEditOrderCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateOrderDto request)
        {
            var order = Context.Orders.Find(request.OrderId);
            if (order == null)
                throw new EntityNotFoundException("Order");
            if (!Context.Orders.Any(o => o.CustomerId == request.CustomerId))
                throw new EntityNotFoundException("Customer");
            if (!Context.Orders.Any(o => o.EmployeeId == request.EmployeeId))
                throw new EntityNotFoundException("Employee");

            order.CustomerId = request.CustomerId;
            order.OrderDate = request.OrderDate;
            order.ShipDate = request.ShipDate;
            order.EmployeeId = request.EmployeeId;
            order.ShipAddress = request.ShipAddress;
            order.ShipName = request.ShipName;
            order.Active = request.Active;

            Context.SaveChanges();
        }
    }
}
