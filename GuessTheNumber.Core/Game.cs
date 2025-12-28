namespace GuessTheNumber.Engine
{
  public sealed class Game
  {
    private readonly Random _rng = new();
    private Match _match;

    public Score Score { get; } = new();

    public Match Match => _match;
    public int RemainingChances => _match.RemainingChances;
    public bool IsGameOver => _match.RemainingChances == 0;

    public Game(Settings? settings = null) =>
      _match = new(settings ?? new(), _rng);

    public Result CheckGuess(int guess)
    {
      Result result = _match.Guess(guess);

      if (result == Result.Correct)
        Score.PlayerWins();
      else if (result == Result.GameOver)
        Score.CpuWins();

      return result;
    }

    public void ResetMatch(Settings? settings = null) =>
      _match = new(settings ?? new(), _rng);
  }
}
