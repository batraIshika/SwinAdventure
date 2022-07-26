using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure

{
    [TestFixture()]
    public class TestBag
    {

        private Item _item;
        private Item _item2;
        private Item _item3;
        private Bag _b1;
        private Bag _b2;

        [SetUp()]
        public void Setup()
        {
            _b1 = new Bag(new string[] { "bag1", "which you have opened" },"bag 1","this contains items");
            _b2 = new Bag(new string[] { "bag2", "which is inside bag1" }, "bag 2", "this contains items");
            _item = new Item(new string[] { "shovel" }, "a shovel", "This is a might fine...");
            
            _b1.Inventory.Put(_item);
           _b1.Inventory.Put(_b2);
        }

        [Test()]

        public void TestLocateItems()
        {
            Assert.AreEqual(_item, _b1.Locate("shovel"));
        }
        [Test()]

        public void TestBagIdentifiable()
        {
            Assert.AreEqual(_b1, _b1.Locate("bag1"));
            Assert.AreEqual(_b1,_b1.Locate("which you have opened"));
            
        }

        [Test()]

        public void TestNotFound()
        {
            Assert.AreEqual(null, _b1.Locate("bag100"));          
        }
        [Test()]

        public void TestFullDescription()
        {
           
            Assert.AreEqual("In the bag1 you can see:\n\ta shovel(shovel)\n\tbag 2(bag2)\n", _b1.FullDescription);

        }
        [Test()]

        public void TestBaginBag()
        {
            _item2 = new Item(new string[] { "spade" }, "a spade", "This is a might fine...");
            _item3 = new Item(new string[] { "sword" }, "bronze sword", "This is a might fine...");
            _b1.Inventory.Put(_item2);
            _b2.Inventory.Put(_item3);
            Assert.AreEqual(_b2, _b1.Locate("bag2"));
            Assert.AreEqual(_item2, _b1.Locate("spade"));
            Assert.AreEqual(null, _b1.Locate("sword"));
        }
    }
}
