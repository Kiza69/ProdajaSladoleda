using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Role
{
    public class EFGetRolesCommand : EFCommand, IGetRolesCommand
    {
        public EFGetRolesCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var roles = Context.Roles
                            .Include(r => r.Users)
                            .AsQueryable();
            if (request.Keyword != null)
                roles = roles.Where(r => r.Name.ToLower().Contains(request.Keyword.ToLower()));
            if (request.IsActive.HasValue)
                roles = roles.Where(r => r.Active == request.IsActive);
            return roles.Select(r => new RoleDto {
                RoleId = r.RoleId,
                Name = r.Name,
                Active = r.Active,
                Users = r.Users.Select(u => new UserDto {
                    UserId = u.UserId,
                    Username = u.Username,
                    RoleId = u.RoleId,
                    Active = u.Active
                })
            });

        }
    }
}
