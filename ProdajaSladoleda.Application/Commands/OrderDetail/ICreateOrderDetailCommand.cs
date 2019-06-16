using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.OrderDetail
{
    public interface ICreateOrderDetailCommand : ICommand<CreateOrderDetailDto>
    {
    }
}
