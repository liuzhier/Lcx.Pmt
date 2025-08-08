using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace Lcx.Pmt.ExportData.Ui.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _gamePath = string.Empty;

    [ObservableProperty]
    private string? _modPath = string.Empty;

    [RelayCommand]
    public void SelectGamePath()
    {
        OpenFolderDialog dialog = new();
        if (dialog.ShowDialog() is true)
        {
            GamePath = dialog.FolderName;
        }
    }

    [RelayCommand]
    public void SelectModsPath()
    {
        OpenFolderDialog dialog = new();
        if (dialog.ShowDialog() is true)
        {
            ModPath = dialog.FolderName;
        }
    }

    [RelayCommand]
    public void Start()
    {
        GoMain.Go(GamePath, ModPath);
    }
}
