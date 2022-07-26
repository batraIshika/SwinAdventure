using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure

{
    [TestFixture()]
    public class TestPlayer
    {
        private Item item;
        private Player _player;
        private Player _player2;

        [SetUp()]
        public void Setup()
        {
            _player = new Player("me", "inventory");
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
            _player.Inventory.Put(item);
        }
        [Test()]

        public void TestPlayerIdentifiable()
        {
           
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }
        [Test()]

        public void TestLocateItems()
        {
            Assert.AreEqual(item, _player.Locate("shovel"));  
        }

        [Test()]

        public void TestLocateItself ()
        {
            Assert.AreEqual(_player, _player.Locate("me"));
            Assert.AreEqual(_player, _player.Locate("inventory"));

        }
        [Test()]

        public void TestLocateNothing()
        {
           
            Assert.AreEqual(null, _player.Locate("sword"));

        }
        [Test()]

        public void TestFullDescription()
        {
            _player2 = new Player("Fred", "the mighty programmer");
            _player2.Inventory.Put(item);
            Assert.AreEqual("You are Fred the mighty programmer\nYou are carrying:\n\ta shovel(shovel)\n", _player2.FullDescription);

        }
    }
}
