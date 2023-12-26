using lab4.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Terminal
{
    public class DisplayPlayersCommand : ICommand
    {
        private readonly IGameAccountService gameAccountService;

        public DisplayPlayersCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            var players = gameAccountService.GetGameAccounts();
            Console.WriteLine("List of Players:");
            foreach (var player in players)
            {
                Console.WriteLine($"- {player.UserName}");
            }
        }
    }
}
