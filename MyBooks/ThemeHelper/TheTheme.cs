namespace MyBooks.ThemeHelper;
public static class TheTheme
{
    public static void SetTheme()
    {
        switch (Settings.Theme)
        {
            case 0:
                App.Current.UserAppTheme = AppTheme.Unspecified; // Default theme
                break;
            case 1:
                App.Current.UserAppTheme = AppTheme.Light; // Light theme
                break;
            case 2:
                App.Current.UserAppTheme = AppTheme.Dark; // Dark theme
                break;
        }
    }
}
