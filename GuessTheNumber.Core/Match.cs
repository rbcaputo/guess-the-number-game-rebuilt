namespace GuessTheNumber.Engine
{
  public sealed class Match
  {
    private readonly Settings _settings;
    private readonly Random _rng;

    public int SecretNumber { get; }
    public HashSet<int> TriedNumbers { get; }
    public int RemainingChances { get; private set; }

    public int Min => _settings.Min;
    public int Max => _settings.Max;

    public Match(Settings settings, Random rng)
    {
      _settings = settings;
      _rng = rng;

      SecretNumber = _rng.Next(_settings.Min, _settings.Max + 1);
      TriedNumbers = [];
      RemainingChances = _settings.Chances;
    }

    public Result Guess(int guess)
    {
      if (RemainingChances == 0)
        return Result.GameOver;

      if (guess < Min || guess > Max)
        return Result.OutOfRange;

      if (!TriedNumbers.Add(guess))
        return Result.Tried;

      if (guess == SecretNumber)
      {
        RemainingChances = 0;
        return Result.Correct;
      }

      RemainingChances--;
      return RemainingChances == 0
        ? Result.GameOver
        : Result.Incorrect;
    }
  }
}
