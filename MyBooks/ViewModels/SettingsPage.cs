using CommunityToolkit.Mvvm.ComponentModel;
using MyBooks.ThemeHelper;

public partial class SettingsPageViewModel : ObservableObject
{
    // SelectedIndex for Picker (0=System,1=Light,2=Dark)
    [ObservableProperty] private int selectedThemeIndex;

    partial void OnSelectedThemeIndexChanged(int value)
    {
        // Save new theme index
        Settings.Theme = value;

        // Apply the theme
        TheTheme.SetTheme();
    }
}
