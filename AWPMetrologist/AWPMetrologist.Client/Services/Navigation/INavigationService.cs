using System;
using System.Threading.Tasks;

namespace AWPMetrologist.Client.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToSettingsAsync();

        Task NavigateToAccountingAsync();

        Task NavigateToVerificationAsync();

        Task NavigateToSchedulesAsync();

        Task NavigateToHandbookAsync();

        Task NavigateToRepairAsync();

        Task GoBackAsync();

        bool CanGoBack { get; }

        bool IsNavigating { get; }

        event EventHandler Navigated;

        event EventHandler<bool> IsNavigatingChanged;
    }
}