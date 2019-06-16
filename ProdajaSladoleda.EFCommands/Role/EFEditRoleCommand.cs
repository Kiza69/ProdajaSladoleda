using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Role
{
    public class EFEditRoleCommand : EFCommand, IEditRoleCommand
    {
        public EFEditRoleCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateRoleDto request)
        {
            var role = Context.Roles.Find(request.RoleId);
            if (role == null)
                throw new EntityNotFoundException("Role");
            role.Name = request.Name;
            role.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
