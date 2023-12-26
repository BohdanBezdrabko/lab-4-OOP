using lab4.Games;
using System;

namespace lab4
{
    class GameFactory
    {
        public static Game CreateGame(string gameType, string gameAcc1, string gameAcc2, int rating, bool result)
        {
            return gameType.ToLower() switch
            {
                "standart" => new StandartGame(gameAcc1, gameAcc2, rating, result),
                "training" => new TrainingGame(gameAcc1, gameAcc2, rating, result),
                "bot" => new BotGame(gameAcc1, rating, result),
                _ => throw new ArgumentException("Invalid game type"),
            };
        }

    }
}
