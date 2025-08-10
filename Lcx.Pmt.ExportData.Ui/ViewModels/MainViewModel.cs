using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lcx.Pmt.ExportData.Ui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? _gamePath = string.Empty;

    [ObservableProperty]
    private string? _modsPath = string.Empty;

    private readonly IStorageProvider _storageProvider;

    public MainViewModel(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    [RelayCommand]
    public async Task SelectGamePath()
    {
        var result = await _storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions());

        if (result.FirstOrDefault()?.Path.LocalPath is { } filePath && Directory.Exists(filePath))
        {
            GamePath = filePath;
        }
    }

    [RelayCommand]
    public async Task SelectModsPath()
    {
        var result = await _storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions());

        if (result.FirstOrDefault()?.Path.LocalPath is { } filePath && Directory.Exists(filePath))
        {
            ModsPath = filePath;
        }
    }

    [RelayCommand]
    public void Start()
    {
        GoMain.Go(GamePath, ModsPath);
    }
}
