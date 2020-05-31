using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public abstract class CommandViewModel
    {
        public abstract void Add(object sender, RoutedEventArgs args);

        public abstract void Delete(object sender, RoutedEventArgs args);

        public abstract void Save(object sender, RoutedEventArgs args);
    }
}
