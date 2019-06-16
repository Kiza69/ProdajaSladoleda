﻿using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Commands.Role
{
    public interface IEditRoleCommand : ICommand<CreateRoleDto>
    {
    }
}