using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace Lcx.Pmt.ExportData.Ui.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _gamePath = string.Empty;

    [ObservableProperty]
    private string _modsPath = string.Empty;

    [RelayCommand]
    public void SelectGamePath()
    {
        OpenFolderDialog dialog = new OpenFolderDialog();
        if (dialog.ShowDialog() is true)
        {
            GamePath = dialog.FolderName;
        }
    }

    [RelayCommand]
    public void SelectModsPath()
    {
        OpenFolderDialog dialog = new OpenFolderDialog();
        if (dialog.ShowDialog() is true)
        {
            ModsPath = dialog.FolderName;
        }
    }

    [RelayCommand]
    public void Start()
    {

    }

}
