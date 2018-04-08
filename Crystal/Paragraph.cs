using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal
{
    class Paragraph : Page
    {
        private string Name { get; }

        public Pointer originalPointer;

        public Pointer newPointer;

        public int originalTextOffset;

        public int newTextOffset;

        public Paragraph() { }

        public Paragraph(string _name, int _originaTextlOffset, int _originalPointerOffset)
        {
            Name = _name;
            OriginalTextOffset = _originaTextlOffset;
            originalPointer = new Pointer(_originalPointerOffset, 2);
        }

        public int OriginalTextOffset
        {
            get { return originalTextOffset; }
            set { originalTextOffset = value; }
        }

        public int NewTextOffset
        {
            get { return newTextOffset; }
            set { newTextOffset = value; }
        }
        //public Pointer NewPointer { }
    }
}
