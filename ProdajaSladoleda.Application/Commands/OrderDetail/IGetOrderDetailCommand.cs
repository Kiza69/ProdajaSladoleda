using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProdajaSladoleda.Application.Commands.OrderDetail
{
    public interface IGetOrderDetailCommand : ICommand<int, OrderDetailDto>
    {
    }
}
