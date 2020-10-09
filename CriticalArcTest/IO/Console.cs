using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest.IO
{
  public class Console : IDevice
  {
    public void WriteLine(string line)
    {
      System.Console.WriteLine(line);
    }

    public string ReadLine()
    {
      return System.Console.ReadLine();
    }
  }
}
