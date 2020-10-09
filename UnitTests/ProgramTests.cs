using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CriticalArcTest
{
  [TestClass]
  public class ProgramTests
  {
    [TestMethod]
    public void TestProcessCoffee()
    {
      string[] input = { "y", "y", "2", "y", "y" };

      TestConsole io = new TestConsole
      {
        Input = input
      };
      Program.ProcessCoffee("Coffee.Fields", io, null);
      Assert.AreEqual("Cost is $3.40", io.Output[5]);

      io.ClearOutput();
      Program.ProcessCoffee("Wine.Fields", io, null);
      Assert.AreEqual("Sorry. Seems something has gone wrong.", io.Output[0]);
    }
  }
}
