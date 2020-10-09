using System.Diagnostics;
using System.Threading;

namespace CriticalArcTest.Utils
{
  public class Log
  {
    private readonly EventLog eventLog;

    public Log(string source)
    {
      try
      {
        if (!EventLog.SourceExists(source))
        {
          EventLog.CreateEventSource(source, "Application");
          Thread.Sleep(3000);
        }

        this.eventLog = new EventLog
        {
          Source = source
        };
      }
      catch (System.Security.SecurityException)
      {
        this.eventLog = null;
      }
    }

    public void Write(string msg)
    {
      if (this.eventLog != null)
      {
        this.eventLog.WriteEntry(msg);
      }
    }

    public static void Write(Log log, string msg)
    {
      if (log != null)
      {
        log.Write(msg);
      }
    }
  }
}
