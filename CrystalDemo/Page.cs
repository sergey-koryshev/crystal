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

        public bool IsLinked {
            get;
            set; }

        public Page() { }

        public Page(string _name,
            bool _isLinked,
            IPointer _pointerPlugin,
            IStoreMethod _storeMethodPlugin,
            ITable _originalTablePlugin,
            ITable _newTablePlugin)
        {
            PageName = _name;
            IsLinked = _isLinked;
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
            GetOriginalBytes(paragraphs.Count - 1);
            GetNewBytes(paragraphs.Count - 1);
            if (IsLinked == true)
            {
                if (paragraphs.Count > 1)
                {
                    SetNextParagraph(paragraphs.Count - 2, paragraphs[paragraphs.Count - 1]);
                } else
                {
                    SetNextParagraph(paragraphs.Count - 1, null);
                }
                if (paragraphs.Count - 1 != 0)
                {
                    SetPreviousParagraph(paragraphs.Count - 1, paragraphs[paragraphs.Count - 2]);
                }
            }
        }

        public void AddParagraph(string _name,
            int _originaTextlOffset,
            int _originalPointerOffset,
            int _newTextOffset,
            int _newPointerOffset)
        {
            paragraphs.Add(new Paragraph(_name, _originaTextlOffset, _originalPointerOffset, _newTextOffset, _newPointerOffset));
            GetOriginalBytes(paragraphs.Count - 1);
            GetNewBytes(paragraphs.Count - 1);
            if (IsLinked == true)
            {
                if (paragraphs.Count > 1)
                {
                    SetNextParagraph(paragraphs.Count - 2, paragraphs[paragraphs.Count - 1]);
                }
                if (paragraphs.Count - 1 != 0)
                {
                    SetPreviousParagraph(paragraphs.Count - 1, paragraphs[paragraphs.Count - 2]);
                }
            }
        }

        public void GetOriginalBytes(int _paragraphID)
        {
            paragraphs[_paragraphID].OriginalBytes = storeMethod.GetBytes(paragraphs[_paragraphID].OriginalTextOffset, Program.settings.OriginalROMPath);
        }

        public void GetOriginalText(int _paragraphID)
        {
            GetOriginalBytes(_paragraphID);
            paragraphs[_paragraphID].OriginalText = originalTable.ToString(paragraphs[_paragraphID].OriginalBytes);
        }

        public void UpdateOriginalText(int _paragraphID)
        {
            GetOriginalText(_paragraphID);
        }

        public void GetNewBytes(int _paragraphID)
        {
            paragraphs[_paragraphID].NewBytes = storeMethod.GetBytes(paragraphs[_paragraphID].NewTextOffset, Program.settings.TraslatedROMPath);
        }

        public void GetNewText(int _paragraphID)
        {
            GetNewBytes(_paragraphID);
            paragraphs[_paragraphID].NewText = newTable.ToString(paragraphs[_paragraphID].NewBytes);
        }

        public void SetNewText(int _paragraphID,
            string _text)
        {
            paragraphs[_paragraphID].NewText = _text;
            SetNewBytes(_paragraphID, _text);
        }

        public void SetNewBytes(int _paragraphID,
            string _text)
        {
            paragraphs[_paragraphID].NewBytes = newTable.ToHex(_text);
        }

        public void InsertNewText(int _pargraphID,
            string _text)
        {
            SetNewText(_pargraphID, _text);
            if(IsLinked == false)
            {
                storeMethod.InsertBytes(paragraphs[_pargraphID].NewTextOffset, Program.settings.TraslatedROMPath, paragraphs[_pargraphID].NewBytes);
            } else
            {
                Paragraph paragraph = paragraphs[_pargraphID];
                do
                {
                    storeMethod.InsertBytes(paragraph.NewTextOffset, Program.settings.TraslatedROMPath, paragraph.NewBytes);
                    paragraph = paragraph.Next;
                    if (paragraph != null)
                    {
                        int oldNewTextOffset = paragraph.NewTextOffset;
                        paragraph.NewTextOffset = paragraph.Previous.NewTextEndOffset + 1;
                        paragraph.newPointer.SetPointer(Program.settings.TraslatedROMPath, oldNewTextOffset, paragraph.NewTextOffset);
                    }
                } while (paragraph != null);
            }
        }

        public void SetNextParagraph(int _pargraphID, Paragraph _next)
        {
            paragraphs[_pargraphID].Next = _next;
        }

        public void SetPreviousParagraph(int _pargraphID, Paragraph _previous)
        {
            paragraphs[_pargraphID].Previous = _previous;
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
