using NhlSystemClassLibrary;

namespace DemoTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(97,"Connor McDavid", Position.C)]
        [DataRow(93, "Ryan Nugent-Hopkins", Position.C)]
        [DataRow(91, "Evander Kane", Position.LW)]
        public void Constructor_ValidData_ShouldPass(int playerNo, string playerName, Position playerPosition)
        {
            // Arrange and Act
            Player currentPlayer = new Player(playerNo,playerName, playerPosition);
            // Assert
            Assert.AreEqual(playerNo, currentPlayer.PlayerNo);
            Assert.AreEqual(playerName, currentPlayer.Name);
            Assert.AreEqual(playerPosition, currentPlayer.Position);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //Player p;// = new Player();
            Assert.Fail("not implemented yet");
        }
    }
}