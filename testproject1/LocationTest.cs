using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace swinAdventure

{
    [TestFixture()]
   public  class LocationTest
    {
        private Item item;
        private Player _player;
        private Location _loc;
        [SetUp()]
        public void Setup()
        {
            _loc = new Location("hall", "a big mysterious place");
            _player = new Player("me", "inventory");
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
            _loc.Inventory.Put(item);
            
        }


        [Test]
        public void TestIdentifiable()
        {
            Assert.IsTrue(_loc.AreYou("hall"));
        }

        [Test]
        public void Testdescription()
        {
            Assert.AreEqual(_loc.FullDescription, "You are currently in hall which is a big mysterious place and you can see: \n\ta shovel(shovel) \n");
        }

        [Test]
        public void TestLocateItem()
        {
            Assert.AreEqual(item,_loc.Locate("shovel"));
        }
        [Test]
        public void TestLocateItemLoc()
        {
            _player.Location = _loc;
            Assert.AreEqual(item, _player.Location.Locate("shovel"));
        }



    }
}
