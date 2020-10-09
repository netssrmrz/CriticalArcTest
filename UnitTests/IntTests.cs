using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CriticalArcTest
{
  [TestClass]
  public class IntTests
  {
    [TestMethod]
    public void TestParse()
    {
      string[] input1 = { "2" };
      string[] input2 = { "" };
      string[] input3 = { "y" };
      TestConsole io = new TestConsole();
      object val;

      IO.Input.Int field = new IO.Input.Int
      {
        FieldName = "NumSugars",
        Question = "How many sugars?"
      };

      io.Input = input1;
      val = field.Parse(io);
      Assert.AreEqual(2, val);
      Assert.IsTrue(field.HaveInput);

      io.Input = input2;
      val = field.Parse(io);
      Assert.AreEqual(0, val);
      Assert.IsTrue(field.HaveInput);

      io.Input = input3;
      val = field.Parse(io);
      Assert.AreEqual(0, val);
      Assert.IsFalse(field.HaveInput);

      // TODO: Test negative numbers
      // TODO: Test large numbers
      // TODO: Test fractional numbers
    }
  }
}
