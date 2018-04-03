using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Page : Book
    {
        private string Name { get; }

        private List<Paragraph> Paragraphs = new List<Paragraph> { };

        public Page() { }

        public Page(string name)
        {
            Name = name;
        }

        public void AddParagraph(string name, int _originalOffset, int[] _originalPointer)
        {
            Paragraphs.Add(new Paragraph(name, _originalOffset, _originalPointer));
        }
    }
}
