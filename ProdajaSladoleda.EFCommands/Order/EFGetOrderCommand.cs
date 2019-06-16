using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Order
{
    public class EFGetOrderCommand : EFCommand, IGetOrderCommand
    {
        public EFGetOrderCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public OrderDto Execute(int request)
        {
            var order = Context.Orders.
                Where(c => c.OrderId == request).
                Include(o => o.OrderDetails).
                ThenInclude(od => od.Product)
                .FirstOrDefault();
            if (order == null)
                throw new EntityNotFoundException("Order");
            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                EmployeeId = order.EmployeeId,
                ShipName = order.ShipName,
                Total = order.Total,
                Active = order.Active,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    ProductName = od.Product.Name,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
            };
        }
    }
}
