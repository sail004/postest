using System.Text.Json;
using Pos.BL.Interfaces;

namespace Pos.BL.Implementation;

public class JsonSerializerService<T>:ISerializer<T>
{
    public string Serialize(object o)
    {
        return JsonSerializer.Serialize(o);
    }

    public T? Deserialize(string model)
    {
        return JsonSerializer.Deserialize<T>(model);
    }
}