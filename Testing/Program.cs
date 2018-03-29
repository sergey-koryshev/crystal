using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Testing
{
    interface ITable
    {
        string Name { get; }

        string GetChar(int _value);

        int? GetValue(string _char);
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl";

            Assembly asm = Assembly.LoadFrom(@"E:\Programming\Crystal\TableBasic\bin\Debug\TableBasic.dll");

            Type type = asm.GetType("Table.Table");

            ITable instance = (ITable)Activator.CreateInstance(type, path);

            Console.WriteLine(instance.GetChar(0x0b));

            Console.ReadLine();
        }
    }
}
