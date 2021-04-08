namespace Slantar.Architecture
{
    public class AbstractSyncDatabase : ISyncDatabase
    {
        
        
        public void Save<TData>(string key, TData data)
        {
            throw new System.NotImplementedException();
        }

        public TData Load<TData>(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Persist()
        {
            throw new System.NotImplementedException();
        }
    }
}