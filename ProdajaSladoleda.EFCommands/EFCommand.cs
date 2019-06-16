using ProdajaSladoleda.DataAccess.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.EFCommands
{
    public abstract class EFCommand
    {
        protected readonly ProdajaSladoledaContext Context;

        protected EFCommand(ProdajaSladoledaContext context)
        {
            Context = context;
        }
    }
}
