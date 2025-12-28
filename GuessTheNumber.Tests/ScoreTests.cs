using FluentAssertions;
using GuessTheNumber.Engine;

namespace GuessTheNumber.Tests
{
  public sealed class ScoreTests
  {
    [Fact]
    public void PlayerWins_IncrementsPlayerScore()
    {
      Score score = new();

      score.PlayerWins();

      score.Player.Should().Be(1);
      score.Cpu.Should().Be(0);
    }

    [Fact]
    public void CpuWins_IncrementsCpuScore()
    {
      Score score = new();

      score.CpuWins();

      score.Player.Should().Be(0);
      score.Cpu.Should().Be(1);
    }

    [Fact]
    public void Reset_SetsScoresToZero()
    {
      Score score = new();

      score.PlayerWins();
      score.CpuWins();
      score.Reset();

      score.Player.Should().Be(0);
      score.Cpu.Should().Be(0);
    }
  }
}
