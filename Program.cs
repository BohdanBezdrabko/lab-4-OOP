using lab4.DB.Repository;
using lab4.DB.Service;
using lab4.DB;
using lab4.Terminal;

namespace lab4.Terminal
{
    class Program
    {
        static void Main()
        {
            DbContext dbContext = new DbContext();
            GameRepository gameRepository = new GameRepository(dbContext);
            GameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);
            GameAccountService gameAccountService = new GameAccountService(gameAccountRepository);
            GameService gameService = new GameService(gameRepository, gameAccountRepository);

            CommandProcessor commandProcessor = new CommandProcessor(gameAccountService, gameService);

            try
            {
                while (true)
                {
                    Console.Write("Enter a command: ");
                    string inputCommand = Console.ReadLine();

                    if (inputCommand.ToLower() == "exit")
                    {
                        break;
                    }

                    commandProcessor.ProcessCommand(inputCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
