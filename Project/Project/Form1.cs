using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;

namespace Project
{
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
        }

        private void SetupChat()
        {
            TextBox logBox = null;
            TextBox inputBox = null;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb)
                {
                    if (tb.Multiline) logBox = tb;
                    else inputBox = tb;
                }
            }

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
                SoundPlayer player = new SoundPlayer(@"C:\Users\Student\source\repos\Project\Project\voice\ai sound.wav");
                player.Play();
            }
            catch { }
        }

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Student\source\repos\Cybersecurity\logo\Screenshot 2026-09-08 145524.png");
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
            Panel row = new Panel() { Width = w, Margin = new Padding(0, 0, 0, 10), BackColor = Color.White, Tag = isUser };
            BubblePanel bubble = new BubblePanel() { Width = bw, BubbleColor = isUser ? Color.FromArgb(255, 182, 193) : Color.FromArgb(240, 240, 240) };
            Label txt = new Label() { Width = bw - 10, Font = new Font("Segoe UI", 9F), Text = (isUser ? "You" : "Bot") + Environment.NewLine + message, BackColor = Color.Transparent, ForeColor = Color.FromArgb(60, 60, 60), Padding = new Padding(10) };
            Size sz = TextRenderer.MeasureText(txt.Text, txt.Font, new Size(bw - 20, 0), TextFormatFlags.WordBreak);
            txt.Height = sz.Height + 16; bubble.Height = txt.Height + 8; row.Height = bubble.Height + 2;
            txt.Location = new Point(4, 2); bubble.Controls.Add(txt);
            bubble.Location = new Point(isUser ? row.Width - bubble.Width : 0, 0);
            row.Controls.Add(bubble); flowChat.Controls.Add(row); flowChat.ScrollControlIntoView(row);
        }

        private void SendMessage()
        {
            TextBox input = null;
            foreach (Control c in this.Controls) if (c is TextBox tb && !tb.Multiline) input = tb;
            if (input == null) return;
            string msg = input.Text.Trim(); if (msg == "") return;

            AddMessage(msg, true); input.Clear();
            string response = waitingForName ? chatEngine.SetUserName(msg) : chatEngine.GetResponse(msg);
            if (waitingForName) waitingForName = false;
            if (response.Contains("Goodbye")) waitingForName = true;

            AddMessage(response, false); input.Focus();
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
    }
}