using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Customer
{
    public interface IEditCustomerCommand : ICommand<CreateCustomerDto>
    {
    }
}
