using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure
{
    [TestFixture()]
   public class LookCommandTest
    {
        private LookCommand _testLook;
        private Player _player;
        private Item _itm;
        private Item _gem;
        private Bag _b1;
        [SetUp()]
        public void Setup()
        {
            _testLook = new LookCommand();
            _player = new Player("me", "inventory");
            _b1 = new Bag(new string[] { "bag", "which you have opened" }, "bag ", "this contains items");
            _itm = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
            _player.Inventory.Put(_itm);
             _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        }

        [Test]
        public void LookAtMe()
        {
            
            Assert.AreEqual(_player.FullDescription, _testLook.Execute(_player, new string[] {"look", "at", "inventory"}));
        }
        [Test]
        public void LookAtGem()
        {
            
            _player.Inventory.Put(_gem);

            Assert.AreEqual(_gem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at","gem"}));
        }
        [Test]
        public void LookAtUnk()
        {
            Assert.AreEqual("I cannot find the gem", _testLook.Execute(_player, new string[] { "look", "at", "gem" }));
        }
        [Test]
        public void LookAtGemInMe()
        {
            Item _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            _player.Inventory.Put(_gem);

            Assert.AreEqual(_gem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "gem","in","inventory" }));
        }
        [Test]
        public void LookAtGemInBag()
        {
            Item _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            
            _b1.Inventory.Put(_gem);
            _player.Inventory.Put(_b1);
            Assert.AreEqual(_gem.FullDescription, _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Item _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            _b1.Inventory.Put(_gem);
            
            Assert.AreEqual("I cannot find the bag", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
        [Test]
        public void LookAtNoGemInBag()
        {
            Item _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");

            
            _player.Inventory.Put(_b1);
            Assert.AreEqual("I cannot find the gem", _testLook.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAround()
        {
            Assert.AreEqual("I don't know how to look like that", _testLook.Execute(_player, new string[] { "look", "around" }));
        }
        [Test]
        public void Hello()
        {
            Assert.AreEqual("Error in look input", _testLook.Execute(_player, new string[] { "Hello","Mr","Bean" }));
        }
        [Test] 
        public void LookInvalid()
        {
            Assert.AreEqual("What do you want to look in?", _testLook.Execute(_player, new string[] { "look","at","a","at","b" }));
        }
    }
}
