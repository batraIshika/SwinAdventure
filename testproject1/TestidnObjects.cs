using NUnit.Framework;

namespace swinAdventure
{
    [TestFixture()]
    public class TestIdentifiableObject
    {
        private IdentifiableObject id;
        [SetUp()]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "fred", "bob" });
        }
        
        [Test()]
        
        public void TestAreYou()
        {
            Assert.IsTrue(id.AreYou("fred"));
        }
        [Test()]
        public void TestNotAreYou()
        {
            Assert.IsFalse(id.AreYou("boby"));
        }

        [Test()]

        public void TestCaseSensitive()
        {
            Assert.IsTrue(id.AreYou("FRED"));
        }
        [Test()]

        public void TestFirstID()
        {
            Assert.AreEqual(id.FirstId, "fred");
        }
        [Test()]

        public void TestAddID()
        {
            id.AddIdentifier("john");
            Assert.IsTrue(id.AreYou("john"));
        }
    }
}