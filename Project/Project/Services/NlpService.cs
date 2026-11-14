namespace Project
{
    public class NlpService
    {
        public string DetectIntent(string input)
        {
            string t = input.ToLower();
            if (t.Contains("add task") || t.Contains("add a task") || t.Contains("remind me") || t.Contains("reminder") || t.Contains("create task")) return "add_task";
            if (t.Contains("quiz") || t.Contains("game") || t.Contains("play") || t.Contains("test me")) return "quiz";
            if (t.Contains("show more")) return "show_more";
            if (t.Contains("log") || t.Contains("history") || t.Contains("activity")) return "log";
            return "chat";
        }
    }
}