using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Crystal
{
    class Program
    {
        public static Settings settings;

        static void Main(string[] args)
        {
            settings = new Settings();

            string originalRom = @"D:\1.gb";
            string translatedRom = @"E:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!][RUS].gb";

            Book book = new Book("Castlevania: Legends (GBC)", originalRom, translatedRom);
            book.AddPage("Dialogs (Stop-Byte)", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", "", "", "Basic Table", "Stop-Byte Store Method", "255");
            book.pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, 0x24524);
            book.pages[0].AddParagraph("Alucard and Sonia (after the fight)", 0x2516f, 0x24553);
            book.pages[0].AddParagraph("Dracula (before the first form)", 0x2536A, 0x24582);
            book.pages[0].AddParagraph("Dracula (before the second form)", 0x2570B, 0x245B1);
            book.pages[0].AddParagraph("Dracual (after the fight)", 0x25C4D, 0x245E0);
            string text = book.ExportText(0, 1);
            Console.WriteLine(text);




            Console.ReadLine();
        }
    }
}
