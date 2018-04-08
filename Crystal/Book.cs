using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class Book
    {
        private string Name { get; }

        public string OriginalROMPath { get; }

        public string TranslatedROMPath { get; }

        public List<Page> pages = new List<Page> { };

        static public LoadedPlugins loadedPlugins;

        public Book() { }

        public Book(string _name, string _originalROMPath, string _traslatedROMPath)
        {
            Name = _name;
            OriginalROMPath = _originalROMPath;
            TranslatedROMPath = _traslatedROMPath;
            loadedPlugins = new LoadedPlugins();
        }

        public void AddPage(string _name, string _originalTablePath, string _russianTablePath, string _pointerPluginName, string _tablePluginName, string _storeMethodPluginName, string _storeMethodPluginParameters)
        {
            pages.Add(new Page(_name, _originalTablePath, _russianTablePath, _pointerPluginName, _tablePluginName, _storeMethodPluginName, _storeMethodPluginParameters));
        }

        public List<byte> ExportBytes(int _pageID, int _paragraphID)
        {
            List<byte> result;

            result = pages[_pageID].storeMethod.GetSequence(pages[_pageID].paragraphs[_paragraphID].OriginalTextOffset, OriginalROMPath);

            return result;
        }

        public string ExportText(int _pageID, int _paragraphID)
        {
            string result;

            List<byte> bytes = ExportBytes(_pageID, _paragraphID);

            result = pages[_pageID].table.ToString(bytes);

            return result;
        }

        public void ImportText(int _pageID, int _paragraphID)
        {

        }

        public void ImportBytes(int _pageID, int _paragraphID)
        {

        }
    }
}
