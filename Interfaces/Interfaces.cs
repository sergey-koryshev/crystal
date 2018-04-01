using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITable
    {
        string ToString(List<int> _intArray);

        List<int> ToHex(string _stringArray);
    }

    public interface IName
    {
        string Name { get; }
    }
}
