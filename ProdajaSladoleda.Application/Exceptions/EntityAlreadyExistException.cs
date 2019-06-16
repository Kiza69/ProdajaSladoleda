using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException(string entity) : base($"{entity} already exist.")
        {

        }
        public EntityAlreadyExistException()
        {

        }
    }
}
