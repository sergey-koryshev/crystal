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
        public string Name { get; set; }

        public List<Page> pages = new List<Page> { };

        public Book() { }

        public Book(string _name)
        {
            Name = _name;
        }

        public Page AddPage(string _name,
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

            pages.Add(new Page(_name, _isLinked, _originalTablePath, _newTablePath, _pointerPluginName, _pointerPluginParameters, _tablePluginName, _tablePluginParameters, _storeMethodPluginName, _storeMethodPluginParameters));

            return pages[pages.Count - 1];
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

        public string RevertNewText(int _pageID,
            int _paragraphID
            )
        {
            string result = string.Empty;
            pages[_pageID].GetNewText(_paragraphID);
            result = pages[_pageID].paragraphs[_paragraphID].NewText;
            return result;
        }

        public string ExportNewText(int _pageID,
            int _paragraphID)
        {
            string result = string.Empty;
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
