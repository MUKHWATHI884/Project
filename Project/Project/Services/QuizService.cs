using System.Collections.Generic;
namespace Project
{
    public class QuizQuestion { public string Question { get; set; } public string[] Options { get; set; } public int CorrectIndex { get; set; } public string Explanation { get; set; } }
    public class QuizService
    {
        public List<QuizQuestion> Questions = new List<QuizQuestion>
        {
            new QuizQuestion { Question = "What should you do if you receive an email asking for your password?", Options = new[]{"Reply with password","Delete the email","Report as phishing"}, CorrectIndex = 2, Explanation = "Reporting phishing emails helps prevent scams." },
            new QuizQuestion { Question = "What makes a strong password?", Options = new[]{"Your birthday","Long mix of letters, numbers and symbols","Your pet's name"}, CorrectIndex = 1, Explanation = "Long and mixed passwords are harder to crack." },
            new QuizQuestion { Question = "What is phishing?", Options = new[]{"A type of malware","Fake messages to steal your info","A firewall"}, CorrectIndex = 1, Explanation = "Phishing tricks you into giving away info." },
            new QuizQuestion { Question = "Should you use public Wi-Fi for banking?", Options = new[]{"Yes, always","No, use secure network or VPN","Only at night"}, CorrectIndex = 1, Explanation = "Public Wi-Fi can be intercepted." },
            new QuizQuestion { Question = "What is two-factor authentication?", Options = new[]{"Two passwords","Password + second code e.g. SMS/app","Two usernames"}, CorrectIndex = 1, Explanation = "2FA adds a second layer of security." },
            new QuizQuestion { Question = "A link says 'Update your account now!' What do you do?", Options = new[]{"Click it immediately","Hover/check sender, go to official site","Forward it to friends"}, CorrectIndex = 1, Explanation = "Always verify links before clicking." },
            new QuizQuestion { Question = "What should you do with software updates?", Options = new[]{"Ignore them","Install them promptly","Delete the app"}, CorrectIndex = 1, Explanation = "Updates fix security holes." },
            new QuizQuestion { Question = "What is social engineering?", Options = new[]{"Building apps","Manipulating people to reveal info","Social media marketing"}, CorrectIndex = 1, Explanation = "Attackers manipulate trust to get info." },
            new QuizQuestion { Question = "Is it safe to share your OTP code?", Options = new[]{"Yes with friends","No, never share it","Yes if they ask nicely"}, CorrectIndex = 1, Explanation = "OTP is for you only, never share it." },
            new QuizQuestion { Question = "How often should you review privacy settings?", Options = new[]{"Never","Regularly","Only when hacked"}, CorrectIndex = 1, Explanation = "Regular checks keep your data safe." },
        };
        public int CurrentIndex = 0; public int Score = 0;
        public QuizQuestion GetCurrent() => CurrentIndex < Questions.Count ? Questions[CurrentIndex] : null;
        public string Answer(int chosen) { var q = Questions[CurrentIndex]; string r; if (chosen == q.CorrectIndex) { Score++; r = "Correct! " + q.Explanation; } else { r = "Incorrect. " + q.Explanation; } CurrentIndex++; return r; }
        public string GetFinalFeedback() { if (Score >= 8) return $"You got {Score}/10 - You're a cybersecurity pro!"; if (Score >= 5) return $"You got {Score}/10 - Good job, keep learning!"; return $"You got {Score}/10 - Keep practising, you'll get there!"; }
    }
}