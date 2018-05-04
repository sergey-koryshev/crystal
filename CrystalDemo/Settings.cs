using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class Settings
    {
        public string PluginsFolder { set; get; }

        public string OriginalROMPath { set; get; }

        public string TraslatedROMPath { set; get; }

        public string ProjectPath { set; get; }


        public Dictionary<string, string> TablePluginList = new Dictionary<string, string>();

        public Dictionary<string, string> PointerPluginList = new Dictionary<string, string>();

        public Dictionary<string, string> StorePluginList = new Dictionary<string, string>();

        public Settings()
        {
            PluginsFolder = @"D:\Repositories\Crystal\Plugins";

            OriginalROMPath = @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!].gb";

            TraslatedROMPath = @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\07_select_difficult - Copy.gb";

            TablePluginList = Plugins.Check(PluginsFolder, typeof(ITable));

            PointerPluginList = Plugins.Check(PluginsFolder, typeof(IPointer));

            StorePluginList = Plugins.Check(PluginsFolder, typeof(IStoreMethod));
        }
    }
}
