namespace Pos.BL.Interfaces;

public interface ISerializer<T>
{
    string Serialize(object o);
    T? Deserialize(string model);
}