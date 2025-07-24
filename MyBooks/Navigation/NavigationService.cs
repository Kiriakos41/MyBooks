namespace MyBooks.Navigation;
public class NavigationService : INavigationService
{
    public Task GoToAsync(ShellNavigationState state)
    {
        return Shell.Current.GoToAsync(state);
    }

    public Task GoToAsync(ShellNavigationState state, bool animate)
    {
        return Shell.Current.GoToAsync(state, animate);
    }

    public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, parameters);
    }

    public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, animate, parameters);
    }

    public Task GoToAsync(ShellNavigationState state, ShellNavigationQueryParameters shellNavigationQueryParameters)
    {
        return Shell.Current.GoToAsync(state, shellNavigationQueryParameters);
    }

    public Task GoToAsync(ShellNavigationState state, bool animate, ShellNavigationQueryParameters shellNavigationQueryParameters)
    {
        return Shell.Current.GoToAsync(state, animate, shellNavigationQueryParameters);
    }

    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..", true);
    }

    public Task GoToAsync(string route, bool animate, string parameterKey, object parameterValue)
    {
        var parameters = new Dictionary<string, object>
        {
            [parameterKey] = parameterValue
        };

        return Shell.Current.GoToAsync(route, animate, parameters);
    }
}