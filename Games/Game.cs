using lab4.Games;

public abstract class Game
{
    public int ID { get; set; }
    public string GameAcc1 { get; }
    public string GameAcc2 { get; }
    public int Rating { get; }
    public int NewRating_gameAcc1 { get; set; }
    public int NewRating_gameAcc2 { get; set; }
    public bool GameResult { get; }

    public static int lastAssignedId = 1;

    public abstract int GameRating(int rating);

    public Game(string gameAcc1, string gameAcc2, int rating, bool result)
    {
        GameAcc1 = gameAcc1;
        GameAcc2 = gameAcc2;
        Rating = GameRating(rating);
        GameResult = result;
        ID = lastAssignedId++;
    }
}





