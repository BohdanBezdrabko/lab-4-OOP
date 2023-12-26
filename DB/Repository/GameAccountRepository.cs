
using lab4.DB.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lab4.DB.Repository
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext dbContext;

        public GameAccountRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            dbContext.GameAccounts.Add(GameAccountFactory.CreateGameAccount(accountType, username, initialRating));
        }

        public List<GameAccount> ReadGameAccounts()
        {
            return dbContext.GameAccounts;
        }

        public GameAccount ReadGameAccountByName(string username)
        {
            return dbContext.GameAccounts.Find(a => a.UserName == username);
        }
        public void UpdateGameAccount(GameAccount gameAccount)
        {
            throw new NotImplementedException();
        }
        public void DeleteGameAccount(GameAccount gameAccount)
        {
            dbContext.GameAccounts.Remove(gameAccount);
        }
    }
}
