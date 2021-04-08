namespace Slantar.Architecture
{
    public interface ISerializer
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string serializedData);
    }
}