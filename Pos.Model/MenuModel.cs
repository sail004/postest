namespace Pos.BL.Implementation.States;

public class MenuModel
{
    private readonly List<string> _menuItems = new() { "1. Registration", "2. Report", "3. Exit" };
    public int CurrentIndex { get; private set; }
    public  List<string>  MenuItems=>_menuItems;
    // public string BuildMenu(string userName, string errorStatus)
    // {
    //     var result = string.Empty;
    //     for (var i = 0; i < _menuItems.Count; i++)
    //     {
    //         result += _menuItems[i];
    //         if (CurrentIndex == i)
    //             result += " *";
    //         result += Environment.NewLine;
    //     }
    //
    //     result += Environment.NewLine;
    //     result += userName;
    //     result += Environment.NewLine;
    //     result += errorStatus;
    //     return result;
    // }

    internal void DecrementCurrentIndex()
    {
        if (CurrentIndex <= 0)
            CurrentIndex = _menuItems.Count - 1;
        else
            CurrentIndex--;
    }

    internal void IncrementCurrentIndex()
    {
        if (CurrentIndex >= _menuItems.Count - 1)
            CurrentIndex = 0;
        else
            CurrentIndex++;
    }
}