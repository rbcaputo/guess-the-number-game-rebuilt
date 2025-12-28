using FluentAssertions;
using GuessTheNumber.Engine;

namespace GuessTheNumber.Tests
{
  public sealed class GameTests
  {
    [Fact]
    public void CorrectGuess_IncrementsPlayerScore()
    {
      Settings settings = new(1, 2, 1);
      Game game = new(settings);
      int secret = game.Match.SecretNumber;
      
      game.CheckGuess(secret);

      game.Score.Player.Should().Be(1);
      game.Score.Cpu.Should().Be(0);
    }

    [Fact]
    public void LosingGame_IncrementsCpuScore()
    {
      Settings settings = new(1, 2, 1);
      Game game = new(settings);
      int secret = game.Match.SecretNumber;
      int incorrect = secret == 1 ? 2 : 1;
      
      game.CheckGuess(incorrect);

      game.Score.Player.Should().Be(0);
      game.Score.Cpu.Should().Be(1);
    }

    [Fact]
    public void RestMatch_KeepsScore()
    {
      Settings settings = new(1, 2, 1);
      Game game = new(settings);
      int secret = game.Match.SecretNumber;

      game.CheckGuess(secret);
      game.ResetMatch();

      game.Score.Player.Should().Be(1);
      game.Score.Cpu.Should().Be(0);
    }
  }
}
