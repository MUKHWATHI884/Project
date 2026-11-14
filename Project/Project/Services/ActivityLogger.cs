using System;
using System.Collections.Generic;
using System.Linq;
namespace Project { public class ActivityLogger { public List<string> Logs = new List<string>(); public void Log(string a) { Logs.Add($"{DateTime.Now:yyyy-MM-dd HH:mm} - {a}"); } public List<string> GetRecentLogs(int n = 10) { return Logs.TakeLast(n).ToList(); } } }