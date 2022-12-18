public class OutputManager : IOutputManager
{
    public void Notify(string message)
    {
        NotifyAction?.Invoke(message);
    }

    public Action<string> NotifyAction { get; set; }
}