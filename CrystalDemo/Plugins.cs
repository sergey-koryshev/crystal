using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Reflection;
using System.IO;

namespace Crystal
{
    class Plugins
    {
        public static Dictionary<string, string> Check(string path, Type seekingInterface)
        {
            Dictionary<string, string> DLLs = new Dictionary<string, string>();

            string[] files;

            files = Directory.GetFiles(path, "*.dll");

            Type DLL;

            foreach (string file in files)
            {
                try
                {
                    DLL = Assembly
                        .LoadFrom(file)
                        .GetTypes()
                        .FirstOrDefault(seekingInterface.IsAssignableFrom);

                    if (DLL != null)
                    {
                        IAbout pointerName = (IAbout)Activator.CreateInstance(DLL);
                        DLLs.Add(pointerName.Name, file);
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return DLLs;
        }

        public static object Load(string path, Type seekingInterface)
        {
            Type DLL = Assembly
                .LoadFrom(path)
                .GetTypes()
                .First(t => seekingInterface.IsAssignableFrom(t) &&
                typeof(IAbout).IsAssignableFrom(t));

            return Activator.CreateInstance(DLL);
        }

        public static object Load(string path, Type seekingInterface, string[] parameters)
        {
            Type DLL = Assembly
                .LoadFrom(path)
                .GetTypes()
                .First(t => seekingInterface.IsAssignableFrom(t) &&
                typeof(IAbout).IsAssignableFrom(t));

            return Activator.CreateInstance(DLL, parameters);
        }

    }
}
