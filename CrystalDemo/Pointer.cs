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

        public Pointer(int _offset, int _countBytes)
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
            result = ToInt(bytes);

            return result;
        }

        public void SetPointer(string _pathToROM, int _originalTextOffset, int _newTextOffset)
        {
            int oldPointer = GetPointer(_pathToROM);

            int difference = _newTextOffset - _originalTextOffset;
            int newPointer = oldPointer + difference;
            byte[] newBytes = BitConverter.GetBytes(newPointer);

            BinaryWriter file = new BinaryWriter(File.Open(_pathToROM, FileMode.Open));
            file.BaseStream.Seek(Offset, SeekOrigin.Begin);
            int i = 0;
            while (i < CountBytes)
            {
                file.Write(newBytes[i]);
                i++;
            }
            file.Close();
        }

        private void ShiftBytes(ref int _pointer)
        {
            byte[] bytes = BitConverter.GetBytes(_pointer);
            _pointer = ToInt(bytes);
        }

        private int ToInt(byte[] array)
        {
            int pos = 0;
            int result = 0;
            foreach (byte by in array)
            {
                result |= ((int)by) << pos;
                pos += 8;
            }
            return result;
        }
    }
}
