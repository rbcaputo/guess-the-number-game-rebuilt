using Avalonia.Controls;
using Avalonia.Input;

namespace GuessTheNumber.App.Views
{
  public partial class SettingsWindow : Window
  {
    public SettingsWindow()
    {
      InitializeComponent();
    }

    private void Header_PointerPressed(object? sender, PointerPressedEventArgs ev)
    {
      if (ev.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        BeginMoveDrag(ev);
    }
  }
}
