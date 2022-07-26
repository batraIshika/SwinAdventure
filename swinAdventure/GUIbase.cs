using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class GUIbase
    {
        string name;
        string desc;
        Move move;
        LookCommand look;
        Put put;
        Take take;
        Quit quit;
        Commandprocessor cpr;
        Player _plr;

        Item _itm;
        Item _gem;
        Bag _b1;
        Item _item2;
        Location hall;
        Location room;
        Path p1;
        Path p2;
        

        StateGame state;
        string output;
        public GUIbase()
        {
            move = new Move();
            look = new LookCommand();
            put = new Put();
            take = new Take();
         quit = new Quit();

         _itm = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
         _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
         _b1 = new Bag(new string[] { "bag1", "which you have opened" }, "bag 1", "this contains items");
         _item2 = new Item(new string[] { "sword" }, "bronze sword", "This is a might fine...");
         hall = new Location("hall", "This is a hall");
         room = new Location("room", "This is a room");

            p1 = new Path(new string[] { "hall", "path1" });
            p2 = new Path(new string[] { "room", "path2" });
            cpr = new Commandprocessor(new string[] { "move", "look" });

            cpr.Addcommands(move);
            cpr.Addcommands(look);
            cpr.Addcommands(quit);
            cpr.Addcommands(put);
            cpr.Addcommands(take);
            _b1.Inventory.Put(_item2);
            hall.Inventory.Put(_itm);
            room.Inventory.Put(_gem);
            hall.Path = p1;
            p1.setLocation("west", room);
            room.Path = p2;
            p2.setLocation("east", hall);

            state = StateGame.inputname;
            output = "What is your name?\n";

        }


        public string Output
        {
            get
            {
                return output;
            }
        }
        public string Inputcommand(string str)
        {
            switch (state)
            {
                case StateGame.inputname:
                    name = str;
                  state = StateGame.inputdescription;
                    return name + "\nPlease enter player's description: \n";

                case StateGame.inputdescription:
                    desc = str;
                    state = StateGame.gameplay;
                    _plr = new Player(name, desc);
                    _plr.Inventory.Put(_gem);
                    _plr.Inventory.Put(_itm);
                    _plr.Location = hall;
                    _plr.Inventory.Put(_b1);

                    return "Welcome, " + name + ", " + desc;
            }
            
            return cpr.Execute(_plr, str.Split());
        }

    }
    public enum StateGame { inputname, inputdescription, gameplay }
}

            





        
    
