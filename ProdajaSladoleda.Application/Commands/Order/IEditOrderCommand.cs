using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Order
{
    public interface IEditOrderCommand : ICommand<CreateOrderDto>
    {
    }
}
