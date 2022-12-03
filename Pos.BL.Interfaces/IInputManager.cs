namespace Pos.BL.Interfaces
{
    public interface IInputManager
    {
        Func<char> InputData { get; set; }
        Action<string> CommanReady { get; set; }

        Task<bool> ProcessInput();
    }
}