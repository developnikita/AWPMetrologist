using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Client.Services.Navigation
{
    public interface INavigableTo
    {
        Task NavigatedTo(NavigationMode navigationMode, object parameter);
    }
}