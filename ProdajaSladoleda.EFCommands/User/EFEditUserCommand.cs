using System;
using System.Collections.Generic;
using System.Text;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.User
{
    public class EFEditUserCommand : EFCommand, IEditUserCommand
    {
        public EFEditUserCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateUserDto request)
        {
            var user = Context.Users.Find(request.UserId);
            if (user == null)
                throw new EntityNotFoundException("User");
            user.Username = request.Username;
            user.Password = request.Password;
            user.RoleId = request.RoleId;
            user.Active = request.Active;
            Context.SaveChanges();
        }
    }
}
