using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal
{
    class Paragraph
    {
        public string Name { get; set; }

        public Pointer originalPointer;

        public Pointer newPointer;

        public int OriginalTextOffset { set; get; }

        public int NewTextOffset { set; get; }

        public string OriginalText { set; get; }

        public string NewText { set; get; }

        public List<byte> OriginalBytes { set; get; }

        public List<byte> NewBytes { set; get; }

        public Paragraph Next { set; get; }

        public Paragraph Previous { set; get; }

        public Paragraph() { }

        public Paragraph(string _name, int _originaTextlOffset, int _originalPointerOffset) : this(_name, _originaTextlOffset, _originalPointerOffset, _originaTextlOffset, _originalPointerOffset) { }

        public Paragraph(string _name, int _originaTextlOffset, int _originalPointerOffset, int _newTextOffset, int _newPointerOffset)
        {
            Name = _name;
            Next = null;
            OriginalTextOffset = _originaTextlOffset;
            originalPointer = new Pointer(_originalPointerOffset, 2);
            NewTextOffset = (int)_newTextOffset;
            newPointer = new Pointer((int)_newPointerOffset, 2);
        }

        public int OriginalSize
        {
            get { return OriginalBytes.Count; }
        }

        public int NewSize
        {
            get { return NewBytes.Count; }
        }

        public int OriginalTextEndOffset
        {
            get { return OriginalTextOffset + OriginalBytes.Count - 1; }
        }

        public int NewTextEndOffset
        {
            get { return NewTextOffset + NewBytes.Count - 1; }
        }
    }
}
