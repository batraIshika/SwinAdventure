using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class Quit : Command
    {
        public Quit() : base(new string[] { "quit" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text[0] == "quit")
            {
                return ("Thx for playing!");
            }
            return null;
        }
    }
}
