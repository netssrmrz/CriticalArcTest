using System.Globalization;

namespace CriticalArcTest.Domain
{
  public class Coffee : IChargeable
  {
    public bool IsLarge { get; set; }
    public bool HasMilk { get; set; }
    public int NumSugars { get; set; }
    public bool MilkIsFoamed { get; set; }
    public bool HasSprinkles { get; set; }

    public void WriteCost(IO.IDevice io, Utils.Log log)
    {
      decimal cost = this.CalculateCost();
      io.WriteLine("Cost is " + cost.ToString("C", CultureInfo.CurrentCulture));
      Utils.Log.Write(log, "Program.Main(): cost = " + cost);
    }

    public decimal CalculateCost()
    {
      // Start with basic Expresso
      decimal cost = 1.50m;

      //Milk 25c or 30c for large
      if (HasMilk & IsLarge)
        cost += .30m;

      if (HasMilk & !IsLarge)
        cost += .25m;

      // Calc sugar @ 10c each
      cost += (0.10m * NumSugars);

      // Milk Foaming 5c
      if (MilkIsFoamed)
        cost += .05m;

      // chocolate sprinkles
      if (HasSprinkles)
        cost += .05m;

      // Add service charge of $1.30 per order
      cost += 1.30m;

      return cost;
    }
  }
}
