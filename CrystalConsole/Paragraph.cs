using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Paragraph
    {
        public string Name { get; }

        public Pointer OriginalPointer;

        public Pointer NewPointer;

        public int originalOffset;

        public int newOffset;



        public Paragraph() { }

        public Paragraph(string name, int _originalOffset, int[] _originalPointer)
        {
            Name = name;
            OriginalOffset = _originalOffset;
            OriginalPointer = new Pointer(_originalPointer);
        }

        public int OriginalOffset
        {
            get { return originalOffset; }
            set { originalOffset = value; }
        }

        public int NewOffset
        {
            get { return newOffset; }
            set { newOffset = value; }
        }

        public void SetNewPointer(int[] values) 
        {
            NewPointer = new Pointer(values);
        }

        public Pointer GetOriginalPointer()
        {
            return OriginalPointer;
        }

        public Pointer GetNewPointer()
        {
            return NewPointer;
        }
    }
}
