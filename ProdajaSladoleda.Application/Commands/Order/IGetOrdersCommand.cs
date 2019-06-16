using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Order
{
    public interface IGetOrdersCommand : ICommand<OrderSearch, PagedResponse<OrderDto>>
    {
    }
}
