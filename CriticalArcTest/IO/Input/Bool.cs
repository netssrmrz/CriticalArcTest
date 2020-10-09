using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest.IO.Input
{
  public class Bool : Field
  {
    public override string GetDefaultDescription()
    {
      return "(Default is false)";
    }

    public override object Parse(IDevice io)
    {
      Boolean res = false;

      this.haveInput = false;
      string line = io.ReadLine().ToLower();
      if (line == "true" || line == "t" || line == "yes" || line == "y")
      {
        res = true;
        this.haveInput = true;
      }
      else if (line == "" || line == "false" || line == "f" || line == "no" || line == "n")
      {
        res = false;
        this.haveInput = true;
      }
      else
      {
        io.WriteLine("Acceptable answers are true, t, yes, y, false, f, no, n. Please try again.");
      }

      return res;
    }
  }
}
