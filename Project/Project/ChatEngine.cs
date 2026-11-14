using Project.Data;
using Project;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    internal class ChatEngine
    {
        // --- NEW: Services for Task 1, 2, 4 ---
        public TaskRepository TaskRepo = new TaskRepository();
        public QuizService Quiz = new QuizService();
        public ActivityLogger Logger = new ActivityLogger();
        public NlpService Nlp = new NlpService();
        public bool QuizActive = false;

        private string userName = "";
        public string UserName { get { return userName; } }

        // --- YOUR ORIGINAL DICTIONARIES - UNCHANGED ---
        private readonly Dictionary<string, string> phishing = new Dictionary<string, string>
        {
            { "what is phishing", "Phishing is a cyberattack where criminals pretend to be trusted organizations to steal passwords or personal information. Never click suspicious links." },
            { "phishing prevention", "Check the sender's email address, avoid suspicious links, and never share passwords or verification codes." }
        };
        private readonly Dictionary<string, string> malware = new Dictionary<string, string>
        {
            { "what is malware", "Malware is malicious software designed to damage devices, steal information, or gain unauthorized access." },
            { "malware prevention", "Keep your operating system updated, use reputable security software, and avoid unknown downloads." }
        };
        private readonly Dictionary<string, string> twoFA = new Dictionary<string, string>
        {
            { "what is 2fa", "Two-factor authentication (2FA) adds an extra verification step to protect your account." },
            { "enable 2fa", "Enable 2FA in your account's security settings. An authenticator app or security key is a good option." }
        };
        private readonly Dictionary<string, string> scams = new Dictionary<string, string>
        {
            { "what is a scam", "A scam is a dishonest attempt to steal money or personal information. Examples include fake prizes, investment fraud, and fraudulent messages." },
            { "avoid scams", "Verify unexpected requests independently. Do not send money, disclose verification codes, or click suspicious links under pressure." }
        };
        private readonly Dictionary<string, string> strongPasswords = new Dictionary<string, string>
        {
            { "what is a strong password", "A strong password is long, unique, and difficult to guess. A long passphrase can be a good choice." },
            { "password tips", "Use a unique password for every account. Consider a password manager and enable 2FA." }
        };
        private readonly Dictionary<string, string> cybersecurity = new Dictionary<string, string>
        {
            { "what is cybersecurity", "Cybersecurity protects computers, networks, accounts, and information from digital attacks and unauthorized access." },
            { "cybersecurity tips", "Update your devices, use unique passwords, enable 2FA, back up important files, and watch out for phishing." }
        };
        private readonly Dictionary<string, string> privacy = new Dictionary<string, string>
        {
            { "what is privacy", "Online privacy means controlling how your personal information is collected, shared, and used." },
            { "privacy tips", "Review app permissions, use privacy settings, limit what you share online, and use strong account security." }
        };
        private readonly Dictionary<string, string> vpn = new Dictionary<string, string>
        {
            { "what is a vpn", "A VPN, or Virtual Private Network, encrypts the connection between your device and a VPN server. It does not make you completely anonymous." },
            { "vpn safety", "Choose a reputable VPN provider. A VPN can help protect traffic on untrusted networks, but it cannot protect you against every cyberattack." }
        };

        public string SetUserName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Please enter your name.";
            name = name.Trim();
            if (name.Length > 50 || name.Any(char.IsControl) || name.Any(char.IsDigit))
                return "Please enter a valid name.";
            userName = name;
            Logger.Log($"User set name: {userName}");
            return $"Nice to meet you, {userName}! I'm a Cybersecurity Chatbot. Ask me about phishing, malware, 2FA, scams, strong passwords, cybersecurity, privacy, or VPNs. You can also say 'Add task', 'Start quiz', or 'Show log'.";
        }

        // --- NEW: Quiz helpers called from Form1.cs Quiz tab ---
        public string StartQuiz()
        {
            QuizActive = true;
            Quiz.CurrentIndex = 0; Quiz.Score = 0;
            Logger.Log("Quiz started");
            var q = Quiz.GetCurrent();
            return $"Let's start the quiz!\n{q.Question}\nA) {q.Options[0]}\nB) {q.Options[1]}\nC) {q.Options[2]}";
        }

        public string AnswerQuiz(int choice)
        {
            if (!QuizActive) return "Press Start Quiz first.";
            string feedback = Quiz.Answer(choice);
            if (Quiz.CurrentIndex >= Quiz.Questions.Count)
            {
                QuizActive = false;
                Logger.Log($"Quiz completed - Score: {Quiz.Score}/10");
                return $"{feedback}\n\nQuiz finished! {Quiz.GetFinalFeedback()}";
            }
            var next = Quiz.GetCurrent();
            return $"{feedback}\n\nNext: {next.Question}\nA) {next.Options[0]}\nB) {next.Options[1]}\nC) {next.Options[2]}";
        }

        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return "Please type a message.";
            string input = message.Trim().ToLowerInvariant();

            // --- NEW: If quiz is active in CHAT, A/B/C answers go to quiz ---
            if (QuizActive)
            {
                int choice = -1;
                if (input == "a" || input == "1" || input.StartsWith("a)")) choice = 0;
                if (input == "b" || input == "2" || input.StartsWith("b)")) choice = 1;
                if (input == "c" || input == "3" || input.StartsWith("c)")) choice = 2;
                if (choice != -1) return AnswerQuiz(choice);
            }

            // --- NEW: NLP Intent Detection - Task 3 ---
            string intent = Nlp.DetectIntent(input);

            if (intent == "add_task")
            {
                // Handles: "Add task - Review privacy settings" / "Remind me to..."
                string title = message.Trim();
                foreach (var p in new[] { "add task", "add a task", "remind me to", "remind me", "create task" })
                    if (title.ToLower().Contains(p)) title = title.Substring(title.ToLower().IndexOf(p) + p.Length).TrimStart('-', ' ', ':');
                if (string.IsNullOrWhiteSpace(title)) title = "New Task";
                TaskRepo.AddTask(new TaskItem { Title = title, ReminderDate = DateTime.Now.AddDays(3) });
                Logger.Log($"Task added: {title}");
                return $"Task added: '{title}'. Reminder set for 3 days from now.";
            }

            if (intent == "quiz") return StartQuiz();

            if (intent == "log")
            {
                Logger.Log("Viewed activity log");
                var recent = Logger.GetRecentLogs(10);
                if (recent.Count == 0) return "No activity yet.";
                return "Here's a summary of recent actions:\n" + string.Join("\n", recent) + "\n\nType 'Show more' to see full history, or check the Activity Log tab.";
            }

            if (intent == "show_more")
            {
                if (Logger.Logs.Count == 0) return "No activity yet.";
                return "Full history:\n" + string.Join("\n", Logger.Logs);
            }

            // --- YOUR ORIGINAL CODE FROM HERE DOWN ---
            if (input == "help" || input.Contains("what can you do"))
            {
                return "I can help you with these topics:\n1. Phishing\n2. Malware\n3. Two-factor authentication (2FA)\n4. Scams\n5. Strong passwords\n6. Cybersecurity\n7. Privacy\n8. VPNs\n\nAlso try: 'Add task - Review privacy settings', 'Start quiz', or 'Show log'";
            }
            if (input == "hi" || input == "hello" || input.StartsWith("hello ") || input.StartsWith("hi "))
                return "Hello, " + GetNameOrFriend() + "! How can I help you stay safe online?";
            if (input.Contains("your name") || input.Contains("who are you"))
                return "I'm your Cybersecurity Chatbot, your assistant for learning about online security.";
            if (input.Contains("thank")) return "You're welcome, " + GetNameOrFriend() + "! Stay safe online.";
            if (input == "bye" || input == "goodbye") return "Goodbye, " + GetNameOrFriend() + "! Remember to protect your accounts.";

            string answer;
            if (TryDictionary(phishing, input, out answer)) return answer;
            if (TryDictionary(malware, input, out answer)) return answer;
            if (TryDictionary(twoFA, input, out answer)) return answer;
            if (TryDictionary(scams, input, out answer)) return answer;
            if (TryDictionary(strongPasswords, input, out answer)) return answer;
            if (TryDictionary(cybersecurity, input, out answer)) return answer;
            if (TryDictionary(privacy, input, out answer)) return answer;
            if (TryDictionary(vpn, input, out answer)) return answer;

            if (input.Contains("phishing") || input.Contains("fake email")) return phishing["what is phishing"];
            if (input.Contains("malware") || input.Contains("ransomware") || input.Contains("spyware") || input.Contains("computer virus")) return malware["what is malware"];
            if (input.Contains("2fa") || input.Contains("two-factor") || input.Contains("two factor") || input.Contains("authentication")) return twoFA["what is 2fa"];
            if (input.Contains("scam") || input.Contains("fraud")) return scams["what is a scam"];
            if (input.Contains("password") || input.Contains("passphrase")) return strongPasswords["what is a strong password"];
            if (input.Contains("cybersecurity") || input.Contains("cyber security")) return cybersecurity["what is cybersecurity"];
            if (input.Contains("privacy") || input.Contains("personal information")) return privacy["what is privacy"];
            if (input.Contains("vpn") || input.Contains("virtual private network")) return vpn["what is a vpn"];
            if (input.Contains("hacked") || input.Contains("account stolen"))
                return "If your account may be compromised, use a trusted device to change your password, secure any accounts using the same password, enable 2FA, review active sessions, and contact the service's official support.";

            // NEW: Better fallback for NLP - still tries to help
            return "Sorry, " + GetNameOrFriend() + ", I didn't quite understand. Could you rephrase?\nType 'help' to see my cybersecurity topics, or try 'Add task', 'Start quiz', or 'Show log'.";
        }

        private bool TryDictionary(Dictionary<string, string> dictionary, string input, out string answer)
        {
            foreach (var item in dictionary)
                if (input.Contains(item.Key)) { answer = item.Value; return true; }
            answer = ""; return false;
        }
        private string GetNameOrFriend() { return string.IsNullOrWhiteSpace(userName) ? "there" : userName; }
    }
}