using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace swinAdventure
{

    [TestFixture()]
    public  class pathTest
    {
        Player p;
        Location l1;
        Location l2;
        Path p1;
        Path p2;
        Move m;
        [SetUp()]
        public void Setup()
        {
            p = new Player("me", "inventory");
            l1 = new Location("hall", "This is a hall");
            l2 = new Location("room", "This is a room");
            p1 = new Path(new string[] { "hall", "path1" });
            p2 = new Path(new string[] { "room", "path2" });
            m = new Move();
            l1.Path = p1;
            p1.setLocation("west", l2);
            l2.Path = p2;
            p2.setLocation("east", l1);
            p.Location = l1;
        }
        [Test]
        public void PlayerMoveTest()
        {
            Assert.AreEqual(m.Execute(p,new string[] { "move", "to", "west" }),l2.FullDescription);
            Assert.AreEqual(m.Execute(p, new string[] { "move", "to", "east" }), l1.FullDescription);
        }
        
        [Test]
        public void PlayerPath()
        {
            Assert.AreEqual(l1.Path,p1);
        }

        [Test]
        public void Leaveloc()
        {
            Assert.AreEqual(m.Execute(p, new string[] { "move", "to", "northwest" }),"Non-existent path");
        }

    }
}
