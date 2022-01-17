namespace Bandwagon.Data
{
using System.Collections.Generic;
using Bandwagon.Models;
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }

}