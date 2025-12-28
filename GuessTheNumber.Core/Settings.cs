namespace GuessTheNumber.Engine
{
  public sealed record Settings
  {
    public int Min { get; }
    public int Max { get; }
    public int Chances { get; }

    public Settings(int min = 1, int max = 9, int chances = 3)
    {
      ValidateInputs(min, max, chances);

      Min = min;
      Max = max;
      Chances = chances;
    }

    private static void ValidateInputs(int min, int max, int chances)
    {
      if (min <= 0)
        throw new ArgumentOutOfRangeException(nameof(min), "Minimum value is equal or less than zero");
      if (min == max)
        throw new ArgumentException("Minimum and maximum values are equal", nameof(max));
      if (min > max)
        throw new ArgumentException("Minimum value is greater than maximum value", nameof(max));
      if (max <= 0)
        throw new ArgumentOutOfRangeException(nameof(max), "Maximum value is equal or less than zero");
      if (chances <= 0)
        throw new ArgumentOutOfRangeException(nameof(chances), "Chances value is equal or less than zero");
    }
  }
}
