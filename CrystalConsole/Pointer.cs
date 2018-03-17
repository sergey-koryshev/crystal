using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CrystalConsole
{
    class Pointer
    {
        private List<int> offsets;

        private int countBytes;

        public Pointer() { }

        public Pointer(int[] _offsets, int _countBytes = 0)
        {
            offsets.AddRange(_offsets);
            countBytes = _countBytes;
        }

        public void SetNewPointer(int _originalOffset, int _newOffset, string _originalROM, string _translatedROM)
        {
            List<byte> originalPointer = new List<byte>();
            BinaryReader openFile = new BinaryReader(File.Open(_originalROM, FileMode.Open));
            if (countBytes == 0)
            {
                foreach(int offset in offsets)
                {
                    openFile.BaseStream.Seek(offset, SeekOrigin.Begin);
                    unpackedArray.Add(openFile.ReadByte());
                }
            }
            openFile.BaseStream.Seek(begin, SeekOrigin.Begin);
            while (unpackedArray.Count < openFile.BaseStream.Length)
            {
                unpackedArray.Add(openFile.ReadByte());
            }
            openFile.Close();
        }
    }
}
