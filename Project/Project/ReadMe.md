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

### Lisense
Zwivhuya Mukhwathi @2026