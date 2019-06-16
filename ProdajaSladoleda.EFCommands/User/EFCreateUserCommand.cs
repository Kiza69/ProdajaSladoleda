using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Exceptions;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace ProdajaSladoleda.EFCommands.User
{
    public class EFCreateUserCommand : EFCommand, ICreateUserCommand
    {
        public EFCreateUserCommand(ProdajaSladoledaContext context) : base(context)
        {
        }

        public void Execute(CreateUserDto request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
                throw new EntityAlreadyExistException("User");
            Context.Users.Add(new Domain.User {
                Username = request.Username,
                Password = request.Password,
                RoleId = request.RoleId
            });
            Context.SaveChanges();
        }
    }
}
