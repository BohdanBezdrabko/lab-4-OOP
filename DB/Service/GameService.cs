
using lab4.DB.Service;
using lab4.Games;
using lab4.DB.Repository;
using lab4.DB.Service;

namespace lab4.DB.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IGameAccountRepository gameAccountRepository;


        public GameService(IGameRepository gameRepository, IGameAccountRepository gameAccountRepository)
        {
            this.gameRepository = gameRepository;
            this.gameAccountRepository = gameAccountRepository;


        }
        public void CreateGame(string player, int rating, bool result)
        {
            var Player = gameAccountRepository.ReadGameAccountByName(player);
            gameRepository.CreateGame("bot", Player, null, rating, result);
        }
        public void CreateGame(string gameType, string player, string opponent, int rating, bool result)
        {
            if (player == opponent) throw new ArgumentException("You can not play with yourself");
            if (gameType != "bot")
            {
                var gameAcc1 = gameAccountRepository.ReadGameAccountByName(player);
                var gameAcc2 = gameAccountRepository.ReadGameAccountByName(opponent);
                gameRepository.CreateGame(gameType, gameAcc1, gameAcc2, rating, result);
            }
            else
            {
                CreateGame(player, rating, result);
                CreateGame(opponent, rating, result);
            }

        }
        public GameAccount GetGameAccountByName(string playerName)
        {
            return gameAccountRepository.ReadGameAccountByName(playerName);
        }
        public void PrintGames()
        {
            gameRepository.PrintGames();
        }
        public void PrintGames(GameAccount gameAccount)
        {
            gameRepository.PrintGames(gameAccount);
        }
        public void UpdateGames(Game game)
        {
            gameRepository.UpdateGame(game);
        }
        public void DeleteGame(Game game)
        {
            gameRepository.DeleteGame(game);
        }




    }
}
