using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class Move : Command
    {
        Location _location;
        public Move() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        

        public override string Execute(Player p,string[] text)
        {
            if (text.Length == 1 && text[0] != "leave" ||  text.Length > 3)
            {
                return "Can't move like this";
            }

            if (text[0] != "move" && text[0] != "go" && text[0] != "head" && text[0] != "leave")
            {
                return "Invalid input";
            }

            if (text[0] != "leave")
            {
                if (text[1] == "to" || text.Length > 3)
                {
                    return MovePlayer(p, text[2]);
                }
                else
                {
                    return "What is your destination?";
                   
                }
            }
            else
            {
                return MovePlayer(p, "leave");
            }

        }
        public string MovePlayer(Player player, string id)
        {
            
            if (id == "leave")
            {
                player.LeaveLoc();
                return player.Location.FullDescription;
            }

            _location = player.Location;

            Path _path = _location.Path;

            if (_path == null)
            {
                return "For this particular location-No path found";
            }

            _location = _path.LocatePath(id);

            if (_location == null)
            {
                return "Non-existent path";
            }

            player.Location = _location;
            return player.Location.FullDescription;
        }
    }
}
