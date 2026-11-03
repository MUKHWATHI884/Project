
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    internal class ChatEngine
    {
        private string userName = "";

        public string UserName
        {
            get { return userName; }
        }

        // Cybersecurity knowledge dictionaries
        private readonly Dictionary<string, string> phishing =
            new Dictionary<string, string>
            {
                { "what is phishing",
                  "Phishing is a cyberattack where criminals pretend " +
                  "to be trusted organizations to steal passwords or " +
                  "personal information. Never click suspicious links." },

                { "phishing prevention",
                  "Check the sender's email address, avoid suspicious " +
                  "links, and never share passwords or verification codes." }
            };

        private readonly Dictionary<string, string> malware =
            new Dictionary<string, string>
            {
                { "what is malware",
                  "Malware is malicious software designed to damage " +
                  "devices, steal information, or gain unauthorized access." },

                { "malware prevention",
                  "Keep your operating system updated, use reputable " +
                  "security software, and avoid unknown downloads." }
            };

        private readonly Dictionary<string, string> twoFA =
            new Dictionary<string, string>
            {
                { "what is 2fa",
                  "Two-factor authentication (2FA) adds an extra " +
                  "verification step to protect your account." },

                { "enable 2fa",
                  "Enable 2FA in your account's security settings. " +
                  "An authenticator app or security key is a good option." }
            };

        private readonly Dictionary<string, string> scams =
            new Dictionary<string, string>
            {
                { "what is a scam",
                  "A scam is a dishonest attempt to steal money or " +
                  "personal information. Examples include fake prizes, " +
                  "investment fraud, and fraudulent messages." },

                { "avoid scams",
                  "Verify unexpected requests independently. Do not " +
                  "send money, disclose verification codes, or click " +
                  "suspicious links under pressure." }
            };

        private readonly Dictionary<string, string> strongPasswords =
            new Dictionary<string, string>
            {
                { "what is a strong password",
                  "A strong password is long, unique, and difficult " +
                  "to guess. A long passphrase can be a good choice." },

                { "password tips",
                  "Use a unique password for every account. Consider " +
                  "a password manager and enable 2FA." }
            };

        private readonly Dictionary<string, string> cybersecurity =
            new Dictionary<string, string>
            {
                { "what is cybersecurity",
                  "Cybersecurity protects computers, networks, accounts, " +
                  "and information from digital attacks and unauthorized access." },

                { "cybersecurity tips",
                  "Update your devices, use unique passwords, enable 2FA, " +
                  "back up important files, and watch out for phishing." }
            };

        private readonly Dictionary<string, string> privacy =
            new Dictionary<string, string>
            {
                { "what is privacy",
                  "Online privacy means controlling how your personal " +
                  "information is collected, shared, and used." },

                { "privacy tips",
                  "Review app permissions, use privacy settings, limit " +
                  "what you share online, and use strong account security." }
            };

        private readonly Dictionary<string, string> vpn =
            new Dictionary<string, string>
            {
                { "what is a vpn",
                  "A VPN, or Virtual Private Network, encrypts the " +
                  "connection between your device and a VPN server. " +
                  "It does not make you completely anonymous." },

                { "vpn safety",
                  "Choose a reputable VPN provider. A VPN can help " +
                  "protect traffic on untrusted networks, but it cannot " +
                  "protect you against every cyberattack." }
            };

        // Capture and remember the user's name
        public string SetUserName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Please enter your name.";

            name = name.Trim();

            if (name.Length > 50 ||
                name.Any(char.IsControl) ||
                name.Any(char.IsDigit))
            {
                return "Please enter a valid name.";
            }

            userName = name;

            return $"Nice to meet you, {userName}! " +
                   "I'm a Cybersecurity Chatbot. " +
                   "Ask me about phishing, malware, 2FA, scams, " +
                   "strong passwords, cybersecurity, privacy, or VPNs.";
        }
        // Process user messages
        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return "Please type a message.";

            string input = message.Trim().ToLowerInvariant();

            if (input == "help" || input.Contains("what can you do"))
            {
                return "I can help you with these topics:\n" +
                       "1. Phishing\n" +
                       "2. Malware\n" +
                       "3. Two-factor authentication (2FA)\n" +
                       "4. Scams\n" +
                       "5. Strong passwords\n" +
                       "6. Cybersecurity\n" +
                       "7. Privacy\n" +
                       "8. VPNs\n\n" +
                       "Try asking: What is phishing?";
            }

            if (input == "hi" || input == "hello" ||
                input.StartsWith("hello ") || input.StartsWith("hi "))
            {
                return "Hello, " + GetNameOrFriend() +
                       "! How can I help you stay safe online?";
            }

            if (input.Contains("your name") || input.Contains("who are you"))
            {
                return "I'm your Cybersecurity Chatbot, your " +
                       "assistant for learning about online security.";
            }

            if (input.Contains("thank"))
                return "You're welcome, " + GetNameOrFriend() +
                       "! Stay safe online.";

            if (input == "bye" || input == "goodbye")
                return "Goodbye, " + GetNameOrFriend() +
                       "! Remember to protect your accounts.";

            // Look for known questions in the dictionaries.
            string answer;

            if (TryDictionary(phishing, input, out answer))
                return answer;

            if (TryDictionary(malware, input, out answer))
                return answer;

            if (TryDictionary(twoFA, input, out answer))
                return answer;

            if (TryDictionary(scams, input, out answer))
                return answer;

            if (TryDictionary(strongPasswords, input, out answer))
                return answer;

            if (TryDictionary(cybersecurity, input, out answer))
                return answer;

            if (TryDictionary(privacy, input, out answer))
                return answer;

            if (TryDictionary(vpn, input, out answer))
                return answer;

            // Match common alternative ways of asking questions.
            if (input.Contains("phishing") || input.Contains("fake email"))
                return phishing["what is phishing"];

            if (input.Contains("malware") || input.Contains("ransomware") ||
                input.Contains("spyware") || input.Contains("computer virus"))
                return malware["what is malware"];

            if (input.Contains("2fa") || input.Contains("two-factor") ||
                input.Contains("two factor") || input.Contains("authentication"))
                return twoFA["what is 2fa"];

            if (input.Contains("scam") || input.Contains("fraud"))
                return scams["what is a scam"];

            if (input.Contains("password") || input.Contains("passphrase"))
                return strongPasswords["what is a strong password"];

            if (input.Contains("cybersecurity") || input.Contains("cyber security"))
                return cybersecurity["what is cybersecurity"];

            if (input.Contains("privacy") || input.Contains("personal information"))
                return privacy["what is privacy"];

            if (input.Contains("vpn") || input.Contains("virtual private network"))
                return vpn["what is a vpn"];

            if (input.Contains("hacked") || input.Contains("account stolen"))
            {
                return "If your account may be compromised, use a trusted " +
                       "device to change your password, secure any accounts " +
                       "using the same password, enable 2FA, review active " +
                       "sessions, and contact the service's official support.";
            }

            return "Sorry, " + GetNameOrFriend() +
                   ", I don't know the answer to that yet.\n\n" +
                   "Type 'help' to see my cybersecurity topics.";
        }

        private bool TryDictionary(
            Dictionary<string, string> dictionary,
            string input,
            out string answer)
        {
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                if (input.Contains(item.Key))
                {
                    answer = item.Value;
                    return true;
                }
            }

            answer = "";
            return false;
        }

        private string GetNameOrFriend()
        {
            return string.IsNullOrWhiteSpace(userName)
                ? "there"
                : userName;
        }
    }
}
