using System.Collections.Generic;
using Bandwagon.Models;

namespace Bandwagon.Data 
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands;
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.Find(id);
        }
    }
}