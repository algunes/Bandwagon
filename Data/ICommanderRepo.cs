namespace Bandwagon.Data
{
using System.Collections.Generic;
using Bandwagon.Models;
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }

}