namespace AWPMetrologist.Client.Services.Navigation
{
    public interface IUserControlWithViewModel<T>
        where T : class
    {
        T ViewModel { get; set; }

        void UpdateBindings();
    }
}
