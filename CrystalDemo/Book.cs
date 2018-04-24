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
        public string BookName { get; }

        public List<Page> pages = new List<Page> { };

        public Book() { }

        public Book(string _name)
        {
            BookName = _name;
        }

        public void AddPage(string _name,
            bool _isLinked,
            string _originalTablePath,
            string _newTablePath,
            string _pointerPluginName,
            string _pointerPluginParameters,
            string _tablePluginName,
            string _tablePluginParameters,
            string _storeMethodPluginName,
            string _storeMethodPluginParameters
            )
        {
            IPointer pointer = null;

            ITable originalTable = (ITable)Plugins
                .Load(Program.settings.TablePluginList[_tablePluginName], typeof(ITable), new string[] { _originalTablePath, _tablePluginParameters });

            ITable newTable = (ITable)Plugins
                .Load(Program.settings.TablePluginList[_tablePluginName], typeof(ITable), new string[] { _newTablePath, _tablePluginParameters });

            IStoreMethod storeMethod = (IStoreMethod)Plugins
                .Load(Program.settings.StorePluginList[_storeMethodPluginName], typeof(IStoreMethod), new string[] { _storeMethodPluginParameters });

            pages.Add(new Page(_name, _isLinked, pointer, storeMethod, originalTable, newTable));
        }

        public string ExportOriginalText(int _pageID,
            int _paragraphID
            )
        {
            string result = string.Empty;
            pages[_pageID].UpdateOriginalText(_paragraphID);
            result = pages[_pageID].paragraphs[_paragraphID].OriginalText;
            return result;
        }

        public string ExportNewText(int _pageID,
            int _paragraphID
            )
        {
            string result = string.Empty;
            pages[_pageID].GetNewText(_paragraphID);
            result = pages[_pageID].paragraphs[_paragraphID].NewText;
            return result;
        }

        public void SetNewText(int _pageID,
            int _paragraphID,
            string _text
            )
        {
            pages[_pageID].SetNewText(_paragraphID, _text);
        }

        public void ImportText(int _pageID, int _paragraphID, string _text)
        {
            pages[_pageID].InsertNewText(_paragraphID, _text);
        }
    }
}
