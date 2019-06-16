using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Role
{
    public class EFGetRoleCommand : EFCommand, IGetRoleCommand
    {
        public EFGetRoleCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Include(r => r.Users)
                                    .Where(r => r.RoleId == request)
                                    .FirstOrDefault();
            if (role == null)
                throw new EntityNotFoundException("Role");
            return new RoleDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Active = role.Active,
                Users = role.Users.Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    RoleId = u.RoleId,
                    Active = u.Active
                })
            };
        }
    }
}
