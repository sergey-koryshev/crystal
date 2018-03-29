using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    interface ITable
    {
        string Name { get; }

        string GetChar(int _value);

        int? GetValue(string _char);
    }
}
