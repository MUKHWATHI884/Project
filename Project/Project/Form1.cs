using Microsoft.VisualBasic.ApplicationServices;
using System.Media;
namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();
        }

        private void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\source\\repos\\Project\\Project\\voice\\ai sound.wav");
            player.Play();
        }

        private void DisplayLogo()
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Student\\source\\repos\\Cybersecurity\\logo\\Screenshot 2026-09-08 145524.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
