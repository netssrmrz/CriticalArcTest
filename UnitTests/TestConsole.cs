using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest
{
  class TestConsole: CriticalArcTest.IO.IDevice
  {
    private int inputIdx;
    private string[] input;
    private readonly List<string> output;

    public string[] Input 
    { 
      set
      {
        input = value;
        inputIdx = 0;
      }
    }

    public string[] Output 
    { 
      get
      {
        return output.ToArray();
      }
    }

    public TestConsole()
    {
      this.output = new List<string>();
    }

    public void WriteLine(string line)
    {
      output.Add(line);
    }

    public string ReadLine()
    {
      string res = input[inputIdx];
      inputIdx++;

      return res;
    }

    public void ClearOutput()
    {
      this.output.Clear();
    }
  }
}
