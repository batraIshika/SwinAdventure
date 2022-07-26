using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
   public class Commandprocessor:Command
    {
        private List<Command> _commands;
        public Commandprocessor(string[] ids):base(ids)
        {
            _commands = new List<Command>();
        }
        public override string Execute(Player p, string[] text)
        {
            foreach(Command c in _commands)
            {
                if(c.AreYou(text[0]))
                {
                    return c.Execute(p, text);
                }
            }
            return "It cannot find the command";
        }

        public void Addcommands(Command cmd)
        {
            _commands.Add(cmd);
        }


    }
}
