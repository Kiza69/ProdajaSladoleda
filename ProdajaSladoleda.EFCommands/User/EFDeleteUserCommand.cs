using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.User
{
    public class EFDeleteUserCommand : EFCommand, IDeleteUserCommand
    {
        public EFDeleteUserCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
                throw new EntityNotFoundException("User");
            user.Active = false;
            Context.SaveChanges();
        }
    }
}
