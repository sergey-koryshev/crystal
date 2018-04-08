using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crystal
{
    class Pointer
    {
        private int Offset { set; get; }

        private int CountBytes { get; set; }

        public Pointer() { }

        public Pointer(int _offset, int _countBytes = 0)
        {
            Offset = _offset;
            CountBytes = _countBytes;
        }

        public int GetPointer(string _pathToROM)
        {
            int result;

            BinaryReader openFile = new BinaryReader(File.Open(_pathToROM, FileMode.Open));
            openFile.BaseStream.Seek(Offset, SeekOrigin.Begin);
            byte[] bytes = openFile.ReadBytes(CountBytes);
            openFile.Close();
            result = BitConverter.ToInt32(bytes, 0);

            return result;
        }
    }
}
