using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Book
    {
        public string Name { get; }

        public string OriginalRom { get; }

        public string TranslatedRom { get; }

        public List<Page> Pages = new List<Page> { };

        public Book() { }

        public Book(string _name, string _originalRom, string _translatedRom)
        {
            Name = _name;
            OriginalRom = _originalRom;
            TranslatedRom = _translatedRom;
        }

        public void AddPage(string _name)
        {
            Pages.Add(new Page(_name));
        }
    }
}
