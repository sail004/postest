namespace Pos.Entities;

public class MenuModel
{
    private readonly List<string> _menuItems = new() { "1. Registration", "2. Report", "3. Exit" };
    public int CurrentIndex { get; set; }
    public  List<string>  MenuItems=>_menuItems;
 
    public void DecrementCurrentIndex()
    {
        if (CurrentIndex <= 0)
            CurrentIndex = _menuItems.Count - 1;
        else
            CurrentIndex--;
    }

    public void IncrementCurrentIndex()
    {
        if (CurrentIndex >= _menuItems.Count - 1)
            CurrentIndex = 0;
        else
            CurrentIndex++;
    }
}