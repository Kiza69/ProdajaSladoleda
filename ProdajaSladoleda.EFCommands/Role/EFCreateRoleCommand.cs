using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Role
{
    public class EFCreateRoleCommand : EFCommand, ICreateRoleCommand
    {
        public EFCreateRoleCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateRoleDto request)
        {
            if (Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAlreadyExistException("Role");
            Context.Roles.Add(new Domain.Role {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
