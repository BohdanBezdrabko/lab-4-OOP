
using lab4.Games;

namespace lab4.DB.Service
{
    public interface IGameService
    {
        void CreateGame(string player, int rating, bool result);
        void CreateGame(string gameType, string player, string opponent, int rating, bool result);
        void UpdateGames(Game game);
        void DeleteGame(Game game);
        void PrintGames(GameAccount gameAccount);
        GameAccount GetGameAccountByName(string playerName);

    }
}
