using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using GuessTheNumber.App.ViewModels;

namespace GuessTheNumber.App.Views
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      // Focus InputBox when window is ready
      Opened += (_, _) =>
        Dispatcher.UIThread.Post(() => InputBox.Focus());

      // Subscribe ViewModel focus events
      DataContextChanged += (_, _) =>
      {
        if (DataContext is MainWindowViewModel viewModel)
        {
          viewModel.RequestInputFocus += () =>
            Dispatcher.UIThread.Post(() => InputBox.Focus());

          viewModel.RequestInputFocus += () =>
            Dispatcher.UIThread.Post(() => ResetButton.Focus());
        }
      };
    }

    public void InputBox_KeyDown(object? sender, KeyEventArgs ev)
    {
      if (ev.Key == Key.Enter && DataContext is MainWindowViewModel viewModel)
      {
        if (viewModel.GuessCommand.CanExecute(null))
          viewModel.GuessCommand.Execute(null);

        ev.Handled = true; // Prevent system beep
      }
    }
  }
}
