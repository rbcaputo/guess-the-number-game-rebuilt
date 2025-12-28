using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using GuessTheNumber.App.Commands;
using GuessTheNumber.App.Views;
using GuessTheNumber.Engine;
using System;
using System.Threading.Tasks;

namespace GuessTheNumber.App.ViewModels
{
  public sealed class MainWindowViewModel : ViewModelBase
  {
    private readonly Game _game;
    private Settings _settings;
    private string _message = string.Empty;
    private string _input = string.Empty;
    private readonly SolidColorBrush _messageBrush = new(Colors.Gray);
    private double _messageOpacity = 1.0;

    public event Action? RequestInputFocus;
    public event Action? RequestResetFocus;

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string Input
    {
      get => _input;
      set => SetProperty(ref _input, value);
    }

    public SolidColorBrush MessageBrush => _messageBrush;

    public double MessageOpacity
    {
      get => _messageOpacity;
      set => SetProperty(ref _messageOpacity, value);
    }

    public RelayCommand GuessCommand { get; }
    public RelayCommand ResetCommand { get; }
    public RelayCommand OpenSettingsCommand { get; }

    public int RemainingChances => _game.RemainingChances;
    public int PlayerScore => _game.Score.Player;
    public int CpuScore => _game.Score.Cpu;
    public bool CanGuess => !_game.IsGameOver;

    public MainWindowViewModel()
    {
      _settings = new();
      _game = new(_settings);
      Message = $"Try to guess my secret number from {_game.Match.Min} to {_game.Match.Max}.";

      GuessCommand = new(ExecuteGuess, () => CanGuess);
      ResetCommand = new(ResetGame, () => !CanGuess);
      OpenSettingsCommand = new(OpenSettings);
    }

    private void ExecuteGuess()
    {
      if (!int.TryParse(Input, out int guess))
      {
        UpdateMessage("Enter a valid number.", Colors.Orange);
        return;
      }

      Result result = _game.CheckGuess(guess);

      switch (result)
      {
        case Result.Correct:
          UpdateMessage($"Correct! The number was {guess}.", Colors.Green);
          break;
        case Result.Incorrect:
          UpdateMessage($"Incorrect! The number is not {guess}.", Colors.Red);
          break;
        case Result.Tried:
          UpdateMessage($"You already tried {guess}.", Colors.Yellow);
          break;
        case Result.GameOver:
          UpdateMessage("Out of chances! Game over.", Colors.Gray);
          break;
        case Result.OutOfRange:
          UpdateMessage("Enter a valid number.", Colors.Orange);
          break;
      }

      Input = string.Empty;

      NotifyGameStateChanged();
      RequestInputFocus?.Invoke();
    }

    private void NotifyGameStateChanged()
    {
      OnPropertyChanged(nameof(RemainingChances));
      OnPropertyChanged(nameof(CanGuess));
      OnPropertyChanged(nameof(PlayerScore));
      OnPropertyChanged(nameof(CpuScore));

      GuessCommand.RaiseCanExecuteChanged();
      ResetCommand.RaiseCanExecuteChanged();

      if (_game.IsGameOver)
        RequestResetFocus?.Invoke();
    }

    private async void UpdateMessage(string message, Color color)
    {
      MessageOpacity = 0.0; // Fade-out

      await Task.Yield(); // Allow render pass

      Message = message;
      MessageBrush.Color = color;

      MessageOpacity = 1.0; // Fade-in
    }

    private void ResetGame()
    {
      _game.ResetMatch(_settings);

      UpdateMessage($"Try to guess my secret number from {_game.Match.Min} to {_game.Match.Max}.", Colors.Gray);
      Input = string.Empty;

      NotifyGameStateChanged();
      RequestInputFocus?.Invoke();
    }

    private void OpenSettings()
    {
      SettingsWindow window = new();
      SettingsWindowViewModel viewModel = new(_settings)
      {
        CloseAction = settings =>
        {
          if (settings is not null)
          {
            _settings = settings;
            ResetGame();
          }

          window.Close();
        }
      };

      window.DataContext = viewModel;

      if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        window.ShowDialog(desktop.MainWindow!);
    }
  }
}
