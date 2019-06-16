using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Customer
{
    public interface IGetCustomersCommand : ICommand<CustomerSearch, PagedResponse<CustomerDto>>
    {
    }
}
