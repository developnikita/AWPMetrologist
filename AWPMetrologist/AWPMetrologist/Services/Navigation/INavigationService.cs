using System;
using System.Threading.Tasks;

namespace AWPMetrologist.Services.Navigation
{
    public interface INavigationService
    {
        event EventHandler Navigated;

        Task NavigateToSettingsAsync();
    }
}