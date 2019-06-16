using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.OrderDetail
{
    public class EFDeleteOrderDetailCommand : EFCommand, IDeleteOrderDetailCommand
    {
        public EFDeleteOrderDetailCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var od = Context.OrderDetails.Find(request);
            if (od == null)
                throw new EntityNotFoundException("OrderDetail");
            od.Active = false;
            Context.SaveChanges();
        }
    }
}
