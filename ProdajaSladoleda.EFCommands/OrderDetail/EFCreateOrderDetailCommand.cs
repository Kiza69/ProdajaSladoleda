using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.OrderDetail
{
    public class EFCreateOrderDetailCommand : EFCommand, ICreateOrderDetailCommand
    {
        public EFCreateOrderDetailCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateOrderDetailDto request)
        {
            if (!Context.OrderDetails.Any(o => o.ProductId == request.ProductId))
                throw new EntityNotFoundException("Product");
            if (!Context.OrderDetails.Any(o => o.OrderId == request.OrderId))
                throw new EntityNotFoundException("Order");
            Context.OrderDetails.Add(new Domain.OrderDetail {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity,
                Discount = request.Discount,
            });
            Context.SaveChanges();
        }
    }
}
