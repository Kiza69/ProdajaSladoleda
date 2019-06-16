using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Response;
using ProdajaSladoleda.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserSearch, PagedResponse<UserDto>>
    {
    }
}
