using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.OrderDetail
{
    public interface IGetOrderDetailsCommand : ICommand<OrderDetailSearch, PagedResponse<OrderDetailDto>>
    {
    }
}
