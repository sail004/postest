public interface IOutputManager
{
    Action<string> NotifyAction { get; set; }

    public void Notify(string message);
}