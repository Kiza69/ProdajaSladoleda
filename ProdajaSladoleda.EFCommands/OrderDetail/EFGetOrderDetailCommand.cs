using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.OrderDetail
{
    public class EFGetOrderDetailCommand : EFCommand, IGetOrderDetailCommand
    {
        public EFGetOrderDetailCommand(ProdajaSladoledaContext context) : base(context)
        {
        }
        public OrderDetailDto Execute(int request)
        {
            var od = Context.OrderDetails.Where(o => o.OrderDetailId == request)
                                            .Include(o => o.Order)
                                            .Include(o => o.Product)
                                            .FirstOrDefault();
            if (od == null)
                throw new EntityNotFoundException("OrderDetail");
            return new OrderDetailDto {
                OrderDetailId = od.OrderDetailId,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                ProductName = od.Product.Name,
                UnitPrice = od.UnitPrice,
                Quantity = od.Quantity,
                Discount = od.Discount,
                Active = od.Active
            };
        }
    }
}
