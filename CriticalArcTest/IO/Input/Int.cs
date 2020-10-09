using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest.IO.Input
{
  public class Int : Field
  {
    public override string GetDefaultDescription()
    {
      return "(Default is 0)";
    }

    public override object Parse(IDevice io)
    {
      Int32 res = 0;
      int val;

      this.haveInput = false;
      string line = io.ReadLine().ToLower();
      if (line == "")
      {
        this.haveInput = true;
      }
      else
      {
        try
        {
          val = int.Parse(line);
          if (val >= 0 && val <= 10)
          {
            res = val;
            this.haveInput = true;
          }
        }
        catch (Exception)
        {
          this.haveInput = false;
        }

        if (!this.HaveInput)
        {
          io.WriteLine("Acceptable answers must be an integer between 0 and 10. Please try again.");
        }
      }

      return res;
    }
  }
}
