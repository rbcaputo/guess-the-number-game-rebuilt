using CommunityToolkit.Mvvm.Input;
using GuessTheNumber.Engine;
using System;

namespace GuessTheNumber.App.ViewModels
{
  public sealed class SettingsWindowViewModel : ViewModelBase
  {
    private string _min = string.Empty;
    private string _max = string.Empty;
    private string _chances = string.Empty;
    private string? _error;
    private bool _showErrors;

    public string Min
    {
      get => _min;
      set
      {
        if (SetProperty(ref _min, value))
          Error = null;
      }
    }

    public string Max
    {
      get => _max;
      set
      {
        if (SetProperty(ref _max, value))
          Error = null;
      }
    }

    public string Chances
    {
      get => _chances;
      set
      {
        if (SetProperty(ref _chances, value))
          Error = null;
      }
    }

    public string? Error
    {
      get => _error;
      private set => SetProperty(ref _error, value);
    }

    public bool ShowErrors
    {
      get => _showErrors;
      private set => SetProperty(ref _showErrors, value);
    }

    public Action<Settings?>? CloseAction { get; set; }

    public RelayCommand ConfirmCommand { get; }
    public RelayCommand CancelCommand { get; }

    public SettingsWindowViewModel(Settings? settings = null)
    {
      if (settings is not null)
      {
        Min = settings.Min.ToString();
        Max = settings.Max.ToString();
        Chances = settings.Chances.ToString();
      }

      ConfirmCommand = new(OnConfirm);
      CancelCommand = new(() => CloseAction?.Invoke(null));
    }

    private void OnConfirm()
    {
      ShowErrors = true;

      if (!int.TryParse(Min, out int min) ||
          !int.TryParse(Max, out int max) ||
          !int.TryParse(Chances, out int chances))
      {
        Error = "All fields must be valid numbers";
        return;
      }


      try
      {
        Settings? settings = new(min, max, chances);
        CloseAction?.Invoke(settings);
      }
      catch (Exception ex)
      {
        Error = ex.Message;
      }
    }
  }
}
