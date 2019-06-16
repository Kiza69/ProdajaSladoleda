using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdajaSladoleda.EFCommands.OrderDetail
{
    public class EFGetOrderDetailsCommand : EFCommand, IGetOrderDetailsCommand
    {
        public EFGetOrderDetailsCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public PagedResponse<OrderDetailDto> Execute(OrderDetailSearch request)
        {
            var ods = Context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .AsQueryable();

            if (request.OrderId != null)
                ods = ods.Where(o => o.OrderId == request.OrderId);
            if (request.ProductName != null)
                ods = ods.Where(od => od.Product.Name.ToLower()
                                .Contains(request.ProductName
                                .Trim().ToLower()));
            if (request.IsActive.HasValue)
                ods = ods.Where(o => o.Active == request.IsActive);

            var totalCounts = ods.Count();
            var pagesCount = (int)Math.Ceiling((double)totalCounts / request.PerPage);


            ods = ods.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var response = new PagedResponse<OrderDetailDto>
            {
                TotalCount = totalCounts,
                PagesCount = pagesCount,
                CurrentPage = request.PageNumber,
                Data = ods.Select(o => new OrderDetailDto
                {
                    OrderDetailId = o.OrderDetailId,
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    ProductName = o.Product.Name,
                    UnitPrice = o.UnitPrice,
                    Quantity = o.Quantity,
                    Discount = o.Discount,
                    Active = o.Active
                })
            };
            return response;
        }
    }
}
