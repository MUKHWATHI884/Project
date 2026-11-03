namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ChatInput = new TextBox();
            type = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Pink;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Firebrick;
            button1.Location = new Point(342, 290);
            button1.Name = "button1";
            button1.Size = new Size(86, 35);
            button1.TabIndex = 0;
            button1.Text = "Start!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 208);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightPink;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Firebrick;
            button3.Location = new Point(570, 290);
            button3.Name = "button3";
            button3.Size = new Size(88, 35);
            button3.TabIndex = 3;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // ChatInput
            // 
            ChatInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatInput.Location = new Point(397, 37);
            ChatInput.Multiline = true;
            ChatInput.Name = "ChatInput";
            ChatInput.ScrollBars = ScrollBars.Vertical;
            ChatInput.Size = new Size(233, 217);
            ChatInput.TabIndex = 4;
            ChatInput.TextChanged += textBox1_TextChanged;
            ChatInput.KeyDown += ChatInput_KeyDown;
            // 
            // type
            // 
            type.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            type.Location = new Point(449, 299);
            type.Name = "type";
            type.Size = new Size(100, 23);
            type.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(type);
            Controls.Add(ChatInput);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Chatbot";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button3;
        private TextBox ChatInput;
        private TextBox type;
    }
}
