using lab4.DB.Service;
namespace lab4.Terminal
{
    public class PlayGameCommand : ICommand
    {
        private readonly IGameService gameService;

        public PlayGameCommand(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of Player 1: ");
            string player1Name = Console.ReadLine();

            Console.Write("Enter the name of Player 2: ");
            string player2Name = Console.ReadLine();

            Console.Write("Enter the game type: ");
            string gameType = Console.ReadLine();

            Console.Write("Enter the rating: ");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating))
            {
                Console.WriteLine("Invalid rating. Please enter a valid integer.");
            }

            gameService.CreateGame(player1Name, player2Name, gameType, rating, true);
            Console.WriteLine($"Game played between {player1Name} and {player2Name} with rating {rating}. Result: {player1Name} wins.");
        }
    }
}