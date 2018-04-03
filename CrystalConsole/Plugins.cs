using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Interfaces;
using System.IO;

namespace CrystalConsole
{
    class Plugins
    {
        public static List<string> Check(string path, Type seekingInterface)
        {
            List<string> DLLs = new List<string>();

            string[] files;

            files = Directory.GetFiles(path, "*.dll");

            Type DLL;

            foreach (string file in files)
            {
                DLL = Assembly
                .LoadFrom(file)
                .GetTypes()
                .FirstOrDefault(seekingInterface.IsAssignableFrom);
                if (DLL != null)
                {
                    DLLs.Add(file);
                }
            }

            return DLLs;
        }

        public static object Load(string path, Type seekingInterface, string[] parameters)
        {
            Type type = Assembly
                .LoadFrom(path)
                .GetTypes()
                .First(seekingInterface.IsAssignableFrom);

            return Activator.CreateInstance(type, parameters);
        }
    }
}

