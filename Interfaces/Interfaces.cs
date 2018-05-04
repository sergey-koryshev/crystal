using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITable
    {
        string Parameters { get; }

        string Path { get; }

        string ToString(List<byte> _intArray);

        List<byte> ToHex(string _stringArray);
    }

    public interface IAbout
    {
        string Description { get; }

        string Name { get; }

        string Author { get; }

        string Date { get; }

        string Link { get; }

        bool IsDefault { get; }

        void About();
    }

    public interface IPointer
    {
        string Parameters { get; }

        int GiveOffset();

        int GivePointer();
    }

    public interface IStoreMethod
    {
        string Parameters { get; }

        List<byte> GetBytes(int offset, string _pathToROM);

        void InsertBytes(int offset, string _pathToROM, List<byte> sequence);
    }
}
