using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalArcTest.Domain
{
  public interface IChargeable
  {
    public decimal CalculateCost();
    public void WriteCost(IO.IDevice io, Utils.Log log);
  }
}
