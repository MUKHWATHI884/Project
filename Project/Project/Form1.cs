using Project;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        private ChatEngine chatEngine = new ChatEngine();
        private FlowLayoutPanel flowChat;
        private bool waitingForName = true;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(255, 238, 242);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();
            SetupChat();
            AddMessage("Hello! I'm your Cybersecurity Chatbot.\nWhat is your name?", false);
            RefreshTaskList();
            RefreshActivityLog();
        }

        // FIXED: Search inside TabPages too, not just Form
        private TextBox FindTextBox(Control parent, bool multiline)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb && tb.Multiline == multiline) return tb;
                var found = FindTextBox(c, multiline);
                if (found != null) return found;
            }
            return null;
        }

        private Control FindControl(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name == name) return c;
                var found = FindControl(c, name);
                if (found != null) return found;
            }
            return null;
        }

        private void SetupChat()
        {
            TextBox logBox = FindTextBox(this, true);
            TextBox inputBox = FindTextBox(this, false);

            if (logBox != null)
            {
                flowChat = new FlowLayoutPanel();
                flowChat.Location = logBox.Location;
                flowChat.Size = logBox.Size;
                flowChat.Anchor = logBox.Anchor;
                flowChat.FlowDirection = FlowDirection.TopDown;
                flowChat.WrapContents = false;
                flowChat.AutoScroll = true;
                flowChat.BackColor = Color.White;
                flowChat.Padding = new Padding(8);
                logBox.Visible = false;
                logBox.Parent.Controls.Add(flowChat);
                flowChat.BringToFront();
            }

            if (inputBox != null) inputBox.KeyDown += ChatInput_KeyDown;
        }

        private void PlayGreeting()
        {
            try
            {
                // Use relative path so it works on lecturer's PC too
                string path = System.IO.Path.Combine(Application.StartupPath, "voice", "ai sound.wav");
                if (!System.IO.File.Exists(path))
                    path = @"C:\Users\Student\source\repos\Project\Project\voice\ai sound.wav";
                new SoundPlayer(path).Play();
            }
            catch { }
        }

        private void DisplayLogo()
        {
            try
            {
                // Try your project folder first
                string path = System.IO.Path.Combine(Application.StartupPath, "logo.png");
                if (!System.IO.File.Exists(path))
                    path = @"C:\Users\Student\source\repos\Project\Project\logo\Screenshot 2026-09-08 145524.png";
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackColor = Color.FromArgb(255, 238, 242);
            }
            catch { }
        }

        private void AddMessage(string message, bool isUser)
        {
            if (flowChat == null) return;
            int w = flowChat.ClientSize.Width - 30;
            int bw = Math.Min(w * 3 / 4, 280);
            Panel row = new Panel() { Width = w, Margin = new Padding(0, 0, 0, 10), BackColor = Color.White };
            BubblePanel bubble = new BubblePanel() { Width = bw, BubbleColor = isUser ? Color.FromArgb(255, 182, 193) : Color.FromArgb(240, 240, 240) };
            Label txt = new Label() { Width = bw - 10, Font = new Font("Segoe UI", 9F), Text = (isUser ? "You" : "Bot") + Environment.NewLine + message, BackColor = Color.Transparent, ForeColor = Color.FromArgb(60, 60, 60), Padding = new Padding(10) };
            Size sz = TextRenderer.MeasureText(txt.Text, txt.Font, new Size(bw - 20, 0), TextFormatFlags.WordBreak);
            txt.Height = sz.Height + 16; bubble.Height = txt.Height + 8; row.Height = bubble.Height + 2;
            txt.Location = new Point(4, 2); bubble.Controls.Add(txt);
            bubble.Location = new Point(isUser ? row.Width - bubble.Width : 0, 0);
            row.Controls.Add(bubble); flowChat.Controls.Add(row); flowChat.ScrollControlIntoView(row);
        }

        // FIXED: Removed bad InitializeComponent() from inside here
        public class BubblePanel : Panel
        {
            public int Radius = 16;
            public Color BubbleColor = Color.White;
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, Radius, Radius, 180, 90);
                    path.AddArc(Width - Radius - 1, 0, Radius, Radius, 270, 90);
                    path.AddArc(Width - Radius - 1, Height - Radius - 1, Radius, Radius, 0, 90);
                    path.AddArc(0, Height - Radius - 1, Radius, Radius, 90, 90);
                    path.CloseFigure();
                    using (SolidBrush b = new SolidBrush(BubbleColor))
                        e.Graphics.FillPath(b, path);
                }
            }
        }

        private void SendMessage()
        {
            TextBox input = FindTextBox(this, false);
            if (input == null) return;
            string msg = input.Text.Trim(); if (msg == "") return;

            AddMessage(msg, true); input.Clear();
            string response = waitingForName ? chatEngine.SetUserName(msg) : chatEngine.GetResponse(msg);
            if (waitingForName) waitingForName = false;
            if (response.Contains("Goodbye")) waitingForName = true;

            AddMessage(response, false);
            RefreshTaskList();
            RefreshActivityLog();
            input.Focus();
        }

        // --- TASK ASSISTANT TAB ---
        private void RefreshTaskList()
        {
            var lst = FindControl(this, "lstTasks") as ListBox;
            if (lst == null) return;
            lst.Items.Clear();
            foreach (var t in chatEngine.TaskRepo.GetAllTasks())
                lst.Items.Add($"{t.Id}. {t.Title} | Reminder: {t.ReminderDate?.ToShortDateString()} | Done: {t.IsCompleted}");
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var txtTitle = FindControl(this, "txtTaskTitle") as TextBox;
            var txtDesc = FindControl(this, "txtTaskDesc") as TextBox;
            var dtp = FindControl(this, "dtpReminder") as DateTimePicker;
            if (txtTitle == null || string.IsNullOrWhiteSpace(txtTitle.Text)) return;
            chatEngine.TaskRepo.AddTask(new TaskItem { Title = txtTitle.Text, Description = txtDesc?.Text ?? "", ReminderDate = dtp?.Value ?? DateTime.Now.AddDays(3) });
            chatEngine.Logger.Log($"Task added: {txtTitle.Text}");
            AddMessage($"Task added: {txtTitle.Text}", false);
            RefreshTaskList(); RefreshActivityLog();
            txtTitle.Clear();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            var lst = FindControl(this, "lstTasks") as ListBox;
            if (lst?.SelectedItem == null) return;
            string s = lst.SelectedItem.ToString();
            int id = int.Parse(s.Split('.')[0]);
            chatEngine.TaskRepo.DeleteTask(id);
            chatEngine.Logger.Log($"Task deleted: ID {id}");
            RefreshTaskList(); RefreshActivityLog();
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            var lst = FindControl(this, "lstTasks") as ListBox;
            if (lst?.SelectedItem == null) return;
            int id = int.Parse(lst.SelectedItem.ToString().Split('.')[0]);
            chatEngine.TaskRepo.MarkComplete(id);
            chatEngine.Logger.Log($"Task completed: ID {id}");
            RefreshTaskList(); RefreshActivityLog();
        }

        // --- QUIZ TAB ---
        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            string start = chatEngine.StartQuiz();
            AddMessage(start, false);
            ShowCurrentQuizQuestion();
        }

        private void ShowCurrentQuizQuestion()
        {
            var lbl = FindControl(this, "lblQuizQuestion") as Label;
            var btnA = FindControl(this, "btnOptionA") as Button;
            var btnB = FindControl(this, "btnOptionB") as Button;
            var btnC = FindControl(this, "btnOptionC") as Button;
            var q = chatEngine.Quiz.GetCurrent();
            if (q == null || lbl == null) return;
            lbl.Text = q.Question;
            if (btnA != null) btnA.Text = "A) " + q.Options[0];
            if (btnB != null) btnB.Text = "B) " + q.Options[1];
            if (btnC != null) btnC.Text = "C) " + q.Options[2];
        }

        private void QuizAnswer_Click(int choice)
        {
            string feedback = chatEngine.AnswerQuiz(choice);
            AddMessage(feedback, false);
            var lblFeedback = FindControl(this, "lblQuizFeedback") as Label;
            if (lblFeedback != null) lblFeedback.Text = feedback;
            if (!chatEngine.QuizActive) RefreshActivityLog();
            else ShowCurrentQuizQuestion();
        }
        private void btnOptionA_Click(object sender, EventArgs e) => QuizAnswer_Click(0);
        private void btnOptionB_Click(object sender, EventArgs e) => QuizAnswer_Click(1);
        private void btnOptionC_Click(object sender, EventArgs e) => QuizAnswer_Click(2);

        // --- ACTIVITY LOG TAB ---
        private void RefreshActivityLog()
        {
            var lst = FindControl(this, "lstActivityLog") as ListBox;
            if (lst == null) return;
            lst.Items.Clear();
            foreach (var log in chatEngine.Logger.GetRecentLogs(10))
                lst.Items.Add(log);
        }

        private void btnShowMoreLog_Click(object sender, EventArgs e)
        {
            var lst = FindControl(this, "lstActivityLog") as ListBox;
            if (lst == null) return;
            lst.Items.Clear();
            foreach (var log in chatEngine.Logger.Logs)
                lst.Items.Add(log);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            waitingForName = true;
            PlayGreeting();
            AddMessage("Let's start over - what is your name?", false);
        }

        private void button2_Click(object sender, EventArgs e) => SendMessage();
        private void button3_Click(object sender, EventArgs e) => SendMessage();
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void ChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                SendMessage();
            }
        }
        private void tabChat_Click(object sender, EventArgs e) { }
        private void tabChat_Click_1(object sender, EventArgs e) { }
    }
}