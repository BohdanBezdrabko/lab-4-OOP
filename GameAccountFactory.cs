using lab4.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class GameAccountFactory
    {
        public static GameAccount CreateGameAccount(string accountType, string username, int initialRating)
        {
            return accountType.ToLower() switch
            {
                "base" => new BaseAccount(username, initialRating),
                "premium" => new PremiumAccount(username, initialRating),
                "streak" => new StreakAccount(username, initialRating),
                _ => throw new ArgumentException($"Account type doesn't exist - {accountType}"),
            };
        }
    }
}
