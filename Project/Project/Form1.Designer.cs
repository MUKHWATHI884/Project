namespace Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ChatInput = new TextBox();
            type = new TextBox();
            tabLog = new TabPage();
            lstActivityLog = new ListBox();
            btnShowMoreLog = new Button();
            tabQuiz = new TabPage();
            lblQuizQuestion = new Label();
            lblQuizFeedback = new Label();
            btnStartQuiz = new Button();
            btnOptionA = new Button();
            btnOptionB = new Button();
            btnOptionC = new Button();
            tabTasks = new TabPage();
            txtTaskTitle = new TextBox();
            txtTaskDesc = new TextBox();
            dtpReminder = new DateTimePicker();
            lstTasks = new ListBox();
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            labelTaskTitle = new Label();
            labelTaskDesc = new Label();
            labelReminder = new Label();
            tabChat = new TabPage();
            tabMain = new TabControl();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabMain.SuspendLayout();
            tabLog.SuspendLayout();
            tabQuiz.SuspendLayout();
            tabTasks.SuspendLayout();
            tabChat.SuspendLayout();
            SuspendLayout();

            // button1 - Start
            button1.BackColor = Color.Pink;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.Firebrick;
            button1.Location = new Point(20, 300);
            button1.Name = "button1";
            button1.Size = new Size(86, 35);
            button1.TabIndex = 0;
            button1.Text = "Start!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;

            // pictureBox1
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 180);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;

            // button3 - Send
            button3.BackColor = Color.LightPink;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.ForeColor = Color.Firebrick;
            button3.Location = new Point(650, 360);
            button3.Name = "button3";
            button3.Size = new Size(88, 35);
            button3.TabIndex = 3;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;

            // ChatInput - chat history (multiline)
            ChatInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatInput.Location = new Point(260, 20);
            ChatInput.Multiline = true;
            ChatInput.Name = "ChatInput";
            ChatInput.ScrollBars = ScrollBars.Vertical;
            ChatInput.Size = new Size(480, 320);
            ChatInput.TabIndex = 4;
            ChatInput.TextChanged += textBox1_TextChanged;
            ChatInput.KeyDown += ChatInput_KeyDown;

            // type - input box
            type.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            type.Location = new Point(260, 360);
            type.Name = "type";
            type.Size = new Size(370, 23);
            type.TabIndex = 5;
            type.Text = "";

            // tabLog
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(792, 422);
            tabLog.TabIndex = 3;
            tabLog.Text = "Activity Log";
            tabLog.UseVisualStyleBackColor = true;
            tabLog.Controls.Add(lstActivityLog);
            tabLog.Controls.Add(btnShowMoreLog);

            lstActivityLog.Location = new Point(20, 20);
            lstActivityLog.Name = "lstActivityLog";
            lstActivityLog.Size = new Size(740, 320);

            btnShowMoreLog.Location = new Point(20, 360);
            btnShowMoreLog.Name = "btnShowMoreLog";
            btnShowMoreLog.Size = new Size(150, 35);
            btnShowMoreLog.Text = "Show More";
            btnShowMoreLog.Click += btnShowMoreLog_Click;

            // tabQuiz
            tabQuiz.Location = new Point(4, 24);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Size = new Size(792, 422);
            tabQuiz.TabIndex = 2;
            tabQuiz.Text = "Quiz";
            tabQuiz.UseVisualStyleBackColor = true;
            tabQuiz.Controls.Add(lblQuizQuestion);
            tabQuiz.Controls.Add(lblQuizFeedback);
            tabQuiz.Controls.Add(btnStartQuiz);
            tabQuiz.Controls.Add(btnOptionA);
            tabQuiz.Controls.Add(btnOptionB);
            tabQuiz.Controls.Add(btnOptionC);

            lblQuizQuestion.Location = new Point(20, 20);
            lblQuizQuestion.Name = "lblQuizQuestion";
            lblQuizQuestion.Size = new Size(740, 60);
            lblQuizQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuizQuestion.Text = "Press Start Quiz to begin!";

            btnStartQuiz.Location = new Point(20, 100);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(150, 35);
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.Click += btnStartQuiz_Click;

            btnOptionA.Location = new Point(20, 160);
            btnOptionA.Name = "btnOptionA";
            btnOptionA.Size = new Size(740, 35);
            btnOptionA.Text = "A)";
            btnOptionA.Click += btnOptionA_Click;

            btnOptionB.Location = new Point(20, 210);
            btnOptionB.Name = "btnOptionB";
            btnOptionB.Size = new Size(740, 35);
            btnOptionB.Text = "B)";
            btnOptionB.Click += btnOptionB_Click;

            btnOptionC.Location = new Point(20, 260);
            btnOptionC.Name = "btnOptionC";
            btnOptionC.Size = new Size(740, 35);
            btnOptionC.Text = "C)";
            btnOptionC.Click += btnOptionC_Click;

            lblQuizFeedback.Location = new Point(20, 320);
            lblQuizFeedback.Name = "lblQuizFeedback";
            lblQuizFeedback.Size = new Size(740, 60);
            lblQuizFeedback.Text = "";

            // tabTasks
            tabTasks.Location = new Point(4, 24);
            tabTasks.Name = "tabTasks";
            tabTasks.Padding = new Padding(3);
            tabTasks.Size = new Size(792, 422);
            tabTasks.TabIndex = 1;
            tabTasks.Text = "Task Assistant";
            tabTasks.UseVisualStyleBackColor = true;
            tabTasks.Controls.Add(labelTaskTitle);
            tabTasks.Controls.Add(txtTaskTitle);
            tabTasks.Controls.Add(labelTaskDesc);
            tabTasks.Controls.Add(txtTaskDesc);
            tabTasks.Controls.Add(labelReminder);
            tabTasks.Controls.Add(dtpReminder);
            tabTasks.Controls.Add(lstTasks);
            tabTasks.Controls.Add(btnAddTask);
            tabTasks.Controls.Add(btnDeleteTask);
            tabTasks.Controls.Add(btnCompleteTask);

            labelTaskTitle.Location = new Point(20, 20);
            labelTaskTitle.Text = "Task Title:";
            txtTaskTitle.Location = new Point(20, 40);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(350, 23);

            labelTaskDesc.Location = new Point(20, 80);
            labelTaskDesc.Text = "Description:";
            txtTaskDesc.Location = new Point(20, 100);
            txtTaskDesc.Name = "txtTaskDesc";
            txtTaskDesc.Size = new Size(350, 23);

            labelReminder.Location = new Point(20, 140);
            labelReminder.Text = "Reminder Date:";
            dtpReminder.Location = new Point(20, 160);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.Size = new Size(350, 23);

            btnAddTask.Location = new Point(20, 200);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(110, 35);
            btnAddTask.Text = "Add Task";
            btnAddTask.Click += btnAddTask_Click;

            btnDeleteTask.Location = new Point(140, 200);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(110, 35);
            btnDeleteTask.Text = "Delete";
            btnDeleteTask.Click += btnDeleteTask_Click;

            btnCompleteTask.Location = new Point(260, 200);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(110, 35);
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.Click += btnCompleteTask_Click;

            lstTasks.Location = new Point(400, 20);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(360, 380);

            // tabChat - NOW controls are INSIDE the tab
            tabChat.Location = new Point(4, 24);
            tabChat.Name = "tabChat";
            tabChat.Padding = new Padding(3);
            tabChat.Size = new Size(792, 422);
            tabChat.TabIndex = 0;
            tabChat.Text = "Chat";
            tabChat.UseVisualStyleBackColor = true;
            tabChat.Controls.Add(pictureBox1);
            tabChat.Controls.Add(button1);
            tabChat.Controls.Add(ChatInput);
            tabChat.Controls.Add(type);
            tabChat.Controls.Add(button3);
            tabChat.Click += tabChat_Click_1;

            // tabMain
            tabMain.Controls.Add(tabChat);
            tabMain.Controls.Add(tabTasks);
            tabMain.Controls.Add(tabQuiz);
            tabMain.Controls.Add(tabLog);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(800, 450);
            tabMain.TabIndex = 6;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(tabMain);
            Name = "Form1";
            Text = "Chatbot";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabMain.ResumeLayout(false);
            tabLog.ResumeLayout(false);
            tabQuiz.ResumeLayout(false);
            tabTasks.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button3;
        private TextBox ChatInput;
        private TextBox type;
        private TabPage tabLog;
        private TabPage tabQuiz;
        private TabPage tabTasks;
        private TabPage tabChat;
        private TabControl tabMain;

        // Task Assistant controls
        private TextBox txtTaskTitle;
        private TextBox txtTaskDesc;
        private DateTimePicker dtpReminder;
        private ListBox lstTasks;
        private Button btnAddTask;
        private Button btnDeleteTask;
        private Button btnCompleteTask;
        private Label labelTaskTitle;
        private Label labelTaskDesc;
        private Label labelReminder;

        // Quiz controls
        private Label lblQuizQuestion;
        private Label lblQuizFeedback;
        private Button btnStartQuiz;
        private Button btnOptionA;
        private Button btnOptionB;
        private Button btnOptionC;

        // Log controls
        private ListBox lstActivityLog;
        private Button btnShowMoreLog;
    }
}