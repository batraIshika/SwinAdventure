using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
   public  class Location :GameObject,IHaveInventory
   {
        private Inventory _inventory = new Inventory();
        private Path _p;

        public Location(string name, string desc) : base(new string[] {"hall","This is a hall"} ,name, desc)
        {

        }
        public Path Path
        {
            get
            {
                return _p;
            }
            set
            {

                _p = value;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }


        public override string FullDescription
        {
            get
            {
                return $"You are currently in {this.Name} which is {base.FullDescription} and you can see: {Inventory.ItemList} \n";
            }
        }

        public GameObject Locate(string id)
        {

            if (AreYou(id))
                return this;
            else if(this.Inventory.HasItem(id))
            return Inventory.Fetch(id);
           return null;
        }
    }
}
