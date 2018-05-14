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
        public string Name { get; }

        public List<Paragraph> paragraphs = new List<Paragraph>();

        public string PointerPluginName { get; set; }

        public string PointerPluginParameters { get; set; }

        public string TablePluginName { get; set; }

        public string TablePluginParameters { get; set; }

        public string StoreMethodPluginName { get; set; }

        public string StoreMethodPluginParameters { get; set; }

        public string OriginalTablePath { set; get; }

        public string NewTablePath { set; get; }

        public IPointer pointer;

        public IStoreMethod storeMethod;

        public ITable originalTable;

        public ITable newTable;

        public bool IsLinked { get; set; }

        public Page() { }

        public Page(string _name,
            bool _isLinked,
            string _originalTablePath,
            string _newTablePath,
            string _pointerPluginName,
            string _pointerPluginParameters,
            string _tablePluginName,
            string _tablePluginParameters,
            string _storeMethodPluginName,
            string _storeMethodPluginParameters)
        {
            Name = _name;
            IsLinked = _isLinked;
            TablePluginName = _tablePluginName;
            TablePluginParameters = _tablePluginParameters;
            StoreMethodPluginName = _storeMethodPluginName;
            StoreMethodPluginParameters = _storeMethodPluginParameters;
            OriginalTablePath = _originalTablePath;
            NewTablePath = _newTablePath;

            pointer = null;
            storeMethod = (IStoreMethod)Plugins
                .Load(Program.settings.StorePluginList[StoreMethodPluginName], typeof(IStoreMethod), new string[] { StoreMethodPluginParameters });
            originalTable = (ITable)Plugins
                .Load(Program.settings.TablePluginList[TablePluginName], typeof(ITable), new string[] { _originalTablePath, TablePluginParameters });
            newTable = (ITable)Plugins
                .Load(Program.settings.TablePluginList[TablePluginName], typeof(ITable), new string[] { _newTablePath, TablePluginParameters });
        }

        public void AddParagraph(string _name,
            int _originaTextlOffset,
            int _originalPointerOffset)
        {
            paragraphs.Add(new Paragraph(_name, _originaTextlOffset, _originalPointerOffset));
            GetOriginalText(paragraphs.Count - 1);
            GetNewText(paragraphs.Count - 1);
            if (IsLinked == true)
            {
                if (paragraphs.Count > 1)
                {
                    SetNextParagraph(paragraphs.Count - 2, paragraphs[paragraphs.Count - 1]);
                }
                else
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
            int _newPointerOffset,
            string _text)
        {
            paragraphs.Add(new Paragraph(_name, _originaTextlOffset, _originalPointerOffset, _newTextOffset, _newPointerOffset));
            GetOriginalText(paragraphs.Count - 1);

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
            SetNewText(paragraphs.Count - 1, _text);
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
            if (IsLinked == false)
            {
                storeMethod.InsertBytes(paragraphs[_pargraphID].NewTextOffset, Program.settings.TraslatedROMPath, paragraphs[_pargraphID].NewBytes);
            }
            else
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
