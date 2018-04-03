using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Book
    {
        private string Name { get; }

        public string OriginalRom { get; }

        public string TranslatedRom { get; }

        public List<Page> pages = new List<Page> { };

        public List<string> tablePlugins = new List<string>();

        public List<string> pointerPlugins = new List<string>();

        public List<string> storeMethodPlugins = new List<string>();

        public Book() { }

        public Book(string _name, string _originalRom, string _translatedRom)
        {
            Name = _name;
            OriginalRom = _originalRom;
            TranslatedRom = _translatedRom;
        }

        public void AddPage(string _name)
        {
            pages.Add(new Page(_name));
        }
    }
}
