namespace lab4.Games
{
    class TrainingGame : Game
    {
        public override int GameRating(int rating)
        {
            return 0;
        }
        public TrainingGame(string user, string opponent, int rating, bool result) : base(user, opponent, rating, result)
        {

        }
    }
}
