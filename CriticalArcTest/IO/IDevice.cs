using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest.IO
{
  public interface IDevice
  {
    public void WriteLine(string line);
    public string ReadLine();
  }
}
