namespace Katas
{
    public class TennisGame
    {
        private Player player1;
        private Player player2;

        public TennisGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public string Score
        {
            get { return GetScore(); }
        }

        private string GetScore()
        {
            if (player1.GetScore() >= 3 && player2.GetScore() >= 3)
            {
                if (Math.Abs(player2.GetScore() - player1.GetScore()) >= 2)
                {
                    return GetLeadPlayer().Name + " won";
                }
                else if (player1.GetScore() == player2.GetScore())
                {
                    return "deuce";
                }
                else
                {
                    return "advantage " + GetLeadPlayer().Name;
                }
            }
            else
            {
                return player1.GetScoreDescription() + ", " + player2.GetScoreDescription();
            }
        }

        private Player GetLeadPlayer()
        {
            return (player1.GetScore() > player2.GetScore()) ? player1 : player2;
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        private int score;

        public Player(string name)
        {
            Name = name;
        }

        public int GetScore()
        {
            return score;
        }

        public void WinBall()
        {
            score++;
        }

        public string GetScoreDescription()
        {
            switch (score)
            {
                case 0:
                    return "love";
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
