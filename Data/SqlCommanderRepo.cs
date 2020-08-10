using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _contex;

        public SqlCommanderRepo(CommanderContext context)
        {
            _contex = context;
        }

        public void CreateCommand(Command cmd)
        {
           if (cmd == null)
           {
               throw new ArgumentNullException(nameof(cmd));
           }
           _contex.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
           {
                throw new ArgumentNullException(nameof(cmd));
           }
           _contex.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommand()
        {
            return _contex.Commands.ToList();
          
        }

        public Command GetCommandById(int id)
        {
            
            return _contex.Commands.FirstOrDefault( p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_contex.SaveChanges()) >= 0;
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}