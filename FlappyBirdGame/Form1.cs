using System;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        int gravity = 8;
        int pipeSpeed = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            // Borular yeniden başa gelsin
            if (pipeBottom.Left < -60)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -60)
            {
                pipeTop.Left = 800;
                score++;
            }

            // Çarpma kontrolü
            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top < 0)
            {
                EndGame();
            }

            // Zorluk artışı
            if (score > 5)
            {
                pipeSpeed = 12;
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  GAME OVER";
        }

        private void pipeBottom_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
