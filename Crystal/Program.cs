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
        static void Main(string[] args)
        {
            string originalRom = @"D:\1.gb";
            string translatedRom = @"E:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!][RUS].gb";

            Book book = new Book("Castlevania: Legends (GBC)", originalRom, translatedRom);
            book.AddPage("Dialogs (Stop-Byte)", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", "", "Basic Table", "Stop-Byte Store Method", "255");
            book.pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, 0x24524);
            string text = book.ExportText(0, 0);
            Console.WriteLine(text);

            Console.ReadLine();
        }
    }
}
