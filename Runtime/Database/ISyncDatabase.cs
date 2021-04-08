namespace Slantar.Architecture
{
    public interface ISyncDatabase
    {
        void Save<TData>(string key, TData data);
        TData Load<TData>(string key);
        void Persist();
    }
}