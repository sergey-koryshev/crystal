using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            Program.book = new Book("Castlevania: Legends (GBC)");
            Program.book.AddPage("Dialogs", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", "", "", "Basic Table", "Stop-Byte Store Method", "255");
            Program.book.pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, 0x24524);
            Program.book.pages[0].AddParagraph("Alucard and Sonia (after the fight)", 0x2516f, 0x24553);
            Program.book.pages[0].AddParagraph("Dracula (before the first form)", 0x2536A, 0x24582);
            Program.book.pages[0].AddParagraph("Dracula (before the second form)", 0x2570B, 0x245B1);
            Program.book.pages[0].AddParagraph("Dracual (after the fight)", 0x25C4D, 0x245E0);
            Program.book.AddPage("History", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\History_screen.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\History_screen.tbl", "", "", "Basic Table", "Tile-Map Store Method", "20;80");
            Program.book.pages[1].AddParagraph("History", 0x6292, 0x1661);

            TreeNode addingBook = new TreeNode(Program.book.BookName);
            addingBook.Tag = "Book";
            treeProject.Nodes.Add(addingBook);

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
            txtOriginal.Clear();
            txtOriginalSize.Clear();
            StringBuilder text;
            switch (treeProject.SelectedNode.Tag)
            {
                case "Paragraph":
                    text = new StringBuilder(Regex.Replace(Program.book.ExportText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

                    txtOriginal.Text = text.ToString();
                    txtOriginalSize.Text = Program.book.pages[treeProject.SelectedNode.Parent.Index].paragraphs[treeProject.SelectedNode.Index].OriginalSize.ToString();
                    break;
                case "Page":
                    txtOriginalSize.Text = Program.book.pages[treeProject.SelectedNode.Index].OriginalSize.ToString();
                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder(Regex.Replace(txtNew.Text, @"·", " "));

            Program.book.ImportText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index, text.ToString());
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtLength.Text = AmountLetters(txtOriginal.SelectedText).ToString();
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            txtLength.Text = AmountLetters(txtOriginal.SelectedText).ToString();
        }

        public int AmountLetters(string _text)
        {
            int result = 0;
            int i = 0;
            string text = Regex.Replace(_text, @"\n+", "");

            while (i < text.Length)
            {
                switch(text[i])
                {
                    case '[':
                        result++;
                        i++;
                        int j = i;
                        while ((j < text.Length) && (text[j] != ']'))
                        {
                            j++;
                        }
                        j++;
                        i = j;
                        break;
                    case '{':
                        result++;
                        i++;
                        int k = i;
                        while ((k < text.Length) && (text[k] != '}'))
                        {
                            k++;
                        }
                        k++;
                        i = k;
                        break;
                    default:
                        result++;
                        i++;
                        break;
                }
            }

            return result;
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtLength.Text = AmountLetters(txtOriginal.SelectedText).ToString();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void txtOriginal_Load(object sender, EventArgs e)
        {

        }

        private void txtOriginal_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            if (e.InsertingText == " ")
            {
                e.InsertingText = "·";
            }
        }
    }
}
