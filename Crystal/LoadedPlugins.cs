using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class LoadedPlugins
    {
        string PluginsFolder { get; }

        public Dictionary<string, string> TablePluginList = new Dictionary<string, string>();

        public Dictionary<string, string> PointerPluginList = new Dictionary<string, string>();

        public Dictionary<string, string> StorePluginList = new Dictionary<string, string>();

        public LoadedPlugins()
        {
            PluginsFolder = @"D:\Repositories\CrystalDup\Plugins";

            TablePluginList = Plugins.Check(PluginsFolder, typeof(ITable));

            PointerPluginList = Plugins.Check(PluginsFolder, typeof(IPointer));

            StorePluginList = Plugins.Check(PluginsFolder, typeof(IStoreMethod));
        }
    }
}
