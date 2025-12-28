namespace GuessTheNumber.Engine
{
  public sealed class Score
  {
    public int Player { get; private set; }
    public int Cpu { get; private set; }

    public void PlayerWins() => Player++;
    public void CpuWins() => Cpu++;

    public void Reset()
    {
      Player = 0;
      Cpu = 0;
    }
  }
}
