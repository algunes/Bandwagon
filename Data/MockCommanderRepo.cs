using System.Collections.Generic;
using Bandwagon.Models;

namespace Bandwagon.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water.", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="Knife and chopping board"},
                new Command{Id=2, HowTo="Make a coffee", Line="Boil water.", Platform="FrenchPress & Beans"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            Command Command = new Command();
            Command.Id=3;
            Command.HowTo="Leave your keys";
            Command.Line="At the nail on the wall";
            Command.Platform="Buy a cup of coffee";
            return Command;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}