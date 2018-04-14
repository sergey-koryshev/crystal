using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal
{
    class Paragraph
    {
        public string ParagraphName { get; }

        public Pointer originalPointer;

        public Pointer newPointer;

        public int OriginalTextOffset { set; get; }

        public int NewTextOffset { set; get; }

        public string OriginalText { set; get; }

        public string NewText { set; get; }

        public List<byte> OriginalBytes { set; get; }

        public List<byte> NewBytes { set; get; }

        public int originalSize;

        public int newSize;

        public Paragraph() { }

        public Paragraph(string _name, int _originaTextlOffset, int _originalPointerOffset)
        {
            ParagraphName = _name;
            OriginalTextOffset = _originaTextlOffset;
            originalPointer = new Pointer(_originalPointerOffset, 2);

        }

        public int OriginalSize
        {
            get { return OriginalBytes.Count; }
        }

        public int NewSize
        {
            get { return NewBytes.Count; }
        }

        //public Pointer NewPointer { }
    }
}
