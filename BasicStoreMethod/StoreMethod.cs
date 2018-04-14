using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;

namespace BasicStoreMethod
{
    public class StoreMethod : IAbout, IStoreMethod
    {
        public string Parameters { get; }

        public byte stopByte;

        public string Name { get; }

        public string Description { get; }

        public string Author { get; }

        public string Date { get; }

        public string Link { get; }

        public bool IsDefault { get; }

        public StoreMethod()
        {
            Parameters = "Stop Byte - The number that means stop reading bytes";
            Name = "Stop-Byte Store Method";
            Description = "Reading bytes by knowing initial offset and stop-byte";
            Author = "Sergey Koryshev";
            Date = "April, 2018";
            Link = string.Empty;
            IsDefault = true;
        }

        public StoreMethod(string _parameters)
        {
            stopByte = byte.Parse(_parameters);
        }

        public List<byte> GetBytes(int _offset, string _pathToROM)
        {
            List<byte> result = new List<byte>();
            byte currentByte;
            BinaryReader openFile = new BinaryReader(File.Open(_pathToROM, FileMode.Open));
            openFile.BaseStream.Seek(_offset, SeekOrigin.Begin);
            do
            {
                currentByte = openFile.ReadByte();
                result.Add(currentByte);
            } while (currentByte != stopByte);
            openFile.Close();
            return result;
        }

        public void InsertBytes(int _offset, string _pathToROM, List<byte> sequence)
        {
            BinaryWriter file = new BinaryWriter(File.Open(_pathToROM, FileMode.Open));
            file.BaseStream.Seek(_offset, SeekOrigin.Begin);
            foreach (byte currentByte in sequence)
            {
                file.Write(currentByte);
            }
            file.Close();
        }

        public void About()
        {
            throw new NotImplementedException();
        }
    }
}
