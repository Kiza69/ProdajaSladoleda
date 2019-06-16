using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Order
{
    public class EFGetOrdersCommand : EFCommand, IGetOrdersCommand
    {
        public EFGetOrdersCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public PagedResponse<OrderDto> Execute(OrderSearch request)
        {
            var orders = Context.Orders.Include(o => o.OrderDetails)
                                        .ThenInclude(od => od.Product)
                                         .AsQueryable();

            if (request.StartDate.HasValue)
                orders = orders.Where(o => o.OrderDate >= request.StartDate);
            if (request.EndDate.HasValue)
                orders = orders.Where(o => o.OrderDate <= request.EndDate);
            if (request.StartTotal.HasValue)
                orders = orders.Where(o => o.Total >= request.StartTotal);
            if (request.EndTotal.HasValue)
                orders = orders.Where(o => o.Total <= request.EndTotal);
            if (request.CustomerId != null)
                orders = orders.Where(o => o.CustomerId == request.CustomerId);
            if (request.IsShipped.HasValue)
            {
                if (request.IsShipped == true)
                {
                    orders = orders.Where(o => o.ShipDate != null);
                }
                else
                {
                    orders = orders.Where(o => o.ShipDate == null);
                }
            }
            if (request.IsActive.HasValue)
                orders = orders.Where(o => o.Active == request.IsActive);

            if (request.ProductName != null)
                orders = orders.Where(o => o.OrderDetails
                                .Any(od => od.Product.Name.ToLower()
                                .Contains(request.ProductName.Trim().ToLower())));

            var totalCounts = orders.Count();
            var pagesCount = (int)Math.Ceiling((double)totalCounts / request.PerPage);


            orders = orders.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var response = new PagedResponse<OrderDto>
            {
                TotalCount = totalCounts,
                PagesCount = pagesCount,
                CurrentPage = request.PageNumber,
                Data = orders.Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    ShipDate = o.ShipDate,
                    EmployeeId = o.EmployeeId,
                    ShipName = o.ShipName,
                    Total = o.Total,
                    Active = o.Active,
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
                    {
                        OrderId = od.OrderId,
                        ProductId = od.ProductId,
                        ProductName = od.Product.Name,
                        UnitPrice = od.UnitPrice,
                        Quantity = od.Quantity,
                        Discount = od.Discount
                    })
                })
            };
            
            return response;
        }
    }
}
