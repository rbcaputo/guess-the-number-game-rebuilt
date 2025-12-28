using FluentAssertions;
using GuessTheNumber.Engine;

namespace GuessTheNumber.Tests
{
  public sealed class MatchTests
  {
    [Fact]
    public void Guess_CorrectNumber_ReturnsCorrect_AndEndsGame()
    {
      Match match = CreateMatch(out int secret);
      Result result = match.Guess(secret);

      result.Should().Be(Result.Correct);
      match.RemainingChances.Should().Be(0);
    }

    [Fact]
    public void Guess_IncorrectNumber_DecrementsChances()
    {
      Match match = CreateMatch(out int secret);
      int incorrect = secret == 1 ? 2 : 1;
      Result result = match.Guess(incorrect);

      result.Should().Be(Result.Incorrect);
      match.RemainingChances.Should().Be(2);
    }

    [Fact]
    public void Guess_SameNumberTwice_ReturnsTried_AndDoesNotDecrement()
    {
      Match match = CreateMatch(out int secret);
      
      match.Guess(secret == 1 ?  2 : 1);

      Result result = match.Guess(secret == 1 ? 2 : 1);

      result.Should().Be(Result.Tried);
      match.RemainingChances.Should().Be(2);
    }

    [Fact]
    public void Guess_OutOfRange_ReturnsOutOfRange_AndDoesNotDecrement()
    {
      Match match = CreateMatch(out int _);
      Result result = match.Guess(11);

      result.Should().Be(Result.OutOfRange);
      match.RemainingChances.Should().Be(3);
    }

    [Fact]
    public void Guess_WhenNoChancesLeft_ReturnsGameOver()
    {
      Match match = CreateMatch(out int secret);
      int incorrect = secret == 1 ? 2 : 1;

      match.Guess(incorrect);
      match.Guess(incorrect == 1 ? 2 : 1);
      match.Guess(incorrect);

      Result result = match.Guess(secret);

      result.Should().Be(Result.GameOver);
    }

    private static Match CreateMatch(out int secret)
    {
      Random rng = new(0);
      Settings settings = new(1, 2, 3);
      Match match = new(settings, rng);
      secret = match.SecretNumber;

      return match;
    }
  }
}
