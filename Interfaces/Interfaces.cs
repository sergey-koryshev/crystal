using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITable
    {
        string Name { get; }

        string GetValue(int _value);

        int? GetValue(string _char);
    }
}
