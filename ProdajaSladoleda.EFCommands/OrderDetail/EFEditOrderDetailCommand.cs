using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.OrderDetail
{
    public class EFEditOrderDetailCommand : EFCommand, IEditOrderDetailCommand
    {
        public EFEditOrderDetailCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateOrderDetailDto request)
        {
            var od = Context.OrderDetails.Find(request.OrderDetailId);
            if (od == null)
                throw new EntityNotFoundException("OrderDetail");
            od.OrderId = request.OrderId;
            od.ProductId = request.ProductId;
            od.UnitPrice = request.UnitPrice;
            od.Quantity = request.Quantity;
            od.Discount = request.Discount;
            od.Active = request.Active;

            Context.SaveChanges();
        }
    }
}
