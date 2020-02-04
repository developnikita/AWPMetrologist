using System.Threading.Tasks;

namespace AWPMetrologist.Services.Navigation
{
    public interface INavigationCommand<T>
    {
        bool CanExecute(T parameter);

        Task ExecuteAsync(T parameter);

        Task GoBackAsync();
    }

    public interface INavigaionCommand : INavigationCommand<object>
    {
        bool CanExecute();

        Task ExecuteAsync();
    }
}