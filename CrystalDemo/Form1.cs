using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.settings = new Settings();

            string originalRom = @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!].gb";
            string translatedRom = @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Original_rom\Castlevania - Legends (UE) [S][!][RUS].gb";

            Program.book = new Book("Castlevania: Legends (GBC)", originalRom, translatedRom);
            Program.book.AddPage("Dialogs (Stop-Byte)", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", "", "", "Basic Table", "Stop-Byte Store Method", "255");
            Program.book.pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, 0x24524);
            Program.book.pages[0].AddParagraph("Alucard and Sonia (after the fight)", 0x2516f, 0x24553);
            Program.book.pages[0].AddParagraph("Dracula (before the first form)", 0x2536A, 0x24582);
            Program.book.pages[0].AddParagraph("Dracula (before the second form)", 0x2570B, 0x245B1);
            Program.book.pages[0].AddParagraph("Dracual (after the fight)", 0x25C4D, 0x245E0);

            TreeNode addingBook = new TreeNode(Program.book.BookName);
            addingBook.Tag = "Book";
            treeView1.Nodes.Add(addingBook);

            foreach (Page page in Program.book.pages)
            {
                TreeNode addingPage = new TreeNode(page.PageName);
                addingPage.Tag = "Page";
                addingBook.Nodes.Add(addingPage);
                foreach (Paragraph paragraph in page.paragraphs)
                {
                    TreeNode addingParagraph = new TreeNode(paragraph.ParagraphName);
                    addingParagraph.Tag = "Paragraph";
                    addingPage.Nodes.Add(addingParagraph);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            switch (treeView1.SelectedNode.Tag)
            {
                case "Paragraph":
                    richTextBox1.Text = Program.book.ExportText(treeView1.SelectedNode.Parent.Index, treeView1.SelectedNode.Index);
                    textBox1.Text = Program.book.pages[treeView1.SelectedNode.Parent.Index].paragraphs[treeView1.SelectedNode.Index].OriginalSize.ToString();
                    break;
                case "Page":
                    textBox1.Text = Program.book.pages[treeView1.SelectedNode.Index].OriginalSize.ToString();
                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox2.Text;

            Program.book.ImportText(treeView1.SelectedNode.Parent.Index, treeView1.SelectedNode.Index, text);
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
