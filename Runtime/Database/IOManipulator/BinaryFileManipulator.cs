
using System.IO;

namespace Slantar.Architecture
{
    public class BinaryFileManipulator : IIOManipulator
    {
        public readonly string path;

        public BinaryFileManipulator(string path)
        {
            this.path = path;
        }

        public void Save(byte[] data)
        {
            //using (BinaryWriter writer = new BinaryWriter())
            //{
                
            //}
        }

        public byte[] Load()
        {
            return new byte[0];
        }
    }
}