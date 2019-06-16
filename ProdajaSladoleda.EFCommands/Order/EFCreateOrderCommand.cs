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
    public class EFCreateOrderCommand : EFCommand, ICreateOrderCommand
    {
        public EFCreateOrderCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateOrderDto request)
        {
            if (!Context.Orders.Any(o => o.CustomerId == request.CustomerId))
                throw new EntityNotFoundException("Customer");
            if (!Context.Orders.Any(o => o.EmployeeId == request.EmployeeId))
                throw new EntityNotFoundException("Employee");

            Context.Orders.Add(new Domain.Order {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                Total = request.Total,
                ShipDate = request.ShipDate,
                EmployeeId = request.EmployeeId,
                ShipAddress = request.ShipAddress,
                ShipName = request.ShipName
            });
            Context.SaveChanges();
        }
    }
}
