using FluentAssertions;
using GuessTheNumber.Engine;

namespace GuessTheNumber.Tests
{
  public sealed class SettingsTests
  {
    [Fact]
    public void Constructor_WithValidValues_CreatesSettings()
    {
      Settings settings = new(1, 9, 3);

      settings.Min.Should().Be(1);
      settings.Max.Should().Be(9);
      settings.Chances.Should().Be(3);
    }

    [Theory]
    [InlineData(0, 9, 3)]
    [InlineData(-1, 9, 3)]
    public void Constructor_MinLessThanOrEqualZero_Throws(int min, int max, int chances)
    {
      Action action = () => new Settings(min, max, chances);

      action.Should()
        .Throw<ArgumentOutOfRangeException>()
        .WithMessage("*Minimum*");
    }

    [Fact]
    public void Constructor_MinEqualsMax_Throws()
    {
      Action action = () => new Settings(5, 5, 3);

      action.Should()
        .Throw<ArgumentException>()
        .WithMessage("*equal*");
    }

    [Fact]
    public void Constructor_MinGreaterThanMax_Throws()
    {
      Action action = () => new Settings(9, 1, 3);

      action.Should()
        .Throw<ArgumentException>()
        .WithMessage("*greater*");
    }

    [Theory]
    [InlineData(1, 9, 0)]
    [InlineData(1, 9, -1)]
    public void Constructor_ChancesLessThanOrEqualZero_Throws(int min, int max, int chances)
    {
      Action action = () => new Settings(min, max, chances);

      action.Should()
        .Throw<ArgumentOutOfRangeException>()
        .WithMessage("*Chances*");
    }
  }
}