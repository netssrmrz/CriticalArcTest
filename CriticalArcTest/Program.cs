using System;

namespace CriticalArcTest
{
  public class Program
  {
    public static void Main(string[] args)
    {
      IO.Console io = new IO.Console();
      Utils.Log log = new Utils.Log("CriticalArcTest");

      ProcessCoffee("Coffee.Fields", io, log);

      Console.ReadKey(true);
    }

    /// <summary>
    /// Takes coffee order from user and returns the order cost.
    /// </summary>
    /// <param name="configKey">A string indicating which configuration keys to use when extracting details about the various questions given to the user.</param>
    /// <param name="io">An IODevice object through which user data is collected</param>
    /// <param name="log">An optional Log object to track progress and errors</param>
    public static void ProcessCoffee(string configKey, IO.IDevice io, Utils.Log log)
    {
      Domain.Coffee exampleCoffee = new Domain.Coffee();

      bool dataInputOk = IO.Input.Field.InputObj(configKey, exampleCoffee, io, log);
      if (dataInputOk && exampleCoffee is Domain.IChargeable)
      {
        exampleCoffee.WriteCost(io, log);
      }

      if (!dataInputOk)
      {
        io.WriteLine("Sorry. Seems something has gone wrong.");
        Utils.Log.Write(log, "Program.Main(): Error");
      }
    }
  }
}