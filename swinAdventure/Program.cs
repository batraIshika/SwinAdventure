using System;

namespace swinAdventure
{
   public class Program
    {
        
        static void Main(string[] args)
        {
             
            Console.WriteLine("What is the your name?");
            string name= Console.ReadLine();
            Console.WriteLine("Enter your Description");
            string desc = Console.ReadLine();
             Player _plr = new Player(name, desc);
            string[] commandSplit= new[] { " " }; 

             

             Item _itm = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
            
             Item _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
           
             _plr.Inventory.Put(_itm);
             _plr.Inventory.Put(_gem);
             Bag _b1 = new Bag(new string[] { "bag1", "which you have opened" }, "bag 1", "this contains items");
             _plr.Inventory.Put(_b1);
             Item _item2 = new Item(new string[] { "sword" }, "bronze sword", "This is a might fine...");
             _b1.Inventory.Put(_item2);

            Location hall = new Location("hall", "This is a hall");
            Location room = new Location("room", "This is a room");
            Path p1 = new Path(new string[] { "hall", "path1" });
            Path p2 = new Path(new string[] { "room", "path2" });
            hall.Inventory.Put(_itm);
            room.Inventory.Put(_gem);
            hall.Path = p1;
            p1.setLocation("west", room);
            room.Path = p2;
            p2.setLocation("east", hall);
            _plr.Location = hall;

            Commandprocessor cpr = new Commandprocessor(new string[] { "move", "look" });
            Move move = new Move();
            LookCommand look = new LookCommand();
            Put put = new Put();
            Take take = new Take();
            Quit quit = new Quit();
            cpr.Addcommands(move);
            cpr.Addcommands(look);
            cpr.Addcommands(quit);
            cpr.Addcommands(put);
            cpr.Addcommands(take);
            while (true)
             {
                Console.WriteLine("Input the command");
                string command = Console.ReadLine();
                commandSplit = command.Split(" ");
                Console.WriteLine(cpr.Execute(_plr, commandSplit));
                if(commandSplit[0] == "quit")
                { break; }
             }
                   
        }
        
    }
}
