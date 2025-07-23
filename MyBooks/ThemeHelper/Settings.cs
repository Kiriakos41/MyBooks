namespace MyBooks.ThemeHelper;
public static class Settings
{
    const int theme = 0;

    public static int Theme
    {
        get => Preferences.Get(nameof(Theme), theme);
        set => Preferences.Set(nameof(Theme), value);
    }
}
