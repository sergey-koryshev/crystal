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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Program.settings = new Settings();

            Program.book = new Book("Castlevania: Legends (GBC)");

            Program.book.AddPage("Dialogs", true, @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\Dialogs.tbl", "", "", "Basic Table", "", "Stop-Byte Store Method", "255");
            Program.book.pages[0].AddParagraph("Alucard and Sonia (before the fight)", 0x24cb9, 0x24524);
            Program.book.pages[0].AddParagraph("Alucard and Sonia (after the fight)", 0x2516f, 0x24553);
            Program.book.pages[0].AddParagraph("Dracula (before the first form)", 0x2536A, 0x24582);
            Program.book.pages[0].AddParagraph("Dracula (after the fight)", 0x2570B, 0x245B1);
            Program.book.pages[0].AddParagraph("Dracual (before the second form)", 0x25C4D, 0x245E0);

            Program.book.AddPage("History", false, @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\History_screen.tbl", @"D:\YandexDisk\Romhacking\Translations\03. Castlevania. Legends\Tables\History_screen (rus).tbl", "", "", "Tile Map Table", "20", "Tile-Map Store Method", "20;20");
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

        private void treeProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtOriginal.Clear();
            StringBuilder originalText;
            StringBuilder newText;
            switch (treeProject.SelectedNode.Tag)
            {
                case "Paragraph":
                    originalText = new StringBuilder(Regex.Replace(Program.book.ExportOriginalText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

                    txtOriginal.Text = originalText.ToString();

                    newText = new StringBuilder(Regex.Replace(Program.book.ExportNewText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index), @"[\s-[\r\n]]", "·"));

                    txtNew.Text = newText.ToString();

                    propertyGrid1.SelectedObject = Program.book.pages[treeProject.SelectedNode.Parent.Index].paragraphs[treeProject.SelectedNode.Index];
                    break;
                case "Page":
                    propertyGrid1.SelectedObject = Program.book.pages[treeProject.SelectedNode.Index];
                    break;
                case "Book":
                    propertyGrid1.SelectedObject = Program.book;
                    break;
                default:
                    break;
            }

        }

        public int AmountLetters(string _text)
        {
            int result = 0;
            int i = 0;
            StringBuilder text = new StringBuilder(Regex.Replace(_text, @"\n+", ""));

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


        private void btnImport_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder(Regex.Replace(txtNew.Text, @"·", " "));

            Program.book.ImportText(treeProject.SelectedNode.Parent.Index, treeProject.SelectedNode.Index, text.ToString());
        }

        private void txtOriginal_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            if (e.InsertingText == " ")
            {
                e.InsertingText = "·";
            }
        }

        private void txtNew_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            if (e.InsertingText == " ")
            {
                e.InsertingText = "·";
            }
        }

        private void txtOriginal_SelectionChanged(object sender, EventArgs e)
        {
            txtLength.Text = AmountLetters(txtOriginal.SelectedText).ToString();
        }

        private void txtNew_SelectionChanged(object sender, EventArgs e)
        {
            txtLength.Text = AmountLetters(txtNew.SelectedText).ToString();
        }

        private void txtNew_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            txtTextAnalizerAmount.Clear();
            txtTextAnalizerCollection.Clear();

            StringBuilder text = new StringBuilder(Regex.Replace(Regex.Replace(txtNew.Text, "·", " "), "[{].*[}]", ""));

            

            FrequencyAnalysis fa = new FrequencyAnalysis(text.ToString());

            fa.Analise();

            txtTextAnalizerAmount.Text = fa.Count.ToString();

            foreach (var c in fa)
            {
                
                if (c.Key == ' ')
                {
                    txtTextAnalizerCollection.AppendText(string.Format("пробел({0}) ", c.Value));
                }
                else
                {
                    txtTextAnalizerCollection.AppendText(string.Format("{0}({1}) ", c.Key, c.Value));
                }
            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }
    }
}
