namespace Bandwagon.Data
{
using System.Collections.Generic;
using Bandwagon.Models;
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
    }

}