using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure

{
    [TestFixture()]
    public class TestInventory
    {
        private Item item;
        private Inventory inventory;
        [SetUp()]
        public void Setup()
        {
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
           
            inventory = new Inventory();
        }
        [Test()]
        public void TestFindItem()
        {
            inventory.Put(item);
            Assert.IsTrue(inventory.HasItem("shovel"));
        }
        [Test()]
        public void TestNoItemFind()
        {
            inventory.Put(item);
            Assert.IsFalse(inventory.HasItem("sword"));
        }
        [Test()]
        public void TestFetchItem()
        {
            inventory.Put(item);
            Assert.AreEqual("shovel",inventory.Fetch("shovel").FirstId );
        }
        [Test()]
        public void TestTakeItem()
        {
            inventory.Put(item);
            inventory.Take("shovel");
            Assert.IsFalse(inventory.HasItem("sword"));
        }
        [Test()]
        public void TestItemList()
        {
            Item itm = new Item(new string[] {"sword"}, "bronze sword", "This is a might fine...");
            inventory.Put(item);
            inventory.Put(itm);
            Assert.AreEqual(inventory.ItemList, "\n\ta shovel(shovel)\n\tbronze sword(sword)");
        }
    }
}
