using lab4.Games;

namespace lab4.Games
{
    class BotGame : Game
    {
        public override int GameRating(int rating)
        {
            return rating / 2;
        }
        public BotGame(string user, int rating, bool result) : base(user, "BOT", rating, result)
        {

        }
    }
}