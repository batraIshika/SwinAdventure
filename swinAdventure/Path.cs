using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
   public class Path:IdentifiableObject
    {
        Location _north, _south, _east, _west;

        public Path(string[] idents):base(idents)
        {
           _north=null;
           _south= null;
           _east= null;
           _west= null;     
        }

        public void setLocation(string direction, Location location)
        {

            if (location == null)
            {
                Console.WriteLine("no location found");
            }

            switch (direction)
            {
                case "north":
                     _north = location;
                     break;
                case "south":
                    _south = location;
                    break;
                case "east":
                    _east = location;
                    break;
                case "west":
                    _west = location;
                    break;
            }
        }
        public Location LocatePath(string direction)
        {
            if(direction=="north")
            { return _north; }
            if (direction == "south")
            { return _south; }
            if (direction == "east")
            { return _east; }
            if (direction == "west")
            { return _west; }
          
            else
            {
                if (_north != null)
                {
                    if (_north.AreYou(direction))
                    {
                        return _north;
                    }
                }
                if (_south != null)
                {
                    if (_south.AreYou(direction))
                    {
                        return _south;
                    }
                }
                if (_east != null)
                {
                    if (_east.AreYou(direction))
                    {
                        return _east;
                    }
                }
                if (_west != null)
                {
                    if (_west.AreYou(direction))
                    {
                        return _west;
                    }
                }
               
                return null;
            }
        }
    }
}
    

   




