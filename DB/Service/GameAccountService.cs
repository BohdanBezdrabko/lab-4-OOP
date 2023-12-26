
using lab4.DB.Service;
using lab4.DB.Repository;
using System.Collections.Generic;

namespace lab4.DB.Service
{
    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository gameAccountRepository;

        public GameAccountService(IGameAccountRepository gameAccountRepository)
        {
            this.gameAccountRepository = gameAccountRepository;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            gameAccountRepository.CreateGameAccount(accountType, username, initialRating);
        }


        public List<GameAccount> GetGameAccounts()
        {
            return gameAccountRepository.ReadGameAccounts();
        }

        public GameAccount GetGameAccountByName(string userName)
        {
            return gameAccountRepository.ReadGameAccountByName(userName);
        }
    }
}
