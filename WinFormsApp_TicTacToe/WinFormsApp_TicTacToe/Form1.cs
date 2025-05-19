namespace WinFormsApp_TicTacToe
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentplayer;
        Random Random = new Random();
        int PlayerWin;
        int CPUWin;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            RestartClickButton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentplayer = Player.X;
            button.Text = currentplayer.ToString();
            button.BackColor = Color.LightBlue;
            button.Enabled = false;
            buttons.Remove(button);
            foreach (Button b in buttons)
            {
                b.Enabled = false;
            }
            CheckGame();
            CPUTimer.Start();
        }


        private void CPUMove(object sender, EventArgs e)
        {
            if(buttons.Count > 0)
            {

                int index = Random.Next(buttons.Count);
                var button = buttons[index];
                currentplayer = Player.O;
                button.Text = currentplayer.ToString();
                button.BackColor = Color.Red;
                button.Enabled = false;
                buttons.Remove(button);
                foreach (Button b in buttons)
                {
                    b.Enabled = true;
                }
                CPUTimer.Stop();
                CheckGame();
             




            }

        }

        private void RestartClickButton(object sender, EventArgs e)
        {
            RestartClickButton();

        }

        private void CheckGame()
        {
            if (   (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "?")
                || (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "?")
                || (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "?")
                || (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "?")
                || (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "?")
                || (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "?")
                || (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "?")
                || (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "?"))
            {
                
                if (currentplayer.ToString() == "X")
                {
                    MessageBox.Show("The winner is: the user!!! Congratulations!!!");
                    PlayerWin++;
                    label1.Text = "Player: "+ PlayerWin;
                }
                else
                {
                    MessageBox.Show("The winner is: the CPU...");
                    CPUWin++;
                    label2.Text = "CPU: " + CPUWin;
                }
                foreach (Button b in buttons)
                {
                    b.Enabled = false;
                }
                buttons.RemoveAll(b => true);
              
            }
            else if (buttons.Count == 0)
            {
                MessageBox.Show("It is a draw!!!");
            }
        }

        private void RestartClickButton()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "?";
                button.BackColor = DefaultBackColor;
            }
        }

    }
}
