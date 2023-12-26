using lab4.Games;
using lab4.Accounts;
using System;

namespace lab4
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        private int _currentRating;
        public int CurrentRating
        {
            get => _currentRating;
            set
            {
                if (value > 1)
                {
                    _currentRating = value;
                }
                else
                {
                    _currentRating = 1;
                }
            }
        }
        public List<int> GamesHistory = new();
        public GameAccount(string userName, int initialRating)
        {
            UserName = userName;
            CurrentRating = initialRating;
        }

        protected virtual void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating;
            }
        }

        public void WinGame(Game game)
        {
            GameRating(true, game.Rating);
            GamesHistory.Add(game.ID);
        }

        public void LoseGame(Game game)
        {
            GameRating(false, game.Rating);
            GamesHistory.Add(game.ID);
        }
    }
}