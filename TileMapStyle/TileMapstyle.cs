using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;

namespace TileMapStyle
{
    public class TileMapStyle : IAbout, IStoreMethod
    {
        public string Description { get; }

        public string Name { get; }

        public string Author { get; }

        public string Date { get; }

        public string Link { get; }

        public bool IsDefault { get; }

        public string Parameters { get; }

        private int letters;

        private int lines;

        public TileMapStyle()
        {
            Parameters = "Letters - the amount of letters in line;Lines - the amount of lines";
            Name = "Tile-Map Store Method";
            Description = "Reading bytes by knowing initial amounts of letters and of lines";
            Author = "Sergey Koryshev";
            Date = "April, 2018";
            Link = string.Empty;
            IsDefault = true;
        }

        public TileMapStyle(string _parameters)
        {
            string[] parameters = _parameters.Split(new char[] { ';' });

            letters = int.Parse(parameters[0]);
            lines = int.Parse(parameters[1]);
        }

        public void About()
        {
            throw new NotImplementedException();
        }

        public List<byte> GetBytes(int _offset, string _pathToROM)
        {
            List<byte> result = new List<byte>();
            byte currentByte;
            BinaryReader openFile = new BinaryReader(File.Open(_pathToROM, FileMode.Open));
            openFile.BaseStream.Seek(_offset, SeekOrigin.Begin);
            for (int i = 0; i < letters*lines; i++)
            {
                currentByte = openFile.ReadByte();
                result.Add(currentByte);
            }
            openFile.Close();
            return result;
        }

        public void InsertBytes(int _offset, string _pathToROM, List<byte> _sequence)
        {
            BinaryWriter file = new BinaryWriter(File.Open(_pathToROM, FileMode.Open));
            file.BaseStream.Seek(_offset, SeekOrigin.Begin);
            foreach (byte currentByte in _sequence)
            {
                file.Write(currentByte);
            }
            file.Close();
        }
    }
}
