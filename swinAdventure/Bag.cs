using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public  class Bag :Item, IHaveInventory
    {
         
        private Inventory _inventory = new Inventory();
        public Bag(string[] ids,string name,string desc) : base(ids, name, desc)
        {
           
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            else
                return Inventory.Fetch(id);
        }
        public override string FullDescription
        {
            get
            {
                return $"In the {this.FirstId} you can see:{_inventory.ItemList}\n";
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
