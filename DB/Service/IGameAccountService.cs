

namespace lab4.DB.Service
{
    public interface IGameAccountService
    {
        void CreateGameAccount(string gameType, string userName, int initialRating);
        List<GameAccount> GetGameAccounts();
        GameAccount GetGameAccountByName(string userName);
    }
}
