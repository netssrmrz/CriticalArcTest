using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CriticalArcTest
{
  [TestClass]
  public class FieldTests
  {
    [TestMethod]
    public void TestInputObj()
    {
      Domain.Coffee hotBeverage = new Domain.Coffee();
      string[] input = { "y", "y", "2", "y", "y" };
      TestConsole io = new TestConsole();
      bool dataInputOk;

      io.Input = input;
      dataInputOk = IO.Input.Field.InputObj("Coffee.Fields", hotBeverage, io, null);
      Assert.IsTrue(dataInputOk);
      Assert.IsTrue(hotBeverage.IsLarge);
      Assert.IsTrue(hotBeverage.HasMilk);
      Assert.AreEqual(2, hotBeverage.NumSugars);
      Assert.IsTrue(hotBeverage.MilkIsFoamed);
      Assert.IsTrue(hotBeverage.HasSprinkles);

      dataInputOk = IO.Input.Field.InputObj("Tea.Fields", hotBeverage, io, null);
      Assert.IsFalse(dataInputOk);
    }

    [TestMethod]
    public void TestAllFromConfig()
    {
      IO.Input.Field[] fields;

      fields = IO.Input.Field.AllFromConfig("Coffee.Fields", null);
      Assert.IsNotNull(fields);
      Assert.AreEqual(5, fields.Length);

      Assert.IsTrue(fields[0] is IO.Input.Bool);
      Assert.AreEqual("Large?", fields[0].Question);
      Assert.AreEqual("IsLarge", fields[0].FieldName);

      Assert.IsTrue(fields[1] is IO.Input.Bool);
      Assert.AreEqual("Milk?", fields[1].Question);
      Assert.AreEqual("HasMilk", fields[1].FieldName);

      Assert.IsTrue(fields[2] is IO.Input.Int);
      Assert.AreEqual("How many sugars?", fields[2].Question);
      Assert.AreEqual("NumSugars", fields[2].FieldName);

      Assert.IsTrue(fields[3] is IO.Input.Bool);
      Assert.AreEqual("Foam the milk?", fields[3].Question);
      Assert.AreEqual("MilkIsFoamed", fields[3].FieldName);

      Assert.IsTrue(fields[4] is IO.Input.Bool);
      Assert.AreEqual("Add chocolate sprinkles?", fields[4].Question);
      Assert.AreEqual("HasSprinkles", fields[4].FieldName);

      fields = IO.Input.Field.AllFromConfig("Tea.Fields", null);
      Assert.IsNull(fields);
    }

    // TODO: Unit tests for function FromConfig

    // TODO: Unit tests for function WriteQuestion

    [TestMethod]
    public void TestReadInput()
    {
      string[] input1 = { "2" };
      string[] input2 = { "" };
      string[] input3 = { "y", "y", "2" };
      TestConsole io = new TestConsole();

      Domain.Coffee coffee = new Domain.Coffee();

      IO.Input.Int field = new IO.Input.Int
      {
        Question = "How many sugars?",
        FieldName = "NumSugars"
      };

      io.Input = input1;
      field.ReadInput(coffee, io, null);
      Assert.AreEqual(2, coffee.NumSugars);

      io.Input = input2;
      field.ReadInput(coffee, io, null);
      Assert.AreEqual(0, coffee.NumSugars);

      io.Input = input3;
      field.ReadInput(coffee, io, null);
      Assert.AreEqual(2, coffee.NumSugars);

      // TODO: Test negative values
      // TODO: Test fractional values
      // TODO: Test large values
      // TODO: Test text values
    }
  }
}
