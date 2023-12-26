using lab4.DB.Service;
using lab4.Terminal;

public class CommandProcessor
{
    private readonly Dictionary<string, ICommand> commands;
    private readonly IGameAccountService gameAccountService; // Change the type to IGameAccountService
    private readonly IGameService gameService;
    public CommandProcessor(IGameAccountService gameAccountService, IGameService gameService) // Change the parameter type
    {
        this.gameAccountService = gameAccountService;

        commands = new Dictionary<string, ICommand>
        {
            { "display_players", new DisplayPlayersCommand(gameAccountService) },
            { "add_player", new AddPlayerCommand(gameAccountService) },
            { "player_stats", new PlayerStatsCommand(gameService) },
            { "play_game", new PlayGameCommand(gameService) },
            { "help", new HelpCommand() },
            { "exit", new ExitCommand() }
        };
        this.gameService = gameService;
    }

    public void ProcessCommand(string command)
    {
        if (commands.TryGetValue(command, out var commandObject))
        {
            commandObject.Execute();
        }
        else
        {
            Console.WriteLine("Invalid command. Enter 'help' for a list of available commands.");
        }
    }
}
