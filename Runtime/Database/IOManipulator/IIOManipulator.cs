namespace Slantar.Architecture
{
    public interface IIOManipulator
    {
        void Save(byte[] data);
        byte[] Load();
    }
}