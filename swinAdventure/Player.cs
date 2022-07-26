using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swinAdventure
{
    public class Player :GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _loc ;
        private Location _finalloc;
        public Player(string name, string desc) : base(new string[] {"me","inventory"} ,name, desc)
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
                return $"You are {this.Name} {base.FullDescription}\nYou are carrying:{_inventory.ItemList}\n";
            }
        }
        public Location Location
        {
            get
            {
                return _loc;
            }
            set
            {
                if (_loc != null)
                {
                    _finalloc = _loc;
                }
                else
                {
                    _finalloc = value;

                }
                _loc = value;
            }
        }
        public Inventory Inventory
        {
            get
            {
            return _inventory;
            }
        }
      
        public void LeaveLoc()
        {
            _loc = _finalloc;
        }
    }
}

