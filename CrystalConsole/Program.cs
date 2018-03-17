using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalRom = @"E:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!].gb";
            string translatedRom = @"E:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!][RUS].gb";

            Book mainBook = new Book ("Castlevania: Legends (GBC)", originalRom, translatedRom);

            mainBook.AddPage("Dialogs");
            mainBook.Pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, );
        }
    }
}
