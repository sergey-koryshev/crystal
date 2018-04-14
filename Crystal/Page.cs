using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class Page
    {
        public string PageName { get; }

        public List<Paragraph> paragraphs = new List<Paragraph>();

        public IPointer pointer;

        public IStoreMethod storeMethod;

        public ITable originalTable;

        public ITable newTable;

        private int originalSize;

        private int newSize;

        public Page() { }

        public Page(string _name,
            IPointer _pointerPlugin,
            IStoreMethod _storeMethodPlugin,
            ITable _originalTablePlugin,
            ITable _newTablePlugin)
        {
            PageName = _name;
            pointer = _pointerPlugin;
            storeMethod = _storeMethodPlugin;
            originalTable = _originalTablePlugin;
            newTable = _newTablePlugin;
        }

        public void AddParagraph(string _name,
            int _originaTextlOffset,
            int _originalPointerOffset)
        {
            paragraphs.Add(new Paragraph(_name, _originaTextlOffset, _originalPointerOffset));
            GetBytes(paragraphs.Count - 1);
        }

        public void GetBytes(int _paragraphID)
        {
            paragraphs[_paragraphID].OriginalBytes = storeMethod.GetBytes(paragraphs[_paragraphID].OriginalTextOffset, Program.settings.OriginalROMPath);
        }

        public void GetText(int _paragraphID)
        {
            GetBytes(_paragraphID);
            paragraphs[_paragraphID].OriginalText = originalTable.ToString(paragraphs[_paragraphID].OriginalBytes);
        }

        public void UpdateOriginalText(int _paragraphID)
        {
            GetText(_paragraphID);
        }

        public void SetText(int _paragraphID, string _text)
        {
            paragraphs[_paragraphID].NewText = _text;
            SetBytes(_paragraphID, _text);
        }

        public void SetBytes(int _paragraphID, string _text)
        {
            paragraphs[_paragraphID].NewBytes = newTable.ToHex(_text);
        }

        public void InsertText(int _pargraphID, string _text)
        {
            SetText(_pargraphID, _text);
            storeMethod.InsertBytes(paragraphs[_pargraphID].NewTextOffset, Program.settings.TraslatedROMPath, paragraphs[_pargraphID].NewBytes);
        }

        public int OriginalSize
        {
            get
            {
                int result = 0;
                foreach (Paragraph paragraph in paragraphs)
                {
                    result += paragraph.OriginalSize;
                }
                return result;
            }
        }

        public int NewSize
        {
            get
            {
                int result = 0;
                foreach (Paragraph paragraph in paragraphs)
                {
                    result += paragraph.NewSize;
                }
                return result;
            }
        }
    }
}
