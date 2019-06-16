using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.Role
{
    public class EFDeleteRoleCommand : EFCommand, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);
            if (role == null)
                throw new EntityNotFoundException("Role");
            role.Active = false;
            Context.SaveChanges();
        }
    }
}
