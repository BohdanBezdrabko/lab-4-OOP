

namespace lab4.DB.Repository
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(string accountType, string username, int initialRating);
        List<GameAccount> ReadGameAccounts();
        GameAccount ReadGameAccountByName(string username);
        void UpdateGameAccount(GameAccount gameAccount);
        void DeleteGameAccount(GameAccount gameAccount);
    }
}
