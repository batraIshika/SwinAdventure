using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure
{
    [TestFixture()]
    public class ItemTests
    {
         Item itm;
        [SetUp()]
        public void Setup()
        {
            itm = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine...");
        }

        [Test()]

        public void TestisIdentifiable()
        {
            Assert.IsTrue(itm.AreYou("shovel"));
        }
        [Test()]

        public void TestShortDescrption()
        {
            Assert.AreEqual(itm.Shortdescription,"a shovel(shovel)");
        }
        [Test()]

        public void TestLongDescrption()
        {
            Assert.AreEqual(itm.FullDescription, "This is a might fine...");
        }
    }
}
