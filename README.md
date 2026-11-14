### Cybersecurity Chatbot
### Project Overview

The Cybersecurity Chatbot is a C# Windows Forms application designed to provide users with basic cybersecurity information, guidance, and awareness. The chatbot uses predefined responses and keyword recognition to answer questions about common cybersecurity topics.

The application provides an interactive environment where users can communicate with the chatbot, learn about online threats, and receive advice on protecting their personal information and digital accounts.

### Project Objectives

The main objectives of this project are to:

Promote cybersecurity awareness among users.
Provide basic information about common cyber threats.
Educate users on how to protect their personal information online.
Encourage safe internet browsing and responsible online behaviour.
Create an interactive chatbot using C# programming.

### Features

The Cybersecurity Chatbot includes the following features:

Personalized Greetings: Welcomes users and asks for their names before starting a conversation.
Name Recognition: Extracts and remembers the user's name from introductions such as "Hi, my name is Frank."
Interactive Conversations: Responds to greetings, questions, expressions of gratitude, and goodbye messages.
Keyword Recognition: Identifies cybersecurity-related questions using predefined keywords.
Cybersecurity Knowledge Base: Provides information and recommendations on different cybersecurity topics.
Help Function: Displays a list of available topics users can explore.
Error Handling: Provides appropriate responses when users enter invalid names, empty messages, or unsupported questions.

### Cybersecurity Topics Covered

The chatbot provides information on eight main cybersecurity topics:


Phishing: Explains phishing attacks and ways to identify and prevent suspicious messages.
Malware: Explains malicious software, including viruses, spyware, and ransomware.
Two-Factor Authentication (2FA): Explains additional account verification and how to enable it.
Online Scams: Provides information about fraudulent activities and ways to avoid scams.
Strong Passwords: Explains password security and the importance of using unique passwords.
Cybersecurity Awareness: Introduces cybersecurity principles and recommended security practices.
Online Privacy: Explains how users can protect their personal information.
Virtual Private Networks (VPNs): Explains VPN technology and its role in online privacy and security.

### Technologies Used
Programming Language: C#
Development Environment: Visual Studio
Framework: Windows Forms (.NET)
User Interface: Windows Forms controls
Data Storage: Predefined dictionaries containing cybersecurity questions and answers.


### How the Chatbot Works

The chatbot uses a rule-based approach to process user messages.

Greeting Process

When the application starts, the chatbot introduces itself and requests the user's name.

Example:

Bot: Hello! Welcome to the Cybersecurity Chatbot.

I'm here to help you understand cybersecurity and stay safe online.

Before we begin, may I know your name?

User: Hi, my name is Frank.

Bot: Nice to meet you, Frank! How may I assist you today?

The chatbot extracts the user's name and stores it for use during the conversation.

Message Processing

When a user sends a message:

The chatbot checks whether the message is empty.
It determines whether the user's name has been provided.
It identifies greetings and conversational messages.
It searches its predefined cybersecurity dictionaries.
It checks for alternative keywords and related questions.
It displays the appropriate response.
If the question is not recognized, it provides a fallback response and suggests using the help command.


### Project Structure

The main chatbot logic is implemented in the ChatEngine.cs class.

The class contains:

GetGreeting() – Displays the chatbot's initial greeting.
ExtractName() – Extracts the user's name from an introductory message.
SetUserName() – Validates and saves the user's name.
GetResponse() – Processes messages and generates chatbot responses.
TryDictionary() – Searches the cybersecurity knowledge dictionaries.

The Windows Forms interface handles user input, displays messages, and connects the Start and Send buttons to the chatbot engine.

### How to Run the Application
Open the project in Microsoft Visual Studio.
Build the solution to check for compilation errors.
Run the application.
Click the Start button to display the initial greeting.
Enter your name in the message textbox.
Click Send to receive a personalized greeting.
Ask questions about any of the supported cybersecurity topics.
Type help to view the available topics.


### Limitations

The chatbot currently uses predefined responses and keyword matching. It does not use artificial intelligence or machine learning to understand every possible question.

Its responses are limited to the cybersecurity information programmed into its knowledge base. Questions outside its supported topics may receive a fallback response.

### Future Improvements

Possible future improvements include:

Integrating artificial intelligence for more natural conversations.
Expanding the cybersecurity knowledge base.
Adding more cybersecurity topics.
Improving natural language processing.
Introducing conversation history and user preferences.
Adding more interactive learning features and cybersecurity quizzes.
11. Conclusion

The Cybersecurity Chatbot provides an interactive way for users to learn about cybersecurity and online safety. Through personalized greetings, keyword recognition, and predefined responses, the application demonstrates how C# programming can be used to develop a basic rule-based chatbot.

The project aims to improve cybersecurity awareness and encourage users to adopt safer online practices.
# Cybersecurity Chatbot

## Project Overview

The Cybersecurity Chatbot is a C# Windows Forms application designed to provide users with basic cybersecurity information, guidance, and awareness. It uses predefined responses, keyword recognition, and simulated Natural Language Processing (NLP) to answer questions about common cybersecurity topics.

The application provides an interactive environment where users can communicate with the chatbot, learn about online threats, manage cybersecurity tasks, test their knowledge with a quiz, and view their activity history.

The app has 4 tabs:
- **Chat** - Main chatbot with NLP
- **Task Assistant** - Task management with MySQL database
- **Quiz** - Cybersecurity mini-game (10 questions)
- **Activity Log** - Log of everything the user does

## Project Objectives

The main objectives of this project are to:

- Promote cybersecurity awareness among users.
- Provide basic information about common cyber threats.
- Educate users on how to protect their personal information online.
- Encourage safe internet browsing and responsible online behaviour.
- Create an interactive chatbot using C# programming.
- Demonstrate database integration, NLP simulation, gamification, and activity logging in one application.

