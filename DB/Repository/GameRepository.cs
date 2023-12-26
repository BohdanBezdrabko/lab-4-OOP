
using lab4.DB.Repository;
using lab4.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.DB.Repository
{

    public class GameRepository : IGameRepository
    {
        private readonly DbContext dbContext;

        public GameRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGame(string gameType, GameAccount gameAcc1, GameAccount gameAcc2, int rating, bool result)
        {
            if (rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating can't be less than 1");
            }

            var gameAcc2Name = gameAcc2 == null ? "BOT" : gameAcc2.UserName;
            var game = GameFactory.CreateGame(gameType, gameAcc1.UserName, gameAcc2Name, rating, result);

            dbContext.Games.Add(game);

            if (result)
            {
                gameAcc1.WinGame(game);
                gameAcc2?.LoseGame(game);
            }
            else
            {
                gameAcc1.LoseGame(game);
                gameAcc2?.WinGame(game);
            }


        }



        public List<Game> ReadGames()
        {
            return dbContext.Games;
        }

        public Game GetGameById(int GameID)
        {
            return dbContext.Games.Find(g => g.ID == GameID);

        }
        public void UpdateGame(Game game)
        {
            var index = dbContext.Games.IndexOf(game);
            dbContext.Games[index] = game;
        }
        public void DeleteGame(Game game)
        {
            dbContext.Games.Remove(game);

        }
        public void PrintGames()
        {
            Console.WriteLine("All games:");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| ID\t| Player 1\t| Player 2\t| Result\t| Rating\t|");
            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (var game in dbContext.Games)
            {
                Console.WriteLine($"| {game.ID,-4}| {game.GameAcc1,-14}| {game.GameAcc2,-14}| {(game.GameResult ? $"{game.GameAcc1} Win" : $"{game.GameAcc2} Win"),-14}| {game.Rating,-14}|");
            }

            Console.WriteLine("--------------------------------------------------------------------------");
        }

        public void PrintGames(GameAccount gameAccount)
        {
            Console.WriteLine($"\nGames history of {gameAccount.UserName}");
            Console.WriteLine($"(Current rating: {gameAccount.CurrentRating})");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Player 1\t| Player 2\t| Result\t| Rating\t|");
            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (int i in gameAccount.GamesHistory)
            {
                var game = GetGameById(i);

                Console.WriteLine($"| {game.GameAcc1,-14}| {game.GameAcc2,-14}| {(game.GameResult ? "Win" : "Lose"),-14}| {game.Rating,-14}|");
            }

            Console.WriteLine("--------------------------------------------------------------------------");
        }
    }
}
