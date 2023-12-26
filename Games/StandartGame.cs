namespace lab4.Games
{
    class StandartGame : Game
    {
        public override int GameRating(int rating)
        {
            return rating;
        }

        public StandartGame(string user, string opponent, int rating, bool result) : base(user, opponent, rating, result)
        {

        }
    }
}
