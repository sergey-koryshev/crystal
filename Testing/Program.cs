using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Interfaces;
using System.IO;

namespace Testing
{
    static class TablePlugins
    {
        public static void Check(string pathToFolder)
        {
            try
            {
                string[] files;

                files = Directory.GetFiles(pathToFolder, "*.dll");

                foreach (string file in files)
                {
                    Assembly dll = Assembly.LoadFrom(file);

                    foreach (Type type in dll.GetTypes())
                    {
                        foreach (Type iType in type.GetInterfaces())
                        {
                            if (iType.Name == typeof(ITable).Name)
                            {
                                Console.WriteLine(type.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl";

            Assembly a = Assembly.LoadFrom(@"D:\Repositories\Crystal\TableBasic\bin\Debug\TableBasic.dll");

            Type someType = null;
            foreach (Type t in a.GetTypes())
            {
                foreach (Type iT in t.GetInterfaces())
                {
                    if (iT == typeof(ITable))
                    {
                        someType = t;
                        break;
                    }
                }
                if (someType != null)
                {
                    break;
                }
            }
            if (someType == null)
            {
                throw new Exception();
            }
            ITable obj = (ITable)Activator.CreateInstance(someType, path);

            Console.WriteLine(string.Format("{0:x}", obj.GetValue("k")));

            Console.ReadLine();
        }
    }
}
