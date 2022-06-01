namespace Game
{
    public partial class Form1 : Form
    {
        Game game;
        int moves = 100;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var position = Convert.ToInt16(((Button)sender).Tag);
            if (game.Shift(position)) PlusMoves();
            Refresh();
            if (game.Win())
            {
                MessageBox.Show("You have won!");
                StartGame();
            }
        }
        public void PlusMoves()
        {
            moves++;
            movesTextBox.Size = new System.Drawing.Size(110 + (15 * (moves.ToString().Length - 1)), 39);
            movesTextBox.Text = "Moves: " + moves.ToString();
        }
        private Button IsButton(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }  
        private void StartGame()
        {
            game.Start();
            for(int i = 0; i < 100; ++i)
                game.ShiftRandom();
            Refresh();
            moves = 0;
            movesTextBox.Text = "Moves: " + moves.ToString();
            movesTextBox.Size = new System.Drawing.Size(110, 39);
        }
        private void Refresh()
        {   
            for (int position = 0; position < 16; ++position)
            {
                var number = game.GetNumber(position);
                IsButton(position).Text = number.ToString();
                IsButton(position).Visible = (number > 0);
            }
        }
    }
}