## Features

### 1. Chat Tab - NLP Simulation & Cybersecurity Chatbot
- **Personalized Greetings:** Welcomes users and asks for their names before starting a conversation.
- **Name Recognition:** Extracts and remembers the user's name. Validates names (no numbers, no control characters, max 50 chars).
- **Interactive Conversations:** Responds to greetings, questions, expressions of gratitude, and goodbye messages.
- **Keyword Recognition:** Identifies cybersecurity-related questions using predefined keywords.
- **Cybersecurity Knowledge Base:** Provides information on 8 topics.
- **Help Function:** Type `help` to display a list of available topics.
- **Error Handling:** Provides appropriate responses when users enter invalid names, empty messages, or unsupported questions.
- **Chat Bubbles UI:** Pink / light-grey rounded message bubbles built with a custom `BubblePanel` class. User messages are pink, bot messages are grey.
- **Greeting Sound:** Plays a greeting sound (`voice/ai sound.wav`) on start / restart.
- **Logo:** Displays the project logo at the top of the Chat tab.

### 2. Task Assistant Tab - Task 1: Database Integration
- **Add Task:** User types a Title, Description, and Reminder Date and clicks Add Task.
- **View Tasks:** All tasks are loaded from the MySQL database and shown in a list: `ID. Title | Reminder: Date | Done: True/False`.
- **Delete Task:** Select a task and delete it from the database.
- **Mark Complete:** Select a task and mark it as completed - updates `IsCompleted = 1` in the database.
- **Chat Integration:** You can also add tasks from Chat by typing: `Add task - Review privacy settings` or `Remind me to enable 2FA`. The chatbot creates the task and sets a reminder for 3 days from now.
- **Database:** Tasks are stored permanently in MySQL, not just in memory. Closing and reopening the app keeps your tasks.

### 3. Quiz Tab - Task 2: Cybersecurity Mini-Game
- **10 Questions:** Multiple-choice questions about phishing, passwords, safe browsing, social engineering, 2FA, OTP, software updates, and privacy.
- **Example:** *What should you do if you receive an email asking for your password? A) Reply B) Delete C) Report as phishing*
- **One At A Time:** Shows 1 question at a time with 3 options (A, B, C).
- **Immediate Feedback:** After each answer it says immediately: `Correct! Reporting phishing emails helps prevent scams.` or `Incorrect. [Explanation]`
- **Final Score:** At the end it shows: `You got 7/10 - You're a cybersecurity pro!` / `Good job, keep learning!` / `Keep practising, you'll get there!`
- **Chat Integration:** You can also start the quiz from Chat by typing: `quiz`, `game`, or `play`, then answer with `A`, `B`, or `C`.

### 4. Activity Log Tab - Task 4: Activity Log
- **Logs Everything:** Every important action is logged with a timestamp:
    - `2026-11-14 14:20 - Task added: Review privacy settings`
    - `2026-11-14 14:21 - Quiz started`
    - `2026-11-14 14:23 - Quiz completed - Score: 7/10`
    - `2026-11-14 14:24 - Task completed: ID 2`
    - `2026-11-14 14:25 - User set name: Frank`
- **Recent View:** By default shows the last 10 entries.
- **Full History:** Click `Show More` to see the full history.
- **Chat Integration:** Type `Show log` in Chat to see the last 10, or `Show more` to see full history.

### 5. NLP Simulation - Task 3
The chatbot does not use real AI. It uses keyword-based intent detection in `NlpService.cs`:
- If message contains `add task`, `remind me`, `reminder`, `create task` -> Intent = `add_task`
- If message contains `quiz`, `game`, `play`, `test me` -> Intent = `quiz`
- If message contains `log`, `history`, `activity` -> Intent = `log`
- If message contains `show more` -> Intent = `show_more`
- If message contains `password`, `phishing`, `privacy`, `scam` -> Cybersecurity topic
- If nothing matches -> Fallback: `I didn't quite understand. Could you rephrase?`

It also handles variations: `Add task`, `Add a task`, `Remind me`, `Remind me to...` all work the same.

## Cybersecurity Topics Covered

The chatbot provides information on eight main cybersecurity topics:

1. **Phishing:** Explains phishing attacks and ways to identify and prevent suspicious messages.
2. **Malware:** Explains malicious software, including viruses, spyware, and ransomware.
3. **Two-Factor Authentication (2FA):** Explains additional account verification and how to enable it.
4. **Online Scams:** Provides information about fraudulent activities and ways to avoid scams.
5. **Strong Passwords:** Explains password security and the importance of using unique passwords.
6. **Cybersecurity Awareness:** Introduces cybersecurity principles and recommended security practices.
7. **Online Privacy:** Explains how users can protect their personal information.
8. **Virtual Private Networks (VPNs):** Explains VPN technology and its role in online privacy and security.

## Technologies Used

- **Programming Language:** C#
- **Development Environment:** Visual Studio 2022
- **Framework:** Windows Forms (.NET)
- **User Interface:** Windows Forms controls + custom `BubblePanel` with `GraphicsPath` for rounded bubbles
- **Database:** MySQL (via XAMPP or MySQL Workbench)
- **Database Connector:** `MySqlConnector` NuGet package (`MySqlConnector.MySqlConnection`)
- **Data Storage:** MySQL table `Tasks` + predefined dictionaries containing cybersecurity questions and answers + in-memory `List<string>` for Activity Log
- **Audio:** `System.Media.SoundPlayer` for greeting sound

## How the Chatbot Works

The chatbot uses a rule-based approach to process user messages.

### Greeting Process

When the application starts, the chatbot introduces itself and requests the user's name.

### Lisense
Zwivhuya Mukhwathi @2026
