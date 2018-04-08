using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class Page : Book
    {
        private string Name { get; }

        private string OriginalTablePath { get; }

        private string RussianTablePath { get; }

        public List<Paragraph> paragraphs = new List<Paragraph>();

        public IPointer pointer;

        public IStoreMethod storeMethod;

        public ITable table;

        public Page() { }

        public Page(string _name, string _originalTablePath, string _russianTablePath, string _pointerPluginName, string _tablePluginName, string _storeMethodPluginName, string _storeMethodPluginParameters)
        {
            Name = _name;
            OriginalTablePath = _originalTablePath;
            RussianTablePath = _russianTablePath;
            //pointer = 

            table = (ITable)Plugins.Load(loadedPlugins.TablePluginList[_tablePluginName], typeof(ITable), new string[] { OriginalTablePath });

            storeMethod = (IStoreMethod)Plugins.Load(loadedPlugins.StorePluginList[_storeMethodPluginName], typeof(IStoreMethod), new string[] { _storeMethodPluginParameters });
        }

        public void AddParagraph(string _name, int _originaTextlOffset, int _originalPointerOffset)
        {
            paragraphs.Add(new Paragraph(_name, _originaTextlOffset, _originalPointerOffset));
        }
    }
}
